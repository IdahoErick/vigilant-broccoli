using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMonitor
{
    class Solution
    {
        private string _controleType="";

        public string ControleType
        {
            get { return _controleType; }
            set { _controleType = value; }
        }
        private string _packageName = "";

        public string PackageName
        {
            get { return _packageName; }
            set { _packageName = value; }
        }
        private string _opmerkingen = "";

        public string Opmerkingen
        {
            get { return _opmerkingen; }
            set { _opmerkingen = value; }
        }

        private string _ssisMessage = "";

        public string SsisMessage
        {
          get { return _ssisMessage; }
          set { _ssisMessage = value; }
        }

        private string _ssisSourceName = "";

        public string SsisSourceName
        {
          get { return _ssisSourceName; }
          set { _ssisSourceName = value; }
        }

        private string _ssisExecutionPath = "";

        public string SsisExecutionPath
        {
          get { return _ssisExecutionPath; }
          set { _ssisExecutionPath = value; }
        }
        
        private string _solution;

        public string SolutionQuery
        {
            get { return _solution; }
            set { _solution = value; }
        }
        private string _problem;

        public string Problem
        {
            get { return _problem; }
            set { _problem = value; }
        }


        public Solution()
        {

        }
        public Solution(string controleType, string packageName, string opmerkingen, string problem, string solution)
        {
            _controleType = controleType;
            _packageName = packageName;
            _opmerkingen = opmerkingen;
            _problem = problem;
            _solution = solution;
        }

        public Solution(string packageName, string ssisMessage, string ssisSourceName, string ssisExecutionPath, string problem, string solution)
        {
            _ssisMessage = ssisMessage;
            _ssisSourceName = ssisSourceName;
            _ssisExecutionPath = ssisExecutionPath;
            _problem = problem;
            _solution = solution;
        }


        public const string SOL_DOUBLE_REF = @"
// A double reference is found in a REF table in ILH_METADATA. The following query can remove the duplicates from the source tables and the reference tables
begin tran
-- Delete duplicate HOUSE.MortgageApplication rows
;WITH numbered
AS (
	select ID, ROW_NUMBER() over (partition by ID order by ID) nr
	from HOUSE.MortgageApplication
)
DELETE FROM numbered WHERE nr > 1

-- Delete duplicate KRO_AANVRAAG_REFERENTIE rows
;WITH numbered
AS (
	select HOUSE_1_MORTGAGEAPPLICATION_BACKOFFICEID, ROW_NUMBER() over (partition by HOUSE_1_MORTGAGEAPPLICATION_BACKOFFICEID order by HOUSE_1_MORTGAGEAPPLICATION_BACKOFFICEID) nr
	from ILH_METADATA.ref.KRO_AANVRAAG_REFERENTIE
	where HOUSE_1_MORTGAGEAPPLICATION_BACKOFFICEID is not null
)
--select * from numbered where nr > 1
DELETE FROM numbered WHERE nr > 1

-- Delete duplicate KRO_KREDIETOVEREENKOMST_REFERENTIE rows
;WITH numbered
AS (
	select HOUSE_1_HYPOTHECAIRELENING_LENINGNR, ROW_NUMBER() over (partition by HOUSE_1_HYPOTHECAIRELENING_LENINGNR order by HOUSE_1_HYPOTHECAIRELENING_LENINGNR) nr
	from ILH_METADATA.ref.KRO_KREDIETOVEREENKOMST_REFERENTIE
	where HOUSE_1_HYPOTHECAIRELENING_LENINGNR is not null
)
--select * from numbered where nr > 1
DELETE FROM numbered WHERE nr > 1

-- Delete duplicate KRO_AANVRAAG_REFERENTIE rows (HOUSE_2_MORTGAGEAPPLICATION_AANVRAAGID)
begin tran
;WITH numbered
AS (
	select AANVRAAG_ID,HOUSE_2_MORTGAGEAPPLICATION_AANVRAAGID, ROW_NUMBER() over (partition by HOUSE_2_MORTGAGEAPPLICATION_AANVRAAGID order by AANVRAAG_ID) nr
	from ILH_METADATA.ref.KRO_AANVRAAG_REFERENTIE
	where HOUSE_2_MORTGAGEAPPLICATION_AANVRAAGID is not null
)
--delete from ILH_METADATA.ref.KRO_AANVRAAG_VERSIE where AANVRAAG_ID in (select AANVRAAG_ID from numbered where nr>1)
DELETE FROM numbered WHERE nr > 1

-- Delete duplicate KRO_AANVRAAG_REFERENTIE rows (QUION_1_LENING_CONTRACT_NUMMER)
;WITH numbered
AS (
	select QUION_1_LENING_CONTRACT_NUMMER, QUION_1_LENING_NUMMER, ROW_NUMBER() over (partition by QUION_1_LENING_CONTRACT_NUMMER,QUION_1_LENING_NUMMER order by QUION_1_LENING_CONTRACT_NUMMER,QUION_1_LENING_NUMMER) nr
	from ILH_METADATA.ref.KRO_AANVRAAG_REFERENTIE
	where QUION_1_LENING_CONTRACT_NUMMER is not null
	and QUION_1_LENING_NUMMER is not null

)
DELETE FROM numbered WHERE nr > 1
rollback tran
--commit tran
";
    }

    
    class SolutionFactory
    {
        private List<Solution> _solutions = new List<Solution>();

        public SolutionFactory()
        {
            // ILVB proces errors
            _solutions.Add(new Solution("DFT Controle op dubbele referenties", "", "", "A double reference is found in a REF table in ILH_METADATA", Solution.SOL_DOUBLE_REF));
            _solutions.Add(new Solution("Controle compleetheid aanlevering", "", "", "Niet alle bestanden staan klaar in de IN folder", "Zoek uit waarom er bestanden niet zijn aangeleverd. Neem contact op met desbetreffende contactpersoon van aanleveringsteam. Maak incident aan."));
            _solutions.Add(new Solution("CF voor PROMMISE", "", "Er zijn 1 blokkerende fouten geconstateerd in RunTellingen", "Bij het aanmaken van de CF bestanden wordt het aantal rijen gecontroleerd. Deze kloppen niet. Kijk in Runtellingen tabel: select top 10 * from ILH_LOGGING_DAG.log.runtellingen where TellingStatus='F' order by InsertDatumTijd desc. Veel voorkomende redenen:\n•	Dubbele economi-sche eigenaar bij zelfde overeenkomst", "Dubbele economische eigenaar bij zelfde over-eenkomst:\n1.	Run script om script te vinden dat de foute data opspoort:\nselect BronSQL FROM [ILH_METADATA].[CTR].[RUNTELLING_CONFIGURATIE] where Controle-Beschrijving like '%econo%'\n2.	Run BronSQL van stap 1 om de foute data te vinden\n3.	Zoek herstelscript:\nSELECT TOP 1000 [SQL_Query],[Opmerking],[SQL_Query_Uitvoeren]  FROM [ILH_METADATA].[DCF].[HERSTEL_STG_DAG]  WHERE Opmerking like '%eco%'\n4.	Zoek uit welke maatschappij de correcte is en dan run het herstelscript van stap 3"));
            _solutions.Add(new Solution("HASH", "", "Filename: <filename>.csv SHA512  uit CLOSE_CTRL komt niet overeen met  IL_SHA512_HashKey uit GevondenBestanden", "De hash waarde berekent door het ILVB proces komt niet overeen met de hash uit het controle bestand.", "Productie:\n-	Terugkoppelen naar bron\nD/T/A:\n-	Bepaal berekende hash:\n  SELECT Bestandsnaam, up-per(cast([IL_SHA512_HashKey] as nvarchar (512))) IL_SHA512_HashKey FROM LOG.GevondenBronbestanden where LeveringNaam = 'CLOSE_CM' and RunId = 1 and Bestandsnaam like '%CollectionMeasureFreeFields_%'\n-	Update controle bestand met hash uit vorige stap"));
            _solutions.Add(new Solution("House FP wordt niet geladen", "", @"Step SEQ_ILH_HOUSE_FP_2 0 komt niet voor in RunStepLog", @"1.	LAAD_HOUSE_FP staat niet op “J” in kalender\n2.	Bestand P:\ILH\RunDirectory\Prog\Loaders\HOUSE_CTRL.xsd bestaat niet", "1: Pas kalender aan\n2: Kopieer bestand van andere omgeving"));
            _solutions.Add(new Solution("Laden STAGING (NIEUWER)", "", "", @"Sommige bronbestanden zijn niet aanwezig", "Controleer bronbestanden"));
 
            // SSIS errors
            _solutions.Add(new Solution("", @"ExProT Controles en rapportages:The task, 'ExProT Controles en rapportages', failed.", "ExProT Controles en rapportages", @"\SEQ_ILH_SCHEDULING\SEQC MAIN\Sequence Container\SEQ_VERWERKING\Sequence Container\EP SEQ_VERWERKING\SEQ_VERWERKING\SEQC Verwerking\SEQC DDS\SEQC verwerken DDS\Sequence Container\ExProT Controles en rapportages", @"Meerdere records in [ILH_LOGGING_MAAND].[LOG].[AUDIT_KALENDERVERWERKING] met hetzelfde RunID", @"Zoek in bestand P:\ILH\RunDirectory\Logs\Scheduler Logs\Scheduler.log naar de reden.\nZet het rapport uit in het xml bestand\nVerwijder extra records, maar laat 1 record intact per RunID: DELETE [LOG].AUDIT_KALENDERVERWERKING\nWHERE  Execution_id IN\n(\nSELECT Execution_Id\nFROM\n    (\n        SELECT Execution_Id\n             , ROW_NUMBER() OVER(PARTITION BY RunId\n               ORDER BY Execution_id DESC) AS RowNbr        FROM   [LOG].AUDIT_KALENDERVERWERKING\n    ) t\n    WHERE  RowNbr > 1\n);"));
            //_solutions.Add(new Solution("", @"SRC Valideer Header:The task, 'SRC Valideer Header', failed.", @"SRC Valideer Header", @"\SEQ_ILH_SCHEDULING\SEQC MAIN\Sequence Container\SEQ_CF\EP SEQ_CF\SEQ_CF\SEQC Verwerking Dag\FELC varFullCFDistributielijst[1]\SEQ overall\SEQ CF dag\EPT CF GENEREREN\CF_CSV_GENEREREN\SEQC Logica toevoegen FRIS\SEQC Aanmaken CF Body Header\SEQC Genereer CF obv AFNEMER_CONFIGURATIE\FELC varTeGenererenCF_Object[1]\SEQC genereer CF\SEQC Valideer body en Genereer header\SRC Valideer Header", @"De XML bestanden van de vorige runs zijn niet verwijderd in folder P:\ILH\RunDirectory\Oplevering. SSIS merged de nieuwe data en door de dubbele records kan het geen header aanmaken.", @"Verwijderen van bestanden in P:\ILH\RunDirectory\Oplevering voor elke run."));
            //_solutions.Add(new Solution("", @"DFT Controle op dubbele referenties Error OLE SRC controle op dubbele referen-ties failed the pre-execute phase and returned error code Ox80040E07 DFT Controle op dubbele referenties", @"DFT Controle op dubbele referenties", @"MAIN\Sequence Container Container\EP SEQ_VERWERKING Verwerking\SEQC DDS\SEQC verwerken DDS\EPT SEQ_REFERENTIES Controle op dubbele referenties", @"Er is data in de staging tables waardoor het dubbele refentie script fails.", "Haal dubbele referentie script op uit SSIS package EPT SEQ REFERENTIES, “Controle op dubbele referenties”. Fix data zodat dit script weer functioneert."));
            //_solutions.Add(new Solution("", "DFT Betalingsachterstanden: error: data conversion failed.", @"Staging", @"SEQ_MAIN\SEQC verwerking DFT Betalingachterstanden (ILVV, SRPZZSQL0052)", @"Onjuiste data in bestand Betalingsachterstanden", @"Zoek de row op (staat in andere messages) en maak een melding voor het EP + devops team. Zie voorbeeld incident INC0232238. Herstel zelf de data als de correctie van EP+ te lang duurt."));
            //_solutions.Add(new Solution("", "CF: Kan peildatum niet bepalen", @"", "", "", ""));
         }

        public Solution FindILSolution(string controleType, string packageName, string opmerkingen)
        {
            Solution sol = null;

            // Find solution based on controleType
            if (controleType != null && controleType != "")
                sol = _solutions.Find(x => x.ControleType.ToLower().Equals(controleType.ToLower()));

            // Find solution based on opmerkingen
            if (sol == null && opmerkingen != null && opmerkingen != "")
                sol = _solutions.Find(x => x.Opmerkingen.ToLower().Contains(opmerkingen.ToLower()));

            // Find solution based on package name
            if (sol == null && packageName != null && packageName != "")
                sol = _solutions.Find(x => x.PackageName.ToLower().Contains(packageName.ToLower()));

            return sol;
        }

        public Solution FindSSISSolution(string ssisMessage, string ssisSourceName, string ssisExecutionPath)
        {
            Solution sol = null;

            // Find solution based on ssisMessage
            if (ssisMessage != null && ssisMessage != "")
                sol = _solutions.Find(x => x.SsisMessage.ToLower().Contains(ssisMessage.ToLower()));

            // Find solution based on ssisSourceName
            if (sol == null && ssisSourceName != null && ssisSourceName != "")
                sol = _solutions.Find(x => x.Opmerkingen.ToLower().Contains(ssisSourceName.ToLower()));

            // Find solution based on ssisExecutionPath
            if (sol == null && ssisExecutionPath != null && ssisExecutionPath != "")
                sol = _solutions.Find(x => x.PackageName.ToLower().Contains(ssisExecutionPath.ToLower()));

            return sol;
        }
 
    }
}
