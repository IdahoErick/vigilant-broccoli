SET NOCOUNT ON
SET TRAN ISOLATION LEVEL READ UNCOMMITTED

--USE IDSConsolidated

DROP TABLE IF EXISTS #ComparisonResults
CREATE TABLE #ComparisonResults (ResultDTM DATETIME, TableName sysname, Inserts BIGINT, Updates BIGINT, Deletes BIGINT, NoAction BIGINT, NbrPKFields INT)

DROP TABLE IF EXISTS #SyncRows
CREATE TABLE #SyncRows (TableName VARCHAR(100) NOT NULL, PKName VARCHAR(255) NOT NULL, PKValue VARCHAR(255) NOT NULL, SyncType CHAR(1) NOT NULL)

DROP TABLE IF EXISTS #SyncStatements
CREATE TABLE #SyncStatements (TableName VARCHAR(100) NOT NULL, SyncStatement NVARCHAR(MAX) NOT NULL)

--SELECT YEAR(DataLoadDateUpdated), COUNT(1) FROM AccountsReceivable.SalesOrderLineSnapshot GROUP BY YEAR(DataLoadDateUpdated) ORDER BY 1

-- Configuration settings
DECLARE @startDate DATE = '<START_DATE>'
	, @endDate DATE = '<END_DATE>'
	, @checkInserts BIT = <CHECK_INSERTS>		-- Check for new rows in source that are not in target
	, @checkUpdates BIT = <CHECK_UPDATES>		-- Check for rows that need to be updated
	, @checkDeletes BIT = <CHECK_DELETES>		-- Check for rows that need to be (soft) deleted
	, @runSyncSQL BIT = <RUN_SYNC_SQL>			-- Run SQL statement(s) to capture the PK values for I/U/D rows
	, @showSyncRows BIT = 0						-- Show the PK values for I/U/D rows
	, @generatePatchStatements BIT = 0			-- Generate the SQL statements to update the target table from the source table
	, @showPathStatements BIT = 0				-- Show the SQL statements for updating the target table from the source table
	, @runPatchStatements BIT = 0				-- Run the SQL statements to update the target table from the source table (@generatePatchStatements needs to be set to 1 to be able to run the update statements)
	, @upperRowLimit BIGINT = <COMPARE_TABLE_SIZE_MAX>
	, @showDiff BIT = <SHOW_DIFF>				-- Show the row level differences
--	, @sourceDBName sysname = 'IDS_Qlik'
--	, @targetDBName sysname = 'IDSConsolidated'
	, @sourceDBName sysname = '<SOURCE_DB>'
	, @targetDBName sysname = '<TARGET_DB>'
	, @parameterSchemaName sysname = '<SCHEMA_NAME>'
	, @parameterTableName sysname = '<TABLE_NAME>'

DECLARE @schemaName sysname = ''
	, @tableName sysname = ''
	, @firstPKField sysname = ''
	, @SQL NVARCHAR(MAX) = ''
	, @compareSQL VARCHAR(MAX) = ''
	, @syncSQL VARCHAR(MAX) = ''
	, @insertSQL VARCHAR(MAX) = ''
	, @updateSQL VARCHAR(MAX) = ''
	, @deleteSQL VARCHAR(MAX) = ''
	, @FQTableName VARCHAR(250) =''
	, @joinClause VARCHAR(250) = ''
	, @fieldList VARCHAR(MAX) = ''
	, @fieldUpdateList VARCHAR(MAX) = ''
	, @UpdateDateFieldExists BIT = 0
	, @DataLoadIsDeletedExists BIT = 0
	, @lineEnd CHAR(6) = CHAR(13) + CHAR(10)
	, @nbrPKFields INT
	, @tableNbr INT = 0
	, @PKFieldString VARCHAR(250) =''
	, @DateUpdatedExists BIT = 0
	, @MaxCompareColumnCount TINYINT = 62

IF @startDate IS NULL	
	SET @startDate = '1900-01-01'
IF @endDate IS NULL	
	SET @endDate = '9999-12-31'

-- Fill tables
DROP TABLE IF EXISTS #tables
CREATE TABLE #tables (schemaName sysname NOT NULL, tableName sysName NOT NULL)
IF @parameterSchemaName IS NOT NULL AND @parameterTableName IS NOT NULL AND @parameterSchemaName <> '' AND @parameterTableName <> ''
	INSERT #tables SELECT @parameterSchemaName, @parameterTableName
