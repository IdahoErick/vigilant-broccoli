using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIMonitor
{
    class SQLQueries
    {

        #region SQL Server
        public const string SQL_RUN_STATUS_EDW =
        @"SELECT TOP 1 cl.CycleLogId, cl.Start, cl.[END], cl.Status, cld.StepName, cld.TableGroupName, cld.Start AS DetailDTM, ce.ErrorDescription, cl.ScheduleName, e.execution_id, e.SSISStatus
	    FROM SSIS.CycleLog AS cl
	    OUTER APPLY (
		    SELECT TOP(1) TableGroupName, SchemaName + '.' + Executable AS StepName , Start, CycleLogDetailId
		    FROM ssis.CycleLogDetails
		    WHERE CycleLogID=cl.CycleLogId
    		ORDER BY COALESCE([END], Start) DESC
	    ) cld
	    OUTER APPLY (
		    SELECT TOP 1 ErrorDescription 
		    FROM SSIS.CycleErrors WHERE CycleLogID=cl.CycleLogId AND CycleLogDetailId=cld.CycleLogDetailId
		    ORDER BY ErrorDate desc
	    ) ce
	    OUTER APPLY  (
		    SELECT top 1 e.execution_id, e.Status as SSISStatus
		    FROM SSISDB.catalog.executions e
		    WHERE package_name = 'MainFramework.dtsx'
		    AND CAST(e.start_time AS DATETIME) BETWEEN DATEADD(MINUTE, -10, cl.Start) AND DATEADD(HOUR, 23, cl.Start)
		    ORDER BY execution_id DESC
        ) e
	    WHERE cl.ScheduleName = 'EDW Main Load'
	    ORDER BY cl.Start DESC";

        public const string SQL_RUN_STATUS_ILH =
        @"
        declare @RunId int
        select @RunId = max(RunId)+(<HistOffset>) from Log.RunLog

        ;with DetailCTE as
        (
        	select top 1 * 
        	from [LOG].[RundetailLog] 
            where RunId = @RunID
        	order by RunDetailId desc 
        ) 
        select top 1 RL.RunId, RunStatus, RL.Kalenderdatum, AKV.PeilDatum, AKV.Execution_ID, RL.StartDatumTijd, RL.EindDatumTijd, RSL.Stepomschrijving, LEGEN_STG, LAAD_STG, DetailCTE.Controletype, DetailCTE.InsertDatumTijd as DetailDTM, DetailCTE.Packagenaam, DetailCTE.Opmerkingen, DetailCTE.Bronsysteem, SSISExe.status as SSISStatus
        from Log.RunLog RL
        left join LOG.AUDIT_KALENDERVERWERKING AKV on RL.RunID=AKV.RunID
        left join Log.RunStepLog RSL on RL.RunId=RSL.RunId
        left join DetailCTE on DetailCTE.RunId=RL.RunId
        left join SSISDB.catalog.executions SSISExe on SSISExe.execution_id=AKV.Execution_ID
        where RL.RunId = @RunID
        order by RL.RunId desc, RSL.StartDatumTijd desc";

        //public const string SQL_RUN_STATUS_ILSB =
        //"select top 1 RunStatus, cast(RL.StartDatumTijd as date) as KalenderDatum, case db_name() when 'ILSB_LOGGING_DAG' then KD.PeilDatum else KD.PeilDatum end as PeilDatum, RL.StartDatumTijd,RL.EindDatumTijd, RSL.Stepomschrijving" +
        //", case db_name() when 'ILSB_LOGGING_DAG' then KD.LEGEN_STG else KM.LEGEN_STG end as LEGEN_STG " +
        //", case db_name() when 'ILSB_LOGGING_DAG' then KD.LAAD_STG else KM.LAAD_STG end as LAAD_STG" +
        //", 'N/A' as Controletype, 'N/A' as DetailDTM, 'N/A' as Packagenaam, 'N/A'as Opmerkingen, 'N/A'as Bronsysteem, 0 as Execution_ID, 0 as SSISStatus" +
        //" from Log.RunLog RL" +
        //" left join Log.RunStepLog RSL on RL.RunId=RSL.RunId" +
        //" left join ILSB_METADATA.MDA.KALENDERVERWERKING_DAG KD on KD.DraaiDatum=cast(getdate() as date)" +
        //" left join ILSB_METADATA.MDA.KALENDERVERWERKING_MAAND KM on KM.DraaiDatum=cast(getdate() as date)" +
        //" order by RL.RunId desc, RSL.StartDatumTijd desc";

        public const string SQL_RUN_STATUS_ILSB =
        @"
        declare @RunId int
        select @RunId = max(RunId)+(<HistOffset>) from Log.RunLog
        ;with DetailCTE as
        (
            select top 1 RunId, Controletype, InsertDatumTijd, Packagenaam, Opmerkingen, Bronsysteem
            from LOG.RundetailLog
            order by RunDetailId desc
        )
        select top 1 rl.RunID, RunStatus, p.DraaiDatum as KalenderDatum
		, p.PeilDatum
		, RL.StartDatumTijd,RL.EindDatumTijd, RSL.Stepomschrijving
        , DetailCTE.Controletype, DetailCTE.InsertDatumTijd as DetailDTM, DetailCTE.Packagenaam, DetailCTE.Opmerkingen, DetailCTE.Bronsysteem, rl.Execution_ID, SSISExe.status as SSISStatus
        from Log.RunLog RL
        left join Log.RunStepLog RSL on RL.RunId=RSL.RunId
		left join log.Parameters p on RL.RunId=p.RunId
        left join DetailCTE on DetailCTE.RunId=RL.RunId
        left join SSISDB.catalog.executions SSISExe on SSISExe.execution_id=rl.Execution_ID
		where RL.RunId = @RunID
        order by RL.RunId desc, RSL.StartDatumTijd desc";

        //"with DetailCTE as\n" +
        //"(\n" +
        //"    select top 1 RunId, Controletype, InsertDatumTijd, Packagenaam, Opmerkingen, Bronsysteem\n" +
        //"    from LOG.RundetailLog\n" +
        //"    order by RunDetailId desc\n" +
        //")\n" +
        //"select top 1 rl.RunID, RunStatus, cast(RL.StartDatumTijd as date) as KalenderDatum, case db_name() when 'ILSB_LOGGING_DAG' then KD.PeilDatum else KD.PeilDatum end as PeilDatum, RL.StartDatumTijd,RL.EindDatumTijd, RSL.Stepomschrijving\n" +
        //", case db_name() when 'ILSB_LOGGING_DAG' then KD.LEGEN_STG else KM.LEGEN_STG end as LEGEN_STG\n" +
        //", case db_name() when 'ILSB_LOGGING_DAG' then KD.LAAD_STG else KM.LAAD_STG end as LAAD_STG\n" +
        //", DetailCTE.Controletype, DetailCTE.InsertDatumTijd as DetailDTM, DetailCTE.Packagenaam, DetailCTE.Opmerkingen, DetailCTE.Bronsysteem, rl.Execution_ID, SSISExe.status as SSISStatus\n" +
        //"from Log.RunLog RL\n" +
        //"left join Log.RunStepLog RSL on RL.RunId=RSL.RunId\n" +
        //"left join ILSB_METADATA.MDA.KALENDERVERWERKING_DAG KD on KD.DraaiDatum=cast(getdate() as date)\n" +
        //"left join ILSB_METADATA.MDA.KALENDERVERWERKING_MAAND KM on KM.DraaiDatum=cast(getdate() as date)\n" +
        //"left join DetailCTE on DetailCTE.RunId=RL.RunId\n" +
        //"left join SSISDB.catalog.executions SSISExe on SSISExe.execution_id=rl.Execution_ID\n" +
        //"order by RL.RunId desc, RSL.StartDatumTijd desc\n";

        public const string SQL_RUN_DETAILS =
        "SELECT * FROM ssis.CycleLogDetails WHERE CycleLogID = (SELECT MAX(CycleLogID) FROM SSIS.CycleLog WHERE ScheduleName = 'EDW Main Load')";

        public const string SQL_RUN_DETAILS_ILH =
        "select Peildatum, LEGEN_STG, LAAD_STG, CLOSE_Peildatum,CLOSE_CM_Peildatum,HOMES_Peildatum,MIDAS_Peildatum,HOUSE_Peildatum,QUION_Peildatum,SAPBW_Achterstand_PolisData_Peildatum " +
        ",SAPBW_KlantData_Peildatum,SAPBW_PolisData_Peildatum,SAP_ICM_Verwacht_Peildatum,DAYBREAK_Verwacht_Peildatum, MIDAS_CK_Verwacht_Peildatum,VOORBEREIDEN_RUN,ARCHIEFBESTANDEN_ZIPPEN,LAAD_HOUSE_FP,LAAD_CBS,LAAD_CLOSE" +
        ",LAAD_CLOSE_CM,LAAD_DAYBREAK,LAAD_HOMES,LAAD_MIDAS,LAAD_MIDAS_CK,LAAD_HOUSE,LAAD_MDS,LAAD_QUION,LAAD_SAPBW_ACHTERSTAND_POLISDATA,LAAD_SAPBW_KLANTDATA,LAAD_SAPBW_POLISDATA,LAAD_SAP_ICM" +
        ",LAAD_DDS,LAAD_DDS_DWH,MAAK_CF,CFDistributielijst,SoortRun from ILH_METADATA.MDA.KALENDERVERWERKING_DAG where Kalenderdatum='<Kalenderdatum>'";

        public const string SQL_RUN_DETAILS_ILSB =
         "select Peildatum, LEGEN_STG, LAAD_STG, BRON_EP_MIDAS, BRON_OFS_MIDAS, BRON_EP_NN, BRON_OFS, BRON_IKV, DOEL_OFS_KLANTDATA, LEGEN_DDS, LAAD_DDS, LAAD_DDS_DWH, MAAK_CF, CFDistributielijst  from ILSB_METADATA.MDA.KALENDERVERWERKING_DAG where DRAAIDATUM='<Kalenderdatum>'";

        public const string SQL_CALENDAR_DATES = "SELECT DISTINCT CalendarDate =CAST(Start AS DATE) FROM SSIS.CycleLog AS cl WHERE cl.ScheduleName = 'EDW Main Load'";

        public const string SQL_CALENDAR_DATES_ILSB = "select distinct DraaiDatum as Kalenderdatum from ILSB_METADATA.mda.KALENDERVERWERKING_<period>";

        public const string SQL_LOGBOEK_ILH = "select * from log.ST_LOGBOEK where RunId=(select max(RunID) from log.ST_LOGBOEK)";

        public const string SQL_LOGBOEK_ILSB = "select 'Logboek not available for S&B'";

        public const string SQL_RUNDETAILLOG = "	SELECT CycleLogDetailId,CycleLogId,TableGroupName,SchemaName,TableName,ExecutableSchema,Executable,Start,[End], Duration = DATEDIFF(ss,Start,[END]), Status,LastUpdateDate,UpdateDate,CountDiffPercent,AmountDiffPercent,SourceCount,DestCount,SourceAmount,DestAmount,TableGroupId,TableId,Message,GroupOwner,Run32Bit FROM ssis.CycleLogDetails WITH (NOLOCK) WHERE CycleLogID = <RunID> AND STATUS = <RunDetailStatus>";

        public const string SQL_ABORT_RUN = "exec SSISDB.catalog.stop_operation <RunID>";

        public const string SQL_LATEST_SSIS_MESSAGE = "select top 1 execution_path from SSISDB.catalog.executable_statistics with (nolock) where execution_id=<RunID> order by start_time desc";

        public const string SQL_LATEST_SSIS_MESSAGES = "select top 10 * from SSISDB.catalog.executable_statistics with (nolock) where execution_id=<RunID> order by start_time desc";

        public const string SQL_DATA_COMPARE = "";
        
        public const string SQL_WF_RUNNING =
            " SELECT Workflow_name Name," +
            " start_time StartTime," +
            " end_time EndTime" +
            " FROM opb_wflow_run" +
            " WHERE run_status_code = 6" +
            " ORDER BY start_time DESC";

        public const string SQL_WF_Scheduled =
            //" SELECT su.subj_name," +
            //"  t.task_name," +
            //"  s.start_time StartDate" +
            //"  FROM opb_workflow o" +
            //"  INNER JOIN opb_scheduler s ON o.scheduler_id = s.scheduler_id" +
            //" INNER JOIN opb_task t" +
            //"  INNER JOIN opb_subject su ON t.subject_id= su.subj_id" +
            //"       ON t.task_id= o.workflow_id" +
            //"    WHERE s.start_time!= s.end_time" +
            //"  AND s.run_options <> 5" +
            //"  AND s.run_options <> 3";
            ////"  AND (s.run_options <> 2" +
            ////"  OR s.start_time > getdate())"; //todo: have to convert start_time to date
            " SELECT su.subj_name, t.task_name, s.start_time StartDate" +
            " FROM opb_workflow o" +
            " INNER JOIN opb_scheduler s ON o.scheduler_id = s.scheduler_id" +
            " INNER JOIN opb_task t ON t.task_id= o.workflow_id" +
            " INNER JOIN opb_subject su ON t.subject_id= su.subj_id" +
            " WHERE s.start_time!= s.end_time" +
            " AND s.run_options not in (2, 3, 5)" +
            " and s.start_time is not null" +
            " and t.Is_Visible = 1" +
            " and s.Is_Visible = 1" +
            " and o.Version_Number = (select max(Version_Number) from opb_workflow where workflow_id = o.workflow_id)";


        public const string SQL_WF_EDW_LATEST =
            "SELECT START_TIME AS STARTTIME," +
            "END_TIME AS ENDTIME  ," +
            "RUN_ERR_CODE                                              ," +
            "RUN_ERR_MSG                                               ," +
            "run_status_code as Status                                 ," +
            "RUN_TYPE                                                  ," +
            "HAS_FAILED_TASKS                                          ," +
            "HAS_INTERRUPTS " +
            "FROM OPB_WFLOW_RUN W " +
            "WHERE (START_TIME = " +
            "(SELECT MAX(START_TIME) AS EXPR1 " +
            "FROM OPB_WFLOW_RUN " +
            "WHERE (WORKFLOW_NAME = 'wf_EDW_DataLoad')" +
            "))";

        public const string SQL_WF_EDW_LAST_30_DAYS =
            "select " +
            "t.start_time as EDW_Data_Load_Start " +
            ", (select start_time from opb_task_inst_run where workflow_run_id = w.workflow_run_id and instance_name = 's_BillDetails_Insert') as EDW_Bill_Details_Start " +
            ", (select end_time from opb_task_inst_run where workflow_run_id = w.workflow_run_id and instance_name = 's_BillDetails_Insert') as EDW_Bill_Details_End " +
            ", (select convert(varchar, end_time - start_time, 108) from  opb_task_inst_run where workflow_run_id = w.workflow_run_id and instance_name = 's_BillDetails_Insert') as EDW_Bill_Details_Duration " +
            ", (select targ_success_rows from OPB_SESS_TASK_LOG where workflow_run_id = w.workflow_run_id and mapping_name = 'm_BillDetails_Insert') as Targ_Success_Rows " +
            ", '' as placeholder " +
            ", w.end_time as EDW_Data_Load_End " +
            ", convert(varchar, w.end_time - t.start_time, 108) as EDW_Duration " +
            ", w.run_status_code as Status " +
            ", (select sum(targ_failed_rows) from opb_sess_task_log where workflow_run_id=w.workflow_run_id) as FailedRows " +
            "from opb_wflow_run w " +
            "left join opb_task_inst_run t on t.workflow_run_id=w.workflow_run_id " +
            "where w.workflow_name = 'wf_EDW_DataLoad' " +
            "and w.start_time > getdate()-30 " +
            "and t.instance_name = 'em_EDW_DataLoad_Start' " +
            "order by w.start_time desc";

        public const string SQL_WF_CINCI_SAVINGS_LATEST =
            "select s.subj_name Area " +
            "	,cast(w.workflow_name as varchar(30)) as Workflow " +
            "	,w.start_time as [Start Time]" +
            "	,w.end_time as [End Time]" +
            "	,convert(varchar, w.end_time - w.start_time, 108) as [Load Duration] " +
            "	, run_status_code as Status  " +
            "from opb_wflow_run w " +
            "inner join opb_subject s on w.subject_id=s.subj_id " +
            "where s.subj_name = 'Savings Transfer To Cincinnati' " +
            "and w.start_time > GETDATE()-30 " +
            "order by Start_Time desc ";

        public const string SQL_WF_ODS_LAST_30_DAYS =
        "select cast(workflow_name as varchar(15)) as Workflow " +
            ",w.start_time as ODS_Start_Time " +
            ",w.end_time as ODS_End_Time " +
            ",convert(varchar, w.end_time - w.start_time, 108) as ODS_Load_Duration " +
            ",s.targ_success_rows as NatlSiteUtilSrvHist_Maint " +
            ",' ' as PlaceHolder " +
            ",t.start_time as ODS_Normalization_Start " +
            ",t.end_time as ODS_Normalization_End  " +
            ",w.run_status_code as Status  " +
            ", (select sum(targ_failed_rows) from opb_sess_task_log where workflow_run_id=w.workflow_run_id) as FailedRows  " +
        "from opb_wflow_run w  " +
        "inner join opb_sess_task_log s on w.workflow_run_id= s.workflow_run_id  " +
        "inner join opb_task_inst_run t on t.workflow_run_id=w.workflow_run_id  " +
        "where w.workflow_name = 'wf_ODS_DataLoad_IDL'  " +
        "and w.start_time > getdate()-30  " +
        "and s.mapping_name = 'm_IDL_NatlSiteUtilSrvHist_Maint'  " +
        "and t.instance_name = 'cmd_NormalizeBillDetails'  " +
        "order by ODS_START_TIME desc ";

        public const string SQL_WF_PROJECTIONS_LATEST =
            "select s.subj_name Area " +
            "	,cast(w.workflow_name as varchar(30)) as Workflow " +
            "	,w.start_time as [Start Time]" +
            "	,w.end_time as [End Time]" +
            "	,convert(varchar, w.end_time - w.start_time, 108) as [Load Duration] " +
            "	, run_status_code as Status  " +
            "from opb_wflow_run w " +
            "inner join opb_subject s on w.subject_id=s.subj_id " +
            "where w.workflow_name in ('wf_ODS_Projections', 'wf_EDW_Projections')  " +
            "and w.start_time > GETDATE()-30 " +
            "order by Start_Time desc ";

        public const string SQL_WF_CINCI_Latest =
            "select s.subj_name Area " +
            "	,cast(w.workflow_name as varchar(30)) as Workflow " +
            "	,w.start_time as [Start Time]" +
            "	,w.end_time as [End Time]" +
            "	,convert(varchar, w.end_time - w.start_time, 108) as [Load Duration] " +
            "	, run_status_code as Status  " +
            "from opb_wflow_run w " +
            "inner join opb_subject s on w.subject_id=s.subj_id " +
            "where s.subj_name = 'Cincinnati Data Transfer' " +
            "and w.start_time > GETDATE()-30 " +
            "order by Start_Time desc ";

        public const string SQL_WF_PDS_PROD_LATEST =
            "select s.subj_name Area " +
            "	,cast(w.workflow_name as varchar(30)) as Workflow " +
            "	,w.start_time as [Start Time]" +
            "	,w.end_time as [End Time]" +
            "	,convert(varchar, w.end_time - w.start_time, 108) as [Load Duration] " +
            "	, run_status_code as Status  " +
            "from opb_wflow_run w " +
            "inner join opb_subject s on w.subject_id=s.subj_id " +
            "where s.subj_name = 'Production Data Subsetting' " +
            "and w.start_time > GETDATE()-30 " +
            "order by Start_Time desc ";

        public const string SQL_RUN_FAILURES =
            "SELECT TOP 10 * FROM SSIS.vwCycleErrors";
  //          "select * from [LOG].[RundetailLog] where runid = <RunID> and RunDetailStatus in ('F','NOK') order by InsertDatumTijd desc";

        public const string SQL_SSIS_ERRORS =
            "use ssisdb;\n" +
            "set transaction isolation level read uncommitted \n" +
            " declare @runid int = <RunID>\n" +
            " --select @runid=max(execution_id) from catalog.executions with (nolock)\n" +
            " exec sp_executesql @stmt=N'USE [SSISDB];\n" +
            " WITH msgEx AS(\n" +
            "    SELECT\n" +
            "        msg.[event_message_id]\n" +
            "        ,msg.[operation_id]\n" +
            "        ,CONVERT(datetime, msg.[message_time]) AS message_time\n" +
            "        ,msg.[message_type]\n" +
            "        ,msg.[message_source_type]\n" +
            "        ,CASE WHEN LEN(msg.[message]) <= 4096 THEN msg.[message] ELSE LEFT(msg.[message], 1024) + ''...'' END AS [message]\n" +
            "        ,msg.[extended_info_id]\n" +
            "        ,msg.[event_name]\n" +
            "        ,CASE WHEN LEN(msg.[message_source_name]) <= 1024 THEN msg.[message_source_name] ELSE LEFT(msg.[message_source_name], 1024) + ''...'' END AS [message_source_name]\n" +
            "        ,msg.[message_source_id]\n" +
            "        ,CASE WHEN LEN(msg.[subcomponent_name]) <= 1024 THEN msg.[subcomponent_name] ELSE LEFT(msg.[subcomponent_name], 1024) + ''...'' END AS [subcomponent_name]\n" +
            "        ,CASE WHEN LEN(msg.[package_path]) <= 1024 THEN msg.[package_path] ELSE LEFT(msg.[package_path], 1024) + ''...'' END AS [package_path]\n" +
            "        ,CASE WHEN LEN(msg.[execution_path]) <= 1024 THEN msg.[execution_path] ELSE LEFT(msg.[execution_path], 1024) + ''...'' END AS [execution_path]\n" +
            "        ,msg.[message_code]\n" +
            "        ,info.reference_id\n" +
            "    FROM\n" +
            "    [catalog].[event_messages] msg with (nolock) LEFT JOIN [catalog].[extended_operation_info] info with (nolock) ON msg.extended_info_id = info.info_id\n" +
            "    WHERE\n" +
            "        msg.[operation_id] = @ExecutionID\n" +
            "        ),\n" +
            " msgRef AS(\n" +
            "    SELECT msgEx.*, ref.[reference_type], ref.[environment_folder_name], ref.[environment_name]\n" +
            "    FROM msgEx LEFT JOIN [catalog].[environment_references] ref with (nolock)\n" +
            "    ON msgEx.[reference_id] = ref.[reference_id]\n" +
            "    ),\n" +
            " msgEnv AS(\n" +
            " SELECT *,\n" +
            "    CASE WHEN [reference_id] IS NULL THEN ''-'' ELSE \n" +
            "    (CASE WHEN [reference_type] = ''R'' OR [reference_type] = ''r'' THEN ''.'' ELSE [environment_folder_name] END) + ''\'' + [environment_name]\n" +
            "    END AS env\n" +
            " FROM\n" +
            "    msgRef\n" +
            " )\n" +
            " SELECT *\n" +
            " FROM\n" +
            "    msgEnv\n" +
            " WHERE\n" +
            "    (@MessageType=-1 OR [message_type] = @MessageType) AND\n" +
            "    (ISNULL([message_source_name],'''') LIKE ''%'' + REPLACE(REPLACE(REPLACE(@SourceNameContains COLLATE database_default,''['', ''[[]''), ''_'', ''[_]''), ''%'',''[%]'') + ''%'' COLLATE database_default) AND\n" +
            "    (ISNULL([message],'''') LIKE ''%'' + REPLACE(REPLACE(REPLACE(@MessageContains COLLATE database_default,''['', ''[[]''), ''_'', ''[_]''), ''%'',''[%]'') + ''%'' COLLATE database_default) AND\n" +
            "    (ISNULL([subcomponent_name],'''') LIKE ''%'' + REPLACE(REPLACE(REPLACE(@SubComponentNameContains COLLATE database_default,''['', ''[[]''), ''_'', ''[_]''), ''%'',''[%]'') + ''%'' COLLATE database_default) AND\n" +
            "    (ISNULL([execution_path],'''') LIKE ''%'' + REPLACE(REPLACE(REPLACE(@ExecutionPathContains COLLATE database_default,''['', ''[[]''), ''_'', ''[_]''), ''%'',''[%]'') + ''%'' COLLATE database_default) AND\n" +
            "    (ISNULL([env],'''') LIKE ''%'' + REPLACE(REPLACE(REPLACE(@EnvironmentContains COLLATE database_default,''['', ''[[]''), ''_'', ''[_]''), ''%'',''[%]'') + ''%'' COLLATE database_default)\n" +
            "	AND event_name = ''OnError''\n" +
            " ORDER BY [message_time] DESC',@params=N'@MessageType Int, @ExecutionID NVarChar(max), @SourceNameContains NVarChar(max), @MessageContains NVarChar(max), @SubComponentNameContains NVarChar(max), @ExecutionPathContains NVarChar(max), @EnvironmentContains NVarChar(max)',\n" +
            " @MessageType=-1,@ExecutionID=@runid,@SourceNameContains=N'',@MessageContains=N'',@SubComponentNameContains=N'',@ExecutionPathContains=N'',@EnvironmentContains=N''";

        public const string SQL_START_RUN_ILH =
            "delete from ILH_METADATA.[MDA].[KALENDERVERWERKING_<PERIOD>_CORRECTIE]\n" +
            "INSERT INTO [ILH_METADATA].[MDA].[KALENDERVERWERKING_<PERIOD>_CORRECTIE] ([Kalenderdatum]) VALUES ('<Kalenderdatum>')\n" +
            "truncate table ILH_metadata.dcf.runstartstatus\n" +
            "declare @reference_id int = (select reference_id from SSISDB.catalog.environment_references where environment_name='ILH_DataIntegratie_<PERIOD>')\n" +
            "Declare @execution_id bigint\n" +
            "EXEC [SSISDB].[catalog].[create_execution] @package_name=N'SEQ_ILH_SCHEDULING.dtsx', @execution_id=@execution_id OUTPUT, @folder_name=N'ILH_DataIntegratie', @project_name=N'ILH_DataIntegratie_SSIS', @use32bitruntime=False, @reference_id=@reference_id\n" +
            "Select @execution_id\n" +
            "DECLARE @var0 bit = 1\n" +
            "EXEC [SSISDB].[catalog].[set_execution_parameter_value] @execution_id,  @object_type=20, @parameter_name=N'parCloseHomesPolisIntegratie', @parameter_value=@var0\n" +
            "DECLARE @var1 bit = 1\n" +
            "EXEC [SSISDB].[catalog].[set_execution_parameter_value] @execution_id,  @object_type=20, @parameter_name=N'parVersieNr0', @parameter_value=@var1\n" +
            "DECLARE @var2 smallint = 1\n" +
            "EXEC [SSISDB].[catalog].[set_execution_parameter_value] @execution_id,  @object_type=50, @parameter_name=N'LOGGING_LEVEL', @parameter_value=@var2\n" +
            "EXEC [SSISDB].[catalog].[start_execution] @execution_id\n";

        public const string SQL_START_RUN_ILSB =
            @"declare @reference_id int = (select reference_id from SSISDB.catalog.environment_references where environment_name='ILSB_DataIntegratie_<PERIOD>')
            Declare @execution_id bigint
            EXEC [SSISDB].[catalog].[create_execution] @package_name=N'SEQ_MAIN.dtsx', @execution_id=@execution_id OUTPUT, @folder_name=N'ILSB_DataIntegratie', @project_name=N'ILSB_DataIntegratie_SSIS', @use32bitruntime=False, @reference_id=@reference_id
            DECLARE @var0 smallint = 1
            EXEC [SSISDB].[catalog].[set_execution_parameter_value] @execution_id,  @object_type=50, @parameter_name=N'LOGGING_LEVEL', @parameter_value=@var0
            EXEC [SSISDB].[catalog].[start_execution] @execution_id";

        /*
        public const string SQL_START_RUN_ILH =
            "delete from ILH_METADATA.[MDA].[KALENDERVERWERKING_<PERIOD>_CORRECTIE]\n" +
            "INSERT INTO [ILH_METADATA].[MDA].[KALENDERVERWERKING_<PERIOD>_CORRECTIE] ([Kalenderdatum]) VALUES ('<Kalenderdatum>')\n" +
            "truncate table ILH_metadata.dcf.runstartstatus\n" +
            "EXEC msdb.dbo.sp_start_job N'Run ILVB <PERIOD>'\n";
        */

 #endregion


    }
}