ELSE
BEGIN
	SET @SQL = 'INSERT #tables 
	SELECT t.TABLE_SCHEMA, t.TABLE_NAME 
	FROM ' + @targetDBName + '.information_schema.tables t
	LEFT JOIN (
		SELECT SCHEMA_NAME(st.schema_id) AS SchemaName, SO.NAME AS TableName, MAX(p.ROWS) AS NbrRows
		FROM ' + @targetDBName + '.SYS.INDEXES SI
		INNER JOIN ' + @targetDBName + '.SYS.OBJECTS SO ON SI.object_id = SO.object_id 
		INNER JOIN ' + @targetDBName + '.sys.tables st ON so.object_id = st.object_id
		INNER JOIN ' + @targetDBName + '.sys.partitions p ON p.object_id = SI.object_id AND p.index_id = SI.index_id
		GROUP BY SCHEMA_NAME(st.schema_id), SO.NAME
	) s ON t.TABLE_SCHEMA = s.SchemaName AND t.TABLE_NAME=s.TableName
	WHERE t.table_type = ''BASE TABLE''  AND s.NbrRows <= @ul
	AND t.TABLE_NAME NOT LIKE ''Movement%''	-- skip these tables because the stored proc to load Consolidated hasn''t been built yet
	AND t.TABLE_NAME NOT LIKE ''OrderPickGroup%''	-- skip these tables because the stored proc to load Consolidated hasn''t been built yet'
	exec sp_executesql @stmt=@SQL, @params=N'@ul BIGINT', @ul=@upperRowLimit
END
--PRINT @sql

-- Loop through tables with cursor
DECLARE tableCursor CURSOR FOR
SELECT t.SchemaName, t.tableName
FROM #tables t
ORDER BY t.SchemaName, t.tableName

OPEN tableCursor  
FETCH NEXT FROM tableCursor INTO @schemaName,  @tableName 

-- Loop through all database tables
WHILE @@FETCH_STATUS = 0  
BEGIN  
	SET @FQTableName = @schemaName + '.' + @tableName
	SET @tableNbr += 1

	RAISERROR('Processing table %d %s ...', 0, 1, @tableNbr, @FQTableName) WITH NOWAIT;

	-- Determine number of PK fields
	SET @SQL = 'SELECT @PKFieldNbr = COUNT(1)
	FROM ' + @sourceDBName + '.INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
	INNER JOIN ' + @sourceDBName + '.INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON TC.CONSTRAINT_TYPE = ''PRIMARY KEY'' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
	WHERE KU.table_name = @tn
	AND ku.TABLE_SCHEMA = @sn'
	exec sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname,@PKFieldNbr INT OUT', @sn=@schemaName, @tn=@tableName, @PKFieldNbr = @NbrPKFields OUT

	-- Determine PK fields
	SET @firstPKField = ''
	SET @SQL = 'SELECT TOP(1) @fPKF = ku.column_name
	FROM ' + @sourceDBName + '.INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
	INNER JOIN ' + @sourceDBName + '.INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON TC.CONSTRAINT_TYPE = ''PRIMARY KEY'' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
	WHERE KU.table_name = @tn
	AND ku.TABLE_SCHEMA = @sn'
	exec sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname, @fPKF sysname OUT', @sn=@schemaName, @tn=@tableName, @fPKF = @firstPKField OUT

	-- Construct concatenated PKField string
	SET @PKFieldString = ''
	SET @SQL = 'SELECT @pkfs =  @pkfs + CASE WHEN @pkfs='''' THEN '''' ELSE ''+''''|''''+'' END + ''CAST(<prefix>.'' + ku.column_name + '' AS VARCHAR)''
	FROM ' + @sourceDBName + '.INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
	INNER JOIN ' + @sourceDBName + '.INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON TC.CONSTRAINT_TYPE = ''PRIMARY KEY'' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
	WHERE KU.table_name = @tn
	AND ku.TABLE_SCHEMA = @sn'
	exec sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname, @pkfs VARCHAR(250) OUT', @sn=@schemaName, @tn=@tableName, @pkfs = @PKFieldString OUT

	-- Construct join clause
	SET @joinClause = ''
	SET @SQL = 'SELECT @jc =  @jc + CASE WHEN @jc='''' THEN '''' ELSE '' AND '' END + ''s.'' + ku.column_name + '' = t.'' + ku.column_name
	FROM ' + @sourceDBName + '.INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC 
	INNER JOIN ' + @sourceDBName + '.INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON TC.CONSTRAINT_TYPE = ''PRIMARY KEY'' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
	WHERE KU.table_name = @tn
	AND ku.TABLE_SCHEMA = @sn'
	exec sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname, @jc VARCHAR(MAX) OUT', @sn=@schemaName, @tn=@tableName, @jc = @joinClause OUT

	-- Construct field list - get all fields that exist in source and target
	SET @fieldList = ''
	SET @SQL = 'SELECT @fl =  @fl + CASE WHEN @fl='''' THEN '''' ELSE '','' END + ''<prefix>'' + cc.column_name
	FROM ' + @targetDBName + '.INFORMATION_SCHEMA.columns cc
	INNER JOIN ' + @sourceDBName + '.information_schema.columns cq ON cc.TABLE_SCHEMA=cq.TABLE_SCHEMA AND cc.TABLE_NAME=cq.TABLE_NAME AND cc.COLUMN_NAME=cq.COLUMN_NAME
	WHERE cc.table_name = @tn
	AND cc.TABLE_SCHEMA = @sn
	AND cc.COLUMN_NAME NOT IN (''ConcurrencyCheck'')'
	exec sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname, @fl VARCHAR(MAX) OUT', @sn=@schemaName, @tn=@tableName, @fl = @fieldList OUT

	-- Construct update field update list - get all fields that exist in source and target that are not part of the PK
	SET @fieldUpdateList=''
	SET @SQL = 'SELECT @ful =  @ful + CASE WHEN @ful='''' THEN '''' ELSE '','' END + ''<prefix1>'' + cc.column_name + ''=<prefix2>'' + cc.column_name
	FROM ' + @targetDBName + '.INFORMATION_SCHEMA.columns cc
	INNER JOIN ' + @sourceDBName + '.information_schema.columns cq ON cc.TABLE_SCHEMA=cq.TABLE_SCHEMA AND cc.TABLE_NAME=cq.TABLE_NAME AND cc.COLUMN_NAME=cq.COLUMN_NAME
	WHERE cc.table_name = @tn
	AND cc.TABLE_SCHEMA = @sn
	AND cc.COLUMN_NAME NOT IN (''ConcurrencyCheck'')
	AND NOT EXISTS (
		SELECT 1 FROM ' + @targetDBName + '.INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC 
		INNER JOIN ' + @targetDBName + '.INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON TC.CONSTRAINT_TYPE = ''PRIMARY KEY'' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
		WHERE ku.table_name = cc.TABLE_NAME
		AND ku.TABLE_SCHEMA = cc.TABLE_SCHEMA
		AND ku.COLUMN_NAME = cc.COLUMN_NAME
	)'
	exec sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname, @ful VARCHAR(MAX) OUT', @sn=@schemaName, @tn=@tableName, @ful = @fieldUpdateList OUT

	IF (@fieldList <> '')
	BEGIN
		-- Determine if DataLoadDateUpdated field exists in the target table
		SET @UpdateDateFieldExists = 0
		SET @SQL = 'IF EXISTS (SELECT 1 FROM ' + @targetDBName + '.information_schema.columns WHERE table_schema=@sn AND TABLE_NAME = @tn AND COLUMN_NAME = ''DataLoadDateUpdated'')
			SET @ufe = 1'
		EXEC sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname, @ufe BIT OUT', @sn=@schemaName, @tn=@tableName, @ufe = @UpdateDateFieldExists OUT

		-- Determine if DataLoadIsDeleted field exists in the target table
		SET @DataLoadIsDeletedExists = 0
		SET @SQL = 'IF EXISTS (SELECT 1 FROM ' + @targetDBName + '.information_schema.columns WHERE table_schema=@sn AND TABLE_NAME = @tn AND COLUMN_NAME = ''DataLoadIsDeleted'')
			SET @dfe = 1'
		EXEC sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname, @dfe BIT OUT', @sn=@schemaName, @tn=@tableName, @dfe = @DataLoadIsDeletedExists OUT

		-- Determine if DateUpdated field exists in the source table
		SET @DateUpdatedExists = 0
		SET @SQL = 'IF EXISTS (SELECT 1 FROM ' + @sourceDBName + '.information_schema.columns WHERE table_schema=@sn AND TABLE_NAME = @tn AND COLUMN_NAME = ''DateUpdated'')
			SET @dfe = 1'
		EXEC sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname, @dfe BIT OUT', @sn=@schemaName, @tn=@tableName, @dfe = @DateUpdatedExists OUT

		SET @compareSQL = '
		insert #ComparisonResults (ResultDTM, TableName, Inserts, Updates, Deletes, NoAction, NbrPKFields)
		select getdate(), ''' + @FQTableName + ''', Inserts, Updates, Deletes, TotalRows - Inserts - Updates - Deletes,' + CAST(@NbrPKFields AS VARCHAR) + '
		from
		(
			SELECT Inserts = sum(Inserts), Deletes = sum(Deletes), Updates = sum(Updates), TotalRows = sum(NbrRows)
			FROM
			(
				select
				Inserts = case when t.' + @firstPKField + ' IS NULL THEN 1 ELSE 0 END'
				+ ', Deletes = case when s.' + @firstPKField + ' IS NULL' + CASE WHEN @DataLoadIsDeletedExists=1 THEN ' AND t.DataLoadIsDeleted = 0' ELSE '' END + ' THEN 1 ELSE 0 END'
				+ ', Updates = ' + CASE WHEN @checkUpdates=1 THEN 'CASE when ' + @joinClause + ' AND (CHECKSUM(' + REPLACE(@fieldList, '<prefix>', 's.') + ') <> CHECKSUM(' + REPLACE(@fieldList, '<prefix>', 't.') + ')' + CASE WHEN @DataLoadIsDeletedExists=1 THEN ' OR t.DataLoadIsDeleted = 1)' ELSE ')' END + ' then 1 else 0 end' ELSE '0' END
--				+ ', Updates = ' + CASE WHEN @checkUpdates=1 THEN 'CASE when ' + @joinClause + ' AND CHECKSUM(' + REPLACE(@fieldList, '<prefix>', 's.') + ') <> CHECKSUM(' + REPLACE(@fieldList, '<prefix>', 't.') + ') then 1 else 0 end' ELSE '0' END
				+ ', NbrRows = 1
				FROM ' + @sourceDBName + '.' + @FQTableName +' s
				FULL OUTER JOIN ' + @targetDBName +'.' + @FQTableName + ' t ON ' + @joinClause --+ CASE WHEN @DataLoadIsDeletedExists=1 THEN ' AND t.DataLoadIsDeleted=0' ELSE '' END
				+ ' WHERE 1=1' + @lineEnd
				+ CASE WHEN @checkInserts=0 THEN ' AND t.' + @firstPKField + ' IS NOT NULL' + @lineEnd ELSE '' END
				+ CASE WHEN @checkUpdates=0 THEN ' AND (s.' + @firstPKField + ' IS NULL OR t.' + @firstPKField + ' IS NULL)'+ @lineEnd ELSE '' END
				+ CASE WHEN @checkDeletes=0 THEN ' AND s.' + @firstPKField + ' IS NOT NULL'  + @lineEnd ELSE '' END
				+ CASE WHEN @UpdateDateFieldExists=1 THEN ' AND (t.DataLoadDateUpdated IS NULL OR t.DataLoadDateUpdated between ''' + CAST(@startDate AS VARCHAR) + ''' AND ''' + CAST(@endDate AS VARCHAR) + ''')' + @lineEnd ELSE '' END
				+ CASE WHEN @DateUpdatedExists=1 THEN ' AND (s.DateUpdated IS NULL OR s.DateUpdated between ''' + CAST(@startDate AS VARCHAR) + ''' AND ''' + CAST(@endDate AS VARCHAR) + ''')' + @lineEnd ELSE '' END
			+ ') t
		) u
		';

		-- Create SQL statement to capture the row PK values for I/U/D rows
		IF @runSyncSQL = 1
		BEGIN
       	SET @syncSQL = 'INSERT #SyncRows (TableName, PKName, PKValue, SyncType)' + @lineEnd
			+ 'SELECT * FROM' + @lineEnd
			+ '(' + @lineEnd
			+ 'SELECT ''' + @FQTableName + ''' AS TableName ' + ', ''' + REPLACE(REPLACE(@PKFieldString, '<prefix>.', ''), '''', '''''') + ''' AS PKName' +
			+ ', COALESCE(' + REPLACE(@PKFieldString, '<prefix>', 's') + ', '  + REPLACE(@PKFieldString, '<prefix>', 't') + ') AS PKValue' + ','  + @lineEnd
			+ 'SyncType = case when t.' + @firstPKField + ' IS NULL THEN ''I'' when s.' + @firstPKField + ' IS NULL' + CASE WHEN @DataLoadIsDeletedExists=1 THEN ' AND t.DataLoadIsDeleted = 0' ELSE '' END + ' THEN ''D'''  + @lineEnd
			+ CASE WHEN @checkUpdates=1 THEN ' WHEN ' + @joinClause + ' AND (CHECKSUM(' + REPLACE(@fieldList, '<prefix>', 's.') + ') <> CHECKSUM(' + REPLACE(@fieldList, '<prefix>', 't.') + ')' + CASE WHEN @DataLoadIsDeletedExists=1 THEN ' OR t.DataLoadIsDeleted = 1)' ELSE ')' END + ' THEN ''U'' END' ELSE ' END' END  + @lineEnd
--			+ CASE WHEN @checkUpdates=1 THEN ' WHEN ' + @joinClause + ' AND CHECKSUM(' + REPLACE(@fieldList, '<prefix>', 's.') + ') <> CHECKSUM(' + REPLACE(@fieldList, '<prefix>', 't.') + ') then ''U'' END' ELSE ' END' END  + @lineEnd
			+ ' FROM ' + @sourceDBName + '.' + @FQTableName +' s' + @lineEnd
			+ ' FULL OUTER JOIN ' + @targetDBName + '.' + @FQTableName + ' t ON ' + @joinClause --+ CASE WHEN @DataLoadIsDeletedExists=1 THEN ' AND t.DataLoadIsDeleted=0' ELSE '' END + @lineEnd
			+ ' WHERE 1=1' + @lineEnd
			+ CASE WHEN @UpdateDateFieldExists=1 THEN ' AND (t.DataLoadDateUpdated IS NULL OR t.DataLoadDateUpdated BETWEEN ''' + CAST(@startDate AS VARCHAR) + ''' AND ''' + CAST(@endDate AS VARCHAR) + ''')' ELSE '' END + @lineEnd
			+ CASE WHEN @DateUpdatedExists=1 THEN ' AND (s.DateUpdated IS NULL OR s.DateUpdated between ''' + CAST(@startDate AS VARCHAR) + ''' AND ''' + CAST(@endDate AS VARCHAR) + ''')' + @lineEnd ELSE '' END
			+ ') t' + @lineEnd
			+ ' WHERE SyncType != '''''
		END

		IF @generatePatchStatements = 1 --AND @NbrPKFields = 1
		BEGIN
			-- Construct SQL statement that generates the Insert queries and stores them in #SyncStatements table
			SET @insertSQL = 'INSERT #SyncStatements (TableName, SyncStatement)'+ @lineEnd
				+ 'SELECT ''' + @FQTableName + ''','
				+ '''INSERT ' + @targetDBName + '.' + @FQTableName + '(' + REPLACE(@fieldList, '<prefix>', '') + ', DataloadDateUpdated, DataLoadIsDeleted)'
				+ ' SELECT ' + REPLACE(@fieldList, '<prefix>', '') + ', getdate(), 0'
				+ ' FROM ' + @sourceDBName + '.' + @FQTableName + ' s'
				+ ' WHERE ' + REPLACE(REPLACE(@PKFieldString, '<prefix>', 's'), '|', '''|''') + ' IN ('
				+ '    SELECT PKValue FROM #SyncRows WHERE TableName = ''''' + @FQTableName + ''''' AND SyncType=''''I'''''
				+ ')'''

			-- Construct SQL statement that generates the Update queries and stores them in #SyncStatements table
			SET @updateSQL = 'INSERT #SyncStatements (TableName, SyncStatement)'+ @lineEnd
				+ 'SELECT ''' + @FQTableName + ''','''
				+ 'UPDATE t 
					SET ' + REPLACE(REPLACE(@fieldUpdateList, '<prefix1>', 't.'), '<prefix2>', 's.') + ', DataLoadDateUpdated = getdate(), DataLoadIsDeleted=0'
					+ ' FROM ' + @targetDBName + '.'+ @FQTableName + ' t'
					+ ' INNER JOIN ' + @sourceDBName + '.'+ @FQTableName + ' s ON ' + @joinClause
					+ ' INNER JOIN #SyncRows sy ON ' + REPLACE(REPLACE(@PKFieldString, '<prefix>', 's'), '|', '''|''') + '= sy.PKValue and sy.TableName = ''''' + @FQTableName + ''''' AND sy.SyncType=''''U'''''''

			-- Construct SQL statement that generates the Soft-Delete queries and stores them in #SyncStatements table
			SET @deleteSQL = 'INSERT #SyncStatements (TableName, SyncStatement)'+ @lineEnd
				+ 'SELECT ''' + @FQTableName + ''','''
				+ 'UPDATE t
					SET DataLoadIsDeleted = 1, DataLoadDateUpdated = getdate()'
					+ ' FROM ' + @targetDBName + '.'+ @FQTableName + ' t'
					+ ' INNER JOIN #SyncRows sy ON ' + REPLACE(REPLACE(@PKFieldString, '<prefix>', 't'), '|', '''|''') + '= sy.PKValue and sy.TableName = ''''' + @FQTableName + ''''' AND sy.SyncType=''''D'''''''
		END
	
		BEGIN TRY  
				--PRINT @insertSQL
--				PRINT @updateSQL			
			EXECUTE(@compareSQL)

			IF @runSyncSQL = 1
				EXECUTE(@syncSQL)
			--PRINT @updateSQL

			IF @generatePatchStatements = 1
			BEGIN
				EXECUTE(@insertSQL)
				EXECUTE(@updateSQL)
				EXECUTE(@deleteSQL)
			END
		END TRY  
		BEGIN CATCH  
			--PRINT @compareSQL
			--PRINT @syncSQL
			IF @generatePatchStatements = 1
			BEGIN
				PRINT @insertSQL
				--PRINT @updateSQL
			END
			SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage
		END CATCH;  

		-- Give the server some time to breath
		WAITFOR DELAY '00:00:00.100'

	END
	FETCH NEXT FROM tableCursor INTO @schemaName,  @tableName
END 

CLOSE tableCursor  
DEALLOCATE tableCursor


RAISERROR('Retrieving comparison results from table %s ...', 0, 1, '#ComparisonResults') WITH NOWAIT;
-- Summary
SELECT COUNT(1) AS TotalTables, SUM(CASE WHEN Inserts>0 OR Updates>0 OR Deletes>0 THEN 1 ELSE 0 END) AS TablesWithDifferences, SUM(Inserts) AS TotalInserts, SUM(Updates) AS TotalUpdates, SUM(Deletes) AS TotalDeletes
	, SUM(Inserts+Updates+Deletes+NoAction) AS TotalNbrRows, 100.00*SUM(Inserts+Updates+Deletes) / SUM(Inserts+Updates+Deletes+NoAction) AS DiffPercent FROM #ComparisonResults

-- All Tables
SELECT * FROM #ComparisonResults WHERE Inserts > 0 OR Updates > 0 OR Deletes > 0

IF @runSyncSQL = 1 AND @showSyncRows = 1
BEGIN
	RAISERROR('Retrieving Sync rows from table %s ...', 0, 1, '#SyncRows') WITH NOWAIT;
	SELECT TOP 100 * FROM #SyncRows
END

IF @showDiff = 1	-- Show the row level differences
BEGIN

	DECLARE @columnName sysname, @PKValue VARCHAR(1000), @fieldDiffMaskClause VARCHAR(MAX)

	DROP TABLE IF EXISTS #DataCompare
	DROP TABLE IF EXISTS #ColumnDiffs
	DROP TABLE IF EXISTS #results

	CREATE TABLE #dataCompare (TableName VARCHAR(100) NOT NULL, PKValue VARCHAR(255) NOT NULL, FieldDiffMask INT NOT NULL)
	CREATE TABLE #results (TableName VARCHAR(100), PKName VARCHAR(255), PKValue VARCHAR(255) NOT NULL, FieldName sysname, SourceValue VARCHAR(255) NULL, TargetValue VARCHAR(255) NULL)

	-- Insert Inserts and Deletes into #results
	INSERT INTO #results (TableName, PKName, PKValue, FieldName, SourceValue, TargetValue)
	SELECT TableName, PKName, 'N/A - ' + CASE WHEN SyncType = 'I' THEN 'Insert' WHEN SyncType = 'D' THEN 'Delete' ELSE '' END, PKValue, NULL, NULL
	FROM #SyncRows
	WHERE SyncType IN ('D', 'I')
	AND (ISNULL(@parameterSchemaName, '')='' OR @parameterSchemaName+'.' + @parameterTableName = TableName)

	-- Insert Updates - Loop through tables in #SyncRows table
	DECLARE tableCursor CURSOR FOR
	SELECT SchemaName, TableName
	FROM
	(
		SELECT DISTINCT LEFT(TableName, CHARINDEX('.', TableName)-1) AS SchemaName 
			, RIGHT(TableName, LEN(TableName)-CHARINDEX('.', TableName)) AS TableName
		FROM #SyncRows
		WHERE SyncType = 'U'
	) t
	WHERE (ISNULL(@parameterSchemaName, '')='' OR @parameterSchemaName=SchemaName)
	AND (ISNULL(@parameterTableName, '')='' OR @parameterTableName=TableName)

	OPEN tableCursor  
	FETCH NEXT FROM tableCursor INTO @schemaName, @tableName

	-- Loop through all tables
	WHILE @@FETCH_STATUS = 0  
	BEGIN 
		-- Construct Fully Qualified table name
		SET @FQTableName = @schemaName + '.' + @tableName

		-- Construct PK Field string
		SET @PKFieldString = ''
		SET @SQL = 'SELECT @pkfs =  @pkfs + CASE WHEN @pkfs='''' THEN '''' ELSE ''+''''|''''+'' END + ''CAST(s.'' + ku.column_name + '' AS VARCHAR)''
		FROM ' + @targetDBName + '.INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
		INNER JOIN ' + @targetDBName + '.INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON TC.CONSTRAINT_TYPE = ''PRIMARY KEY'' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
		WHERE KU.table_name = @tn
		AND ku.TABLE_SCHEMA = @sn'
		exec sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname, @pkfs VARCHAR(MAX) OUT', @sn=@schemaName, @tn=@tableName, @pkfs = @PKFieldString OUT

		PRINT 'TableName: ' + @tableName + '; PKFieldString: ' + @PKFieldString

		-- Concatenate PK Values
		DECLARE @PKValues VARCHAR(MAX) = ''
		SELECT @PKValues = @PKValues + CASE WHEN @PKValues='' THEN '' ELSE ',' END + '''' + PKValue + ''''
		FROM #SyncRows WHERE TableName = @FQTableName AND SyncType='U'

		-- Construct join clause
		SET @joinClause = ''
		SET @SQL = 'SELECT @jc =  @jc + CASE WHEN @jc='''' THEN '''' ELSE '' AND '' END + ''s.'' + ku.column_name + '' = t.'' + ku.column_name
		FROM ' + @targetDBName + '.INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC 
		INNER JOIN ' + @targetDBName + '.INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON TC.CONSTRAINT_TYPE = ''PRIMARY KEY'' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
		WHERE KU.table_name = @tn
		AND ku.TABLE_SCHEMA = @sn'
		exec sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname, @jc VARCHAR(MAX) OUT', @sn=@schemaName, @tn=@tableName, @jc = @joinClause OUT

		--SELECT * FROM information_schema.columns WHERE table_name = 'Period' AND TABLE_SCHEMA='Financial'

		-- Cunstruct Field Diff Mask clause
		SET @fieldDiffMaskClause=''
		SET @SQL = 'SELECT @fdmc =  @fdmc + CASE WHEN @fdmc='''' THEN '''' ELSE '' + '' END + ''CASE WHEN ISNULL(s.'' + cc.COLUMN_NAME + '', '' 
			+ CASE WHEN cc.DATA_TYPE LIKE ''date%'' THEN ''''''1900-01-01'''''' ELSE ''''''0'''''' END + '') != ISNULL(t.'' + cc.Column_NAME + '', '' + CASE WHEN cc.DATA_TYPE LIKE ''date%'' THEN ''''''1900-01-01'''''' ELSE ''''''0'''''' END + '') THEN '' + CAST(POWER(2, cc.ORDINAL_POSITION) AS VARCHAR) + '' ELSE 0 END''
		FROM ' + @targetDBName + '.INFORMATION_SCHEMA.columns cc
		INNER JOIN ' + @sourceDBName + '.information_schema.columns cq ON cc.TABLE_SCHEMA=cq.TABLE_SCHEMA AND cc.TABLE_NAME=cq.TABLE_NAME AND cc.COLUMN_NAME=cq.COLUMN_NAME
		WHERE cc.table_name = @tn
		AND cc.TABLE_SCHEMA = @sn
		AND cc.COLUMN_NAME NOT IN (''ConcurrencyCheck'')
		AND cc.ORDINAL_POSITION < ' + CAST(@MaxCompareColumnCount AS VARCHAR) + '
		AND NOT EXISTS (
			SELECT 1 FROM ' + @targetDBName + '.INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC 
			INNER JOIN ' + @targetDBName + '.INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON TC.CONSTRAINT_TYPE = ''PRIMARY KEY'' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
			WHERE ku.table_name = cc.TABLE_NAME
			AND ku.TABLE_SCHEMA = cc.TABLE_SCHEMA
			AND ku.COLUMN_NAME = cc.COLUMN_NAME
		)'
		exec sp_executesql @stmt=@SQL, @params=N'@sn sysname, @tn sysname, @fdmc VARCHAR(MAX) OUT', @sn=@schemaName, @tn=@tableName, @fdmc = @fieldDiffMaskClause OUT

		SET @sql = 'INSERT INTO #DataCompare (TableName, PKValue, FieldDiffMask)' + @lineEnd
				+ 'SELECT ''' + @FQTableName + ''' AS TableName, ' + @PKFieldString + ' AS PKValue' + @lineEnd
				+ ', FieldDiffMask = CASE WHEN sr.SyncType=''I'' THEN -1 ELSE ' + @fieldDiffMaskClause + ' END' + @lineEnd
				+ 'FROM ' + @sourceDBName + '.' + @FQTableName + ' s' + @lineEnd
				+ 'INNER JOIN ' + @targetDBName + '.' + @FQTableName + ' t ON ' + @joinClause + @lineEnd
				+ 'INNER JOIN #SyncRows sr ON ' + @PKFieldString + ' = sr.PKValue AND sr.SyncType IN (''U'')'
	--	PRINT @sql
		EXEC sp_executesql @stmt = @sql

		-- Insert Update field values in #results
		DROP TABLE IF EXISTS #pks
		CREATE TABLE #pks (columnName sysname, PKValue VARCHAR(1000))

		SET @SQL = 'INSERT INTO #pks
		SELECT c.COLUMN_NAME, dc.PKValue
		FROM #DataCompare dc
		INNER JOIN ' + @targetDBName + '.information_schema.columns c ON  c.TABLE_SCHEMA+''.''+ c.table_name=dc.TableName
		WHERE dc.FieldDiffMask & POWER(CAST(2 as BIGINT), CASE WHEN c.ORDINAL_POSITION > ' + CAST(@MaxCompareColumnCount AS VARCHAR) + ' THEN -1 ELSE c.ORDINAL_POSITION END) > 0'
		EXEC sp_executesql @stmt = @SQL

		DECLARE diffCursor CURSOR FOR
		SELECT columnName, PKValue FROM #pks

		OPEN diffCursor  
		FETCH NEXT FROM diffCursor INTO @columnName, @PKValue

		-- Loop through all columns
		WHILE @@FETCH_STATUS = 0  
		BEGIN 
			SET @sql = 'INSERT INTO #results (TableName, PKName, PKValue, FieldName, SourceValue, TargetValue)' + @lineEnd
			+ 'SELECT ''' + @FQTableName + ''',''' + @PKFieldString + ''','''  + @PKValue + ''', ''' + @columnName + ''', s.' + @columnName + ', t.' + @columnName + @lineEnd
			+ 'FROM ' + @sourceDBName +'.' + @FQTableName + ' s'+  + @lineEnd
			+ 'LEFT JOIN ' + @targetDBName + '.' + @FQTableName + ' t ON ' + @joinClause +  + @lineEnd
			+ 'WHERE ' + @PKFieldString + ' = ''' + @PKValue + ''''

			PRINT @sql
			EXEC sp_executesql @stmt = @sql

			FETCH NEXT FROM diffCursor INTO @columnName, @PKValue
		END 

		CLOSE diffCursor  
		DEALLOCATE diffCursor

		FETCH NEXT FROM tableCursor INTO @schemaName, @tableName
	END 

	CLOSE tableCursor  
	DEALLOCATE tableCursor

	SELECT * FROM #results ORDER BY TableName
END

