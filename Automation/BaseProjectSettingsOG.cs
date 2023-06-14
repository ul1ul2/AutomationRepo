using Aspose.Cells;
using Newtonsoft.Json;
using NUnit.Framework;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Xml;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace HedgeOpsAutomation
{
    public class BaseProjectSettingsOG
    {
        //~║·AUTOMATION CONTROL CENTER·╠═══════════════════════════════════════════════════════════════════════════════════════════════╗
        //!Who will be running HedgeOps automated tests?
        public static string userName = "John McDonnell"; //>Defines the name of a user which will be referenced in relevant tests

        //!What directory should applicable files save to?
        public static string customUserDirectory = @"\\chic-dfs\Shares\lif_general\frm_group\Financial Technology Practice\John McDonnell\";
        //>All On-Prem test report files will arrive in the location defined in their respective run list configurations - currently set to the defaultUserDirectory

        //!Should fresh copies of gold standard run groups be IMPORTED (0) or IGNORED (1)?
        public static int goldImports = 1; //>Set to 0 or 1

        //!What grid environment should applicable tests submit to?
        public static string targetGridMachine = "grid-temp-2019"; //>Defines a grid which will be used for all applicable tests

        //!Are you testing HedgeOps ON-PREMISES (0) or the CLOUD (1)?
        public static int targetTestingLocation = 0; //>Set to 0 or 1

        //!Are you targeting the DEV STAGING environment?
        public static int targetDevStaging = 0; //>Set to 0 (NO) or 1 (YES)

        //!Are you targeting the CHAMELEON environment?
        public static int targetChameleon = 1; //>Set to 0 (NO) or 1 (YES)

        //!Are you testing on program SP (0), SECONDARY (1), or TERTIARY(2)?
        public static int targetProgram = 0; //>Set to 0, 1, or 2 (defaults to SECONDARY for role/permission AND date token tests)

        //!Do your tests need to reference the RunAutomation project?
        public static int runAutomationReference = 1; //>Set to 0 (NO) or 1 (YES)
        //~║·AUTOMATION CONTROL CENTER·╠═══════════════════════════════════════════════════════════════════════════════════════════════╝

        //GLOBAL PROJECT ITEMS--------------------------------------------------------------------------------------------------------<>
        #region Global Bools
        public bool condition = true;
        #endregion

        #region Global Integers
        public static int data1 = 0, importToggle = 0, lineCount = 0, straightSubmit, targetedProgramOverride = 0, testVariation = 0;
        public static int timeoutWait = 15;
        public static int timerTiny = 15;
        public static int timerShort = 45;
        public static int timerLogin = 10;

        public static int timerMinute = 60;
        public static int timerMinutePlus = 80;
        public static int timer2Minute = 120;
        public static int timer3MinutePlus = 200;

        public static int timerBarker = 90;
        public static int timerBloomberg = 480; //>8 mins
        public static int timerInforce = 200;
        public static int timerMGHedge = 480; //>8 mins
        public static int timerReport = 180;
        public static int timerReportNotif = 100;
        public static int timerScenario = 180;
        public static int timerSplit = 500; //>8+ mins
        public static int timerSync = 1740; //>29 mins

        public static int waitDelayCustom, waitDelay3 = 300, waitDelay5 = 500, waitDelay6 = 600, waitDelayLong = 1000, waitDelayLongPlus = 1500,
            waitDelaySuper = 2000, waitDelayMega = 3000, waitDelayBrowse = 4400, waitDelayExtreme = 4000, waitDelayDataStore = 6100, waitDelayExport = 6500;
        #endregion

        #region Global Strings
        public static string UserNameOnPrem()
        {
            userName = userName.Replace(" ", ".");
            return userName = userName.ToLower();
        }
        public static string userNameCloud = userName;
        public static string userNameFirst = userName.Split(' ')[0];

        public static string ftpDirectory = @"\\chic-dfs\Shares\lif_general\frm_group\Financial Technology Practice\";
        public static string defaultUserDirectory = string.Format("{0}{1}\\", ftpDirectory, "John McDonnell");
        public static string mainAutomationDirectory = string.Format(@"{0}PLEASE_DO_NOT_DELETE_CONTENTS\HedgeOps\AutomationTestFiles\", defaultUserDirectory);

        public string assumptionDirectory = @"AutoAssumptionDataFiles\";
        public string adhocDirectory = @"AutoAdHocFiles\";
        public static string automationFolderCustom = @"AutomationTest\";
        public string dateTokenDirectory = @"AutoDateTokenFiles\";
        public string dateTokensubDirectory1 = @"DT Mult Inforce\";
        public string dateTokensubDirectory2 = @"DT Non Hedge\";

        public string defaultPluginDirectory = @"AutoDefaultPlugins\";
        public string downloadDirectory = string.Format(@"C:\Users\{0}\Downloads\", UserNameOnPrem());
        public string entityDirectory = @"AutoEntityStructure\";
        public string etlDirectorySource = @"AutoETLFiles\";
        public string externalModels_2_10_Directory = @"2.10 External Models\";
        public string valuationDirectory = @"Valuation\";
        public string MGHedgeFormatPXR8DefaultValuationDirectory = @"MGHedgeFormat-PXR8 Default\";
        public string MGHedgeFormatPXR7DefaultValuationDirectory = @"MGHedgeFormat-PXR7 Default\";
        public string MGHedgeFormatPXR6DefaultValuationDirectory = @"MGHedgeFormat-PXR6 Default\";

        public static string etlDirectoryCustomCloud = @"F:\CloudETLTesting";
        public static string etlDirectoryCustomSourceSP = @"ETL_Sync\";
        public static string etlDirectoryCustomSourceSP2 = @"ETL_Sync_Secondary\";
        public static string etlDirectoryCustomSourceSP3 = @"ETL_Sync_Tertiary\";
        public static string etlDirectoryCustomTemp = string.Format(@"{0}PLEASE_DO_NOT_DELETE_CONTENTS\{1}", defaultUserDirectory, automationFolderCustom);
        public static string ETLDropLocation()
        {
            if (targetTestingLocation == 0)
            {
                if (targetProgram == 1 || targetedProgramOverride == 1)
                {
                    etlDirectoryCustomFinal = etlDirectoryCustomSourceSP2;
                }

                if (targetProgram == 2 || targetedProgramOverride == 2)
                {
                    etlDirectoryCustomFinal = etlDirectoryCustomSourceSP3;
                }
                else
                {
                    etlDirectoryCustomFinal = etlDirectoryCustomSourceSP;
                }

                etlDirectoryCustomFinal = string.Format(@"{0}PLEASE_DO_NOT_DELETE_CONTENTS\{1}", defaultUserDirectory, etlDirectoryCustomFinal);
            }

            if (targetTestingLocation == 1)
            {
                etlDirectoryCustomFinal = etlDirectoryCustomCloud;
                nysaTargetPath = string.Format(@"\\{0}\nysadatastore\1234-{1}-20\", nysaMachine, nysaProgramTag);
            }

            return etlDirectoryCustomFinal;
        }

        public static string fileCopyToLocationOnPrem = string.Format("{0}", customUserDirectory);
        public string fundmapDirectory = @"AutoFundMapFiles\";
        public string inforceDirectory = @"AutoInforceFiles\";
        public string inputProcessorsDirectory = @"AutoInputProcessors\";

        public string machineDevStaging = "chic-ftg-dev1";
        public string machineOnPrem = "CHIC-jenk-db1";
        public string machineOnPremChameleon = "CHIC-nysa-qa1";

        public string nysaTargetPathCloud = @"\\CHIC-hdge-qadb\SFTP_Root";
        public static string NysaProgram()
        {
            char[] chars = new char[] { '[', ']' };

            foreach (char c in chars)
            {
                programTag = programTag.Replace(c, ' ');
            }
            programTag = programTag.Trim();
            return programTag;
        }
        public static string NysaProgramTagConvert()
        {
            if (targetProgram == 0 && targetedProgramOverride == 0)
            {
                nysaProgramTag = nysaProgramTagSP;
            }

            if (targetProgram == 1 || targetedProgramOverride == 1)
            {
                nysaProgramTag = nysaProgramTagSP2;
            }

            if (targetProgram == 2 || targetedProgramOverride == 2)
            {
                nysaProgramTag = nysaProgramTagSP3;
            }

            return nysaProgramTag;
        }
        public static string nysaProgramTagSP = "SP", nysaProgramTagSP2 = "sp2", nysaProgramTagSP3 = "SP3";
        public string nysaFolderArchive = @"Archive\";
        public string nysaFolderData = @"Data\";
        public static string nysaFolderRunList = @"RunList\";
        public string nysaServiceName = "Milliman.FRM.Nysa";

        public string parameterSetDirectory = @"AutoParameterSetFiles\";
        public string parameterSetMGHedgeDirectory = @"MGHedge Format Upload\";
        public string parameterSetMGHedgeMisconfigDirectory = @"Misconfigured MGHedge Parameter Set Test\";
        public string productsDirectory = @"AutoProductsFiles\";
        public string reportDirectory = @"AutoReportFiles\";
        public string resultsProfileDirectory = @"AutoResultsProfileFiles\";
        public string resultsProcessorsDirectory = @"AutoResultsProcessors\";
        public string riskTaxonomyDirectory = @"AutoRiskTaxonomy\";
        public static string runGroupDirectory = @"AutoRunGroupFiles\";
        public string runTypeSubDirectoryOld = @"AutoRunGroupSuite 2.9\";
        public string runTypeSubDirectoryNew = @"AutoRunGroupSuite 2.10\";
        public string scenarioDirectory = @"AutoScenarioFiles\";
        public string testResultsDirectory = @"HOAutomationTestResults\";

        public string userEmailAddress = string.Format("{0}@milliman.com", UserNameOnPrem());
        public string userOnPremRecord = string.Format(@"ROOT_MILLIMAN\{0}", UserNameOnPrem());
        public static string genericTestComment = ".Automation Test";
        public static string genericTestHeader = ".AutomationTest";
        public static string goldTestHeader = "Stub";
        public string linerowdata = "";
        public static string programTagSP = "[SP]";
        public string programTagSecondary = "[Secondary]";
        public string programTagTertiary = "[Tertiary]";

        public string guidCloudSP = "BC76A070-2EFD-4F70-8C04-731F19E60FA2";
        public string guidDevStaging = "A64D09C2-DB43-4951-9107-EDE518E05E41";
        public string guidCloudSecondary = "D3369A9C-5FE1-46F5-AC6C-7F1B2CF2E971";
        public string guidOnPremSP = "37DEF352-40AF-43C9-A620-DCE82680406C";
        public string guidOnPremSecondary = "8648A69B-4F20-4E30-BF8C-2E7CEEDFAB9C";
        public string guidOnPremTertiary = "8D9BE482-710D-484E-93A9-8884330E85D0";

        public static string compareFile, configName, extPNG = ".png", extTXT = ".txt", extXLSX = ".xlsx", extXML = ".xml", etlDirectoryCustomFinal, fileCopyToLocationCloud, gridName, line, newName, nysaProgramTag, programTag, nysaMachine, nysaTargetPath,
            revisionId1, revisionId2, revisionId3, runInstanceName, sourceFile, targetProgramGuid, targetUserName, valDate;
        public string Id, importName, runListInstId1, runListInstId2, runListInstId3, runListInstId4, runListInstId5, runListInstId6, runListInstId7, runListInstId8, runListInstId9, siteVersion, xpath1, xpath2;
        #endregion
        //GLOBAL PROJECT ITEMS--------------------------------------------------------------------------------------------------------<>

        //SETUP & TEARDOWN METHODS----------------------------------------------------------------------------------------------------<>
        #region Nunit Test Setup/Teardown
        public static IWebDriver driver;
        //public IWebDriver driver = RunAutoDriver.driver;
        public static WebDriverWait wait;
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void StartUp()
        {
            //>Prevents file download warning popup from triggering.
            var options = new ChromeOptions();
            options.AddUserProfilePreference("safebrowsing.enabled", true);

            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutWait));

            //Start session.         
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Size = new Size(1740, 1040);
            //Maximize window.
            //driver.Manage().Window.Maximize();

            if (targetTestingLocation != 1)
            {
                if (targetChameleon == 1 && targetDevStaging == 0)
                {
                    driver.Url = "http://chic-nysa-qa1:8097/";
                }

                if (targetDevStaging == 1)
                {
                    driver.Url = "http://chic-ftg-dev1:8097/";
                    targetChameleon = 1;
                }

                //Store the parent window of the driver.
                parentWindowHandle = driver.CurrentWindowHandle;
            }

            if (targetTestingLocation == 1)
            {
                if (targetChameleon == 1)
                {
                    driver.Url = "https://chameleon.hedgeops.net/";
                }
                else
                {
                    driver.Url = "https://qa2.hedgeops.net/";
                }

                //Store the parent window of the driver.
                parentWindowHandle = driver.CurrentWindowHandle;
            }
        }
        public void CloseDown()
        {
            //Close session.
            driver.Close();
        }
        #endregion

        #region SQL Connect/Close
        public SqlConnection connectionLocation = null;
        public SqlConnection connectionOnPrem = new SqlConnection("server=WEST-SQL-DEV1;" + "Trusted_Connection=yes;" + "database=JenkDB; " + "connection timeout=30");
        public SqlConnection connectionChameleonOnPrem = new SqlConnection("server=WEST-SQL-DEV1;" + "Trusted_Connection=yes;" + "database=ALDB_QA; " + "connection timeout=30");
        public SqlConnection connectionChameleonOnPremLACDB = new SqlConnection("server=WEST-SQL-DEV1;" + "Trusted_Connection=yes;" + "database=LACDB_QA; " + "connection timeout=30");
        public SqlConnection connectionCloud = new SqlConnection("Integrated Security=false;" + "user id=hopsadmin;" + "password=Milliman@123;" + "server=0317zrm1960qa2sql.database.windows.net;" + "database=ALDB_QA; " + "connection timeout=30");
        public SqlConnection connectionChameleonCloud = new SqlConnection("Integrated Security=false;" + "user id=hopsadmin;" + "password=Milliman@123;" + "server=0317zrm1960qa4sql.database.windows.net;" + "database=ALDB; " + "connection timeout=30");
        public SqlConnection connectionChameleonCloudLACDB = new SqlConnection("Integrated Security=false;" + "user id=hopsadmin;" + "password=Milliman@123;" + "server=0317zrm1960qa4sql.database.windows.net;" + "database=LACDB; " + "connection timeout=30");
        public SqlConnection connectionDevStaging = new SqlConnection("server=WEST-SQL-DEV1;" + "Trusted_Connection=yes;" + "database=ALDB_DEV; " + "connection timeout=30");
        public SqlConnection connectionDevStagingLACDB = new SqlConnection("server=WEST-SQL-DEV1;" + "Trusted_Connection=yes;" + "database=LACDB_DEV; " + "connection timeout=30");

        public void SQLConnect()
        {
            if (targetTestingLocation == 0)
            {
                try
                {
                    if (targetChameleon == 1 && targetDevStaging == 0)
                    {
                        targetUserName = UserNameOnPrem();
                        connectionLocation = connectionChameleonOnPrem;
                    }
                    if (targetDevStaging == 1)
                    {
                        targetUserName = UserNameOnPrem();
                        connectionLocation = connectionDevStaging;
                    }
                    else
                    {
                        targetUserName = UserNameOnPrem();
                        connectionLocation = connectionOnPrem;
                    }

                    //Connect to SQL On-Prem DB.
                    connectionLocation.Open();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (targetTestingLocation == 1)
            {
                try
                {
                    if (targetChameleon == 1)
                    {
                        targetUserName = userEmailAddress;
                        connectionLocation = connectionChameleonCloud;
                    }
                    else
                    {
                        targetUserName = userNameCloud;
                        connectionLocation = connectionCloud;
                    }

                    //Connect to SQL Cloud DB.
                    connectionLocation.Open();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        public void SQLClose()
        {
            if (targetTestingLocation == 0)
            {
                try
                {
                    if (targetChameleon == 1 && targetDevStaging == 0)
                    {
                        //Close connection to SQL On-Prem DB.
                        connectionChameleonOnPrem.Close();
                    }

                    if (targetDevStaging == 1)
                    {
                        //Close connection to SQL On-Prem DB.
                        connectionDevStaging.Close();
                    }
                    else
                    {
                        //Close connection to SQL On-Prem DB.
                        connectionOnPrem.Close();
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (targetTestingLocation == 1)
            {
                try
                {
                    if (targetChameleon == 1)
                    {
                        //Close connection to SQL Cloud DB.
                        connectionChameleonCloud.Close();
                    }
                    else
                    {
                        //Close connection to SQL Cloud DB.
                        connectionCloud.Close();
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        public void SQLConnectLACDB()
        {
            if (targetTestingLocation == 0)
            {
                try
                {
                    if (targetChameleon == 1 && targetDevStaging == 0)
                    {
                        targetUserName = UserNameOnPrem();
                        connectionLocation = connectionChameleonOnPremLACDB;
                    }
                    if (targetDevStaging == 1)
                    {
                        targetUserName = UserNameOnPrem();
                        connectionLocation = connectionDevStagingLACDB;
                    }

                    //Connect to SQL On-Prem DB.
                    connectionLocation.Open();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (targetTestingLocation == 1)
            {
                try
                {
                    if (targetChameleon == 1)
                    {
                        targetUserName = userEmailAddress;
                        connectionLocation = connectionChameleonCloudLACDB;
                    }

                    //Connect to SQL Cloud DB.
                    connectionLocation.Open();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        public void SQLCloseLACDB()
        {
            if (targetTestingLocation == 0)
            {
                try
                {
                    if (targetChameleon == 1 && targetDevStaging == 0)
                    {
                        //Close connection to SQL On-Prem DB.
                        connectionChameleonOnPremLACDB.Close();
                    }

                    if (targetDevStaging == 1)
                    {
                        //Close connection to SQL On-Prem DB.
                        connectionDevStagingLACDB.Close();
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (targetTestingLocation == 1)
            {
                try
                {
                    if (targetChameleon == 1)
                    {
                        //Close connection to SQL Cloud DB.
                        connectionChameleonCloudLACDB.Close();
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        #endregion
        //SETUP & TEARDOWN METHODS----------------------------------------------------------------------------------------------------<>

        //SQL DATABASE ITEMS----------------------------------------------------------------------------------------------------------<>
        #region SQL DB Report Testing Strings
        public string sqlAssertModifiedDate = DateTime.Now.ToShortDateString();

        public string sqlTableRunListInstanceStatus = "[runlistinstance_status]";
        public string sqlTableRunListOutputModifiedUser = "[runlistoutput_modifieduser]";
        public string sqlTableRunListOutputModifiedDate = "[runlistoutput_modifieddate]";
        public string sqlTableRunListOutputOverridden = "[runlistoutput_overridden]";
        public string sqlTableRunListOutputReviewer = "[runlistoutput_reviewer]";
        public string sqlTableRunListOutputReviewDate = "[runlistoutput_reviewdate]";
        public string sqlTableRunListOutputStatus = "[runlistoutput_status]";

        public string sqlQueryResult1, sqlQueryResult2, sqlModifiedUser, sqlNullReturn = null;
        public string sqlAssertDefaultModifiedUser = "System";
        public string sqlAssertEditedModifiedUser = "%.%";
        public string sqlAssertETLSuccess = "True";
        public string sqlAssertReportStatusApprove = "Approved";
        public string sqlAssertStatusComplete = "Complete";
        public string sqlAssertReportStatusDeny = "Denied";
        public string sqlAssertReportStatusPending = "PendingApproval";
        public string sqlAssertNull = "";
        public string sqlAssertOverridden = "True";

        public string sqlAssertRunStatusGeneratedReport = "GeneratedReport";
        public string sqlAssertRunStatusGeneratingReport = "GeneratingReport";
        public string sqlAssertRunStatusDownloadedModels = "DownloadedModels";
        public string sqlAssertRunStatusDownloadingModels = "DownloadingModels";
        public string sqlAssertRunStatusPrepared = "Prepared";
        public string sqlAssertRunStatusPreparing = "Preparing";
        public string sqlAssertRunStatusOpen = "Open";
        public string sqlAssertRunStatusReady = "Ready";

        public string sqlAssertRiskTaxonomy = "TickerTest";
        public string sqlMarketDescId, sqlMarketId;
        public string sqlMarketDescKey = "LBUSMD Index";
        public string sqlSPMarketDataValue = "6.0400000000";
        public string sqlMarketDataValueTrunc = "6.04";
        public string sqlSPScenarioId = "2";
        public string sqlSPScenarioIdCloud = "3";
        public string sqlSecondaryMarketDataValue = "7.7700000000";
        public string sqlSecondaryScenarioId = "4";
        public string sqlSecondaryScenarioIdCloud = "2";

        public string sqlAssertRunListActive = "1";
        public string sqlAssertRunListNotActive = "False";
        public string sqlAssertVoidedFlag = "1";
        #endregion

        #region SQL DB Date Token Strings
        public string sqlAssertDT1BeginInforce = "2/8/2019";
        public string sqlAssertDT1EndInforce = "2/15/2019";
        public string sqlAssertDT1BeginAttr = "2/8/2019";
        public string sqlAssertDT1EndAttr = "2/15/2019";
        public string sqlAssertDT1Valuation = "2/18/2019";

        public string sqlAssertDT2BeginInforce = "12/26/2019";
        public string sqlAssertDT2EndInforce = "12/27/2019";
        public string sqlAssertDT2BeginAttr = "12/26/2019";
        public string sqlAssertDT2EndAttr = "12/27/2019";
        public string sqlAssertDT2Valuation = "12/27/2019";

        public string sqlAssertDT3BeginInforce = "12/27/2019";
        public string sqlAssertDT3EndInforce = "12/30/2019";
        public string sqlAssertDT3BeginAttr = "12/27/2019";
        public string sqlAssertDT3EndAttr = "12/30/2019";
        public string sqlAssertDT3Valuation = "12/27/2019";

        public string sqlAssertDT4BeginInforce = "9/30/2019";
        public string sqlAssertDT4EndInforce = "9/30/2019";
        public string sqlAssertDT4BeginAttr = "9/30/2019";
        public string sqlAssertDT4EndAttr = "10/31/2019";
        public string sqlAssertDT4Valuation = "9/30/2019";

        public string sqlAssertDT5BeginInforce = "12/30/2016";
        public string sqlAssertDT5EndInforce = "12/30/2016";
        public string sqlAssertDT5BeginAttr = "10/31/2016";
        public string sqlAssertDT5EndAttr = "12/30/2016";
        public string sqlAssertDT5Valuation = "12/30/2016";

        public string sqlAssertDT6BeginInforce = "6/29/2018";
        public string sqlAssertDT6EndInforce = "7/31/2018";
        public string sqlAssertDT6BeginAttr = "6/29/2018";
        public string sqlAssertDT6EndAttr = "7/31/2018";
        public string sqlAssertDT6Valuation = "7/31/2018";

        public string sqlAssertDT7BeginInforce = "7/31/2018";
        public string sqlAssertDT7EndInforce = "10/31/2018";
        public string sqlAssertDT7BeginAttr = "7/31/2018";
        public string sqlAssertDT7EndAttr = "10/31/2018";
        public string sqlAssertDT7Valuation = "10/31/2018";

        public string sqlAssertDT8BeginInforce = "9/14/2018";
        public string sqlAssertDT8EndInforce = "9/14/2018";
        public string sqlAssertDT8BeginAttr = "9/7/2018";
        public string sqlAssertDT8EndAttr = "9/14/2018";
        public string sqlAssertDT8Valuation = "9/14/2018";

        public string sqlAssertDT9BeginInforce = "10/31/2018";
        public string sqlAssertDT9EndInforce = "4/23/2019";
        public string sqlAssertDT9BeginAttr = "10/31/2018";
        public string sqlAssertDT9EndAttr = "2/28/2019";

        public string sqlAssertDT10BeginInforce = "2/28/2019";
        public string sqlAssertDT10EndInforce = "2/28/2019";
        public string sqlAssertDT10BeginAttr = "10/31/2018";
        public string sqlAssertDT10EndAttr = "2/28/2019";

        public string sqlAssertDT11BeginInforce = "6/29/2018";
        public string sqlAssertDT11EndInforce = "9/20/2018";
        public string sqlAssertDT11BeginAttr = "6/29/2018";
        public string sqlAssertDT11EndAttr = "7/31/2018";
        public string sqlAssertDT11Valuation = "7/31/2018";

        public string sqlAssertDTBadassBeginInforce = "3/22/2019";
        public string sqlAssertDTBadassEndInforce = "4/1/2019";
        public string sqlAssertDTBadassBeginAttr = "3/22/2019";
        public string sqlAssertDTBadassEndAttr = "4/1/2019";

        public string sqlAssertDTBarkerBeginInforce = "4/1/2019";
        public string sqlAssertDTBarkerEndInforce = "4/1/2019";
        public string sqlAssertDTBarkerBeginAttr = "3/22/2019";
        public string sqlAssertDTBarkerEndAttr = "4/1/2019";

        public string sqlAssertDTBloombergBeginInforce = "3/22/2019";
        public string sqlAssertDTBloombergEndInforce = "4/1/2019";
        public string sqlAssertDTBloombergBeginAttr = "3/22/2019";
        public string sqlAssertDTBloombergEndAttr = "4/1/2019";

        public string sqlAssertDTInforce1BeginInforce = "12/31/2015";
        public string sqlAssertDTInforce1EndInforce = "12/29/2017";
        public string sqlAssertDTInforce1BeginAttr = "12/31/2015";
        public string sqlAssertDTInforce1EndAttr = "12/29/2017";

        public string sqlAssertDTInforce2BeginInforce = "3/8/2019";
        public string sqlAssertDTInforce2EndInforce = "3/22/2019";
        public string sqlAssertDTInforce2BeginAttr = "3/8/2019";
        public string sqlAssertDTInforce2EndAttr = "3/22/2019";

        public string sqlAssertDTInforceSplitBeginInforce = "12/29/2017";
        public string sqlAssertDTInforceSplitEndInforce = "1/31/2019";
        public string sqlAssertDTInforceSplitBeginAttr = "12/29/2017";
        public string sqlAssertDTInforceSplitEndAttr = "1/31/2019";

        public string sqlAssertDTHedgeTempBeginInforce = "4/1/2019";
        public string sqlAssertDTHedgeTempEndInforce = "4/1/2019";
        public string sqlAssertDTHedgeTempBeginAttr = "3/22/2019";
        public string sqlAssertDTHedgeTempEndAttr = "4/1/2019";

        public string sqlAssertDTReportBeginInforce = "12/29/2017";
        public string sqlAssertDTReportEndInforce = "12/29/2017";
        public string sqlAssertDTReportBeginAttr = "12/29/2017";
        public string sqlAssertDTReportEndAttr = "1/31/2019";
        #endregion
        //SQL DATABASE ITEMS----------------------------------------------------------------------------------------------------------<>

        //~║·AUTOMATION CORE TESTING·╠═════════════════════════════════════════════════════════════════════════════════════════════════╗

        //--HOME------------------------------------------------------------------------------------------------------oo
        #region Login Tests
        public string hedgeNamespace = "Working Version";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void ActiveLogin()
        {
            if (targetTestingLocation != 1)
            {
                if (targetProgram != 1)
                {
                    LoginSP();
                }

                if (targetProgram == 1)
                {
                    LoginSecondary();
                }

                if (targetProgram == 2)
                {
                    LoginTertiary();
                }

                targetUserName = UserNameOnPrem();
            }

            if (targetTestingLocation == 1)
            {
                LoginCloud();

                if (targetChameleon == 1)
                {
                    targetUserName = userEmailAddress;
                }
                else
                {
                    targetUserName = userNameCloud;
                }
            }

            //Identify the name of the program for the environment.
            IdentifyEnvProgram();

            //Identify testing program and append corresponding file tag.
            DetermineProgramFileTag();

            //Define custom ETL file source folder.
            ETLDropLocation();
        }
        public void RolePermissionsLogin()
        {
            if (targetTestingLocation == 1)
            {
                LoginCloud();
            }

            else
            {
                LoginSecondary();
            }
        }
        public void LoginSelection()
        {
            if (targetChameleon == 1)
            {
                //Wait for program name to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//b[text()[contains(.,'{0}')]]", hedgeNamespace))));
            }

            else
            {
                //Check for Change login link.
                var loginChangeActive = driver.FindElements(By.XPath("//a[@id[contains(.,'changeProgramLink')]]"));

                //Wait for login modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Pick your Program and Namespace']")));

                if (loginChangeActive.Any())
                {
                    //Select a Program.
                    Task.Delay(waitDelay5).Wait();
                    driver.FindElement(By.XPath("//input[@id[contains(.,'programPickerWindow_programSelector_I')]]")).Click();
                    Task.Delay(waitDelay5).Wait();
                    driver.FindElement(By.XPath(string.Format("//td[text()='{0}']", NysaProgram()))).Click();
                    Task.Delay(waitDelayLong).Wait();

                    //Restart stopwatch.
                    timer.Restart();

                    try
                    {
                        if (targetChameleon == 1)
                        {
                            waitDelayCustom = 6000;

                            //Click on Namespace field.
                            driver.FindElement(By.XPath("//input[@id[contains(.,'programPickerWindow_namespaceSelector_I')]]")).Click();
                            Task.Delay(waitDelayCustom).Wait();

                            //Enter a 'w' in the field (this triggers the drop down seclection to appear in view).
                            driver.FindElement(By.XPath("//input[@id[contains(.,'programPickerWindow_namespaceSelector_I')]]")).SendKeys("w");
                            Task.Delay(waitDelay6).Wait();

                            //Hit the Enter key.
                            HitEnterKey();
                        }
                        else
                        {
                            while (timer.Elapsed.TotalSeconds < timerLogin && timer.IsRunning.Equals(true))
                            {
                                var pickNamespace = driver.FindElements(By.XPath(string.Format("//td[text()='{0}']", hedgeNamespace)));

                                do
                                {
                                    //Click on Namespace field.
                                    driver.FindElement(By.XPath("//input[@id[contains(.,'programPickerWindow_namespaceSelector_I')]]")).Click();
                                    Task.Delay(waitDelay5).Wait();
                                }
                                while (!pickNamespace.Any());

                                //Stop stopwatch.
                                timer.Stop();
                            }

                            //Select a Namespace.
                            driver.FindElement(By.XPath(string.Format("//tr[@class='dxeListBoxItemRow_SoftOrange']/td[contains(.,'{0}')]", hedgeNamespace))).Click();
                            Task.Delay(waitDelay5).Wait();
                        }

                        //Click OK button.
                        driver.FindElement(By.XPath("//div[@id[contains(.,'programPickerWindow_ProgramPickButton_CD')]]/span[text()='OK']")).Click();
                        Task.Delay(waitDelay5).Wait();

                    }
                    catch (Exception)
                    {
                        Assert.Fail("Unable to log into environment.");
                    }
                }

                //Waits for login modal to disappear.
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Pick your Program and Namespace']")));
            }
        }

        public void LoginSP()
        {
            if (targetTestingLocation == 0)
            {
                if (targetChameleon == 1 && targetDevStaging == 0)
                {
                    nysaMachine = machineOnPremChameleon;
                    targetProgramGuid = guidOnPremSP;
                }

                if (targetDevStaging == 1)
                {
                    nysaMachine = machineDevStaging;
                    targetProgramGuid = guidDevStaging;
                }
                else
                {
                    nysaMachine = machineOnPrem;
                    targetProgramGuid = guidOnPremSP;
                }
            }

            if (targetTestingLocation == 1)
            {
                targetProgramGuid = guidCloudSP;
            }

            //nysaProgramTag = nysaProgramTagSP;
            programTag = programTagSP;

            NysaProgramTagConvert();
            nysaTargetPath = string.Format(@"\\{0}\nysadatastore\1234-{1}-20\", nysaMachine, nysaProgramTag);
            fileCopyToLocationCloud = string.Format(@"F:\nysadatastore\1234-{0}-20\TestingFolder", nysaProgramTag);

            //Log into HedgeOps.
            LoginSelection();
        }
        public void LoginSecondary()
        {
            if (targetTestingLocation == 0)
            {
                targetProgramGuid = guidOnPremSecondary;

                if (targetChameleon == 1)
                {
                    nysaMachine = machineOnPremChameleon;
                }
                else
                {
                    nysaMachine = machineOnPrem;
                }
            }

            if (targetTestingLocation == 1)
            {
                targetProgramGuid = guidCloudSecondary;
            }

            //nysaProgramTag = nysaProgramTagSP2;
            programTag = programTagSecondary;

            NysaProgramTagConvert();
            nysaTargetPath = string.Format(@"\\{0}\nysadatastore\1234-{1}-20\", nysaMachine, nysaProgramTag);
            fileCopyToLocationCloud = string.Format(@"F:\nysadatastore\1234-{0}-20\TestingFolder", nysaProgramTag);

            //Log into HedgeOps.
            LoginSelection();
        }
        public void LoginTertiary()
        {
            targetProgramGuid = guidOnPremTertiary;

            //nysaProgramTag = nysaProgramTagSP3;
            programTag = programTagTertiary;

            NysaProgramTagConvert();
            nysaTargetPath = string.Format(@"\\{0}\nysadatastore\1234-{1}-20\", nysaMachine, nysaProgramTag);

            //Log into HedgeOps.
            LoginSelection();
        }
        public void LoginCloud()
        {
            //>Start with Microsoft Account Login------------------------------------------------------
            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerShort && timer.IsRunning.Equals(true))
            {
                //Thread.Sleep(10000);
                var microsoftLanding = driver.FindElements(By.XPath("//a[text()='Terms of use']"));

                if (microsoftLanding.Any())
                {
                    var cloudSignIn = driver.FindElements(By.XPath("//div[text()='Sign in']"));
                    //Check if Microsoft account login modal requires account sign in.
                    if (cloudSignIn.Any())
                    {
                        //Enter an email.
                        Task.Delay(waitDelayLongPlus).Wait();
                        driver.FindElement(By.XPath("//input[@type='email']")).Click();
                        Task.Delay(waitDelay5).Wait();
                        driver.FindElement(By.XPath("//input[@type='email']")).SendKeys(userEmailAddress);
                        Task.Delay(waitDelay5).Wait();

                        //Hit Next.
                        driver.FindElement(By.XPath("//input[@type='submit']")).Click();
                        Task.Delay(waitDelayMega).Wait();
                    }

                    var cloudLogin = driver.FindElements(By.XPath("//div[text()='Pick an account']"));

                    //Check if Microsoft account login modal requires account selection.
                    if (cloudLogin.Any())
                    {
                        //Click on first user account.
                        driver.FindElement(By.XPath("//small[@data-bind='text: session.unsafe_displayName'][1]")).Click();
                        Task.Delay(waitDelayMega).Wait();
                    }

                    //>Transition to HedgeOps Login------------------------------------------------------------
                    if (targetChameleon == 1)
                    {
                        //Wait for program name to appear.
                        Task.Delay(waitDelay6).Wait();
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//b[text()[contains(.,'{0}')]]", hedgeNamespace))));
                        targetProgramGuid = guidCloudSP;
                    }
                    else
                    {
                        //Waits for program pick window to load.
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Pick your Program and Namespace']")));

                        if (targetProgram != 1)
                        {
                            //Log into HedgeOps.
                            LoginSP();
                        }

                        if (targetProgram == 1)
                        {
                            //Log into HedgeOps.
                            LoginSecondary();
                        }
                    }

                    //Stop stopwatch.
                    timer.Stop();
                }
                else
                {
                    //>Check for Security Warning Page---------------------------------------------------------
                    var warning = driver.FindElements(By.XPath("//button[text()[contains(.,'Advanced')]]"));

                    if (warning.Any())
                    {
                        //Click Advanced button.
                        driver.FindElement(By.XPath("//button[text()[contains(.,'Advanced')]]")).Click();
                        Task.Delay(waitDelay5).Wait();

                        //Click proceed link.
                        driver.FindElement(By.XPath("//a[@id='proceed-link']")).Click();
                        Task.Delay(waitDelayLong).Wait();
                    }
                }
            }
        }
        #endregion
        //--HOME------------------------------------------------------------------------------------------------------oo

        //--INPUT AND ASSUMPTIONS-------------------------------------------------------------------------------------oo
        #region Approvals Tests
        public string versionTypeLiabilityInforce = "LiabilityInforce";
        public string versionTypeName;
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void FilterByVersionType()
        {
            versionTypeName = versionTypeLiabilityInforce;

            //Click on Type drop down.
            driver.FindElement(By.XPath("//tr[td[text()='Type']]//img[@alt='[Filter]']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Toggle a variation of method test steps.
            clickHoldToggle = 1;

            //Click on the window resizer and drag it down.
            ClickHold();

            //Click on LiabilityInforce type.
            driver.FindElement(By.XPath(string.Format("//table[@id[contains(.,'ApprovalGridView_HFListBox')]]//td[text()='{0}']", versionTypeName))).Click();
            Task.Delay(waitDelay6).Wait();

            //Click on Date column.
            driver.FindElement(By.XPath("//td[text()='Date']")).Click();
            Task.Delay(waitDelay6).Wait();
        }
        #endregion

        #region Assumption Data Tests
        public string assumptionComment1 = "big!";
        public string assumptionComment2 = "pokemon";
        public string assumptionDataFile = "TestAssumptionData.csv";
        public string assumptionDataFilePichu1 = "TestAssumptionDataPichu1.csv";
        public string assumptionDataFilePichu2 = "TestAssumptionDataPichu2.csv";

        public string assumptionDataName1 = ".AutomationTestAssumptionData";
        public string assumptionDataName2 = "pichu";
        public string assumptionDataName3 = "PIcHu";
        public string assumptionLargeDataFile = "LargeAssumptionData.csv";
        public string assumptionLargeDataName = "Large 100+ MB";
        public string assumptionFileName;
        public string assumptionVersionID;
        public string versionDate, assetStubDate;

        private string assumptionData, assumptionFile, comment;
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public bool ValidateRevisionRowCreatedByUser(int revisionId)
        {
            //This function expands assumption data sets window and validates fields given the version id
            //for any file that is processed via the UI

            //Expand the Assumption Set
            if (driver.VerifyAsserts(By.XPath(string.Format
                ("//td[text()='{0}']/preceding-sibling::td[text()='{1}']/preceding-sibling::td/img[@alt = 'Expand']", versionDate, etlGroupVersionName))))
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format
                    ("//td[text()='{0}']/preceding-sibling::td[text()='{1}']/preceding-sibling::td", versionDate, etlGroupVersionName))));
                driver.FindElement(By.XPath(string.Format
                    ("//td[text()='{0}']/preceding-sibling::td[text()='{1}']/preceding-sibling::td", versionDate, etlGroupVersionName))).Click();
            }
            //Validate row
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Download']")));
            DateTime today = DateTime.Today; // As DateTime
            string s_today = today.ToString("M/d/yyyy"); // As String
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text() = '{0}']/following-sibling::td[text()='Uploaded via UI']", revisionId))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format
                ("//td[text() = '{0}']/following-sibling::td[2][text()[contains(.,'{1}')]]", revisionId, s_today))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text() = '{0}']/following-sibling::td[3][text()='{1}']", revisionId, targetUserName))));
            Assert.IsTrue(String.IsNullOrWhiteSpace(driver.FindElement(By.XPath(string.Format("//td[text() = '{0}']/following-sibling::td[4]", revisionId))).Text));
            Assert.IsTrue(String.IsNullOrWhiteSpace(driver.FindElement(By.XPath(string.Format("//td[text() = '{0}']/following-sibling::td[5]", revisionId))).Text));
            Assert.IsTrue(String.IsNullOrWhiteSpace(driver.FindElement(By.XPath(string.Format("//td[text() = '{0}']/following-sibling::td[6]", revisionId))).Text));

            return true;
        }
        public bool ValidateRevisionRowCreatedByETLConfig(int revisionId)
        {
            //This function expands assumption data sets window and validates fields given the version id
            //for any file that is processed via the ETL config 

            //Expand the Assumption Set
            if (driver.VerifyAsserts(By.XPath(string.Format
                ("//td[text()='{0}']/preceding-sibling::td[text()='{1}']/preceding-sibling::td/img[@alt = 'Expand']", versionDate, etlGroupVersionName))))
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format
                    ("//td[text()='{0}']/preceding-sibling::td[text()='{1}']/preceding-sibling::td", versionDate, etlGroupVersionName))));
                driver.FindElement(By.XPath(string.Format
                    ("//td[text()='{0}']/preceding-sibling::td[text()='{1}']/preceding-sibling::td", versionDate, etlGroupVersionName))).Click();
            }
            //Validate row
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Download']")));
            DateTime today = DateTime.Today; // As DateTime
            string s_today = today.ToString("M/d/yyyy"); // As String
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text() = '{0}']/following-sibling::td[text()='Generated by ETL']", revisionId))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format
                ("//td[text() = '{0}']/following-sibling::td[2][text()[contains(.,'{0}')]]", revisionId, s_today))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text() = '{0}']/following-sibling::td[3][text()='System']", revisionId))));
            Assert.IsTrue(String.IsNullOrWhiteSpace(driver.FindElement(By.XPath(string.Format("//td[text() = '{0}']/following-sibling::td[4]", revisionId))).Text));
            Assert.IsTrue(String.IsNullOrWhiteSpace(driver.FindElement(By.XPath(string.Format("//td[text() = '{0}']/following-sibling::td[5]", revisionId))).Text));
            Assert.IsTrue(String.IsNullOrWhiteSpace(driver.FindElement(By.XPath(string.Format("//td[text() = '{0}']/following-sibling::td[6]", revisionId))).Text));

            return true;
        }
        public void CompareParameterPostFileLocationToGridFile(string folderPath, string parameterFileName, string runListInstanceID)
        {
            //Download param file from scratch folder
            var gridParameterFile = DownloadFileFromDataStore(runListInstanceID, parameterFileName);

            //Get param file from File posting location
            FileInfo sourceParameterFile = new FileInfo(folderPath + string.Format
                (@"\run_{0}_{1}", runListInstanceID, parameterFileName));

            //Assert files are the same
            Assert.IsTrue(FileMD5AreSame(gridParameterFile, sourceParameterFile));

            //Delete Files
            gridParameterFile.Delete();
            sourceParameterFile.Delete();
        }
        public FileInfo DownloadFileFromDataStore(string runListID, string fileName)
        {
            //Refresh the page
            driver.Navigate().Refresh();

            //Expand RunList folder.
            driver.FindElement(By.XPath("(//li[div[span[text()='RunList']]]//img[@alt='Expand'])[1]")).Click();

            //Waits for list to expand.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//li[div[span[text()='RunList']]]//img[@alt='Collapse'])[1]")));

            //Click runlistinstanceID folder.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//span[text()[contains(.,'{0}')]]", runListID))));
            driver.FindElement(By.XPath(string.Format("//span[text()[contains(.,'{0}')]]", runListID))).Click();

            //Waits for list to expand.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//tr[@title[contains(.,'{0}')]]", runListID))));

            //Validate absence of the following files.
            Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[@title[contains(.,'{0}.csv')]]", runListID))));


            //Deletes specified files in dir before downloading 
            var path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            path = Path.Combine(path, "Downloads");
            var fileEntries = Directory.GetFiles(path, string.Format("{0}", fileName));
            foreach (string fileEntry in fileEntries)
            {
                if (File.Exists(fileEntry))
                {
                    File.Delete(fileEntry);
                }
            }

            //Select the file.
            driver.FindElement(By.XPath(string.Format
                ("//tr[td[div[text()[normalize-space() = '{0}']]]]//span[@class[contains(.,'edtCheckBoxUnchecked')]]", fileName))).Click();

            //Click on the Download button.
            driver.FindElement(By.XPath("(//img[@alt='Download'])[1]")).Click();

            //Wait for file to finish dowloading
            bool FileExist() { return Directory.GetFiles(path).Where(s => s.Contains(string.Format("{0}", fileName))).Count() > 0; }
            WaitUntilTrueOrTimeout(FileExist, TimeSpan.FromMinutes(1));
            string DatastoreFile = string.Format("{0}", fileName);
            FileInfo downloadedFile = new FileInfo(Path.Combine(path, DatastoreFile));

            return downloadedFile;
        }
        public void DownloadAndCompareFromDataStore(string runListID, FileInfo sourceAssumptionFile)
        {
            //Expand RunList folder.
            driver.FindElement(By.XPath("(//li[div[span[text()='RunList']]]//img[@alt='Expand'])[1]")).Click();
            Task.Delay(waitDelayDataStore).Wait();

            //Waits for list to expand.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//li[div[span[text()='RunList']]]//img[@alt='Collapse'])[1]")));

            //Expand runlistinstanceID folder.
            driver.FindElement(By.XPath(string.Format("//span[text()[contains(.,'{0}')]]", runListID))).Click();
            Task.Delay(waitDelayDataStore).Wait();

            //Waits for list to expand.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//tr[@title[contains(.,'{0}')]]", runListID))));


            //Validate absence of the following files.
            Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[@title[contains(.,'{0}.csv')]]", runListID))));

            //Deletes specified files in dir before downloading 
            var path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            path = Path.Combine(path, "Downloads");
            var fileEntries = Directory.GetFiles(path, string.Format("{0}.csv", assumptionVersionID));
            foreach (string fileName in fileEntries)
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }

            //Download the file 
            //Select the RunListInstance ID's xml file.
            driver.FindElement(By.XPath(string.Format
                ("//tr[td[div[text()[contains(.,'{0}.csv')]]]]//span[@class[contains(.,'edtCheckBoxUnchecked')]]", assumptionVersionID))).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on the Download button.
            driver.FindElement(By.XPath("(//img[@alt='Download'])[1]")).Click();

            //Wait for file to finish dowloading
            bool VersionFileExist() { return Directory.GetFiles(path).Where(s => s.Contains(string.Format("{0}.csv", assumptionVersionID))).Count() > 0; }
            WaitUntilTrueOrTimeout(VersionFileExist, TimeSpan.FromMinutes(1));
            string DatastoreFile = string.Format("{0}.csv", assumptionVersionID);
            FileInfo DataStoreAssumptionFile = new FileInfo(Path.Combine(path, DatastoreFile));

            //Compare
            Assert.IsTrue(FileMD5AreSame(sourceAssumptionFile, DataStoreAssumptionFile));

            //Delete downloaded files
            sourceAssumptionFile.Delete();
            DataStoreAssumptionFile.Delete();
        }

        public void AttachAssumptionSetToMGHedgePXR8()
        {
            //Attach assumption set to a MGhedgeRun PXR8
            //Expand MGHedge run
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath
                (string.Format("//*[text()='{0}']/preceding-sibling::td/img", runGroup))));
            driver.FindElement(By.XPath
                (string.Format("//*[text()='{0}']/preceding-sibling::td/img", runGroup))).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[text()='Loading…']")));

            //Click edit on MGHedge Run -PV-PXR8
            Task.Delay(waitDelayBrowse).Wait();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='MGHedge Run - PV-PXR8']/following-sibling::td[4]/a")));
            driver.FindElement(By.XPath("//td[text()='MGHedge Run - PV-PXR8']/following-sibling::td[4]/a")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Click 'New' Dataset link
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(@id, 'DataSetCtrl_DataSetGridView_DXMainTable')]/tbody/tr[1]/td[7]")));
            driver.FindElement(By.XPath("//*[contains(@id, 'DataSetCtrl_DataSetGridView_DXMainTable')]/tbody/tr[1]/td[7]")).Click();

            //Select AssumptionData for version type
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[contains(text(),'Version Type:')]")));
            driver.FindElement(By.XPath("//input[contains(@id,'PrimaryVersionType_I')]")).SendKeys("AssumptionData");
            HitEnterKey();
            Task.Delay(waitDelayMega).Wait();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[text()='Loading…']")));

            //Select Name
            driver.FindElement(By.XPath("//input[contains(@id,'PrimaryVersionName_I')]")).SendKeys(etlGroupVersionNameAssumption);
            Task.Delay(waitDelayBrowse).Wait();
            HitEnterKey();
            Task.Delay(waitDelayMega).Wait();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[text()='Loading…']")));

            //Add date
            driver.FindElement(By.XPath("//input[contains(@id,'PrimaryVersionDate_I')]")).SendKeys("2019-01-07");

            //Select Revision 1
            driver.FindElement(By.XPath("//input[contains(@id,'PrimaryVersionRevision_I')]")).SendKeys(OpenQA.Selenium.Keys.Control + 'a');
            driver.FindElement(By.XPath("//input[contains(@id,'PrimaryVersionRevision_I')]")).SendKeys("1 - Generated by ETL");
            HitEnterKey();
            Task.Delay(waitDelayLong).Wait();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[text()='Loading…']")));

            //Verify Revision 1, 2 and 3 exist
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[text()='1 - Generated by ETL']")));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[text()='2 - Generated by ETL']")));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[text()='3 - Uploaded via UI']")));

            //Click update
            driver.FindElement(By.XPath("//*[text()='Update']")).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[text()='Loading…']")));
            Task.Delay(waitDelayMega).Wait();
            driver.FindElement(By.XPath("//*[text()='Update']")).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[text()='Loading…']")));
            Task.Delay(waitDelayLong).Wait();
        }
        public static bool WaitUntilTrueOrTimeout(Func<bool> task, TimeSpan timeout, TimeSpan pollrate)
        {
            bool success = false;
            int elapsed = 0;
            while ((!success) && (elapsed < timeout.TotalMilliseconds))
            {
                Thread.Sleep(pollrate);
                elapsed += Convert.ToInt32(pollrate.TotalMilliseconds);
                success = task();
            }
            if (!success)
            {
                throw new Exception("After " + timeout.TotalSeconds + " seconds, " + task.Method.Name + " did not return true.");
            }
            return success;
        }
        public static bool WaitUntilTrueOrTimeout(Func<bool> task, TimeSpan timeout)
        {
            return WaitUntilTrueOrTimeout(task, timeout, TimeSpan.FromSeconds(5));
        }
        public bool FileMD5AreSame(FileInfo file1, FileInfo file2)
        {
            Byte[] pathMD5;
            Byte[] path2MD5;
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(file1.FullName))
                {
                    pathMD5 = md5.ComputeHash(stream);
                }
                using (var stream = File.OpenRead(file2.FullName))
                {
                    path2MD5 = md5.ComputeHash(stream);
                }
                var path1 = string.Concat(pathMD5);
                var path2 = string.Concat(path2MD5);
                if (path1 == path2)
                {
                    Console.WriteLine("{0}'s MD5 checksum is equal to {1}'s", file1.Name, file2.Name);
                    return true;
                }
            }
            Console.WriteLine("{0}'s MD5 checksum is NOT equal to {1}'s", file1.Name, file2.Name);
            return false;
        }
        public FileInfo DownloadAssumptionFile(int versionRevision)
        {
            //Downloads assumption file from the manage assumption data page
            var path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            path = Path.Combine(path, "Downloads");
            FileInfo assumptionFile;
            bool FileExists() { assumptionFile.Refresh(); return assumptionFile.Exists; }


            //Deletes specified files in dir before downloading 
            var fileEntries = Directory.GetFiles(path).Where(s => s.Contains("Assumption_Stub_") || s.Contains("Version_"));
            foreach (string fileName in fileEntries)
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }

            //Click download and get the file 
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[text()='{0}']/following-sibling::td[8]/a", versionRevision))));
            driver.FindElement(By.XPath(string.Format("//td[text()='{0}']/following-sibling::td[8]/a", versionRevision))).Click();

            //Convert to FileInfo  object 
            if (versionRevision != 3)
            {

                bool VersionFileExist() { return Directory.GetFiles(path).Where(s => s.Contains("Version_")).Count() > 0; }
                WaitUntilTrueOrTimeout(VersionFileExist, TimeSpan.FromMinutes(1));
                assumptionFileName = Directory.GetFiles(path).Where(s => s.Contains("Version_")).First();
                try
                {
                    Regex regexObj = new Regex(@"[^\d]");
                    assumptionVersionID = regexObj.Replace(assumptionFileName, "");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Syntax error in the regular expression: " + ex);
                }
                path = Path.Combine(path, assumptionFileName);
                assumptionFile = new FileInfo(path);
            }
            else
            {
                path = Path.Combine(path, etlAssumptionV3File);
                assumptionFile = new FileInfo(path);
                WaitUntilTrueOrTimeout(FileExists, TimeSpan.FromMinutes(1));
            }
            return assumptionFile;
        }

        public void DownloadAssumptionFileAndCompare()
        {
            //This methods downloads assumptions files and compares them to the source file 
            //Expand the Assumption Set
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format
                ("//td[text()='{0}']/preceding-sibling::td", etlGroupVersionNameAssumption))));
            driver.FindElement(By.XPath(string.Format
                ("//td[text()='{0}']/preceding-sibling::td", etlGroupVersionNameAssumption))).Click();

            //Download the first assumption
            var firstAssumptionFile = DownloadAssumptionFile(1);

            //Convert source file to FileInfo
            var etlAssumptionSourceFile = Path.Combine
                (mainAutomationDirectory, etlDirectorySource, etlAssumptionV1File);
            FileInfo sourceAssumptionFile = new FileInfo(etlAssumptionSourceFile);

            //Compare
            Assert.IsTrue(FileMD5AreSame(firstAssumptionFile, sourceAssumptionFile));

            //Delete downloaded file
            firstAssumptionFile.Delete();

            //Download the second assumption
            var secondAssumptionFile = DownloadAssumptionFile(2);

            //Convert source file to FileInfo
            etlAssumptionSourceFile = Path.Combine
                (mainAutomationDirectory, etlDirectorySource, etlAssumptionV2File);
            sourceAssumptionFile = new FileInfo(etlAssumptionSourceFile);

            //Compare
            Assert.IsTrue(FileMD5AreSame(secondAssumptionFile, sourceAssumptionFile));

            //Delete downloaded file
            secondAssumptionFile.Delete();

            //Download the third assumption
            var thirdAssumptionFile = DownloadAssumptionFile(3);

            //Convert source file to FileInfo
            etlAssumptionSourceFile = Path.Combine
                (mainAutomationDirectory, etlDirectorySource, etlAssumptionV3File);
            sourceAssumptionFile = new FileInfo(etlAssumptionSourceFile);

            //Compare
            Assert.IsTrue(FileMD5AreSame(thirdAssumptionFile, sourceAssumptionFile));

            //Delete downloaded file
            thirdAssumptionFile.Delete();
        }
        public void ValidateDataSetExist()
        {
            if (!driver.VerifyAsserts(By.XPath(string.Format
                ("//td[text()='{0}']/preceding-sibling::td[text()='{1}']/preceding-sibling::td", versionDate, etlGroupVersionName))))
            {
                //Drop Assumption ETL file 
                DropETLAssumptionV2File();
                ApproveETLFiles();
                NavigateToManageAssumptionDataPage();
            }
            else
            {
                //Expand the Assumption Set
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format
                    ("//td[text()='{0}']/preceding-sibling::td[text()='{1}']/preceding-sibling::td", versionDate, etlGroupVersionName))));
                driver.FindElement(By.XPath(string.Format
                    ("//td[text()='{0}']/preceding-sibling::td[text()='{1}']/preceding-sibling::td", versionDate, etlGroupVersionName))).Click();
            }
            if (GetNumberOfAssumptionRevisions() != 2)
            {
                //Drop Assumption ETL file 
                DropETLAssumptionV2File();
                ApproveETLFiles();
                NavigateToManageAssumptionDataPage();
            }
        }
        public void ImportAssumptionV3FileViaUI()
        {
            versionDate = versionSlashDate_1_7_2019;
            etlGroupVersionName = etlGroupVersionNameAssumption;
            //Verify there is an existing Data set
            ValidateDataSetExist();

            ImportDataSetViaUI(etlAssumptionV3File);
        }
        public void ImportDataSetViaUI(string assumptionFile)
        {
            //Click the import button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format
                ("//td[text()='{0}']/following-sibling::td[text()='{1}']/following-sibling::td/a", etlGroupVersionNameAssumption, versionDate))));
            driver.FindElement(By.XPath(string.Format
                ("//td[text()='{0}']/following-sibling::td[text()='{1}']/following-sibling::td/a", etlGroupVersionNameAssumption, versionDate))).Click();

            //Wait until pop form appears and then continue to submit new Assumption record
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@id, 'CommentTextBox_I')]")));
            driver.FindElement(By.XPath("//input[contains(@id, 'CommentTextBox_I')]")).SendKeys("Uploaded via UI");

            etlSourceFile = Path.Combine(customUserDirectory, @"PLEASE_DO_NOT_DELETE_CONTENTS\HedgeOps\AutomationTestFiles\", etlDirectorySource, assumptionFile);
            nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, assumptionFile);
            nysaData = Path.Combine(nysaTargetPath, nysaFolderData);

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'AssumptionFileUploadControl_Browse0')]]/a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(etlSourceFile);
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Click on OK button.
            wait.Until(ExpectedConditions.ElementToBeClickable
                (By.XPath("//*[@id='ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_Content_CreateNewPopup_ctl17_CD']")));
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_Content_CreateNewPopup_ctl17_CD']")).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated
                (By.XPath("//*[@id='ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_Content_CreateNewPopup_ctl17_CD']")));
            Task.Delay(waitDelayMega).Wait();
        }
        public int GetNumberOfAssumptionRevisions()
        {
            //Get number of revisions
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Download']")));
            var count = driver.FindElements(By.XPath("//a[text()='Download']")).Count;
            return count;
        }

        public void AddAssumptionData()
        {
            var dataPresent = driver.FindElements(By.XPath(string.Format("//td[text()='{0}']", assumptionDataName1)));

            if (dataPresent.Any())
            {
                //Expand row.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", assumptionDataName1))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for row to expand.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Revision']")));

                //Void assumption data file.
                VoidAssumptionData();
            }

            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Assumption Data']")));

            if (testVariation == 0)
            {
                assumptionData = assumptionDataName1;
                comment = genericTestComment;
                assumptionFile = assumptionDataFile;
            }

            if (testVariation == 1)
            {
                assumptionData = assumptionDataName2;
                comment = assumptionComment2;
                assumptionFile = assumptionDataFilePichu1;
            }

            if (testVariation == 2)
            {
                assumptionData = assumptionDataName3;
                comment = assumptionComment2;
                assumptionFile = assumptionDataFilePichu2;
            }

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).SendKeys(assumptionData);
            Task.Delay(waitDelay5).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).SendKeys(comment);
            Task.Delay(waitDelay5).Wait();

            //Enter a Date.
            driver.FindElement(By.XPath("//td[@id[contains(.,'CreateNewPopup_FormLayout_DateBox_B-1')]]")).Click();
            Task.Delay(waitDelayLongPlus).Wait();
            driver.FindElement(By.XPath("(//button[text()='Today'])[3]")).Click();
            Task.Delay(waitDelayLong).Wait();


            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'AssumptionFileUploadControl_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(customUserDirectory, @"PLEASE_DO_NOT_DELETE_CONTENTS\HedgeOps\AutomationTestFiles\", assumptionDirectory, assumptionFile));
            Task.Delay(waitDelaySuper).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", assumptionFile))));

            //Click on OK.
            driver.FindElement(By.XPath("//div[@id[contains(.,'CreateNewPopup')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for assumption data modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Assumption Data']")));
            Task.Delay(waitDelayMega).Wait();
        }
        public void ImportInvalidAssFile()
        {
            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Assumption Data']")));

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).SendKeys(assumptionDataName1);
            Task.Delay(waitDelay5).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Enter a Date.
            driver.FindElement(By.XPath("//td[@id[contains(.,'CreateNewPopup_FormLayout_DateBox_B-1')]]")).Click();
            Task.Delay(waitDelayLongPlus).Wait();
            driver.FindElement(By.XPath("(//button[text()='Today'])[3]")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'AssumptionFileUploadControl_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, reportOverrideFile4));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();
            Task.Delay(waitDelayMega).Wait();

            //Handle popup alert.
            driver.SwitchTo().Alert().Accept();

            //Verify no file appears in file field.
            Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//td[@title='{0}']", reportOverrideFile4))));
        }
        public void ImportLargeAssFile()
        {
            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < waitDelayMega && timer.IsRunning.Equals(true))
            {
                var dataPresent = driver.FindElements(By.XPath("//tr[td[text()='Large 100+ MB']]//img"));

                if (dataPresent.Any())
                {
                    //Void data.
                    driver.FindElement(By.XPath("//tr[td[text()='Large 100+ MB']]//img")).Click();
                    Task.Delay(waitDelayLongPlus).Wait();
                    driver.FindElement(By.XPath("//span[text()='Void']")).Click();
                    Task.Delay(waitDelayLongPlus).Wait();

                    //Waits for modal to appear.
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Void Assumption Set...']")));

                    //Click OK button.
                    driver.FindElement(By.XPath("//div[@id[contains(.,'VoidOkButton')]]/span[text()='OK']")).Click();
                    Task.Delay(waitDelaySuper).Wait();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Assumption Data']")));

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).SendKeys(assumptionLargeDataName);
            Task.Delay(waitDelay5).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).SendKeys(assumptionComment1);
            Task.Delay(waitDelay5).Wait();

            //Enter a Date.
            driver.FindElement(By.XPath("//td[@id[contains(.,'CreateNewPopup_FormLayout_DateBox_B-1')]]")).Click();
            Task.Delay(waitDelayLongPlus).Wait();
            driver.FindElement(By.XPath("(//button[text()='Today'])[3]")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'AssumptionFileUploadControl_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, assumptionDirectory, assumptionLargeDataFile));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();
            Task.Delay(waitDelaySuper).Wait();

            //Verify file appears in file field.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[@title='{0}']", assumptionLargeDataFile))));

            //Click on OK.
            driver.FindElement(By.XPath("//div[@id[contains(.,'CreateNewPopup')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();
        }
        public void SeedAssTestFiles()
        {
            var testData = driver.FindElements(By.XPath(string.Format("//td[text()='{0}']", assumptionDataName2)));

            //Seed test group and two rows of assumption data if test group doesnt exist.
            if (testData.Any())
            {
                //Expand row.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", assumptionDataName2))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for row to expand.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Revision']")));

                //Void assumtion data records.
                VoidAssumptionData();
            }

            //Toggle a variation of method test steps.
            testVariation = 1;

            //Create new assumption data file.
            AddAssumptionData();

            var expand = driver.FindElements(By.XPath(string.Format("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", assumptionDataName2)));

            if (expand.Any())
            {
                //Expand row.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", assumptionDataName2))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for row to expand.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Revision']")));
            }

            //Validate correct import details.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", assumptionDataName2))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[@id[contains(.,'DXDataRow0')]]/td[text()='{0}']", assumptionComment2))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[@id[contains(.,'DXDataRow0')]]/td[contains(.,'{0}/{1}/{2}')]", todayMonthNum, todayFullDay, todayYear))));

            //Toggle a variation of method test steps.
            testVariation = 2;

            //Create new assumption data file.
            AddAssumptionData();

            //Validate correct import details.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", assumptionDataName2))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[@id[contains(.,'DXDataRow0')]]/td[text()='{0}']", assumptionComment2))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[@id[contains(.,'DXDataRow0')]]/td[contains(.,'{0}/{1}/{2}')]", todayMonthNum, todayFullDay, todayYear))));

            String textValue2 = driver.FindElement(By.XPath("//tr[@id[contains(.,'VersionDetailGridView_DXDataRow0')]]//td[@class='dxgv dx-ar'][1]")).Text;
            revisionId2 = textValue2;

            String textValue3 = driver.FindElement(By.XPath("//tr[@id[contains(.,'VersionDetailGridView_DXDataRow1')]]//td[@class='dxgv dx-ar'][1]")).Text;
            revisionId3 = textValue3;
        }
        public void VoidAssumptionData()
        {
            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerMinutePlus && timer.IsRunning.Equals(true))
            {
                var nonVoided = driver.FindElements(By.XPath("//span[text()='Void']"));

                if (nonVoided.Any())
                {
                    //Click on Void.
                    driver.FindElement(By.XPath("//span[text()='Void']")).Click();
                    Task.Delay(waitDelayLongPlus).Wait();

                    //Waits for void modal to appear.
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Void Assumption Set...']")));

                    //Enter a comment.
                    driver.FindElement(By.XPath("//textarea[@id[contains(.,'VoidCommentMemo_I')]]")).Click();
                    Task.Delay(waitDelay5).Wait();
                    driver.FindElement(By.XPath("//textarea[@id[contains(.,'VoidCommentMemo_I')]]")).SendKeys(genericTestComment);
                    Task.Delay(waitDelay5).Wait();

                    //Click on OK.
                    driver.FindElement(By.XPath("//div[@id[contains(.,'VoidPopup_VoidOkButton')]]//span[text()='OK']")).Click();
                    Task.Delay(waitDelayLong).Wait();

                    //Waits for New link to load.
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='New']")));
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }
        }
        public void VoidAssumptionData(int RevisionId)
        {
            //Click on void
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[text()='{0}']/following-sibling::td[7]/a", RevisionId))));
            driver.FindElement(By.XPath(string.Format("//td[text()='{0}']/following-sibling::td[7]/a", RevisionId))).Click();

            //Waits for void modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Void Assumption Set...']")));

            //Enter a comment.
            driver.FindElement(By.XPath("//textarea[@id[contains(.,'VoidCommentMemo_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//textarea[@id[contains(.,'VoidCommentMemo_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on OK.
            driver.FindElement(By.XPath("//div[@id[contains(.,'VoidPopup_VoidOkButton')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for New link to load or void comment to appear 
            wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format("//span[text()='New' or text()='{0}']", genericTestComment))));
        }
        #endregion

        #region Date Token Tests
        public string inforceDTName1 = "TestInforce";
        public string inforceDTName2 = "A";
        public string fundMapDTName1 = "StubFundMap";

        public string fundMapDate, fundMapFileDate, fundMapSheetDate;
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void DateTokenFundMapAssertHedge()
        {
            //Confirm or create a testing folder.
            string pathString = Path.Combine(nysaTargetPath, "AutomationTest");

            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }

            //Verify all necessary test inforces are present.            
            try//>--- StubFundMap  1/7/2019
            {
                fundMapDate = "1/7/2019"; //format = m/d/yyyy
                fundMapFileDate = "01-07-2019"; //format = mm-dd-yyyy
                fundMapSheetDate = "01_07_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", fundMapDTName1, fundMapDate))));
            }

            catch (Exception)
            {
                CreateFundMapFile();
            }

            //Verify all necessary test inforces are present.            
            try//>--- StubFundMap  1/10/2019
            {
                fundMapDate = "1/10/2019"; //format = m/d/yyyy
                fundMapFileDate = "01-10-2019"; //format = mm-dd-yyyy
                fundMapSheetDate = "01_10_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", fundMapDTName1, fundMapDate))));
            }

            catch (Exception)
            {
                CreateFundMapFile();
            }

            try//>--- StubFundMap  11/21/2017
            {
                fundMapDate = "11/21/2017"; //format = m/d/yyyy
                fundMapFileDate = "11-21-2017"; //format = mm-dd-yyyy
                fundMapSheetDate = "11_21_2017"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", fundMapDTName1, fundMapDate))));
            }

            catch (Exception)
            {
                CreateFundMapFile();
            }

            try//>--- StubFundMap  12/23/2016
            {
                fundMapDate = "12/23/2016"; //format = m/d/yyyy
                fundMapFileDate = "12-23-2016"; //format = mm-dd-yyyy
                fundMapSheetDate = "12_23_2016"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", fundMapDTName1, fundMapDate))));
            }

            catch (Exception)
            {
                CreateFundMapFile();
            }

            try//>--- StubFundMap  12/14/2016
            {
                fundMapDate = "12/14/2016"; //format = m/d/yyyy
                fundMapFileDate = "12-14-2016"; //format = mm-dd-yyyy
                fundMapSheetDate = "12_14_2016"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", fundMapDTName1, fundMapDate))));
            }

            catch (Exception)
            {
                CreateFundMapFile();
            }

            try//>--- StubFundMap  11/29/2016
            {
                fundMapDate = "11/29/2016"; //format = m/d/yyyy
                fundMapFileDate = "11-29-2016"; //format = mm-dd-yyyy
                fundMapSheetDate = "11_29_2016"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", fundMapDTName1, fundMapDate))));
            }

            catch (Exception)
            {
                CreateFundMapFile();
            }

            try//>--- StubFundMap  10/31/2016
            {
                fundMapDate = "10/31/2016"; //format = m/d/yyyy
                fundMapFileDate = "10-31-2016"; //format = mm-dd-yyyy
                fundMapSheetDate = "10_31_2016"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", fundMapDTName1, fundMapDate))));
            }

            catch (Exception)
            {
                CreateFundMapFile();
            }

            try//>--- StubFundMap  9/30/2016
            {
                fundMapDate = "9/30/2016"; //format = m/d/yyyy
                fundMapFileDate = "09-30-2016"; //format = mm-dd-yyyy
                fundMapSheetDate = "09_30_2016"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", fundMapDTName1, fundMapDate))));
            }

            catch (Exception)
            {
                CreateFundMapFile();
            }

            try//>--- StubFundMap  12/31/2015
            {
                fundMapDate = "12/31/2015"; //format = m/d/yyyy
                fundMapFileDate = "12-31-2015"; //format = mm-dd-yyyy
                fundMapSheetDate = "12_31_2015"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", fundMapDTName1, fundMapDate))));
            }

            catch (Exception)
            {
                CreateFundMapFile();
            }

            //Delete all .xlsx files.
            foreach (FileInfo file in new DirectoryInfo(pathString).GetFiles("*.xlsx"))
            {
                file.Delete();
            }

            //Override and force use of Secondary program.
            targetProgram = 1;

            //Move all .csv files to Data folder for ETL.
            foreach (FileInfo file in new DirectoryInfo(pathString).GetFiles("*.csv"))
            {
                fileName = file.ToString();
                string pathSource = Path.Combine(etlDirectoryCustomTemp, fileName);
                string pathDest = Path.Combine(etlDirectoryCustomFinal, fileName);

                File.Move(pathSource, pathDest);
            }

            //Restart stopwatch.
            timer.Restart();

            //Attempt to check for uploaded inforce total count until timer expires.
            while ((timer.Elapsed.TotalSeconds < timer3MinutePlus) && (timer.IsRunning.Equals(true)))
            {
                //Refresh page until inforce is uploaded.
                var allFundMaps = driver.FindElements(By.XPath(string.Format("(//tr[@id[contains(.,'FundMapGridView_DXDataRow')]]/td[text()='{0}'])[9]", fundMapDTName1)));

                if (!allFundMaps.Any())
                {
                    //Refresh browser.
                    RefreshBrowser();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            var page2 = driver.FindElements(By.XPath("//img[@class='dxWeb_pPrev_SoftOrange']"));

            if (page2.Any())
            {
                //Navigate to first page.
                driver.FindElement(By.XPath("//img[@alt='Prev']")).Click();
                Task.Delay(waitDelay6).Wait();
            }

            //Verify all necessary test inforces are present. (9 total)
            try
            {
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='1/7/2019']", fundMapDTName1))));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='1/10/2019']", fundMapDTName1))));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='11/21/2017']", fundMapDTName1))));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='12/23/2016']", fundMapDTName1))));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='12/14/2016']", fundMapDTName1))));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='11/29/2016']", fundMapDTName1))));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='10/31/2016']", fundMapDTName1))));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='9/30/2016']", fundMapDTName1))));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='12/31/2015']", fundMapDTName1))));
            }

            catch (Exception)
            {
                Assert.Fail("Unexpected Result: One or more testing required fund map dates are missing or an unnecessary one is present. Please re-ETL missing fund maps and/or void unnecessary ones.");
            }
        }
        public void DateTokenInforceAssertHedge()
        {
            //Confirm or create a testing folder.
            string pathString = Path.Combine(nysaTargetPath, "AutomationTest");

            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }

            //Verify all necessary test inforces are present.            
            try//>--- A  12/30/2019
            {
                inforceDate = "12/30/2019"; //format = m/d/yyyy
                inforceFileDate = "12-30-2019"; //format = mm-dd-yyyy
                sheetDate = "12_30_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }

            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  12/28/2019
            {
                inforceDate = "12/28/2019"; //format = m/d/yyyy
                inforceFileDate = "12-28-2019"; //format = mm-dd-yyyy
                sheetDate = "12_28_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  12/27/2019
            {
                inforceDate = "12/27/2019"; //format = m/d/yyyy
                inforceFileDate = "12-27-2019"; //format = mm-dd-yyyy
                sheetDate = "12_27_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  12/26/2019
            {
                inforceDate = "12/26/2019"; //format = m/d/yyyy
                inforceFileDate = "12-26-2019"; //format = mm-dd-yyyy
                sheetDate = "12_26_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  11/30/2019
            {
                inforceDate = "11/30/2019"; //format = m/d/yyyy
                inforceFileDate = "11-30-2019"; //format = mm-dd-yyyy
                sheetDate = "11_30_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  10/31/2019
            {
                inforceDate = "10/31/2019"; //format = m/d/yyyy
                inforceFileDate = "10-31-2019"; //format = mm-dd-yyyy
                sheetDate = "10_31_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  9/30/2019
            {
                inforceDate = "9/30/2019"; //format = m/d/yyyy
                inforceFileDate = "09-30-2019"; //format = mm-dd-yyyy
                sheetDate = "09_30_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  4/23/2019
            {
                inforceDate = "4/23/2019"; //format = m/d/yyyy
                inforceFileDate = "04-23-2019"; //format = mm-dd-yyyy
                sheetDate = "04_23_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  4/19/2019
            {
                inforceDate = "4/19/2019"; //format = m/d/yyyy
                inforceFileDate = "04-19-2019"; //format = mm-dd-yyyy
                sheetDate = "04_19_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  3/29/2019
            {
                inforceDate = "3/29/2019"; //format = m/d/yyyy
                inforceFileDate = "03-29-2019"; //format = mm-dd-yyyy
                sheetDate = "03_29_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  2/28/2019
            {
                inforceDate = "2/28/2019"; //format = m/d/yyyy
                inforceFileDate = "02-28-2019"; //format = mm-dd-yyyy
                sheetDate = "02_28_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  2/27/2019
            {
                inforceDate = "2/27/2019"; //format = m/d/yyyy
                inforceFileDate = "02-27-2019"; //format = mm-dd-yyyy
                sheetDate = "02_27_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  2/22/2019
            {
                inforceDate = "2/22/2019"; //format = m/d/yyyy
                inforceFileDate = "02-22-2019"; //format = mm-dd-yyyy
                sheetDate = "02_22_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  2/18/2019
            {
                inforceDate = "2/18/2019"; //format = m/d/yyyy
                inforceFileDate = "02-18-2019"; //format = mm-dd-yyyy
                sheetDate = "02_18_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  2/15/2019
            {
                inforceDate = "2/15/2019"; //format = m/d/yyyy
                inforceFileDate = "02-15-2019"; //format = mm-dd-yyyy
                sheetDate = "02_15_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  2/8/2019
            {
                inforceDate = "2/8/2019"; //format = m/d/yyyy
                inforceFileDate = "02-08-2019"; //format = mm-dd-yyyy
                sheetDate = "02_08_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  10/31/2018
            {
                inforceDate = "10/31/2018"; //format = m/d/yyyy
                inforceFileDate = "10-31-2018"; //format = mm-dd-yyyy
                sheetDate = "10_31_2018"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  10/31/2018
            {
                inforceDate = "10/31/2018"; //format = m/d/yyyy
                inforceFileDate = "10-31-2018"; //format = mm-dd-yyyy
                sheetDate = "10_31_2018"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  9/20/2018
            {
                inforceDate = "9/20/2018"; //format = m/d/yyyy
                inforceFileDate = "09-20-2018"; //format = mm-dd-yyyy
                sheetDate = "09_20_2018"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  9/14/2018
            {
                inforceDate = "9/14/2018"; //format = m/d/yyyy
                inforceFileDate = "09-14-2018"; //format = mm-dd-yyyy
                sheetDate = "09_14_2018"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  9/14/2018
            {
                inforceDate = "9/14/2018"; //format = m/d/yyyy
                inforceFileDate = "09-14-2018"; //format = mm-dd-yyyy
                sheetDate = "09_14_2018"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  9/7/2018
            {
                inforceDate = "9/7/2018"; //format = m/d/yyyy
                inforceFileDate = "09-07-2018"; //format = mm-dd-yyyy
                sheetDate = "09_07_2018"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  8/31/2018
            {
                inforceDate = "8/31/2018"; //format = m/d/yyyy
                inforceFileDate = "08-31-2018"; //format = mm-dd-yyyy
                sheetDate = "08_31_2018"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  7/31/2018
            {
                inforceDate = "7/31/2018"; //format = m/d/yyyy
                inforceFileDate = "07-31-2018"; //format = mm-dd-yyyy
                sheetDate = "07_31_2018"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  6/29/2018
            {
                inforceDate = "6/29/2018"; //format = m/d/yyyy
                inforceFileDate = "06-29-2018"; //format = mm-dd-yyyy
                sheetDate = "06_29_2018"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  3/29/2018
            {
                inforceDate = "3/29/2018"; //format = m/d/yyyy
                inforceFileDate = "03-29-2018"; //format = mm-dd-yyyy
                sheetDate = "03_29_2018"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  12/31/2017
            {
                inforceDate = "12/31/2017"; //format = m/d/yyyy
                inforceFileDate = "12-31-2017"; //format = mm-dd-yyyy
                sheetDate = "12_31_2017"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  7/31/2017
            {
                inforceDate = "7/31/2017"; //format = m/d/yyyy
                inforceFileDate = "07-31-2017"; //format = mm-dd-yyyy
                sheetDate = "07_31_2017"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  12/31/2016
            {
                inforceDate = "12/31/2016"; //format = m/d/yyyy
                inforceFileDate = "12-31-2016"; //format = mm-dd-yyyy
                sheetDate = "12_31_2016"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  12/30/2016
            {
                inforceDate = "12/30/2016"; //format = m/d/yyyy
                inforceFileDate = "12-30-2016"; //format = mm-dd-yyyy
                sheetDate = "12_30_2016"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            var page = driver.FindElements(By.XPath("//img[@class='dxWeb_pNext_SoftOrange']"));

            if (page.Any())
            {
                //Navigate to second page.
                driver.FindElement(By.XPath("//img[@alt='Next']")).Click();
                Task.Delay(waitDelay6).Wait();
            }

            try//>--- A  11/30/2016
            {
                inforceDate = "11/30/2016"; //format = m/d/yyyy
                inforceFileDate = "11-30-2016"; //format = mm-dd-yyyy
                sheetDate = "11_30_2016"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  10/31/2016
            {
                inforceDate = "10/31/2016"; //format = m/d/yyyy
                inforceFileDate = "10-31-2016"; //format = mm-dd-yyyy
                sheetDate = "10_31_2016"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            //Delete all .xlsx files.
            foreach (FileInfo file in new DirectoryInfo(pathString).GetFiles("*.xlsx"))
            {
                file.Delete();
            }

            //Override and force use of Secondary program.
            targetProgram = 1;

            //Move all .csv files to Data folder for ETL.
            foreach (FileInfo file in new DirectoryInfo(pathString).GetFiles("*.csv"))
            {
                fileName = file.ToString();
                string pathSource = Path.Combine(etlDirectoryCustomTemp, fileName);
                string pathDest = Path.Combine(etlDirectoryCustomFinal, fileName);

                File.Move(pathSource, pathDest);
            }

            //Restart stopwatch.
            timer.Restart();

            //Attempt to check for uploaded inforce total count until timer expires.
            while ((timer.Elapsed.TotalSeconds < timer3MinutePlus) && (timer.IsRunning.Equals(true)))
            {
                //Refresh page until inforce is uploaded.
                var allInforces = driver.FindElements(By.XPath("//b[text()[contains(.,' (32 items)')]]"));

                if (!allInforces.Any())
                {
                    //Refresh browser.
                    RefreshBrowser();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            var page2 = driver.FindElements(By.XPath("//img[@class='dxWeb_pPrev_SoftOrange']"));

            if (page2.Any())
            {
                //Navigate to first page.
                driver.FindElement(By.XPath("//img[@alt='Prev']")).Click();
                Task.Delay(waitDelay6).Wait();
            }

            //Verify all necessary test inforces are present. (32 total)
            try
            {
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='12/30/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='12/28/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='12/27/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='12/26/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='11/30/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='10/31/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='9/30/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='4/23/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='4/19/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='3/29/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='2/28/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='2/27/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='2/22/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='2/18/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='2/15/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='2/8/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='10/31/2018']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='10/31/2018']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='9/20/2018']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='9/14/2018']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='9/14/2018']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='9/7/2018']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='8/31/2018']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='7/31/2018']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='6/29/2018']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='3/29/2018']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='12/31/2017']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='7/31/2017']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='12/31/2016']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='12/30/2016']")));

                //Navigate to second page.
                driver.FindElement(By.XPath("//img[@alt='Next']")).Click();
                Task.Delay(waitDelay6).Wait();

                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='11/30/2016']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='10/31/2016']")));
            }

            catch (Exception)
            {
                Assert.Fail("Unexpected Result: One or more testing required inforce dates are missing or an unnecessary one is present. Please re-ETL missing inforces and/or void unnecessary ones.");
            }
        }
        public void DateTokenInforceAssertNonHedge()
        {
            //Confirm or create a testing folder.
            string pathString = Path.Combine(nysaTargetPath, "AutomationTest");

            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }

            //Verify all necessary test inforces are present. 
            try//>--- TestInforce  4/1/2019
            {
                inforceDate = "4/1/2019"; //format = m/d/yyyy
                inforceFileDate = "04-01-2019"; //format = mm-dd-yyyy
                sheetDate = "04_01_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  3/29/2019
            {
                inforceDate = "3/29/2019"; //format = m/d/yyyy
                inforceFileDate = "03-29-2019"; //format = mm-dd-yyyy
                sheetDate = "03_29_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  3/22/2019
            {
                inforceDate = "3/22/2019"; //format = m/d/yyyy
                inforceFileDate = "03-22-2019"; //format = mm-dd-yyyy
                sheetDate = "03_22_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  3/15/2019
            {
                inforceDate = "3/15/2019"; //format = m/d/yyyy
                inforceFileDate = "03-15-2019"; //format = mm-dd-yyyy
                sheetDate = "03_15_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  3/8/2019
            {
                inforceDate = "3/8/2019"; //format = m/d/yyyy
                inforceFileDate = "03-08-2019"; //format = mm-dd-yyyy
                sheetDate = "03_08_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  2/28/2019
            {
                inforceDate = "2/28/2019"; //format = m/d/yyyy
                inforceFileDate = "02-28-2019"; //format = mm-dd-yyyy
                sheetDate = "02_28_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  1/31/2019
            {
                inforceDate = "1/31/2019"; //format = m/d/yyyy
                inforceFileDate = "01-31-2019"; //format = mm-dd-yyyy
                sheetDate = "01_31_2019"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  12/31/2018
            {
                inforceDate = "12/31/2018"; //format = m/d/yyyy
                inforceFileDate = "12-31-2018"; //format = mm-dd-yyyy
                sheetDate = "12_31_2018"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  12/29/2017
            {
                inforceDate = "12/29/2017"; //format = m/d/yyyy
                inforceFileDate = "12-29-2017"; //format = mm-dd-yyyy
                sheetDate = "12_29_2017"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- A  12/30/2016
            {
                inforceDate = "12/30/2016"; //format = m/d/yyyy
                inforceFileDate = "12-30-2016"; //format = mm-dd-yyyy
                sheetDate = "12_30_2016"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- A  11/30/2016
            {
                inforceDate = "11/30/2016"; //format = m/d/yyyy
                inforceFileDate = "11-30-2016"; //format = mm-dd-yyyy
                sheetDate = "11_30_2016"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='A']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName2;

                CreatePolicyFile();
            }

            try//>--- TestInforce  12/31/2015
            {
                inforceDate = "12/31/2015"; //format = m/d/yyyy
                inforceFileDate = "12-31-2015"; //format = mm-dd-yyyy
                sheetDate = "12_31_2015"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            try//>--- TestInforce  12/31/2014
            {
                inforceDate = "12/31/2014"; //format = m/d/yyyy
                inforceFileDate = "12-31-2014"; //format = mm-dd-yyyy
                sheetDate = "12_31_2014"; //format = mm_dd_yyyy

                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='TestInforce']]/td[text()='{0}']", inforceDate))));
            }
            catch (Exception)
            {
                inforceName = inforceDTName1;

                CreatePolicyFile();
            }

            //Delete all .xlsx files.
            foreach (FileInfo file in new DirectoryInfo(pathString).GetFiles("*.xlsx"))
            {
                file.Delete();
            }

            //Override and force use of Tertiary program.
            targetProgram = 2;

            //Move all .csv files to Data folder for ETL.
            foreach (FileInfo file in new DirectoryInfo(pathString).GetFiles("*.csv"))
            {
                fileName = file.ToString();
                string pathSource = Path.Combine(etlDirectoryCustomTemp, fileName);
                string pathDest = Path.Combine(etlDirectoryCustomFinal, fileName);

                File.Move(pathSource, pathDest);
            }

            //Restart stopwatch.
            timer.Restart();

            //Attempt to check for uploaded inforce total count until timer expires.
            while ((timer.Elapsed.TotalSeconds < timer3MinutePlus) && (timer.IsRunning.Equals(true)))
            {
                //Refresh page until inforce is uploaded.
                var allInforces = driver.FindElements(By.XPath("//tr[@id[contains(.,'DXDataRow12')]]"));

                if (!allInforces.Any())
                {
                    //Refresh browser.
                    RefreshBrowser();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Verify all necessary test inforces are present. (13 total)
            try
            {
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='4/1/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='3/29/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='3/22/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='3/15/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='3/8/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='2/28/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='1/31/2019']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='12/31/2018']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='12/29/2017']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='12/30/2016']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='A']]/td[text()='11/30/2016']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='12/31/2015']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='TestInforce']]/td[text()='12/31/2014']")));
            }

            catch (Exception)
            {
                Assert.Fail("Unexpected Result: One or more testing required inforce dates are missing or an unnecessary one is present. Please re-ETL missing inforces and/or void unnecessary ones.");
            }
        }
        #endregion

        #region Entity Structure Tests
        public string entityKey = "EntityTestKey";
        public string entityKey2 = "EntityTestKeyEdit";
        public string entityLevel = "EntityTestLevel";
        public string entityLevel2 = "EntityTestLevelEdit";

        public string entityName = "EntityTestName";
        public string entityName2 = "EntityTestNameEdit";
        public string entityName3 = "SampleEntityStructure";
        public string entityVersionName = "Test Entity Structure";
        public string entityFile = "TestEntityStructure.csv";
        public string entityDesc = "TestSample";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void CreateEntityStructure()
        {
            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Key:']")));

            //Enter a Key.
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR1_I')]]")).SendKeys(entityKey);
            Task.Delay(waitDelay5).Wait();

            //Enter a Level.
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR2_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR2_I')]]")).SendKeys(entityLevel);
            Task.Delay(waitDelay5).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR0_I')]]")).SendKeys(entityName);
            Task.Delay(waitDelay5).Wait();

            //Enter a Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR3_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR3_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            if (targetChameleon == 1)
            {
                //Check Is Legal Entity box.
                driver.FindElement(By.XPath("//span[@class=' dxICheckBox_SoftOrange dxichSys dx-not-acc dxWeb_edtCheckBoxUnchecked_SoftOrange']")).Click();
                Task.Delay(waitDelay5).Wait();
            }
            else
            {
                //Check Is Legal Entity box.
                driver.FindElement(By.XPath("//span[@class='dxWeb_edtCheckBoxUnchecked_SoftOrange dxICheckBox_SoftOrange dxichSys']")).Click();
                Task.Delay(waitDelay5).Wait();
            }

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for field to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//label[text()='Key:']")));
        }
        public void ImportEntityStructure()
        {
            //Click on Import.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Import Input File']")));

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Panel1_cmbInputEntityVersionName_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'Panel1_cmbInputEntityVersionName_I')]]")).SendKeys(entityVersionName);
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Panel1_ucEntityStruct_TextBox0_FakeInput')]]")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, entityDirectory, entityFile));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", entityFile))));

            //Enter a comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Panel1_txtInputComment_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'Panel1_txtInputComment_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on Save button.
            driver.FindElement(By.XPath("(//span[text()='Save'])[2]")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Import Input File']")));
        }
        public void EditEntityStructure()
        {
            var entityExists = driver.FindElements(By.XPath(string.Format("//td[text()[contains(.,'{0}')]]", entityName)));

            if (entityExists.Any())
            {
                //Click on Edit link.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()[contains(.,'{0}')]]]//span[text()='Edit']", entityName))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for field to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Key:']")));
            }

            //Enter a Key.
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR1_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR1_I')]]")).SendKeys(entityKey2);
            Task.Delay(waitDelay5).Wait();

            //Enter a Level.
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR2_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR2_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR2_I')]]")).SendKeys(entityLevel2);
            Task.Delay(waitDelay5).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR0_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR0_I')]]")).SendKeys(entityName2);
            Task.Delay(waitDelay5).Wait();

            //Enter a Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR3_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR3_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'EntityStructureTreeList_DXEDITOR3_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            if (targetChameleon == 1)
            {
                //Check Is Legal Entity box.
                driver.FindElement(By.XPath("//span[@class=' dxICheckBox_SoftOrange dxichSys dx-not-acc dxWeb_edtCheckBoxChecked_SoftOrange']")).Click();
                Task.Delay(waitDelay5).Wait();
            }
            else
            {
                //Check Is Legal Entity box.
                driver.FindElement(By.XPath("//span[@class='dxWeb_edtCheckBoxChecked_SoftOrange dxICheckBox_SoftOrange dxichSys']")).Click();
                Task.Delay(waitDelay5).Wait();
            }

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for field to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//label[text()='Key:']")));
        }
        public void DeleteEntityStructure()
        {
            var entity = driver.FindElements(By.XPath(string.Format("//tr[td[contains(.,'{0}')]]", entityName)));

            if (entity.Any())
            {
                //Click on Delete link.
                driver.FindElement(By.XPath(string.Format("//tr[td[contains(.,'{0}')]]//span[text()='Delete']", entityName))).Click();
                Task.Delay(waitDelayLong).Wait();
            }

            else
            {
                //Click on Delete link.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", entityName3))).Click();
                Task.Delay(waitDelayLong).Wait();
            }

            //Hit the Enter key.
            HitEnterKey();
            Task.Delay(waitDelayMega).Wait();
        }
        #endregion

        #region ETL Configuration Tests
        public string etlGroupVersionName;
        public string etlGroupName = ".AutomationTestETL";
        public string etlGroupNameAsset = "Asset";
        public string etlGroupVersionNameAsset = "Asset";
        public string etlGroupVersionNameAssumption = ".AutomationTestAssumptionData";
        public string etlMedium = "Directory";
        public string etlStoredProc = "pr_NysaAssetDataCommit";
        public string etlTableName = "tbl_NysaAssetDataImport";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void CreateAssumptionETLConfig()
        {
            //Verify ETL plugin exist
            NavigateToExternalModelsPage();

            IdentifyStubETLPlugin();

            etlGroupVersionName = etlGroupVersionNameAssumption;
            etlType = etlTypeAssumption;
            etlStoredProc = "";
            etlTableName = "";
            etlTypeMask = etlTypeAssumptionMask;

            NavigateToETLConfigurationPage();
            CreateETLConfig();
        }
        public void CreateETLConfig()
        {
            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerMinutePlus && timer.IsRunning.Equals(true))
            {
                var record = driver.FindElements(By.XPath(string.Format("//td[text()='{0}']", etlGroupVersionName)));

                if (record.Any())
                {
                    //Delete record.
                    driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", etlGroupVersionName))).Click();
                    Task.Delay(waitDelayMega).Wait();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Click on New.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelayLongPlus).Wait();

            #region Configure ETL Group
            //Enter an ETL group Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ASPxGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ASPxGridView_DXEFL_DXEditor0_I')]]")).SendKeys(etlGroupName);
            Task.Delay(waitDelay5).Wait();

            //Enter an ETL group Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ASPxGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ASPxGridView_DXEFL_DXEditor1_I')]]")).SendKeys(etlGroupVersionName);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//a[span[text()='Update']]")).Click();
            Task.Delay(waitDelayLongPlus).Wait();
            #endregion

            //Expand ETL Group.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format
                ("//tr[td[text()='{0}']]//td[img[@class[contains(.,'DetailCollapsedButton')]]]", etlGroupName))));
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//td[img[@class[contains(.,'DetailCollapsedButton')]]]", etlGroupName))).Click();
            Task.Delay(waitDelayLongPlus).Wait();

            //Waits for row expansion.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='ETL Type']")));

            #region Configure ETL Type
            //Click on New.
            driver.FindElement(By.XPath("(//span[text()='New'])[2]")).Click();
            Task.Delay(waitDelayLongPlus).Wait();

            //Enter an ETL Type.

            driver.FindElement(By.XPath("//input[@id[contains(.,'gvConfigs_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'gvConfigs_DXEFL_DXEditor0_I')]]")).SendKeys(etlType);
            Task.Delay(waitDelay5).Wait();

            //Enter an ETL Location.
            driver.FindElement(By.XPath("//input[@id[contains(.,'gvConfigs_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'gvConfigs_DXEFL_DXEditor1_I')]]")).SendKeys(etlDirectoryCustomTemp);
            Task.Delay(waitDelay5).Wait();

            //Enter an ETL Medium.
            driver.FindElement(By.XPath("//input[@id[contains(.,'gvConfigs_DXEFL_DXEditor2_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'gvConfigs_DXEFL_DXEditor2_I')]]")).SendKeys(etlMedium);
            Task.Delay(waitDelay5).Wait();

            //Enter an ETL Table Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'gvConfigs_DXEFL_DXEditor3_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'gvConfigs_DXEFL_DXEditor3_I')]]")).SendKeys(etlTableName);
            Task.Delay(waitDelay5).Wait();

            //Enter an ETL Stored Procedure.
            driver.FindElement(By.XPath("//input[@id[contains(.,'gvConfigs_DXEFL_DXEditor4_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'gvConfigs_DXEFL_DXEditor4_I')]]")).SendKeys(etlStoredProc);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//a/span[text()='Update']")).Click();
            Task.Delay(waitDelayLongPlus).Wait();
            #endregion

            //Expand ETL Config.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//td[img[@class[contains(.,'DetailCollapsedButton')]]]", etlType))).Click();
            Task.Delay(waitDelayLongPlus).Wait();

            //Waits for row expansion.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Filemask']")));

            #region Configure ETL File Mask
            //Click on New.
            driver.FindElement(By.XPath("(//span[text()='New'])[3]")).Click();
            Task.Delay(waitDelayLongPlus).Wait();

            //Enter an ETL Filemask.
            driver.FindElement(By.XPath("//input[@id[contains(.,'gvFiles_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'gvFiles_DXEFL_DXEditor0_I')]]")).SendKeys(etlTypeMask);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//a/span[text()='Update']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Validate ETL configurations.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", etlGroupName))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", etlGroupVersionName))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", etlType))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", etlDirectoryCustomTemp))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", etlMedium))));
            #endregion
        }
        public void DeleteETLConfigTiers()
        {
            //Delete Filemask.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", etlTypeAssetMask))).Click();
            Task.Delay(waitDelayMega).Wait();

            //Validate Filemask deletion.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//div[text()[contains(.,'No data to display')]]")));

            //Delete ETL Configuration.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", etlTypeAsset))).Click();
            Task.Delay(waitDelayMega).Wait();

            //Validate ETL Configuration deletion.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//div[text()[contains(.,'No data to display')]]")));

            //Delete ETL Group.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", etlGroupName))).Click();
            Task.Delay(waitDelayMega).Wait();

            //Validate ETL Group deletion.
            Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", etlGroupName))));
        }
        #endregion

        #region ETL Validation Tests
        public string etlType;
        public string etlTypeAsset = "assets";
        public string etlTypeDeposit = "deposit";
        public string etlTypeFundInfo = "fundinfo";
        public string etlTypePolicy = "policy";
        public string etlTypeAssumption = "assumption";

        public string etlTypeMask;
        public string etlTypeAssetMask = "Asset_Stub*";
        public string etlTypeAssumptionMask = "Assumption_Stub*.csv";
        public string etlAssetFile = "Asset_Stub_12-30-1999.csv";
        public string etlDepositFile1 = "Deposit_Stub_01-08-2019.csv";
        public string etlAssumptionV1File = "Assumption_Stub_01-07-2019_V1.csv";
        public string etlAssumptionV1NewDateFile = "Assumption_Stub_01-08-2019_V1.csv";
        public string etlAssumptionNewDate2File = "Assumption_Stub_01-09-2019.csv";
        public string etlAssumptionNewDate3File = "Assumption_Stub_01-10-2019.csv";
        public string etlAssumptionV2File = "Assumption_Stub_01-07-2019_V2.csv";
        public string etlAssumptionV3File = "Assumption_Stub_01-07-2019_V3.csv";
        public string etlFundInfoFile1 = "FundInfo_Stub_01-08-2019.csv";
        public string etlPolicyFile1 = "Policy_Stub_01-08-2019.csv";
        public string etlPolicyFile3 = "Policy_Stub_01-09-2019.csv";
        public string etlPolicyFile4 = "Policy_Stub_01-10-2019.csv";
        public string etlPolicyFile5 = "Policy_Stub_01-11-2019.csv";

        public string etlPolicyHOPS796_File1 = "Policy_Stub_02-01-2019.csv", etlPolicyHOPS796_File2 = "Policy_Stub_02-02-2019.csv", etlPolicyHOPS796_File3 = "Policy_Stub_02-03-2019.csv",
            etlPolicyHOPS796_File4 = "Policy_Stub_02-04-2019.csv", etlPolicyHOPS796_File5 = "Policy_Stub_02-05-2019.csv", etlPolicyHOPS796_File6 = "Policy_Stub_02-06-2019.csv",
            etlPolicyHOPS796_File7 = "Policy_Stub_02-07-2019.csv", etlPolicyHOPS796_File8 = "Policy_Stub_02-81-2019.csv", etlPolicyHOPS796_File9 = "Policy_Stub_02-09-2019.csv";

        public string inforceStubDate = "1/8/2019"; //> m/d/yyyy format
        public string versionSlashDate_1_7_2019 = "1/7/2019";
        public string versionSlashDate_1_8_2019 = "1/8/2019";

        public string etlPolicyFileVar1 = "Policy_Stub_1Rows_01-08-2019.csv";
        public string etlPolicyFileVar2 = "Policy_Stub_2Rows_01-08-2019.csv";
        public string etlPolicyFileVar3 = "Policy_Stub_3Rows_01-08-2019.csv";
        public string etlPolicyFileVar4 = "Policy_Stub_4Rows_01-09-2019.csv";
        public string etlPolicyFileVar5 = "Policy_Stub_5Rows_01-09-2019.csv";
        public string etlPolicyFileVar6 = "Policy_Stub_6Rows_01-09-2019.csv";
        public string etlPolicyFileVar7 = "Policy_Stub_7Rows_01-09-2019.csv";
        public string etlPolicyFileVar8 = "Policy_Stub_8Rows_01-09-2019.csv";
        public string etlPolicyFileVar9 = "Policy_Stub_9Rows_01-09-2019.csv";

        public string etlDepositFile2 = "Deposit_Stub_12-31-2014.csv";
        public string etlFundInfoFile2 = "FundInfo_Stub_12-31-2014.csv";
        public string etlPolicyFile2 = "Policy_Stub_12-31-2014.csv";

        public string etlException = "Automation Test Exception";
        public string etlTestInforce = "TestInforce";
        public string etlDate, etlDestFile, etlDestFile2, etlDestFile3, etlDestFile4, etlFile, etlFile1, etlFile2, etlFile3, etlFile4, etlFile5, etlFile6, etlFile7, etlFile8, etlFile9, etlFinal,
            etlNysaDataDrop, etlSourceFile, etlSourceFile2, etlSourceFile3, etlSourceFile4, inforceArchive, nysaArchive, nysaArchive2, nysaArchive3, nysaArchive4, nysaData;
        public string inforceDestFileDeposit, inforceDestFileFundInfo, inforceDestFilePolicy, inforceSourceFileDeposit, inforceSourceFileFundInfo, inforceSourceFilePolicy;
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void ApproveETLFiles()
        {
            var assetExists = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='Approve']", etlTypeAsset)));

            if (assetExists.Any())
            {
                etlFile = etlAssetFile;

                //Click on Approve link.
                driver.FindElement(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='Approve']", etlTypeAsset))).Click();
                Task.Delay(waitDelay5).Wait();

                FinishETLApproval();
            }

            var depositExists = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='Approve']", etlTypeDeposit)));

            if (depositExists.Any())
            {
                etlFile = etlDepositFile1;

                //Click on Approve link.
                driver.FindElement(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='Approve']", etlTypeDeposit))).Click();
                Task.Delay(waitDelay5).Wait();

                FinishETLApproval();
            }

            var policyExists = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='Approve']", etlTypePolicy)));

            if (policyExists.Any())
            {
                etlFile = etlPolicyFile1;

                //Click on Approve link.
                driver.FindElement(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='Approve']", etlTypePolicy))).Click();
                Task.Delay(waitDelay5).Wait();

                FinishETLApproval();
            }

            var fundInfoExists = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='Approve']", etlTypeFundInfo)));

            if (fundInfoExists.Any())
            {
                etlFile = etlFundInfoFile1;

                //Click on Approve link.
                driver.FindElement(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='Approve']", etlTypeFundInfo))).Click();
                Task.Delay(waitDelay5).Wait();

                FinishETLApproval();
            }
            var AssumptionExists = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='Approve']", etlTypeAssumption)));

            if (AssumptionExists.Any())
            {
                //Click on Approve link.
                driver.FindElement(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='Approve']", etlTypeAssumption))).Click();
                Task.Delay(waitDelay5).Wait();

                FinishETLApproval();
            }
        }
        public void FinishETLApproval()
        {
            //Wait for approval Submit button to load.
            Task.Delay(waitDelayMega).Wait();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Submit']")));

            //Enter an Exception.
            driver.FindElement(By.XPath("//textarea[@id[contains(.,'approvalCallbackPanel_ctl28_ExceptionBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//textarea[@id[contains(.,'approvalCallbackPanel_ctl28_ExceptionBox_I')]]")).SendKeys(etlException);
            Task.Delay(waitDelay5).Wait();

            //Enter a comment.
            driver.FindElement(By.XPath("//textarea[@id[contains(.,'approvalCallbackPanel_ctl28_CommentBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//textarea[@id[contains(.,'approvalCallbackPanel_ctl28_CommentBox_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on Submit Button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'SubmitApprovalBtn_CD')]]/span[text()='Submit']")).Click();
            Task.Delay(waitDelayLong).Wait();
        }

        public void DropETLAsset()
        {
            if (targetTestingLocation == 0)
            {
                //Check for folder's existance.
                if (!Directory.Exists(Path.Combine(nysaTargetPath, nysaFolderData)))
                {
                    //Create new folder if none exist.
                    Directory.CreateDirectory(Path.Combine(nysaTargetPath, nysaFolderData));
                }
            }

            etlFile = etlAssetFile;

            //Set file and directory paths.
            etlSourceFile = Path.Combine(mainAutomationDirectory, etlDirectorySource, etlFile);

            if (targetTestingLocation == 0)
            {
                MoveETLFilesOnPrem();
            }

            if (targetTestingLocation == 1)
            {
                UploadETLFilesCloud();

                NavigateToETLValidationPage();
            }
        }
        public void DropETLDeposit()
        {
            if (testVariation == 0)
            {
                etlFile = etlDepositFile1;

                //Set file and directory paths.
                etlSourceFile = Path.Combine(mainAutomationDirectory, etlDirectorySource, etlFile);
            }

            if (testVariation == 1)
            {
                etlFile = etlDepositFile1;

                //Set file and directory paths.
                etlSourceFile = Path.Combine(mainAutomationDirectory, inforceDirectory, etlFile);
            }

            if (testVariation == 2)
            {
                etlFile = etlDepositFile2;

                //Set file and directory paths.
                etlSourceFile = Path.Combine(mainAutomationDirectory, etlDirectorySource, etlFile);
            }

            if (targetTestingLocation == 0)
            {
                MoveETLFilesOnPrem();
            }

            if (targetTestingLocation == 1)
            {
                UploadETLFilesCloud();
            }
        }
        public void DropETLFundInfo()
        {
            if (testVariation == 0)
            {
                etlFile = etlFundInfoFile1;

                //Set file and directory paths.
                etlSourceFile = Path.Combine(mainAutomationDirectory, etlDirectorySource, etlFile);
            }

            if (testVariation == 1)
            {
                etlFile = etlFundInfoFile1;

                //Set file and directory paths.
                etlSourceFile = Path.Combine(mainAutomationDirectory, inforceDirectory, etlFile);
            }

            if (testVariation == 2)
            {
                etlFile = etlFundInfoFile2;

                //Set file and directory paths.
                etlSourceFile = Path.Combine(mainAutomationDirectory, etlDirectorySource, etlFile);
            }

            if (targetTestingLocation == 0)
            {
                MoveETLFilesOnPrem();
            }

            if (targetTestingLocation == 1)
            {
                UploadETLFilesCloud();
            }
        }
        public void DropETLInforce()
        {
            if (targetTestingLocation == 0)
            {
                //Check for folder's existance.
                if (!Directory.Exists(Path.Combine(nysaTargetPath, nysaFolderData)))
                {
                    //Create new folder if none exist.
                    Directory.CreateDirectory(Path.Combine(nysaTargetPath, nysaFolderData));
                }
            }

            //ETL a Deposit file.
            //DropETLDeposit();

            //ETL a FundInfo file.
            //DropETLFundInfo();

            //ETL a Policy file.
            DropETLPolicy();
        }
        public void DropETLPolicy()
        {
            if (testVariation == 1)
            {
                etlFile = etlPolicyFile2;
            }

            else
            {
                etlFile = etlPolicyFile1;
            }

            //Set file and directory paths.
            etlSourceFile = Path.Combine(mainAutomationDirectory, etlDirectorySource, etlFile);


            if (targetTestingLocation == 0)
            {
                MoveETLFilesOnPrem();
            }

            if (targetTestingLocation == 1)
            {
                UploadETLFilesCloud();

                NavigateToETLValidationPage();
            }
        }

        public void RemoveAutomationETLAssumptionRecordsFromDatabase()
        {
            string vTypeID = "17";
            //Clean up assumption data etl records
            #region Delete ETL Records - Assumption Data
            if (targetTestingLocation == 1)
            {
                try
                {
                    string sql1Query = string.Format("DECLARE @verID TABLE(v INT); " + "DECLARE @ID TABLE(i INT); " +

                        "INSERT INTO @verID(v) " +
                        "SELECT version_id FROM tbl_Version " +
                        "WHERE version_name = '{0}' AND programversion_guid = '{1}' AND versiontype_id = {2} " +

                        "INSERT INTO @ID(i) " +
                        "SELECT id FROM tbl_ETLInstance " +
                        "WHERE version_id in (SELECT v FROM @verID) " +

                        "DELETE FROM tbl_ETLInstanceControl " +
                        "WHERE ETLInstanceId IN(SELECT i FROM @ID) " +

                        "DELETE FROM tbl_ETLFileInstance " +
                        "WHERE id IN(SELECT i FROM @ID) " +

                        "DELETE FROM tbl_ETLInstanceAudit " +
                        "WHERE ETLInstanceId IN(SELECT i FROM @ID) " +

                        "DELETE FROM tbl_ETLInstance " +
                        "WHERE version_id IN(SELECT v FROM @verID) " +

                        "DELETE FROM tbl_VersionFileStorage " +
                        "WHERE VersionId IN(SELECT v FROM @verID) " +

                        "DELETE FROM tbl_AssumptionFiles " +
                        "WHERE version_id IN(SELECT v FROM @verID) " +

                        "DELETE FROM tbl_VersionETL " +
                        "WHERE version_id IN(SELECT v FROM @verID) " +

                        "DELETE FROM tbl_RunListInstanceDataSet " +
                        "WHERE VersionId IN(SELECT v FROM @verID) " +

                        "DELETE FROM tbl_Version " +
                        "WHERE version_name = '{0}' AND programversion_guid = '{1}' AND versiontype_id = {2} ",
                        etlGroupVersionNameAssumption, targetProgramGuid, vTypeID);

                    SQLConnect();
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    SQLClose();
                }
                catch (Exception)
                {
                    Assert.Fail(string.Format("Unexpected Result: Failed to delete database records for {0}.", etlGroupVersionNameAssumption));
                }
            }
            else
            {
                try
                {
                    string sql1Query = string.Format("DECLARE @verID TABLE(v INT); " + "DECLARE @ID TABLE(i INT); " +

                        "INSERT INTO @verID(v) " +
                        "SELECT version_id FROM tbl_Version " +
                        "WHERE version_name = '{0}' AND programversion_guid = '{1}' AND versiontype_id = {2} " +



                        "INSERT INTO @ID(i) " +
                        "SELECT id FROM tbl_ETLInstance " +
                        "WHERE version_id in (SELECT v FROM @verID) " +



                        "DELETE FROM tbl_ETLInstanceControl " +
                        "WHERE ETLInstanceId IN(SELECT i FROM @ID) " +



                        "DELETE FROM tbl_ETLFileInstance " +
                        "WHERE ETLInstanceId IN(SELECT i FROM @ID) " +



                        "DELETE FROM tbl_ETLInstanceAudit " +
                        "WHERE ETLInstanceId IN(SELECT i FROM @ID) " +



                        "DELETE FROM tbl_ETLInstance " +
                        "WHERE version_id IN(SELECT v FROM @verID) " +



                        "DELETE FROM tbl_VersionFileStorage " +
                        "WHERE VersionId IN(SELECT v FROM @verID) " +



                        "DELETE FROM tbl_AssumptionFiles " +
                        "WHERE version_id IN(SELECT v FROM @verID) " +



                        "DELETE FROM tbl_VersionETL " +
                        "WHERE version_id IN(SELECT v FROM @verID) " +

                        "DELETE FROM tbl_RunListInstanceDataSet " +
                        "WHERE VersionId IN(SELECT v FROM @verID) " +

                        "DELETE FROM tbl_Version " +
                        "WHERE version_name = '{0}' AND programversion_guid = '{1}' AND versiontype_id = {2} ",
                        etlGroupVersionNameAssumption, targetProgramGuid, vTypeID);


                    SQLConnect();
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    SQLClose();
                }
                catch (Exception e)
                {
                    Assert.Fail(string.Format("Unexpected Result: Failed to delete database records for {0}.", etlGroupVersionNameAssumption + " - " + e));
                }
            }
            #endregion
        }
        public void VerifyOnlyAssumptionV1Exist()
        {
            //This verifies assumption file v1 has been proccessed
            NavigateToManageAssumptionDataPage();

            versionDate = versionSlashDate_1_7_2019;
            etlGroupVersionName = etlGroupVersionNameAssumption;

            if (!driver.VerifyAsserts(By.XPath(string.Format
                ("//td[text()='{0}']/preceding-sibling::td[text()='{1}']/preceding-sibling::td", versionDate, etlGroupVersionName))))
            {
                //Clean up any automated related assumption ETLs from the database
                RemoveAutomationETLAssumptionRecordsFromDatabase();

                //Drop Assumption ETL file 
                DropETLAssumptionV1File();
                ApproveETLFiles();
            }
            else if ((!ValidateRevisionRowCreatedByETLConfig(1)) || (GetNumberOfAssumptionRevisions() > 1))
            {
                //Clean up any automated related assumption ETLs from the database
                RemoveAutomationETLAssumptionRecordsFromDatabase();

                //Drop Assumption ETL file 
                DropETLAssumptionV1File();
                ApproveETLFiles();
            }
        }
        public void VerifyAssumptionETLConfigExist()
        {
            NavigateToETLConfigurationPage();

            if (!driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", etlGroupName))))
            {
                CreateAssumptionETLConfig();
            }
        }

        public void DropETLAssumptionNewDate3WithAutoApprove()
        {
            DropETLAssumptionFileWithAutoApprove(etlAssumptionNewDate3File);
        }
        public void DropETLAssumptionNewDate2()
        {
            DropETLAssumptionFile(etlAssumptionNewDate2File);
        }
        public void DropETLAssumptionV1NewDate()
        {
            //Ensures there is an ETL Config prior to run
            VerifyAssumptionETLConfigExist();

            DropETLAssumptionFile(etlAssumptionV1NewDateFile);
        }
        public void DropETLAssumptionV2File()
        {
            //Ensures there is an ETL Config prior to run
            VerifyAssumptionETLConfigExist();

            //Verify only Assumption V1 file was processed
            VerifyOnlyAssumptionV1Exist();

            //Drops assumption file version 2 for processing
            DropETLAssumptionFile(etlAssumptionV2File);
        }
        public void DropETLAssumptionV1File()
        {
            //Ensures there is an ETL Config prior to run
            VerifyAssumptionETLConfigExist();

            //Drops assumption file version 1 for processing
            DropETLAssumptionFile(etlAssumptionV1File);
        }
        public void DropETLAssumptionFileWithAutoApprove(string etlAssumptionFile)
        {
            etlFile = etlAssumptionFile;
            etlType = etlTypeAssumption;

            if (targetTestingLocation == 1)
            {
                var currentPage = driver.FindElements(By.XPath("//span[text()='TestingFolder']"));

                if (!currentPage.Any())
                {
                    //Navigate to Data Store Page
                    NavigateToDataStorePage();
                }

                //~DATA STORE PAGE:----------------------------------------------------------------------------------------------------------------------------------------
                //Click on Data folder.
                driver.FindElement(By.XPath("//span[text()='Data']")).Click();
                Task.Delay(waitDelayDataStore).Wait();
            }

            etlSourceFile = Path.Combine(customUserDirectory, @"PLEASE_DO_NOT_DELETE_CONTENTS\HedgeOps\AutomationTestFiles\", etlDirectorySource, etlFile);
            nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, etlFile);
            nysaData = Path.Combine(nysaTargetPath, nysaFolderData);

            //Remove existing file(s) from NYSA archive (required to allow re-ETLs)
            if (targetTestingLocation == 0)
            {
                #region Delete Existing File From Archive
                if (File.Exists(nysaArchive))
                {
                    File.Delete(nysaArchive);
                }
                #endregion

                #region Move File To Destination
                etlFinal = nysaData;

                etlDestFile = Path.Combine(etlFinal, etlFile);

                //Check for folder's existance.
                if (!Directory.Exists(etlFinal))
                {
                    //Create new folder if none exist.
                    Directory.CreateDirectory(etlFinal);
                }

                //Copy files from source folder to destination folder and overwrite existing if necessary.
                File.Copy(etlSourceFile, etlDestFile, true);
                #endregion
            }

            if (targetTestingLocation == 1)
            {
                //Click on Browse button.
                driver.FindElement(By.XPath("//td[@id[contains(.,'DataStoreFileManager_Splitter_Upload_Browse0')]]/a[text()='Browse...']")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                //Navigate and select file in file explorer.
                SendKeys.SendWait(etlSourceFile);
                Task.Delay(waitDelayLongPlus).Wait();
                HitEnterKey();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id[contains(.,'Upload')]]//td[@title[contains(.,'')]]")));

                //Click on Upload button.
                driver.FindElement(By.XPath("//a[text()='Upload']")).Click();
                Task.Delay(waitDelayExtreme).Wait();

                //Restart stopwatch.
                timer.Restart();

                //Check for appearance of file.
                while (timer.Elapsed.TotalSeconds < timerShort && timer.IsRunning.Equals(true))
                {
                    var filePresent = driver.FindElements(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile)));

                    if (!filePresent.Any())
                    {
                        Task.Delay(waitDelayLong).Wait();
                    }

                    else
                    {
                        //Stop stopwatch.
                        timer.Stop();
                    }
                }

                //Validate presence of file.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile))));
            }

            //Validate that each ETL file moves to Archive.
            waitDelayCustom = 10000;

            string month = etlFile.Substring(16, 2);
            string day = etlFile.Substring(19, 2);
            string year = etlFile.Substring(22, 4);

            etlDate = year + "-" + month + "-" + day;

            string slashFormatDate = month + "/" + day + "/" + year;
            var dateTimeFormat = DateTime.Parse(slashFormatDate);
            versionDate = dateTimeFormat.ToString("M/d/yyyy");

            if (targetTestingLocation == 0)
            {
                //Restart stopwatch.
                timer.Restart();

                //Check for dissappearcance of file.
                while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
                {
                    var nysaData = Path.Combine(nysaTargetPath, nysaFolderData, etlFile);

                    if (File.Exists(nysaData))
                    {
                        Task.Delay(waitDelayCustom).Wait();
                    }

                    else
                    {
                        //Stop stopwatch.
                        timer.Stop();
                    }
                }

                nysaData = Path.Combine(nysaTargetPath, nysaFolderData, etlFile);

                if (File.Exists(nysaData))
                {
                    Assert.Fail(string.Format(@"ETL file ""{0}"" failed to process in {1}{2}.", etlFile, nysaTargetPath, nysaFolderData));
                }

                nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, etlFile);

                if (!File.Exists(nysaArchive))
                {
                    Assert.Fail(string.Format(@"ETL file ""{0}"" encountered an error and failed to ETL.", etlFile));
                }
            }

            if (targetTestingLocation == 1)
            {
                //Restart stopwatch.
                timer.Restart();

                //Check for dissappearcance of file.
                while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
                {
                    var fileName = driver.FindElements(By.XPath(string.Format("//div[text() = '{0}']", etlFile)));
                    if (fileName.Any())
                    {
                        Task.Delay(waitDelayCustom).Wait();
                    }

                    else
                    {
                        //Stop stopwatch.
                        timer.Stop();
                    }
                }

                var fileNameA = driver.FindElements(By.XPath(string.Format("//div[text() = '{0}']", etlFile)));

                if (fileNameA.Any())
                {
                    Assert.Fail(string.Format(@"ETL file ""{0}"" failed to process in Data folder.", etlFile));
                }

                //Click on Archive folder.
                driver.FindElement(By.XPath("//span[text()='Archive']")).Click();
                Task.Delay(waitDelayDataStore).Wait();

                var fileNameB = driver.FindElements(By.XPath(string.Format("//div[text() = '{0}']", etlFile)));

                if (fileNameB.Any())
                {
                    Assert.Fail(string.Format(@"ETL file ""{0}"" encountered an error and failed to ETL.", etlFile));
                }
            }

            //Verify ETL instance and group success.
            #region Verify ETL Instance Success
            try
            {
                string sql1Query = string.Format("DECLARE @setProgram VARCHAR(MAX); " + "DECLARE @versionID VARCHAR(30); " + "DECLARE @groupID VARCHAR(30); " +
                    "DECLARE @versionName VARCHAR(30); " + "DECLARE @versionDate VARCHAR(30); " + "DECLARE @configID INT; " + "DECLARE @versionTypeID INT; " +

                    "SET @setProgram = '{0}' " + "SET @versionName = '{1}' " + "SET @versionDate = '{2}'" +

                    "SET @versionTypeID = (SELECT TOP(1) versiontype_id " +
                    "FROM tbl_Version WITH(NOLOCK) " +
                    "WHERE version_name = @versionName AND programversion_guid = @setProgram " +
                    "ORDER BY version_updated DESC) " +

                    "SET @versionID = (SELECT TOP(1) version_id " +
                    "FROM tbl_Version WITH(NOLOCK) " +
                    "WHERE version_name = @versionName AND version_date = @versionDate AND programversion_guid = @setProgram " +
                    "ORDER BY version_updated DESC) " +

                    "SET @groupID = (SELECT TOP (1) Id " +
                    "FROM tbl_ETLGroup WITH(NOLOCK) " +
                    "WHERE VersionName = @versionName AND programversion_guid = @setProgram AND Voided IS NULL) " +

                    "SET @configID = (SELECT TOP(1) i1.Id " +
                    "FROM tbl_ETLConfig i1 WITH(NOLOCK) " +
                    "WHERE ETLGroupId = @groupID AND etltype_id = 27 AND Voided IS NULL) " +

                    "SELECT TOP(1) Success " +
                    "FROM tbl_ETLInstance i1 " +
                    "INNER JOIN tbl_ETLFile i2 ON i1.ETLConfigId = i2.ETLConfigId " +
                    "INNER JOIN tbl_ETLConfig i3 ON i1.ETLConfigId = i3.Id " +
                    "WHERE version_id = @versionID AND i1.ETLConfigId = @configID " +
                    "ORDER BY Processed DESC ", targetProgramGuid, etlGroupVersionNameAssumption, etlDate);

                SQLConnect();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        var data = myReader.GetValue(i);
                        string actual = data.ToString();

                        //Verify that the record is NULL in the DB.
                        Assert.AreEqual(sqlAssertETLSuccess, actual);
                    }
                }

                myReader.Close();
            }

            catch (Exception e)
            {
                Assert.Fail("Unexpected Result: ETL instance was unsuccessfull." + e);
            }
            #endregion

            #region Verify ETL Group Completion
            try
            {
                string sql1Query = string.Format("DECLARE @setProgram VARCHAR(MAX); " + "DECLARE @versionID VARCHAR(30); " + "DECLARE @versionName VARCHAR(30); " +
                    "DECLARE @versionDate VARCHAR(30); " +

                    "SET @setProgram = '{0}' " + "SET @versionName = '{1}' " + "SET @versionDate = '{2}'" +

                    "SET @versionID = (SELECT TOP(1) version_id " +
                    "FROM tbl_Version WITH(NOLOCK) " +
                    "WHERE version_name = @versionName AND version_date = @versionDate AND programversion_guid = @setProgram " +
                    "ORDER BY version_updated DESC) " +

                    "SELECT Complete " +
                    "FROM tbl_VersionETL " +
                    "WHERE version_id = @versionID ", targetProgramGuid, etlGroupVersionNameAssumption, etlDate);

                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        var data = myReader.GetValue(i);
                        string actual = data.ToString();

                        //Verify that the record is NULL in the DB.
                        Assert.AreEqual(sqlAssertETLSuccess, actual);
                    }
                }

                myReader.Close();
                SQLClose();
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected Result: ETL group belonging to ETL instance did not complete.");
            }
            #endregion

            if (!driver.VerifyAsserts(By.XPath("//td[text()='Status']")))
            {
                //Navigate to the ETL Validation Page.
                NavigateToETLValidationPage();
            }
        }

        public void DropETLAssumptionFile(string etlAssumptionFile)
        {
            etlFile = etlAssumptionFile;
            etlType = etlTypeAssumption;

            if (targetTestingLocation == 1)
            {
                var currentPage = driver.FindElements(By.XPath("//span[text()='TestingFolder']"));

                if (!currentPage.Any())
                {
                    //Navigate to Data Store Page
                    NavigateToDataStorePage();
                }

                //~DATA STORE PAGE:----------------------------------------------------------------------------------------------------------------------------------------
                //Click on Data folder.
                driver.FindElement(By.XPath("//span[text()='Data']")).Click();
                Task.Delay(waitDelayDataStore).Wait();
            }

            etlSourceFile = Path.Combine(customUserDirectory, @"PLEASE_DO_NOT_DELETE_CONTENTS\HedgeOps\AutomationTestFiles\", etlDirectorySource, etlFile);
            nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, etlFile);
            nysaData = Path.Combine(nysaTargetPath, nysaFolderData);

            //Remove existing file(s) from NYSA archive (required to allow re-ETLs)
            if (targetTestingLocation == 0)
            {
                #region Delete Existing File From Archive
                if (File.Exists(nysaArchive))
                {
                    File.Delete(nysaArchive);
                }
                #endregion

                #region Move File To Destination
                etlFinal = nysaData;

                etlDestFile = Path.Combine(etlFinal, etlFile);

                //Check for folder's existance.
                if (!Directory.Exists(etlFinal))
                {
                    //Create new folder if none exist.
                    Directory.CreateDirectory(etlFinal);
                }

                //Copy files from source folder to destination folder and overwrite existing if necessary.
                File.Copy(etlSourceFile, etlDestFile, true);
                #endregion
            }

            if (targetTestingLocation == 1)
            {
                //Click on Browse button.
                driver.FindElement(By.XPath("//td[@id[contains(.,'DataStoreFileManager_Splitter_Upload_Browse0')]]/a[text()='Browse...']")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                //Navigate and select file in file explorer.
                SendKeys.SendWait(etlSourceFile);
                Task.Delay(waitDelayLongPlus).Wait();
                HitEnterKey();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id[contains(.,'Upload')]]//td[@title[contains(.,'')]]")));

                //Click on Upload button.
                driver.FindElement(By.XPath("//a[text()='Upload']")).Click();
                Task.Delay(waitDelayExtreme).Wait();

                //Restart stopwatch.
                timer.Restart();

                //Check for appearance of file.
                while (timer.Elapsed.TotalSeconds < timerShort && timer.IsRunning.Equals(true))
                {
                    var filePresent = driver.FindElements(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile)));

                    if (!filePresent.Any())
                    {
                        Task.Delay(waitDelayLong).Wait();
                    }

                    else
                    {
                        //Stop stopwatch.
                        timer.Stop();
                    }
                }

                //Validate presence of file.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile))));
            }

            //Validate that each ETL file moves to Archive.
            waitDelayCustom = 10000;

            string month = etlFile.Substring(16, 2);
            string day = etlFile.Substring(19, 2);
            string year = etlFile.Substring(22, 4);

            etlDate = year + "-" + month + "-" + day;

            string slashFormatDate = month + "/" + day + "/" + year;
            var dateTimeFormat = DateTime.Parse(slashFormatDate);
            versionDate = dateTimeFormat.ToString("M/d/yyyy");

            if (targetTestingLocation == 0)
            {
                //Restart stopwatch.
                timer.Restart();

                //Check for dissappearcance of file.
                while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
                {
                    var nysaData = Path.Combine(nysaTargetPath, nysaFolderData, etlFile);

                    if (File.Exists(nysaData))
                    {
                        Task.Delay(waitDelayCustom).Wait();
                    }

                    else
                    {
                        //Stop stopwatch.
                        timer.Stop();
                    }
                }

                nysaData = Path.Combine(nysaTargetPath, nysaFolderData, etlFile);

                if (File.Exists(nysaData))
                {
                    Assert.Fail(string.Format(@"ETL file ""{0}"" failed to process in {1}{2}.", etlFile, nysaTargetPath, nysaFolderData));
                }

                nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, etlFile);

                if (!File.Exists(nysaArchive))
                {
                    Assert.Fail(string.Format(@"ETL file ""{0}"" encountered an error and failed to ETL.", etlFile));
                }
            }

            if (targetTestingLocation == 1)
            {
                //Restart stopwatch.
                timer.Restart();

                //Check for dissappearcance of file.
                while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
                {
                    var fileName = driver.FindElements(By.XPath(string.Format("//div[text() = '{0}']", etlFile)));
                    if (fileName.Any())
                    {
                        Task.Delay(waitDelayCustom).Wait();
                    }

                    else
                    {
                        //Stop stopwatch.
                        timer.Stop();
                    }
                }

                var fileNameA = driver.FindElements(By.XPath(string.Format("//div[text() = '{0}']", etlFile)));

                if (fileNameA.Any())
                {
                    Assert.Fail(string.Format(@"ETL file ""{0}"" failed to process in Data folder.", etlFile));
                }

                //Click on Archive folder.
                driver.FindElement(By.XPath("//span[text()='Archive']")).Click();
                Task.Delay(waitDelayDataStore).Wait();

                var fileNameB = driver.FindElements(By.XPath(string.Format("//div[text() = '{0}']", etlFile)));

                if (fileNameB.Any())
                {
                    Assert.Fail(string.Format(@"ETL file ""{0}"" encountered an error and failed to ETL.", etlFile));
                }
            }

            //Verify ETL instance and group success.
            #region Verify ETL Instance Success
            try
            {
                string sql1Query = string.Format("DECLARE @setProgram VARCHAR(MAX); " + "DECLARE @versionID VARCHAR(30); " + "DECLARE @groupID VARCHAR(30); " +
                    "DECLARE @versionName VARCHAR(30); " + "DECLARE @versionDate VARCHAR(30); " + "DECLARE @configID INT; " + "DECLARE @versionTypeID INT; " +

                    "SET @setProgram = '{0}' " + "SET @versionName = '{1}' " + "SET @versionDate = '{2}'" +

                    "SET @versionTypeID = (SELECT TOP(1) versiontype_id " +
                    "FROM tbl_Version WITH(NOLOCK) " +
                    "WHERE version_name = @versionName AND programversion_guid = @setProgram " +
                    "ORDER BY version_updated DESC) " +

                    "SET @versionID = (SELECT TOP(1) version_id " +
                    "FROM tbl_Version WITH(NOLOCK) " +
                    "WHERE version_name = @versionName AND version_date = @versionDate AND programversion_guid = @setProgram " +
                    "ORDER BY version_updated DESC) " +

                    "SET @groupID = (SELECT TOP (1) Id " +
                    "FROM tbl_ETLGroup WITH(NOLOCK) " +
                    "WHERE VersionName = @versionName AND programversion_guid = @setProgram AND Voided IS NULL) " +

                    "SET @configID = (SELECT TOP(1) i1.Id " +
                    "FROM tbl_ETLConfig i1 WITH(NOLOCK) " +
                    "WHERE ETLGroupId = @groupID AND etltype_id = 27 AND Voided IS NULL) " +

                    "SELECT TOP(1) Success " +
                    "FROM tbl_ETLInstance i1 " +
                    "INNER JOIN tbl_ETLFile i2 ON i1.ETLConfigId = i2.ETLConfigId " +
                    "INNER JOIN tbl_ETLConfig i3 ON i1.ETLConfigId = i3.Id " +
                    "WHERE version_id = @versionID AND i1.ETLConfigId = @configID " +
                    "ORDER BY Processed DESC ", targetProgramGuid, etlGroupVersionNameAssumption, etlDate);

                SQLConnect();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        var data = myReader.GetValue(i);
                        string actual = data.ToString();

                        //Verify that the record is NULL in the DB.
                        Assert.AreEqual(sqlAssertETLSuccess, actual);
                    }
                }

                myReader.Close();
            }

            catch (Exception e)
            {
                Assert.Fail("Unexpected Result: ETL instance was unsuccessfull." + e);
            }
            #endregion

            #region Verify ETL Group Completion
            try
            {
                string sql1Query = string.Format("DECLARE @setProgram VARCHAR(MAX); " + "DECLARE @versionID VARCHAR(30); " + "DECLARE @versionName VARCHAR(30); " +
                    "DECLARE @versionDate VARCHAR(30); " +

                    "SET @setProgram = '{0}' " + "SET @versionName = '{1}' " + "SET @versionDate = '{2}'" +

                    "SET @versionID = (SELECT TOP(1) version_id " +
                    "FROM tbl_Version WITH(NOLOCK) " +
                    "WHERE version_name = @versionName AND version_date = @versionDate AND programversion_guid = @setProgram " +
                    "ORDER BY version_updated DESC) " +

                    "SELECT Complete " +
                    "FROM tbl_VersionETL " +
                    "WHERE version_id = @versionID ", targetProgramGuid, etlGroupVersionNameAssumption, etlDate);

                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        var data = myReader.GetValue(i);
                        string actual = data.ToString();

                        //Verify that the record is NULL in the DB.
                        Assert.AreEqual(sqlAssertETLSuccess, actual);
                    }
                }

                myReader.Close();
                SQLClose();
            }
            catch (Exception)
            {
                Assert.Fail("Unexpected Result: ETL group belonging to ETL instance did not complete.");
            }
            #endregion

            //if (targetTestingLocation == 1)
            //{
            //Navigate to the ETL Validation Page.
            //NavigateToETLValidationPage();
            //}

            if (!driver.VerifyAsserts(By.XPath("//td[text()='Status']")))
            {
                //Navigate to the ETL Validation Page.
                NavigateToETLValidationPage();
            }

            //~VALIDATION PAGE:----------------------------------------------------------------------------------------------------------------------------------------------
            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < waitDelayCustom && timer.IsRunning.Equals(true))
            {
                var etlRow1 = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='Approve']", etlGroupName)));
                var etlRow2 = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}'][1]//td[text()='{1}']", etlGroupName, versionDate)));

                if (!etlRow1.Any() || !etlRow2.Any())
                {
                    //Refresh browser.                    
                    driver.Navigate().Refresh();

                    //Waits for Status column to load.
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Status']")));
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Obtain ETL Instance ID.
            string etlInstance = driver.FindElement(By.XPath(string.Format("//tr[td/text()='{0}'][1]//td[@class='dxgv dx-ar'][1]", etlGroupName))).Text;
            string etlID = etlInstance;

            //Toggle a variation of method test steps.
            testVariation = 1;

            //Calculate date format.
            DetermineDateTime();

            //Click on View.
            driver.FindElement(By.XPath(string.Format("//tr[td/text()='{0}'][1]//span[text()='View']", etlGroupName))).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Validation Report']")));

            //Validate that Validation Report opens.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()='Validation Report']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format
                ("//div[text()[contains(.,'ETL Instance: {0} was processed at {1}-{2}-{3}')]]", etlID, todayYear, todayMonthNum, todayFullDay))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[text()[contains(.,'Files Processed: {0}')]]", etlFile))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//td[text()='Control']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//td[text()='Value']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//td[text()='Rows Imported']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//td[text()='Rows Not Processed']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//td[text()='Rows Processed']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//td[text()='Field Checksum Before Import']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//td[text()='Field Checksum After Import']")));

            //Close Validation Report window.
            driver.FindElement(By.XPath("//div[@id[contains(.,'ViewPopupControl_HCB-1')]]/img[@alt='Close']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Validation Report']")));

            //Validate appearance of asset file.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format
                ("//tr[td/text()='{0}'][1]//td/img[@class[contains(.,'gvDetailCollapsedButton')]]", etlGroupName))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format
                ("//tr[td/text()='{0}'][1]//td/a/img[@class[contains(.,'dxIcon_actions_apply')]]", etlGroupName))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td/text()='{0}'][1]//td/a/span[text()='View']", etlGroupName))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td/text()='{0}'][1]//td[text()[contains(.,'')]][1]", etlGroupName))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td/text()='{0}'][1]//td[text()='{1}']", etlGroupName, etlType))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td/text()='{0}'][1]//td[text()='{1}']", etlGroupName, etlGroupVersionNameAssumption))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td/text()='{0}'][1]//td[text()='{1}']", etlGroupName, versionDate))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td/text()='{0}'][1]//td[text()[contains(.,'')]][6]", etlGroupName))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td/text()='{0}'][1]//td/a/span[text()='Approve']", etlGroupName))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td/text()='{0}'][1]//td[text()[contains(.,'{1}/{2}/{3}')]]", etlGroupName, todayMonth, todayDay, todayYear))));
        }
        public void DropETLPolicyMulti()
        {
            etlFile1 = etlPolicyFile1;
            etlFile2 = etlPolicyFile3;
            etlFile3 = etlPolicyFile4;
            etlFile4 = etlPolicyFile5;

            //Create a list of ETL Files.
            List<string> etlPolicyFiles = new List<string>
            {
                etlFile1,
                etlFile2,
                etlFile3,
                etlFile4
            };

            if (targetTestingLocation == 1)
            {
                var currentPage = driver.FindElements(By.XPath("//span[text()='TestingFolder']"));

                if (!currentPage.Any())
                {
                    //Navigate to Data Store Page
                    NavigateToDataStorePage();
                }

                //~DATA STORE PAGE:----------------------------------------------------------------------------------------------------------------------------------------
                //Click on Data folder.
                driver.FindElement(By.XPath("//span[text()='Data']")).Click();
                Task.Delay(waitDelayDataStore).Wait();
            }

            //ETL in each file.
            foreach (string file in etlPolicyFiles)
            {
                etlFile = file;
                etlSourceFile = Path.Combine(mainAutomationDirectory, etlDirectorySource, etlFile);
                nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, etlFile);
                nysaData = Path.Combine(nysaTargetPath, nysaFolderData);

                //Remove existing file(s) from NYSA archive (required to allow re-ETLs)
                if (targetTestingLocation == 0)
                {
                    #region Delete Existing File From Archive
                    if (File.Exists(nysaArchive))
                    {
                        File.Delete(nysaArchive);
                    }
                    #endregion

                    #region Move File To Destination
                    etlFinal = nysaData;

                    etlDestFile = Path.Combine(etlFinal, etlFile);

                    //Check for folder's existance.
                    if (!Directory.Exists(etlFinal))
                    {
                        //Create new folder if none exist.
                        Directory.CreateDirectory(etlFinal);
                    }

                    //Copy files from source folder to destination folder and overwrite existing if necessary.
                    File.Copy(etlSourceFile, etlDestFile, true);
                    #endregion
                }

                if (targetTestingLocation == 1)
                {
                    //Click on Browse button.
                    driver.FindElement(By.XPath("//td[@id[contains(.,'DataStoreFileManager_Splitter_Upload_Browse0')]]/a[text()='Browse...']")).Click();
                    Task.Delay(waitDelayBrowse).Wait();

                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(etlSourceFile);
                    Task.Delay(waitDelayLongPlus).Wait();
                    HitEnterKey();

                    //Waits for file to appear in field (sometimes theres a few second delay)
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id[contains(.,'Upload')]]//td[@title[contains(.,'')]]")));

                    //Click on Upload button.
                    driver.FindElement(By.XPath("//a[text()='Upload']")).Click();
                    Task.Delay(waitDelayExtreme).Wait();

                    //Restart stopwatch.
                    timer.Restart();

                    //Check for appearance of file.
                    while (timer.Elapsed.TotalSeconds < timerShort && timer.IsRunning.Equals(true))
                    {
                        var filePresent = driver.FindElements(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile)));

                        if (!filePresent.Any())
                        {
                            Task.Delay(waitDelayLong).Wait();
                        }

                        else
                        {
                            //Stop stopwatch.
                            timer.Stop();
                        }
                    }

                    //Validate presence of file.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile))));
                }
            }

            //Validate that each ETL file moves to Archive.
            foreach (string file in etlPolicyFiles)
            {
                waitDelayCustom = 10000;
                etlFile = file;

                string month = file.Substring(12, 2);
                string day = file.Substring(15, 2);
                string year = file.Substring(18, 4);

                etlDate = year + "-" + month + "-" + day;

                if (targetTestingLocation == 0)
                {
                    //Restart stopwatch.
                    timer.Restart();

                    //Check for dissappearcance of file.
                    while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
                    {
                        var nysaData = Path.Combine(nysaTargetPath, nysaFolderData, etlFile);

                        if (File.Exists(nysaData))
                        {
                            Task.Delay(waitDelayCustom).Wait();
                        }

                        else
                        {
                            //Stop stopwatch.
                            timer.Stop();
                        }
                    }

                    nysaData = Path.Combine(nysaTargetPath, nysaFolderData, etlFile);

                    if (File.Exists(nysaData))
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" failed to process in {1}{2}.", etlFile, nysaTargetPath, nysaFolderData));
                    }

                    nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, etlFile);

                    if (!File.Exists(nysaArchive))
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" encountered an error and failed to ETL.", etlFile));
                    }
                }

                if (targetTestingLocation == 1)
                {
                    //Restart stopwatch.
                    timer.Restart();

                    //Check for dissappearcance of file.
                    while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
                    {
                        var fileName = driver.FindElements(By.XPath(string.Format("//text()[contains(.,'{0}')]", etlFile)));

                        if (fileName.Any())
                        {
                            Task.Delay(waitDelayCustom).Wait();
                        }

                        else
                        {
                            //Stop stopwatch.
                            timer.Stop();
                        }
                    }

                    var fileNameA = driver.FindElements(By.XPath(string.Format("//text()[contains(.,'{0}')]", etlFile)));

                    if (fileNameA.Any())
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" failed to process in Data folder.", etlFile));
                    }

                    //Click on Archive folder.
                    driver.FindElement(By.XPath("//span[text()='Archive']")).Click();
                    Task.Delay(waitDelayDataStore).Wait();

                    var fileNameB = driver.FindElements(By.XPath(string.Format("//text()[contains(.,'{0}')]", etlFile)));

                    if (fileNameB.Any())
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" encountered an error and failed to ETL.", etlFile));
                    }
                }

                //Verify ETL instance and group success.
                #region Verify ETL Instance Success
                try
                {
                    string sql1Query = string.Format("DECLARE @setProgram VARCHAR(MAX); " + "DECLARE @versionID VARCHAR(30); " + "DECLARE @groupID VARCHAR(30); " +
                        "DECLARE @versionName VARCHAR(30); " + "DECLARE @versionDate VARCHAR(30); " + "DECLARE @configID INT; " + "DECLARE @versionTypeID INT; " +

                        "SET @setProgram = '{0}' " + "SET @versionName = '{1}' " + "SET @versionDate = '{2}'" +

                        "SET @versionTypeID = (SELECT TOP(1) versiontype_id " +
                        "FROM tbl_Version WITH(NOLOCK) " +
                        "WHERE version_name = @versionName AND programversion_guid = @setProgram " +
                        "ORDER BY version_updated DESC) " +

                        "SET @versionID = (SELECT TOP(1) version_id " +
                        "FROM tbl_Version WITH(NOLOCK) " +
                        "WHERE version_name = @versionName AND version_date = @versionDate AND programversion_guid = @setProgram " +
                        "ORDER BY version_updated DESC) " +

                        "SET @groupID = (SELECT TOP (1) Id " +
                        "FROM tbl_ETLGroup WITH(NOLOCK) " +
                        "WHERE VersionName = @versionName AND programversion_guid = @setProgram AND Voided IS NULL) " +

                        "SET @configID = (SELECT TOP(1) i1.Id " +
                        "FROM tbl_ETLConfig i1 WITH(NOLOCK) " +
                        "WHERE ETLGroupId = @groupID AND etltype_id = 1 AND Voided IS NULL) " +

                        "SELECT TOP(1) Success " +
                        "FROM tbl_ETLInstance i1 " +
                        "INNER JOIN tbl_ETLFile i2 ON i1.ETLConfigId = i2.ETLConfigId " +
                        "INNER JOIN tbl_ETLConfig i3 ON i1.ETLConfigId = i3.Id " +
                        "WHERE version_id = @versionID AND i1.ETLConfigId = @configID " +
                        "ORDER BY Processed DESC ", targetProgramGuid, etlTestInforce, etlDate);

                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        for (int i = 0; i < myReader.FieldCount; i++)
                        {
                            var data = myReader.GetValue(i);
                            string actual = data.ToString();

                            //Verify that the record is NULL in the DB.
                            Assert.AreEqual(sqlAssertETLSuccess, actual);
                        }
                    }

                    myReader.Close();
                }

                catch (Exception)
                {
                    Assert.Fail("Unexpected Result: ETL instance was unsuccessfull.");
                }
                #endregion

                #region Verify ETL Group Completion
                try
                {
                    string sql1Query = string.Format("DECLARE @setProgram VARCHAR(MAX); " + "DECLARE @versionID VARCHAR(30); " + "DECLARE @versionName VARCHAR(30); " +
                        "DECLARE @versionDate VARCHAR(30); " +

                        "SET @setProgram = '{0}' " + "SET @versionName = '{1}' " + "SET @versionDate = '{2}'" +

                        "SET @versionID = (SELECT TOP(1) version_id " +
                        "FROM tbl_Version WITH(NOLOCK) " +
                        "WHERE version_name = @versionName AND version_date = @versionDate AND programversion_guid = @setProgram " +
                        "ORDER BY version_updated DESC) " +

                        "SELECT Complete " +
                        "FROM tbl_VersionETL " +
                        "WHERE version_id = @versionID ", targetProgramGuid, etlTestInforce, etlDate);

                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        for (int i = 0; i < myReader.FieldCount; i++)
                        {
                            var data = myReader.GetValue(i);
                            string actual = data.ToString();

                            //Verify that the record is NULL in the DB.
                            Assert.AreEqual(sqlAssertETLSuccess, actual);
                        }
                    }

                    myReader.Close();
                }

                catch (Exception)
                {
                    Assert.Fail("Unexpected Result: ETL group belonging to ETL instance did not complete.");
                }
                #endregion
            }

            if (targetTestingLocation == 1)
            {
                //Navigate to the ETL Validation Page.
                NavigateToETLValidationPage();
            }
        }
        public void DropETLPolicyMulti_HOPS_796()
        {
            etlFile1 = etlPolicyHOPS796_File1;
            etlFile2 = etlPolicyHOPS796_File2;
            etlFile3 = etlPolicyHOPS796_File3;
            etlFile4 = etlPolicyHOPS796_File4;
            etlFile5 = etlPolicyHOPS796_File5;
            etlFile6 = etlPolicyHOPS796_File6;
            etlFile7 = etlPolicyHOPS796_File7;
            etlFile8 = etlPolicyHOPS796_File8;
            etlFile9 = etlPolicyHOPS796_File9;

            //Create a list of ETL Files.
            List<string> etlPolicyFiles = new List<string>
            {
                etlFile1,
                etlFile2,
                etlFile3,
                etlFile4,
                etlFile5,
                etlFile6,
                etlFile7,
                etlFile8,
                etlFile9
            };

            if (targetTestingLocation == 1)
            {
                var currentPage = driver.FindElements(By.XPath("//span[text()='TestingFolder']"));

                if (!currentPage.Any())
                {
                    //Navigate to Data Store Page
                    NavigateToDataStorePage();
                }

                //~DATA STORE PAGE:----------------------------------------------------------------------------------------------------------------------------------------
                //Click on Data folder.
                driver.FindElement(By.XPath("//span[text()='Data']")).Click();
                Task.Delay(waitDelayDataStore).Wait();
            }

            //ETL in each file.
            foreach (string file in etlPolicyFiles)
            {
                etlFile = file;
                etlSourceFile = Path.Combine(mainAutomationDirectory, etlDirectorySource, etlFile);
                nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, etlFile);
                nysaData = Path.Combine(nysaTargetPath, nysaFolderData);

                //Remove existing file(s) from NYSA archive (required to allow re-ETLs)
                if (targetTestingLocation == 0)
                {
                    #region Delete Existing File From Archive
                    if (File.Exists(nysaArchive))
                    {
                        File.Delete(nysaArchive);
                    }
                    #endregion

                    #region Move File To Destination
                    etlFinal = nysaData;

                    etlDestFile = Path.Combine(etlFinal, etlFile);

                    //Check for folder's existance.
                    if (!Directory.Exists(etlFinal))
                    {
                        //Create new folder if none exist.
                        Directory.CreateDirectory(etlFinal);
                    }

                    //Copy files from source folder to destination folder and overwrite existing if necessary.
                    File.Copy(etlSourceFile, etlDestFile, true);
                    #endregion
                }

                if (targetTestingLocation == 1)
                {
                    //Click on Browse button.
                    driver.FindElement(By.XPath("//td[@id[contains(.,'DataStoreFileManager_Splitter_Upload_Browse0')]]/a[text()='Browse...']")).Click();
                    Task.Delay(waitDelayBrowse).Wait();

                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(etlSourceFile);
                    Task.Delay(waitDelayLongPlus).Wait();
                    HitEnterKey();

                    //Waits for file to appear in field (sometimes theres a few second delay)
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id[contains(.,'Upload')]]//td[@title[contains(.,'')]]")));

                    //Click on Upload button.
                    driver.FindElement(By.XPath("//a[text()='Upload']")).Click();
                    Task.Delay(waitDelayExtreme).Wait();

                    //Restart stopwatch.
                    timer.Restart();

                    //Check for appearance of file.
                    while (timer.Elapsed.TotalSeconds < timerShort && timer.IsRunning.Equals(true))
                    {
                        var filePresent = driver.FindElements(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile)));

                        if (!filePresent.Any())
                        {
                            Task.Delay(waitDelayLong).Wait();
                        }

                        else
                        {
                            //Stop stopwatch.
                            timer.Stop();
                        }
                    }

                    //Validate presence of file.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile))));
                }
            }

            //Validate that each ETL file moves to Archive.
            foreach (string file in etlPolicyFiles)
            {
                waitDelayCustom = 10000;
                etlFile = file;

                string month = file.Substring(12, 2);
                string day = file.Substring(15, 2);
                string year = file.Substring(18, 4);

                etlDate = year + "-" + month + "-" + day;

                if (targetTestingLocation == 0)
                {
                    //Restart stopwatch.
                    timer.Restart();

                    //Check for dissappearcance of file.
                    while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
                    {
                        var nysaData = Path.Combine(nysaTargetPath, nysaFolderData, etlFile);

                        if (File.Exists(nysaData))
                        {
                            Task.Delay(waitDelayCustom).Wait();
                        }

                        else
                        {
                            //Stop stopwatch.
                            timer.Stop();
                        }
                    }

                    nysaData = Path.Combine(nysaTargetPath, nysaFolderData, etlFile);

                    if (File.Exists(nysaData))
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" failed to process in {1}{2}.", etlFile, nysaTargetPath, nysaFolderData));
                    }

                    nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, etlFile);

                    if (!File.Exists(nysaArchive))
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" encountered an error and failed to ETL.", etlFile));
                    }
                }

                if (targetTestingLocation == 1)
                {
                    //Restart stopwatch.
                    timer.Restart();

                    //Check for dissappearcance of file.
                    while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
                    {
                        var fileName = driver.FindElements(By.XPath(string.Format("//text()[contains(.,'{0}')]", etlFile)));

                        if (fileName.Any())
                        {
                            Task.Delay(waitDelayCustom).Wait();
                        }

                        else
                        {
                            //Stop stopwatch.
                            timer.Stop();
                        }
                    }

                    var fileNameA = driver.FindElements(By.XPath(string.Format("//text()[contains(.,'{0}')]", etlFile)));

                    if (fileNameA.Any())
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" failed to process in Data folder.", etlFile));
                    }

                    //Click on Archive folder.
                    driver.FindElement(By.XPath("//span[text()='Archive']")).Click();
                    Task.Delay(waitDelayDataStore).Wait();

                    var fileNameB = driver.FindElements(By.XPath(string.Format("//text()[contains(.,'{0}')]", etlFile)));

                    if (fileNameB.Any())
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" encountered an error and failed to ETL.", etlFile));
                    }
                }

                //Verify ETL instance and group success.
                #region Verify ETL Instance Success
                try
                {
                    string sql1Query = string.Format("DECLARE @setProgram VARCHAR(MAX); " + "DECLARE @versionID VARCHAR(30); " + "DECLARE @groupID VARCHAR(30); " +
                        "DECLARE @versionName VARCHAR(30); " + "DECLARE @versionDate VARCHAR(30); " + "DECLARE @configID INT; " + "DECLARE @versionTypeID INT; " +

                        "SET @setProgram = '{0}' " + "SET @versionName = '{1}' " + "SET @versionDate = '{2}'" +

                        "SET @versionTypeID = (SELECT TOP(1) versiontype_id " +
                        "FROM tbl_Version WITH(NOLOCK) " +
                        "WHERE version_name = @versionName AND programversion_guid = @setProgram " +
                        "ORDER BY version_updated DESC) " +

                        "SET @versionID = (SELECT TOP(1) version_id " +
                        "FROM tbl_Version WITH(NOLOCK) " +
                        "WHERE version_name = @versionName AND version_date = @versionDate AND programversion_guid = @setProgram " +
                        "ORDER BY version_updated DESC) " +

                        "SET @groupID = (SELECT TOP (1) Id " +
                        "FROM tbl_ETLGroup WITH(NOLOCK) " +
                        "WHERE VersionName = @versionName AND programversion_guid = @setProgram AND Voided IS NULL) " +

                        "SET @configID = (SELECT TOP(1) i1.Id " +
                        "FROM tbl_ETLConfig i1 WITH(NOLOCK) " +
                        "WHERE ETLGroupId = @groupID AND etltype_id = 1 AND Voided IS NULL) " +

                        "SELECT TOP(1) Success " +
                        "FROM tbl_ETLInstance i1 " +
                        "INNER JOIN tbl_ETLFile i2 ON i1.ETLConfigId = i2.ETLConfigId " +
                        "INNER JOIN tbl_ETLConfig i3 ON i1.ETLConfigId = i3.Id " +
                        "WHERE version_id = @versionID AND i1.ETLConfigId = @configID " +
                        "ORDER BY Processed DESC ", targetProgramGuid, etlTestInforce, etlDate);

                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        for (int i = 0; i < myReader.FieldCount; i++)
                        {
                            var data = myReader.GetValue(i);
                            string actual = data.ToString();

                            //Verify that the record is NULL in the DB.
                            Assert.AreEqual(sqlAssertETLSuccess, actual);
                        }
                    }

                    myReader.Close();
                }

                catch (Exception)
                {
                    Assert.Fail("Unexpected Result: ETL instance was unsuccessfull.");
                }
                #endregion

                #region Verify ETL Group Completion
                try
                {
                    string sql1Query = string.Format("DECLARE @setProgram VARCHAR(MAX); " + "DECLARE @versionID VARCHAR(30); " + "DECLARE @versionName VARCHAR(30); " +
                        "DECLARE @versionDate VARCHAR(30); " +

                        "SET @setProgram = '{0}' " + "SET @versionName = '{1}' " + "SET @versionDate = '{2}'" +

                        "SET @versionID = (SELECT TOP(1) version_id " +
                        "FROM tbl_Version WITH(NOLOCK) " +
                        "WHERE version_name = @versionName AND version_date = @versionDate AND programversion_guid = @setProgram " +
                        "ORDER BY version_updated DESC) " +

                        "SELECT Complete " +
                        "FROM tbl_VersionETL " +
                        "WHERE version_id = @versionID ", targetProgramGuid, etlTestInforce, etlDate);

                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        for (int i = 0; i < myReader.FieldCount; i++)
                        {
                            var data = myReader.GetValue(i);
                            string actual = data.ToString();

                            //Verify that the record is NULL in the DB.
                            Assert.AreEqual(sqlAssertETLSuccess, actual);
                        }
                    }

                    myReader.Close();
                }

                catch (Exception)
                {
                    Assert.Fail("Unexpected Result: ETL group belonging to ETL instance did not complete.");
                }
                #endregion
            }
        }
        public void DropETLFlex()
        {
            //Create a list of ETL Files.
            List<string> etlPolicyFiles = new List<string>
            {
                etlFile1,
                etlFile2,
            };

            if (targetTestingLocation == 1)
            {
                var currentPage = driver.FindElements(By.XPath("//span[text()='TestingFolder']"));

                if (!currentPage.Any())
                {
                    //Navigate to Data Store Page
                    NavigateToDataStorePage();
                }

                //~DATA STORE PAGE:----------------------------------------------------------------------------------------------------------------------------------------
                //Click on Data folder.
                driver.FindElement(By.XPath("//span[text()='Data']")).Click();
                Task.Delay(waitDelayDataStore).Wait();
            }

            //ETL in each file.
            foreach (string file in etlPolicyFiles)
            {
                etlFile = file;
                etlSourceFile = Path.Combine(mainAutomationDirectory, etlDirectorySource, etlFile);
                nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, etlFile);
                nysaData = Path.Combine(nysaTargetPath, nysaFolderData);

                //Remove existing file(s) from NYSA archive (required to allow re-ETLs)
                if (targetTestingLocation == 0)
                {
                    #region Delete Existing File From Archive
                    if (File.Exists(nysaArchive))
                    {
                        File.Delete(nysaArchive);
                    }
                    #endregion

                    #region Move File To Destination
                    etlFinal = nysaData;

                    etlDestFile = Path.Combine(etlFinal, etlFile);

                    //Check for folder's existance.
                    if (!Directory.Exists(etlFinal))
                    {
                        //Create new folder if none exist.
                        Directory.CreateDirectory(etlFinal);
                    }

                    //Copy files from source folder to destination folder and overwrite existing if necessary.
                    File.Copy(etlSourceFile, etlDestFile, true);
                    #endregion
                }

                if (targetTestingLocation == 1)
                {
                    //Click on Browse button.
                    driver.FindElement(By.XPath("//td[@id[contains(.,'DataStoreFileManager_Splitter_Upload_Browse0')]]/a[text()='Browse...']")).Click();
                    Task.Delay(waitDelayBrowse).Wait();

                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(etlSourceFile);
                    Task.Delay(waitDelayLongPlus).Wait();
                    HitEnterKey();

                    //Waits for file to appear in field (sometimes theres a few second delay)
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id[contains(.,'Upload')]]//td[@title[contains(.,'')]]")));

                    //Click on Upload button.
                    driver.FindElement(By.XPath("//a[text()='Upload']")).Click();
                    Task.Delay(waitDelayExtreme).Wait();

                    //Restart stopwatch.
                    timer.Restart();

                    //Check for appearance of file.
                    while (timer.Elapsed.TotalSeconds < timerShort && timer.IsRunning.Equals(true))
                    {
                        var filePresent = driver.FindElements(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile)));

                        if (!filePresent.Any())
                        {
                            Task.Delay(waitDelayLong).Wait();
                        }

                        else
                        {
                            //Stop stopwatch.
                            timer.Stop();
                        }
                    }

                    //Validate presence of file.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile))));
                }
            }

            //Validate that each ETL file moves to Archive.
            foreach (string file in etlPolicyFiles)
            {
                waitDelayCustom = 10000;
                etlFile = file;

                string month = file.Substring(12, 2);
                string day = file.Substring(15, 2);
                string year = file.Substring(18, 4);

                etlDate = year + "-" + month + "-" + day;

                if (targetTestingLocation == 0)
                {
                    //Restart stopwatch.
                    timer.Restart();

                    //Check for dissappearcance of file.
                    while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
                    {
                        var nysaData = Path.Combine(nysaTargetPath, nysaFolderData, etlFile);

                        if (File.Exists(nysaData))
                        {
                            Task.Delay(waitDelayCustom).Wait();
                        }

                        else
                        {
                            //Stop stopwatch.
                            timer.Stop();
                        }
                    }

                    nysaData = Path.Combine(nysaTargetPath, nysaFolderData, etlFile);

                    if (File.Exists(nysaData))
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" failed to process in {1}{2}.", etlFile, nysaTargetPath, nysaFolderData));
                    }

                    nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, etlFile);

                    if (!File.Exists(nysaArchive))
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" encountered an error and failed to ETL.", etlFile));
                    }
                }

                if (targetTestingLocation == 1)
                {
                    //Restart stopwatch.
                    timer.Restart();

                    //Check for dissappearcance of file.
                    while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
                    {
                        var fileName = driver.FindElements(By.XPath(string.Format("//text()[contains(.,'{0}')]", etlFile)));

                        if (fileName.Any())
                        {
                            Task.Delay(waitDelayCustom).Wait();
                        }

                        else
                        {
                            //Stop stopwatch.
                            timer.Stop();
                        }
                    }

                    var fileNameA = driver.FindElements(By.XPath(string.Format("//text()[contains(.,'{0}')]", etlFile)));

                    if (fileNameA.Any())
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" failed to process in Data folder.", etlFile));
                    }

                    //Click on Archive folder.
                    driver.FindElement(By.XPath("//span[text()='Archive']")).Click();
                    Task.Delay(waitDelayDataStore).Wait();

                    var fileNameB = driver.FindElements(By.XPath(string.Format("//text()[contains(.,'{0}')]", etlFile)));

                    if (fileNameB.Any())
                    {
                        Assert.Fail(string.Format(@"ETL file ""{0}"" encountered an error and failed to ETL.", etlFile));
                    }
                }

                //Verify ETL instance and group success.
                #region Verify ETL Instance Success
                try
                {
                    string sql1Query = string.Format("DECLARE @setProgram VARCHAR(MAX); " + "DECLARE @versionID VARCHAR(30); " + "DECLARE @groupID VARCHAR(30); " +
                        "DECLARE @versionName VARCHAR(30); " + "DECLARE @versionDate VARCHAR(30); " + "DECLARE @configID INT; " + "DECLARE @versionTypeID INT; " +

                        "SET @setProgram = '{0}' " + "SET @versionName = '{1}' " + "SET @versionDate = '{2}'" +

                        "SET @versionTypeID = (SELECT TOP(1) versiontype_id " +
                        "FROM tbl_Version WITH(NOLOCK) " +
                        "WHERE version_name = @versionName AND programversion_guid = @setProgram " +
                        "ORDER BY version_updated DESC) " +

                        "SET @versionID = (SELECT TOP(1) version_id " +
                        "FROM tbl_Version WITH(NOLOCK) " +
                        "WHERE version_name = @versionName AND version_date = @versionDate AND programversion_guid = @setProgram " +
                        "ORDER BY version_updated DESC) " +

                        "SET @groupID = (SELECT TOP (1) Id " +
                        "FROM tbl_ETLGroup WITH(NOLOCK) " +
                        "WHERE VersionName = @versionName AND programversion_guid = @setProgram AND Voided IS NULL) " +

                        "SET @configID = (SELECT TOP(1) i1.Id " +
                        "FROM tbl_ETLConfig i1 WITH(NOLOCK) " +
                        "WHERE ETLGroupId = @groupID AND etltype_id = 1 AND Voided IS NULL) " +

                        "SELECT TOP(1) Success " +
                        "FROM tbl_ETLInstance i1 " +
                        "INNER JOIN tbl_ETLFile i2 ON i1.ETLConfigId = i2.ETLConfigId " +
                        "INNER JOIN tbl_ETLConfig i3 ON i1.ETLConfigId = i3.Id " +
                        "WHERE version_id = @versionID AND i1.ETLConfigId = @configID " +
                        "ORDER BY Processed DESC ", targetProgramGuid, etlTestInforce, etlDate);

                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        for (int i = 0; i < myReader.FieldCount; i++)
                        {
                            var data = myReader.GetValue(i);
                            string actual = data.ToString();

                            //Verify that the record is NULL in the DB.
                            Assert.AreEqual(sqlAssertETLSuccess, actual);
                        }
                    }

                    myReader.Close();
                }

                catch (Exception)
                {
                    Assert.Fail("Unexpected Result: ETL instance was unsuccessfull.");
                }
                #endregion

                #region Verify ETL Group Completion
                try
                {
                    string sql1Query = string.Format("DECLARE @setProgram VARCHAR(MAX); " + "DECLARE @versionID VARCHAR(30); " + "DECLARE @versionName VARCHAR(30); " +
                        "DECLARE @versionDate VARCHAR(30); " +

                        "SET @setProgram = '{0}' " + "SET @versionName = '{1}' " + "SET @versionDate = '{2}'" +

                        "SET @versionID = (SELECT TOP(1) version_id " +
                        "FROM tbl_Version WITH(NOLOCK) " +
                        "WHERE version_name = @versionName AND version_date = @versionDate AND programversion_guid = @setProgram " +
                        "ORDER BY version_updated DESC) " +

                        "SELECT Complete " +
                        "FROM tbl_VersionETL " +
                        "WHERE version_id = @versionID ", targetProgramGuid, etlTestInforce, etlDate);

                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        for (int i = 0; i < myReader.FieldCount; i++)
                        {
                            var data = myReader.GetValue(i);
                            string actual = data.ToString();

                            //Verify that the record is NULL in the DB.
                            Assert.AreEqual(sqlAssertETLSuccess, actual);
                        }
                    }

                    myReader.Close();
                }

                catch (Exception)
                {
                    Assert.Fail("Unexpected Result: ETL group belonging to ETL instance did not complete.");
                }
                #endregion
            }
        }

        public void MoveETLFilesOnPrem()
        {
            #region Delete Existing File From Archive
            nysaArchive = Path.Combine(nysaTargetPath, nysaFolderArchive, etlFile);

            //Remove existing file(s) from NYSA archive (required to allow re-ETLs)
            if (targetTestingLocation == 0)
            {
                if (File.Exists(nysaArchive))
                {
                    File.Delete(nysaArchive);
                }
            }
            #endregion

            #region Move File To Directory
            etlNysaDataDrop = Path.Combine(nysaTargetPath, nysaFolderData);

            //Custom drop of ETL file into automation ETL sync folder.
            if (testVariation == 1)
            {
                etlFinal = etlDirectoryCustomTemp;
            }

            //Standard drop of ETL file into NYSA data folder.
            if (testVariation == 2)
            {
                etlFinal = etlNysaDataDrop;
            }
            else
            {
                etlFinal = etlDirectoryCustomFinal;
            }

            etlDestFile = Path.Combine(etlFinal, etlFile);

            if (testVariation != 2)
            {
                //Check for folder's existance.
                if (!Directory.Exists(etlFinal))
                {
                    //Create new folder if none exist.
                    Directory.CreateDirectory(etlFinal);
                }
            }

            //Copy files from source folder to destination folder and overwrite existing if necessary.
            File.Copy(etlSourceFile, etlDestFile, true);
            #endregion
        }
        public void UploadETLFilesCloud()
        {
            var currentPage = driver.FindElements(By.XPath("//span[text()='TestingFolder']"));

            if (!currentPage.Any())
            {
                //Navigate to Data Store Page
                NavigateToDataStorePage();
            }

            //~DATA STORE PAGE:----------------------------------------------------------------------------------------------------------------------------------------
            //Click on Data folder.
            driver.FindElement(By.XPath("//span[text()='Data']")).Click();
            Task.Delay(waitDelayDataStore).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'DataStoreFileManager_Splitter_Upload_Browse0')]]/a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(etlSourceFile);
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id[contains(.,'Upload')]]//td[@title[contains(.,'')]]")));

            //Click on Upload button.
            driver.FindElement(By.XPath("//a[text()='Upload']")).Click();
            Task.Delay(waitDelayExtreme).Wait();

            //Restart stopwatch.
            timer.Restart();

            //Check for appearance of file.
            while (timer.Elapsed.TotalSeconds < timerShort && timer.IsRunning.Equals(true))
            {
                var filePresent = driver.FindElements(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile)));

                if (!filePresent.Any())
                {
                    Task.Delay(waitDelayLong).Wait();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Validate presence of file.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", etlFile))));
        }
        #endregion

        #region External Models Tests
        public string defaultStubETL = "StubETL.dll";
        public string defaultInputProc = "RefInputProcessor.dll";
        public string defaultStubParameter = "StubOverlay.dll";
        public string defaultStubParamXML = "param.xml";
        public string defaultSheetInfo = "sheetinfo.xml";
        public string defaultTstruct = "tstruct.xml";
        public string defaultStubReport = "StubReport.dll";
        public string defaultStubResultsProc = "ReferenceResultsProcessor.dll";
        public string defaultStubResultsProcXML = "config.xml";
        public string defaultStubTranslator = "StubTranslator.dll";
        public string defaultStubValuation = "StubValuation.dll";
        public string StubValuationBlankpxr8 = "StubValuationBlankpxr8.dll";
        public string StubValuationBlankpxr7 = "StubValuationBlankpxr7.dll";
        public string StubValuationBlankpxr6 = "StubValuationBlankpxr6.dll";
        public string[] valuationFiles;

        public static string modelTypeETL = "ETL";
        public string modelTypeETLVersionName = genericTestHeader + modelTypeETL;
        public string goldModelTypeVersion = goldTestHeader + modelTypeETL;
        public static string modelTypeInputProcessor = "InputProcessor";
        public string modeltypeInputProcessorName = genericTestHeader + modelTypeInputProcessor;
        public string modeltypeInputProcessorStubName = "Stub" + modelTypeInputProcessor;
        public static string modelTypeParameter = "Parameter";
        public string modelTypeParameterVersionName = genericTestHeader + modelTypeParameter + "Overlay";
        public static string modelTypeResults = "Results";
        public string modelTypeResultsVersionName1 = genericTestHeader + modelTypeResults;
        public string modelTypeResultsVersionName2 = ".AutoDummyTest";

        public static string modelTypeResultsProcessor = "ResultsProcessor";
        public string modelTypeResultProcName = genericTestHeader + modelTypeResultsProcessor;
        public static string modelTypeTranslator = "Translator";
        public string modelTypeTranslatorVersionName = genericTestHeader + modelTypeTranslator;
        public string modelTypeTranslatorVersionName2 = "StubTranslator";
        public static string modelTypeValuation = "Valuation";
        public string modelTypeValuationVersionName = genericTestHeader + modelTypeValuation;
        public string mgHedgeFormatPXR8ModelTypeValuationVersionName = ".AutomationTestMGHedgeFormat-PXR8" + modelTypeValuation;
        public string mgHedgeFormatPXR7ModelTypeValuationVersionName = ".AutomationTestMGHedgeFormat-PXR7" + modelTypeValuation;
        public string mgHedgeFormatPXR6ModelTypeValuationVersionName = ".AutomationTestMGHedgeFormat-PXR6" + modelTypeValuation;
        public string StubValuationDirectory;
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void IdentifyStubETLPlugin()
        {
            //Choose the ETL model type.            
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelTypeETL);
            Task.Delay(waitDelay5).Wait();

            //Hit the ENTER key. (this closes the drop down list)
            HitEnterKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelTypeETL))));

            //Click the Version name drop down
            driver.FindElement(By.XPath("//img[contains(@id, 'VersionComboBox')]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[contains(@id, 'VersionComboBox_DDD_L_LBT')]/tr")));

            //If Modal type version name does not appear then create the Model ETL
            driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", goldModelTypeVersion)));
        }
        public void CreateModelETL()
        {
            //Choose the ETL model type.            
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelTypeETL);
            Task.Delay(waitDelay5).Wait();

            //Hit the ENTER key. (this closes the drop down list)
            HitEnterKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelTypeETL))));

            //Click on the Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(modelTypeETLVersionName);
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'ASPxUploadControl2_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, defaultPluginDirectory, defaultStubETL));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", defaultStubETL))));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'UploadAccept_CD')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));

            //Wait for Version Name field to appear.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id[contains(.,'VersionComboBox_I')]]")));

            //Verify Version Name is correct in field.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("(//input[@value='{0}'])[2]", modelTypeETLVersionName))));

            //Verify File Name is correct.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", defaultStubETL))));
        }
        public void CreateModelInputProcessor()
        {
            //Choose the Results model type.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelTypeInputProcessor);
            Task.Delay(waitDelay5).Wait();

            //Hit the Tab key. (this closes the drop down list)
            HitTabKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelTypeInputProcessor))));

            //Click on the Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Wait for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            if (testVariation == 1)
            {
                driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(modeltypeInputProcessorStubName);
            }
            else
            {
                driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(modeltypeInputProcessorName);
            }
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'ASPxUploadControl2_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, inputProcessorsDirectory, defaultInputProc));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", defaultInputProc))));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'UploadAccept_CD')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
        }
        public bool VerifyAutomatedModelParameterExists()
        {
            //Choose the Parameter model type.            
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelTypeParameter);
            Task.Delay(waitDelay5).Wait();

            //Hit the ENTER key. (this closes the drop down list)
            HitEnterKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelTypeParameter))));

            //Click the Version name drop down
            driver.FindElement(By.XPath("//img[contains(@id, 'VersionComboBox')]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[contains(@id, 'VersionComboBox_DDD_L_LBT')]/tr")));

            //Verify if Model Parameter type version name appears 
            return driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", modelTypeParameterVersionName)));
        }
        public void CreateAutomatedModelParameter()
        {
            if (!VerifyAutomatedModelParameterExists())
            {
                CreateModelParameter();
            }
            else
            {
                Console.WriteLine(string.Format("Parameter Model {0} already exist", modelTypeParameterVersionName));
            }
        }
        public void EnterModelType(string modelType)
        {
            //Choose the Parameter model type.            
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(OpenQA.Selenium.Keys.Control + 'a');
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelType);

            //Hit the ENTER key. (this closes the drop down list)
            HitEnterKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelType))));
        }
        public void EnterVersionName(string versionName)
        {
            //Enter the Version name 
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionComboBox_I')]]")).SendKeys(OpenQA.Selenium.Keys.Control + 'a');
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionComboBox_I')]]")).SendKeys(versionName);
            Task.Delay(waitDelay5).Wait();

            //Hit the ENTER key. (this closes the drop down list)
            HitEnterKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format("//input[@value='{0}']", versionName))));
        }

        public void CreateModelParameter()
        {
            //Choose the Parameter model type.            
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(OpenQA.Selenium.Keys.Control + 'a');
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelTypeParameter);
            Task.Delay(waitDelay5).Wait();

            //Hit the ENTER key. (this closes the drop down list)
            HitEnterKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelTypeParameter))));

            //Click on the Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(OpenQA.Selenium.Keys.Control + 'a');
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(modelTypeParameterVersionName);
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'ASPxUploadControl2_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, defaultPluginDirectory, defaultStubParameter));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", defaultStubParameter))));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'UploadAccept_CD')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));

            //Wait for Version Name field to appear.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id[contains(.,'VersionComboBox_I')]]")));

            //Verify Version Name is correct in field.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("(//input[@value='{0}'])[2]", modelTypeParameterVersionName))));

            //Verify File Name is correct.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", defaultStubParameter))));
        }
        public void CreateModelResults()
        {
            //Choose the Results model type.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelTypeResults);
            Task.Delay(waitDelay5).Wait();

            //Hit the Tab key. (this closes the drop down list)
            HitTabKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelTypeResults))));

            //Click on the Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Wait for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(modelTypeResultsVersionName1);
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'ASPxUploadControl2_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, defaultPluginDirectory, defaultStubReport));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", defaultStubReport))));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'UploadAccept_CD')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
        }
        public void CreateModelResultsProcessor()
        {
            //Choose the ResultsProcessor model type.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelTypeResultsProcessor);
            Task.Delay(waitDelay5).Wait();

            //Hit the Tab key. (this closes the drop down list)
            HitTabKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelTypeResultsProcessor))));

            //Click on the Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Wait for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(modelTypeResultProcName);
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'ASPxUploadControl2_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(string.Format(@"{0}{1}""{2}""""{3}""", mainAutomationDirectory, resultsProcessorsDirectory, defaultStubResultsProc, defaultStubResultsProcXML));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title[contains(.,'{0}')]]", defaultStubResultsProc))));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'UploadAccept_CD')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
        }
        public void CreateModelTranslator()
        {
            //Choose the Translator model type.            
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelTypeTranslator);
            Task.Delay(waitDelay5).Wait();

            //Hit the ENTER key. (this closes the drop down list)
            HitEnterKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelTypeTranslator))));

            //Click on the Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(modelTypeTranslatorVersionName);
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'ASPxUploadControl2_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, defaultPluginDirectory, defaultStubTranslator));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", defaultStubTranslator))));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'UploadAccept_CD')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
        }
        public bool VerifyModelExistInExternalModelsPage(string modelTypeValuation, string modelTypeValuationVersionName)
        {
            //Choose the Valuation model type.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(OpenQA.Selenium.Keys.Control + 'a');
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelTypeValuation);

            //Hit the ENTER key. (this closes the drop down list)
            HitEnterKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelTypeValuation))));

            //Click the Version name drop down
            driver.FindElement(By.XPath("//img[contains(@id, 'VersionComboBox')]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[contains(@id, 'VersionComboBox_DDD_L_LBT')]/tr")));

            //Verify if Model Parameter type version name appears 
            return driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", modelTypeValuationVersionName)));
        }

        public void CreateMGHedgeFormatPXR6ModelValuation()
        {
            //Set required files and location
            StubValuationDirectory = MGHedgeFormatPXR6DefaultValuationDirectory;
            defaultStubValuation = StubValuationBlankpxr6;
            valuationFiles = new string[] { defaultStubValuation, defaultStubParamXML, defaultSheetInfo, defaultTstruct };
            modelTypeValuationVersionName = mgHedgeFormatPXR6ModelTypeValuationVersionName;
            //Check if model already exist else create
            if (!VerifyModelExistInExternalModelsPage(modelTypeValuation, mgHedgeFormatPXR6ModelTypeValuationVersionName))
            {
                CreateModelValuation(valuationFiles);
            }
            else
            {
                Console.WriteLine(string.Format("Valuation Model {0} already exist", modelTypeValuationVersionName));
            }
        }
        public void CreateMGHedgeFormatPXR7ModelValuation()
        {
            //Set required files and location
            StubValuationDirectory = MGHedgeFormatPXR7DefaultValuationDirectory;
            defaultStubValuation = StubValuationBlankpxr7;
            valuationFiles = new string[] { defaultStubValuation, defaultStubParamXML, defaultSheetInfo, defaultTstruct };
            modelTypeValuationVersionName = mgHedgeFormatPXR7ModelTypeValuationVersionName;
            //Check if model already exist else create
            if (!VerifyModelExistInExternalModelsPage(modelTypeValuation, mgHedgeFormatPXR7ModelTypeValuationVersionName))
            {
                CreateModelValuation(valuationFiles);
            }
            else
            {
                Console.WriteLine(string.Format("Valuation Model {0} already exist", modelTypeValuationVersionName));
            }
        }
        public void CreateMGHedgeFormatPXR8ModelValuation()
        {
            //Set required files and location
            StubValuationDirectory = MGHedgeFormatPXR8DefaultValuationDirectory;
            defaultStubValuation = StubValuationBlankpxr8;
            valuationFiles = new string[] { defaultStubValuation, defaultStubParamXML, defaultSheetInfo, defaultTstruct };
            modelTypeValuationVersionName = mgHedgeFormatPXR8ModelTypeValuationVersionName;
            //Check if model already exist else create
            if (!VerifyModelExistInExternalModelsPage(modelTypeValuation, mgHedgeFormatPXR8ModelTypeValuationVersionName))
            {
                CreateModelValuation(valuationFiles);
            }
            else
            {
                Console.WriteLine(string.Format("Valuation Model {0} already exist", modelTypeValuationVersionName));
            }
        }
        public void CreateModelValuation(string valuationFile)
        {
            //Creates Model Valuation with one file
            valuationFiles = new string[] { valuationFile };
            CreateModelValuation(valuationFiles);
        }
        public void CreateModelValuation(string[] valuationFiles)
        {
            //Creates Model Valuation with one or multiple files

            //Choose the Valuation model type.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(OpenQA.Selenium.Keys.Control + 'a');
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelTypeValuation);

            //Hit the ENTER key. (this closes the drop down list)
            HitEnterKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelTypeValuation))));

            //Click on the Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();

            //Wait for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(OpenQA.Selenium.Keys.Control + 'a');
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(modelTypeValuationVersionName);

            //Upload files
            var fileUploadElement = driver.FindElement(By.XPath("//input[contains(@id, 'ASPxUploadControl2_TextBox0_Input')]"));
            foreach (string valuationFile in valuationFiles)
            {
                fileUploadElement.SendKeys(string.Format(@"{0}{1}{2}{3}{4}",
                mainAutomationDirectory, externalModels_2_10_Directory, valuationDirectory, StubValuationDirectory, valuationFile));
            }

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title[contains(.,'{0}')]]", defaultStubValuation))));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).Click();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).SendKeys(genericTestComment);

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'UploadAccept_CD')]]//span[text()='OK']")).Click();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Extracting data from files...']")));

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));

            //Wait for Version Name field to appear.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id[contains(.,'VersionComboBox_I')]]")));

            //Verify Version Name is correct in field.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("(//input[@value='{0}'])[2]", modelTypeValuationVersionName))));

            //Verify file names are correct.
            foreach (string valuationFile in valuationFiles)
            {
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", valuationFile))));
            }
        }
        public void CreateModelValuation()
        {
            waitDelayCustom = 7000;

            //Choose the Valuation model type.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ModelTypeComboBox_I')]]")).SendKeys(modelTypeValuation);
            Task.Delay(waitDelay5).Wait();

            //Hit the ENTER key. (this closes the drop down list)
            HitEnterKey();

            //Waits for table to reload.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//input[@value='{0}']", modelTypeValuation))));

            //Click on the Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            if (data1 == 1)
            {
                //Enter a Version Name.
                driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(modelTypeResultsVersionName2);
                Task.Delay(waitDelay5).Wait();
            }

            else
            {
                //Enter a Version Name.
                driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(modelTypeValuationVersionName);
                Task.Delay(waitDelay5).Wait();
            }

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'ASPxUploadControl2_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(string.Format(@"{0}{1}""{2}""""{3}""", mainAutomationDirectory, defaultPluginDirectory, defaultStubValuation, defaultStubParamXML));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title[contains(.,'{0}')]]", defaultStubValuation))));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CommentTextBox')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'UploadAccept_CD')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelayCustom).Wait();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Extracting data from files...']")));

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
        }
        public void VoidModel()
        {
            //Click on Void button.
            driver.FindElement(By.XPath("//span[text()='Void']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Wait for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Void Model']")));

            //Enter a comment.
            driver.FindElement(By.XPath("//textarea[@id[contains(.,'ModelVoidCommentMemo_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//textarea[@id[contains(.,'ModelVoidCommentMemo_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'VoidModelButton_CD')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Void Model']")));


            //~EXTERNAL MODELS PAGE:-----------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='File Name']"))); //Waits for the File Name column to load.
        }
        #endregion

        #region Fund Map Tests
        public static string fundmap, fundMapName;
        public string fileFundMap = "Fundmap_Stub_";
        public string fundmapETL1 = "Fundmap_Stub_01-08-2019.csv";

        public string fundmapDate1 = "2/26/2019";
        public string fundmapDate2 = "3/30/2019";
        public string fundmapFile = "FundMapSample.csv";
        public string fundmapFile2 = "FundMapPichu.csv";
        public string fundmapFileCloud = "FundMapCloudSample.csv";

        public string fundmapName1 = ".AutomationTestFundMap";
        public string fundmapName2 = "StubFundMap";
        public string fundmapName3 = ".Pichu";
        public string fundmapRename = ".AutomationTestRenameFundMap";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void AddFundMap()
        {
            waitDelayCustom = 10000;

            if (testVariation == 1)
            {
                fundMapName = fundmapName2;
            }
            else
            {
                fundMapName = fundmapName1;
            }

            //Click on Import link.
            driver.FindElement(By.XPath("//a[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Wait for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Enter a Date.
            driver.FindElement(By.XPath("//img[@id[contains(.,'deImportDate_B-1Img')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            if (targetChameleon == 1)
            {
                driver.FindElement(By.XPath("(//button[text()='Today'])[2]")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("(//td[text()='Today'])[2]")).Click();
            }
            Task.Delay(waitDelay5).Wait();

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(fundMapName);
            Task.Delay(waitDelay5).Wait();
            HitEnterKey();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'txtImportComment_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'txtImportComment_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelayLong).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'UploadPopupControl_ucFundMap_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            if (targetTestingLocation == 0)
            {
                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, fundmapDirectory, fundmapFile));
            }

            if (targetTestingLocation == 1)
            {
                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, fundmapDirectory, fundmapFileCloud));
            }

            Task.Delay(waitDelayLongPlus).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@title[contains(.,'FundMap')]]")));

            //Click OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'UploadPopupControl')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelayCustom).Wait();

            //Hit the Enter key.
            SendKeys.SendWait(@"{Enter}");
            Task.Delay(waitDelayMega).Wait();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
        }
        public void CreateActivationFundMaps()
        {
            waitDelayCustom = 10000;

            var fundmap1 = driver.FindElements(By.XPath(string.Format("//tr[td[text()='{0}']]//td[text()='{1}']", fundmapName3, fundmapDate1)));

            if (!fundmap1.Any())
            {
                //Click on Import link.
                driver.FindElement(By.XPath("//a[text()='Import']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Wait for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

                //Enter a Version Name.
                driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(fundmapName3);
                Task.Delay(waitDelay5).Wait();
                HitEnterKey();

                //Enter a Date.
                driver.FindElement(By.XPath("//input[@id[contains(.,'UploadPopupControl_deImportDate_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'UploadPopupControl_deImportDate_I')]]")).SendKeys(fundmapDate1);
                Task.Delay(waitDelay5).Wait();

                //Enter a Comment.
                driver.FindElement(By.XPath("//input[@id[contains(.,'txtImportComment_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'txtImportComment_I')]]")).SendKeys(genericTestComment);
                Task.Delay(waitDelayLong).Wait();

                //Click on Browse button.
                driver.FindElement(By.XPath("//td[@id[contains(.,'UploadPopupControl_ucFundMap_Browse0')]]//a[text()='Browse...']")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, fundmapDirectory, fundmapFile2));
                Task.Delay(waitDelayLongPlus).Wait();
                HitEnterKey();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", fundmapFile2))));

                //Click OK button.
                driver.FindElement(By.XPath("//div[@id[contains(.,'UploadPopupControl')]]//span[text()='OK']")).Click();
                Task.Delay(waitDelayCustom).Wait();

                //Hit the Enter key.
                SendKeys.SendWait(@"{Enter}");
                Task.Delay(waitDelayMega).Wait();

                //Wait for modal to disappear.
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
            }

            var fundmap2 = driver.FindElements(By.XPath(string.Format("//tr[td[text()='{0}']]//td[text()='{1}']", fundmapName3, fundmapDate2)));

            if (!fundmap2.Any())
            {
                //Click on Import link.
                driver.FindElement(By.XPath("//a[text()='Import']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Wait for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

                //Enter a Version Name.
                driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'VersionNameComboBox_I')]]")).SendKeys(fundmapName3);
                Task.Delay(waitDelay5).Wait();
                HitEnterKey();

                //Enter a Date.
                driver.FindElement(By.XPath("//input[@id[contains(.,'UploadPopupControl_deImportDate_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'UploadPopupControl_deImportDate_I')]]")).SendKeys(fundmapDate2);
                Task.Delay(waitDelay5).Wait();

                //Enter a Comment.
                driver.FindElement(By.XPath("//input[@id[contains(.,'txtImportComment_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'txtImportComment_I')]]")).SendKeys(genericTestComment);
                Task.Delay(waitDelayLong).Wait();

                //Click on Browse button.
                driver.FindElement(By.XPath("//td[@id[contains(.,'UploadPopupControl_ucFundMap_Browse0')]]//a[text()='Browse...']")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, fundmapDirectory, fundmapFile2));
                Task.Delay(waitDelayLongPlus).Wait();
                HitEnterKey();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", fundmapFile2))));

                //Click OK button.
                driver.FindElement(By.XPath("//div[@id[contains(.,'UploadPopupControl')]]//span[text()='OK']")).Click();
                Task.Delay(waitDelayCustom).Wait();

                //Hit the Enter key.
                SendKeys.SendWait(@"{Enter}");
                Task.Delay(waitDelayMega).Wait();

                //Wait for modal to disappear.
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
            }
        }
        public void CreateFundMapFile()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                sheetName = string.Format("{0}{1}", fileFundMap, sheetDate);

                excel.Workbook.Worksheets.Add(sheetName);

                //This is what will be included in the A1 cell.
                var headerRow = new List<string[]>()
                {
                   new string[] {"fundmap_date", "fund_id_external", "Fund_Name", "fund_ticker", "fund_cusip", "fund_isin", "fund_number", "riskvariable_name", "fundmap_value", "error_string",}
                };

                //This will determine the header range.
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                //This will target the worksheet.
                var worksheet = excel.Workbook.Worksheets[sheetName];

                //This will populate the header row data.
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                //This will populate data into specific cells.
                worksheet.Cells["A2"].Value = fundMapDate;
                worksheet.Cells["B2"].Value = "Fund1";
                worksheet.Cells["C2"].Value = "Fund1";
                worksheet.Cells["D2"].Value = "NULL";
                worksheet.Cells["E2"].Value = "NULL";
                worksheet.Cells["F2"].Value = "NULL";
                worksheet.Cells["G2"].Value = "NULL";
                worksheet.Cells["H2"].Value = "LBUSMD Index";
                worksheet.Cells["I2"].Value = 80;
                worksheet.Cells["J2"].Value = "NULL";

                worksheet.Cells["A3"].Value = fundMapDate;
                worksheet.Cells["B3"].Value = "Fund2";
                worksheet.Cells["C3"].Value = "Fund2";
                worksheet.Cells["D3"].Value = "NULL";
                worksheet.Cells["E3"].Value = "NULL";
                worksheet.Cells["F3"].Value = "NULL";
                worksheet.Cells["G3"].Value = "NULL";
                worksheet.Cells["H3"].Value = "LBUSMD Index";
                worksheet.Cells["I3"].Value = 80;
                worksheet.Cells["J3"].Value = "NULL";

                worksheet.Cells["A3"].Value = fundMapDate;
                worksheet.Cells["B3"].Value = "Fund3";
                worksheet.Cells["C3"].Value = "Fund3";
                worksheet.Cells["D3"].Value = "NULL";
                worksheet.Cells["E3"].Value = "NULL";
                worksheet.Cells["F3"].Value = "NULL";
                worksheet.Cells["G3"].Value = "NULL";
                worksheet.Cells["H3"].Value = "LBUSMD Index";
                worksheet.Cells["I3"].Value = 80;
                worksheet.Cells["J3"].Value = "NULL";

                worksheet.Cells["A3"].Value = fundMapDate;
                worksheet.Cells["B3"].Value = "Fund4";
                worksheet.Cells["C3"].Value = "Fund4";
                worksheet.Cells["D3"].Value = "NULL";
                worksheet.Cells["E3"].Value = "NULL";
                worksheet.Cells["F3"].Value = "NULL";
                worksheet.Cells["G3"].Value = "NULL";
                worksheet.Cells["H3"].Value = "LBUSMD Index";
                worksheet.Cells["I3"].Value = 80;
                worksheet.Cells["J3"].Value = "NULL";

                targetPath = etlDirectoryCustomTemp;

                //This is what the file will be saved as.
                FileInfo excelFile = new FileInfo(string.Format("{0}{1}_{2}.xlsx", targetPath, fileFundMap, fundMapFileDate));
                excel.SaveAs(excelFile);

                string filePath = string.Format("{0}{1}_{2}.xlsx", targetPath, fileFundMap, fundMapFileDate);

                Task.Delay(waitDelay6).Wait();

                Workbook workbook = new Workbook(filePath);
                workbook.Save(string.Format("{0}{1}_{2}.csv", targetPath, fileFundMap, fundMapFileDate), SaveFormat.CSV);

                string filePath2 = string.Format("{0}{1}_{2}.csv", targetPath, fileFundMap, fundMapFileDate);

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath2);
                try
                {
                    Microsoft.Office.Interop.Excel.Sheets excelWorkSheet = excelWorkbook.Sheets;
                    foreach (Microsoft.Office.Interop.Excel.Worksheet work in excelWorkSheet)
                    {
                        Microsoft.Office.Interop.Excel.Range range = work.get_Range("A4");
                        Microsoft.Office.Interop.Excel.Range entireRow = range.EntireRow;
                        entireRow.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlUp);
                    }

                    excelWorkbook.Save();
                }
                catch (Exception)
                {

                }

                finally
                {
                    excelApp.Quit();
                    Task.Delay(waitDelay5).Wait();
                    SendKeys.SendWait(@"{N}");
                }
            }
        }
        public void CreateFundMapCopy()
        {
            //Click on Save As... link.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Save As...']", fundmapName1))).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for Save As... popup window to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id[contains(.,'ForkPopup_PW-1')]]")));
            Task.Delay(waitDelayLong).Wait();

            //Enter a New Version Name
            driver.FindElement(By.XPath("//input[@id[contains(.,'ForkNameTxt_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ForkNameTxt_I')]]")).SendKeys(fundmapRename);
            Task.Delay(waitDelay5).Wait();

            //Click on Namespace field.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//td[text()='Working Version']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ForkCommentTxt_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ForkCommentTxt_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'ForkPopup_ctl18_CD')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for Save As... popup window to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id[contains(.,'ForkPopup_PW-1')]]")));
        }
        public void RemoveFundMap()
        {
            //Click on Void link for test fundmap.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Void']", fundmap))).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Wait for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Void Fund Map']")));

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'VoidFundMapButton')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Void Fund Map']")));
        }
        #endregion

        #region Holiday Tests
        public string deleteGroup, testDateTrunc;
        public string holidayDay = "25";
        public string holidayDayEdit = "3";
        public string holidayDesBase = ".Automation Test Holiday";

        public static string holidayGroup = "Default Holidays";
        public static string holidayGroupTest = "AutoTestHolidayGroup";
        public static string holidayGroup30Plus = "HolidayGroupNameWith30CharactersPlus5";
        public string holidayGroup30PlusTrunc = holidayGroup30Plus.Substring(0, holidayGroup30Plus.Length - 5);
        public string holidayMonth = "April";
        public string holidayMonthEdit = "February";
        public static string holidayOneTimeDate = "6/30/2018";
        public static string holidayOneTimeDateEdit = "8/14/2018";

        public string relativeWeekDay = "Wednesday";
        public string relativeWeekDayEdit = "Friday";
        public string relativeWeekIndex = "Second";
        public string relativeWeekIndexEdit = "First";
        public string relativeMonthEdit = "May";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void CreateHoliday()
        {
            //~Precise---------------------------------------------------------------------------------------------------------------
            //Click on New Holiday button.
            driver.FindElement(By.XPath("//span[text()='New Holiday']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Holiday Type']")));

            var radioSelected = driver.FindElement(By.XPath("//tr[td/span[@class[contains(.,'edtRadioButtonChecked_SoftOrange')]]]//label[text()='Precise']"));

            if (!radioSelected.Displayed)
            {
                //Choose Precise radio button.
                driver.FindElement(By.XPath("//tr[td/label[text()='Precise']]//span[@class[contains(.,'edtRadioButtonChecked_SoftOrange')]]")).Click();
                Task.Delay(waitDelay5).Wait();
            }

            //Enter a Group.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_TokenGroupBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_TokenGroupBox_I')]]")).SendKeys(holidayGroup);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Hit the Esc key.
            SendKeys.SendWait(@"{Esc}");
            Task.Delay(waitDelay5).Wait();

            //Enter a Month.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbPreciseMonth_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbPreciseMonth_I')]]")).SendKeys(holidayMonth);
            Task.Delay(waitDelay5).Wait();

            //Enter a Day.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbPreciseDay_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbPreciseDay_I')]]")).SendKeys(holidayDay);
            Task.Delay(waitDelay5).Wait();

            //Enter a Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtPreciseDescription_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtPreciseDescription_I')]]")).SendKeys(holidayDesBase + " Precise");
            Task.Delay(waitDelay5).Wait();

            //Click the Save button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'NewHolidayDialog_btnSave_CD')]]//span[text()='Save']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Holiday Type']")));

            //Waits for item to appear.
            wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format("//td[text()='{0}']", holidayDesBase + " Precise"))));

            //~One Time--------------------------------------------------------------------------------------------------------------
            //Click on New Holiday button.
            driver.FindElement(By.XPath("//span[text()='New Holiday']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Holiday Type']")));

            //Choose One Time radio button.
            driver.FindElement(By.XPath("//label[text()='One Time']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Enter a Group.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_TokenGroupBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_TokenGroupBox_I')]]")).SendKeys(holidayGroup);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Hit the Esc key.
            SendKeys.SendWait(@"{Esc}");
            Task.Delay(waitDelay5).Wait();

            //Enter a Date.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_deOneTime_')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_deOneTime_')]]")).SendKeys(holidayOneTimeDate);
            Task.Delay(waitDelay5).Wait();

            //Enter a Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtOneTimeDescription_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtOneTimeDescription_I')]]")).SendKeys(holidayDesBase + " One Time");
            Task.Delay(waitDelay5).Wait();

            //Click the Save button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'NewHolidayDialog_btnSave_CD')]]//span[text()='Save']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Holiday Type']")));

            //Waits for item to appear.
            wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format("//td[text()='{0}']", holidayDesBase + " Precise"))));

            //~Relative-------------------------------------------------------------------------------------------------------------
            //Click on New Holiday button.
            driver.FindElement(By.XPath("//span[text()='New Holiday']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Holiday Type']")));

            //Choose Relative radio button.
            driver.FindElement(By.XPath("//label[text()='Relative']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Enter a Group.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_TokenGroupBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_TokenGroupBox_I')]]")).SendKeys(holidayGroup);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Hit the Esc key.
            SendKeys.SendWait(@"{Esc}");
            Task.Delay(waitDelay5).Wait();

            //Enter a week frequency.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbRelativeIndex_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbRelativeIndex_I')]]")).SendKeys(relativeWeekIndex);
            Task.Delay(waitDelay5).Wait();

            //Enter a week day.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbRelativeWeekday_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbRelativeWeekday_I')]]")).SendKeys(relativeWeekDay);
            Task.Delay(waitDelay5).Wait();

            //Enter a month.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbRelativeMonth_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbRelativeMonth_I')]]")).SendKeys(holidayMonth);
            Task.Delay(waitDelay5).Wait();

            //Enter a Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtRelativeDescription_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtRelativeDescription_I')]]")).SendKeys(holidayDesBase + " Relative");
            Task.Delay(waitDelay5).Wait();

            //Click the Save button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'NewHolidayDialog_btnSave_CD')]]//span[text()='Save']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Holiday Type']")));

            //Waits for item to appear.
            wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format("//td[text()='{0}']", holidayDesBase + " Precise"))));
        }
        public void DeleteHoliday()
        {
            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerMinutePlus && timer.IsRunning.Equals(true))
            {
                var holidayGroups = driver.FindElements(By.XPath(string.Format("//tr[td[text()[contains(.,'{0}')]]]//span[text()='Delete']", holidayDesBase)));

                if (holidayGroups.Any())
                {
                    //Delete holiday.
                    driver.FindElement(By.XPath(string.Format("//tr[td[text()[contains(.,'{0}')]]]//span[text()='Delete']", holidayDesBase))).Click();
                    Task.Delay(waitDelaySuper).Wait();

                    //Hit the Enter key.
                    HitEnterKey();
                    Task.Delay(waitDelaySuper).Wait();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }
        }
        public void EditHoliday()
        {
            //~Precise---------------------------------------------------------------------------------------------------------------
            //Edit holiday.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()[contains(.,'{0} Precise')]]]//span[text()='Edit']", holidayDesBase))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Holiday Type']")));

            //Enter a Group.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_TokenGroupBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("(//td[text()='{0}'])[2]", holidayGroup30PlusTrunc))).Click();
            Task.Delay(waitDelay5).Wait();

            //Hit the Tab key.
            HitTabKey();

            //Enter a Month.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbPreciseMonth_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("(//td[text()='{0}'])[1]", holidayMonthEdit))).Click(); //Chooses February.
            Task.Delay(waitDelay5).Wait();

            //Enter a Day.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbPreciseDay_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//td[@id[contains(.,'cmbPreciseDay_DDD_L_LBI2T0')]]")).Click(); //Chooses 3.
            Task.Delay(waitDelay5).Wait();

            //Enter a Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtPreciseDescription_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtPreciseDescription_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtPreciseDescription_I')]]")).SendKeys(holidayDesBase + " Precise");
            Task.Delay(waitDelay5).Wait();

            //Click the Update button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'NewHolidayDialog_btnSave_CD')]]//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Holiday Type']")));

            //~One Time---------------------------------------------------------------------------------------------------------------
            //Edit holiday.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()[contains(.,'{0} One Time')]]]//span[text()='Edit']", holidayDesBase))).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Holiday Type']")));

            //Enter a Group.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_TokenGroupBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("(//td[text()='{0}'])[2]", holidayGroup30PlusTrunc))).Click();
            Task.Delay(waitDelay5).Wait();

            //Hit the Tab key.
            HitTabKey();

            //Enter a Date.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_deOneTime_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_deOneTime_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_deOneTime_I')]]")).SendKeys(holidayOneTimeDateEdit);
            Task.Delay(waitDelay5).Wait();

            //Enter a Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtOneTimeDescription_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtOneTimeDescription_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtOneTimeDescription_I')]]")).SendKeys(holidayDesBase + " One Time");
            Task.Delay(waitDelay5).Wait();

            //Click the Update button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'NewHolidayDialog_btnSave_CD')]]//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Holiday Type']")));

            //~Relative-------------------------------------------------------------------------------------------------------------
            //Edit holiday.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()[contains(.,'{0} Relative')]]]//span[text()='Edit']", holidayDesBase))).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Holiday Type']")));

            //Enter a Group.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_TokenGroupBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("(//td[text()='{0}'])[2]", holidayGroup30PlusTrunc))).Click();
            Task.Delay(waitDelay5).Wait();

            //Hit the Tab key.
            HitTabKey();

            //Enter a week frequency.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbRelativeIndex_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("//td[text()='{0}']", relativeWeekIndexEdit))).Click();
            Task.Delay(waitDelay5).Wait();

            //Enter a week day.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbRelativeWeekday_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("//td[text()='{0}']", relativeWeekDayEdit))).Click(); // Chooses Friday
            Task.Delay(waitDelay5).Wait();

            //Enter a month.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_cmbRelativeMonth_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("//table[@id[contains(.,'NewHolidayDialog_cmbRelativeMonth_DDD_L_LBT')]]//td[text()='{0}']", relativeMonthEdit))).Click(); //Chooses May
            Task.Delay(waitDelay5).Wait();

            //Enter a Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtRelativeDescription_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtRelativeDescription_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NewHolidayDialog_txtRelativeDescription_I')]]")).SendKeys(holidayDesBase + " Relative");
            Task.Delay(waitDelay5).Wait();

            //Click the Update button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'NewHolidayDialog_btnSave_CD')]]//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Holiday Type']")));
        }
        public void CreateHolidayGroup()
        {
            if (testVariation == 1)
            {
                holidayGroup = holidayGroupTest;
            }

            else
            {
                holidayGroup = holidayGroup30PlusTrunc;
            }

            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Name:']")));

            //Enter a holiday group name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'HolidayGroupGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'HolidayGroupGridView_DXEFL_DXEditor0_I')]]")).SendKeys(holidayGroup);
            Task.Delay(waitDelay5).Wait();

            //Enter a holiday group description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'HolidayGroupGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'HolidayGroupGridView_DXEFL_DXEditor1_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on Update link.
            driver.FindElement(By.XPath("(//span[text()='Update'])[1]")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for field to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//label[text()='Name:']")));
        }
        public void DeleteHolidayGroup()
        {
            if (testVariation == 1)
            {
                //Delete holiday group.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", holidayGroupTest))).Click();
                Task.Delay(waitDelayMega).Wait();
            }
            else
            {
                //Delete holiday group.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", holidayGroup30PlusTrunc))).Click();
                Task.Delay(waitDelayMega).Wait();
            }
        }
        #endregion

        #region Inforce Stub Creation Tests
        public string fileDeposit = "Deposit_Stub_";
        public string fileFundInfo = "FundInfo_Stub_";
        public string filePolicy = "Policy_Stub";
        public string fileSuffix = "A";
        public string inforceDate, inforceFileDate, inforceName, targetPath, sheetDate, sheetName;
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void CreateDepositFile()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                if (inforceName == inforceDTName1)
                {
                    sheetName = string.Format("{0}{1}", fileDeposit, sheetDate);
                }

                if (inforceName == inforceDTName2)
                {
                    sheetName = string.Format("{0}{1}{2}", fileDeposit, fileSuffix, sheetDate);
                }

                excel.Workbook.Worksheets.Add(sheetName);

                //This is what will be included in the A1 cell.
                var headerRow = new List<string[]>()
                {
                    new string[] { "inforce_date", "author", "policy_number", "policy_product", "fund_id_external", "fund_value" }
                };

                //This will determine the header range.
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                //This will target the worksheet.
                var worksheet = excel.Workbook.Worksheets[sheetName];

                //This will populate the header row data.
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                //This will populate data into specific cells.
                worksheet.Cells["A2"].Value = inforceDate;
                worksheet.Cells["B2"].Value = "Inforce1";
                worksheet.Cells["C2"].Value = 900;
                worksheet.Cells["D2"].Value = "StubStub";
                worksheet.Cells["E2"].Value = 200;
                worksheet.Cells["F2"].Value = 998;

                targetPath = etlDirectoryCustomTemp;

                //This is what the file will be saved as.
                if (inforceName == inforceDTName1)
                {
                    FileInfo excelFile = new FileInfo(string.Format("{0}{1}_{2}.xlsx", targetPath, fileDeposit, inforceFileDate));
                    excel.SaveAs(excelFile);

                    string filePath = string.Format("{0}{1}_{2}.xlsx", targetPath, fileDeposit, inforceFileDate);

                    Workbook workbook = new Workbook(filePath);
                    workbook.Save(string.Format("{0}{1}_{2}.csv", targetPath, fileDeposit, inforceFileDate), SaveFormat.CSV);

                    string filePath2 = string.Format("{0}{1}_{2}.csv", targetPath, fileDeposit, inforceFileDate);

                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath2);
                    try
                    {
                        Microsoft.Office.Interop.Excel.Sheets excelWorkSheet = excelWorkbook.Sheets;
                        foreach (Microsoft.Office.Interop.Excel.Worksheet work in excelWorkSheet)
                        {
                            Microsoft.Office.Interop.Excel.Range range = work.get_Range("A3");
                            Microsoft.Office.Interop.Excel.Range entireRow = range.EntireRow;
                            entireRow.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlUp);
                        }

                        excelWorkbook.Save();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        excelApp.Quit();
                        Task.Delay(waitDelay5).Wait();
                        SendKeys.SendWait(@"{N}");
                    }
                }

                if (inforceName == inforceDTName2)
                {
                    FileInfo excelFile = new FileInfo(string.Format("{0}{1}{2}_{3}.xlsx", targetPath, fileDeposit, fileSuffix, inforceFileDate));
                    excel.SaveAs(excelFile);

                    string filePath = string.Format("{0}{1}{2}_{3}.xlsx", targetPath, fileDeposit, fileSuffix, inforceFileDate);

                    Workbook workbook = new Workbook(filePath);
                    workbook.Save(string.Format("{0}{1}{2}_{3}.csv", targetPath, fileDeposit, fileSuffix, inforceFileDate), SaveFormat.CSV);

                    string filePath2 = string.Format("{0}{1}{2}_{3}.csv", targetPath, fileDeposit, fileSuffix, inforceFileDate);

                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath2);
                    try
                    {
                        Microsoft.Office.Interop.Excel.Sheets excelWorkSheet = excelWorkbook.Sheets;
                        foreach (Microsoft.Office.Interop.Excel.Worksheet work in excelWorkSheet)
                        {
                            Microsoft.Office.Interop.Excel.Range range = work.get_Range("A3");
                            Microsoft.Office.Interop.Excel.Range entireRow = range.EntireRow;
                            entireRow.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlUp);
                        }

                        excelWorkbook.Save();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        excelApp.Quit();
                        Task.Delay(waitDelay5).Wait();
                        SendKeys.SendWait(@"{N}");
                    }
                }
            }
        }
        public void CreateFundInfoFile()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                if (inforceName == inforceDTName1)
                {
                    sheetName = string.Format("{0}{1}", fileFundInfo, sheetDate);
                }

                if (inforceName == inforceDTName2)
                {
                    sheetName = string.Format("{0}{1}{2}", fileFundInfo, fileSuffix, sheetDate);
                }

                excel.Workbook.Worksheets.Add(sheetName);

                //This is what will be included in the A1 cell. (For a stub fund file, just leave this blank.)
                var headerRow = new List<string[]>()
                {
                    new string[] { "inforce_date", "author", "policy_product", "fund_id_external", "fund_name" , "fund_nav", "fund_distributions", "fund_lnreturn", "fund_misc", "fund_revision", "fee_name", "fee_value", "error_string", "fund_return" }
                };

                //This will determine the header range.
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                //This will target the worksheet.
                var worksheet = excel.Workbook.Worksheets[sheetName];

                //This will populate the header row data.
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                //This will populate data into specific cells.
                worksheet.Cells["A2"].Value = inforceDate;
                worksheet.Cells["B2"].Value = "Inforce1";
                worksheet.Cells["C2"].Value = "StubStub";
                worksheet.Cells["D2"].Value = "Fund1";
                worksheet.Cells["E2"].Value = "Fund1";
                worksheet.Cells["F2"].Value = 1;
                worksheet.Cells["G2"].Value = "NULL";
                worksheet.Cells["H2"].Value = "NULL";
                worksheet.Cells["I2"].Value = "NULL";
                worksheet.Cells["J2"].Value = 0;
                worksheet.Cells["K2"].Value = "FeeFee";
                worksheet.Cells["L2"].Value = 98;
                worksheet.Cells["M2"].Value = "NULL";
                worksheet.Cells["N2"].Value = 98;

                targetPath = etlDirectoryCustomTemp;

                //This is what the file will be saved as.
                if (inforceName == inforceDTName1)
                {
                    FileInfo excelFile = new FileInfo(string.Format("{0}{1}_{2}.xlsx", targetPath, fileFundInfo, inforceFileDate));
                    excel.SaveAs(excelFile);

                    string filePath = string.Format("{0}{1}_{2}.xlsx", targetPath, fileFundInfo, inforceFileDate);

                    Workbook workbook = new Workbook(filePath);
                    workbook.Save(string.Format("{0}{1}_{2}.csv", targetPath, fileFundInfo, inforceFileDate), SaveFormat.CSV);

                    string filePath2 = string.Format("{0}{1}_{2}.csv", targetPath, fileFundInfo, inforceFileDate);

                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath2);
                    try
                    {
                        Microsoft.Office.Interop.Excel.Sheets excelWorkSheet = excelWorkbook.Sheets;
                        foreach (Microsoft.Office.Interop.Excel.Worksheet work in excelWorkSheet)
                        {
                            Microsoft.Office.Interop.Excel.Range range = work.get_Range("A3");
                            Microsoft.Office.Interop.Excel.Range entireRow = range.EntireRow;
                            entireRow.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlUp);
                        }

                        excelWorkbook.Save();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        excelApp.Quit();
                        Task.Delay(waitDelay5).Wait();
                        SendKeys.SendWait(@"{N}");
                    }
                }

                if (inforceName == inforceDTName2)
                {
                    FileInfo excelFile = new FileInfo(string.Format("{0}{1}{2}_{3}.xlsx", targetPath, fileFundInfo, fileSuffix, inforceFileDate));
                    excel.SaveAs(excelFile);

                    string filePath = string.Format("{0}{1}{2}_{3}.xlsx", targetPath, fileFundInfo, fileSuffix, inforceFileDate);

                    Workbook workbook = new Workbook(filePath);
                    workbook.Save(string.Format("{0}{1}{2}_{3}.csv", targetPath, fileFundInfo, fileSuffix, inforceFileDate), SaveFormat.CSV);

                    string filePath2 = string.Format("{0}{1}{2}_{3}.csv", targetPath, fileFundInfo, fileSuffix, inforceFileDate);

                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath2);
                    try
                    {
                        Microsoft.Office.Interop.Excel.Sheets excelWorkSheet = excelWorkbook.Sheets;
                        foreach (Microsoft.Office.Interop.Excel.Worksheet work in excelWorkSheet)
                        {
                            Microsoft.Office.Interop.Excel.Range range = work.get_Range("A3");
                            Microsoft.Office.Interop.Excel.Range entireRow = range.EntireRow;
                            entireRow.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlUp);
                        }

                        excelWorkbook.Save();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        excelApp.Quit();
                        Task.Delay(waitDelay5).Wait();
                        SendKeys.SendWait(@"{N}");
                    }
                }
            }
        }
        public void CreatePolicyFile()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                if (inforceName == inforceDTName1)
                {
                    sheetName = string.Format("{0}{1}", filePolicy, sheetDate);
                }

                if (inforceName == inforceDTName2)
                {
                    sheetName = string.Format("{0}{1}{2}", filePolicy, fileSuffix, sheetDate);
                }

                excel.Workbook.Worksheets.Add(sheetName);

                //This is what will be included in the A1 cell.
                var headerRow = new List<string[]>()
                {
                   new string[] {"policy_number", "policy_seed", "policy_product", "policy_issuedate", "policy_owner_dob", "policy_owner_sex", "policy_owner_status", "policy_accountvalue", "policy_totalpremiums", "policy_maturitydate", "GMDB_type", "GMDB_issue_date", "GMDB_balance",}
                };

                //This will determine the header range.
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                //This will target the worksheet.
                var worksheet = excel.Workbook.Worksheets[sheetName];

                //This will populate the header row data.
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                //This will populate data into specific cells.
                worksheet.Cells["A2"].Value = 0;
                worksheet.Cells["B2"].Value = 479;
                worksheet.Cells["C2"].Value = "StubStub";
                worksheet.Cells["D2"].Value = "4/10/2013 11:13";
                worksheet.Cells["E2"].Value = "3/3/2007 11:13";
                worksheet.Cells["F2"].Value = 1;
                worksheet.Cells["G2"].Value = "TRUE";
                worksheet.Cells["H2"].Value = 99488980;
                worksheet.Cells["I2"].Value = 17477670;
                worksheet.Cells["J2"].Value = "12/1/2010 11:13";
                worksheet.Cells["K2"].Value = "a";
                worksheet.Cells["L2"].Value = "10/19/2007 11:13";
                worksheet.Cells["M2"].Value = 22614590;

                worksheet.Cells["A3"].Value = 1;
                worksheet.Cells["B3"].Value = 179;
                worksheet.Cells["C3"].Value = "StubStub";
                worksheet.Cells["D3"].Value = "9/16/2013 11:13";
                worksheet.Cells["E3"].Value = "10/8/2007 11:13";
                worksheet.Cells["F3"].Value = 1;
                worksheet.Cells["G3"].Value = "TRUE";
                worksheet.Cells["H3"].Value = 18078280;
                worksheet.Cells["I3"].Value = 18751380;
                worksheet.Cells["J3"].Value = "8/29/2011 11:13";
                worksheet.Cells["K3"].Value = "a";
                worksheet.Cells["L3"].Value = "1/26/2016 11:13";
                worksheet.Cells["M3"].Value = 85691780;

                targetPath = etlDirectoryCustomTemp;

                //This is what the file will be saved as.
                if (inforceName == inforceDTName1)
                {
                    FileInfo excelFile = new FileInfo(string.Format("{0}{1}_{2}.xlsx", targetPath, filePolicy, inforceFileDate));
                    excel.SaveAs(excelFile);

                    string filePath = string.Format("{0}{1}_{2}.xlsx", targetPath, filePolicy, inforceFileDate);

                    Task.Delay(waitDelay6).Wait();

                    Workbook workbook = new Workbook(filePath);
                    workbook.Save(string.Format("{0}{1}_{2}.csv", targetPath, filePolicy, inforceFileDate), SaveFormat.CSV);

                    string filePath2 = string.Format("{0}{1}_{2}.csv", targetPath, filePolicy, inforceFileDate);

                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath2);
                    try
                    {
                        Microsoft.Office.Interop.Excel.Sheets excelWorkSheet = excelWorkbook.Sheets;
                        foreach (Microsoft.Office.Interop.Excel.Worksheet work in excelWorkSheet)
                        {
                            Microsoft.Office.Interop.Excel.Range range = work.get_Range("A4");
                            Microsoft.Office.Interop.Excel.Range entireRow = range.EntireRow;
                            entireRow.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlUp);
                        }

                        excelWorkbook.Save();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        excelApp.Quit();
                        Task.Delay(waitDelay5).Wait();
                        SendKeys.SendWait(@"{N}");
                    }
                }

                if (inforceName == inforceDTName2)
                {
                    FileInfo excelFile = new FileInfo(string.Format("{0}{1}{2}_{3}.xlsx", targetPath, filePolicy, fileSuffix, inforceFileDate));
                    excel.SaveAs(excelFile);

                    string filePath = string.Format("{0}{1}{2}_{3}.xlsx", targetPath, filePolicy, fileSuffix, inforceFileDate);

                    Task.Delay(waitDelay6).Wait();

                    Workbook workbook = new Workbook(filePath);
                    workbook.Save(string.Format("{0}{1}{2}_{3}.csv", targetPath, filePolicy, fileSuffix, inforceFileDate), SaveFormat.CSV);

                    string filePath2 = string.Format("{0}{1}{2}_{3}.csv", targetPath, filePolicy, fileSuffix, inforceFileDate);

                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath2);
                    try
                    {
                        Microsoft.Office.Interop.Excel.Sheets excelWorkSheet = excelWorkbook.Sheets;
                        foreach (Microsoft.Office.Interop.Excel.Worksheet work in excelWorkSheet)
                        {
                            Microsoft.Office.Interop.Excel.Range range = work.get_Range("A4");
                            Microsoft.Office.Interop.Excel.Range entireRow = range.EntireRow;
                            entireRow.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlUp);
                        }

                        excelWorkbook.Save();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        excelApp.Quit();
                        Task.Delay(waitDelay5).Wait();
                        SendKeys.SendWait(@"{N}");
                    }
                }
            }
        }
        #endregion

        #region Inforce Step Tests
        public string inforceCategory = "Test Category";
        public string inforceCompressionStep = "9";
        public string inforceStep = "9";
        public string inforceInputSchema = "table input test";
        public string inforceOutputSchema = "table output test";
        public string inforceType = "Test Inforce";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void CreateInforceStep()
        {
            //Click on New link.
            driver.FindElement(By.XPath("//a[text()='New']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Enter a Step.
            driver.FindElement(By.XPath("//input[@id[contains(.,'InforceStepsGridView_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'InforceStepsGridView_DXEditor1_I')]]")).SendKeys(inforceStep);
            Task.Delay(waitDelay5).Wait();

            //Enter a Compression of Step.
            driver.FindElement(By.XPath("(//div[@class='dxgBCTC'])[2]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'InforceStepsGridView_DXEditor2_I')]]")).SendKeys(inforceCompressionStep);
            Task.Delay(waitDelay5).Wait();

            //Enter an Input Schema.
            driver.FindElement(By.XPath("(//div[@class='dxgBCTC'])[3]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'InforceStepsGridView_DXEditor3_I')]]")).SendKeys(inforceInputSchema);
            Task.Delay(waitDelay5).Wait();

            //Enter an Output Schema.
            driver.FindElement(By.XPath("(//div[@class='dxgBCTC'])[4]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'InforceStepsGridView_DXEditor4_I')]]")).SendKeys(inforceOutputSchema);
            Task.Delay(waitDelay5).Wait();

            //Enter a Category.
            driver.FindElement(By.XPath("(//div[@class='dxgBCTC'])[5]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'InforceStepsGridView_DXEditor5_I')]]")).SendKeys(inforceCategory);
            Task.Delay(waitDelay5).Wait();

            //Enter a Description.
            driver.FindElement(By.XPath("(//div[@class='dxgBCTC'])[6]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'InforceStepsGridView_DXEditor6_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on Save Changes.
            driver.FindElement(By.XPath("//span[text()='Save Changes']")).Click();
            Task.Delay(waitDelayMega).Wait();
        }
        public void DeleteInforceStep()
        {
            //Delete inforce step.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", genericTestComment))).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//span[text()='Save Changes']")).Click();
            Task.Delay(waitDelayMega).Wait();
        }
        #endregion

        #region Liability Data Tests
        public string newVersionName = "New Version Test";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void SaveAsNewInforce()
        {
            //Save inforce as a new instance.
            driver.FindElement(By.XPath("//tr[td/text()='1/2/2100']//td/a/span[text()='Save As...']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for Save As modal to load.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'z-index: 12000; visibility: visible')]]")));

            //Enter a Comment.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_ForkPopup_ForkCommentTxt_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_ForkPopup_ForkCommentTxt_I")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Enter a New Version Name.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_ForkPopup_ForkNameTxt_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_ForkPopup_ForkNameTxt_I")).SendKeys(newVersionName);
            Task.Delay(waitDelay5).Wait();

            //Click on OK button.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_ForkPopup_ctl18_CD")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for first row's Activate link to load.
            wait.Until(ExpectedConditions.ElementExists(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_BalanceSheetGridView_DXCBtn0")));
        }
        public void VoidInforce()
        {
            //Click on Void link.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Void']", Id))).Click();
            Task.Delay(waitDelayLongPlus).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Void Balance Sheet']")));

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'VoidBalanceSheetButton')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for first row's expand icon to load.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']")));
        }
        #endregion

        #region Namespace Tests
        public string namespaceGrid;
        public static string namespaceName = "Working Version";
        public string namespaceNameEdit = namespaceName + "-";
        public static string namespaceDescription = "This is the active, working version of the program.";
        public string namespaceDescriptionEdit = namespaceDescription + "-";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void NamespaceEdit1()
        {
            //Edit the Namespace record.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Edit']", namespaceName))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Name:']")));

            //Edit the Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor1_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor1_I')]]")).SendKeys(namespaceNameEdit);
            Task.Delay(waitDelay5).Wait();

            //Edit the Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor2_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor2_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor2_I')]]")).SendKeys(namespaceDescriptionEdit);
            Task.Delay(waitDelay5).Wait();

            //Edit the Default Grid.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor3_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("//td[text()='{0}']", namespaceGrid))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayCustom).Wait();
        }
        public void NamespaceEdit2()
        {
            //Edit the Namespace record.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Edit']", namespaceNameEdit))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Name:']")));

            //Edit the Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor1_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor1_I')]]")).SendKeys(namespaceName);
            Task.Delay(waitDelay5).Wait();

            //Edit the Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor2_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor2_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor2_I')]]")).SendKeys(namespaceDescription);
            Task.Delay(waitDelay5).Wait();

            //Edit the Default Grid.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor3_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceGridView_DXEFL_DXEditor3_I')]]")).Clear();
            Task.Delay(waitDelayLong).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayCustom).Wait();
        }
        #endregion

        #region Parameter Set Tests
        public string parameterName1 = ".Automation Parameter Set";
        public string parameterName2 = ".Automation Same Name Test";
        public static string parameterNameBad = "param-bad";
        public string hedgeOpsFormatParameterName = ".AutomationHedgeOpsFormatParameterSet";
        public string MGHedgeFormatParameterName = ".AutomationMGHedgeFormatParameterSet";

        public string parameterFile = "TestParameterSet.csv";
        public string parameterFileBad = parameterNameBad + extTXT;
        public string pxr8HedgeOpsFormatParameterSetFile = "PXR8HedgeOpsFormatParameterSet.csv";
        public string paramtxt = "param.txt";
        public string sheetinfotxt = "sheetinfo.txt";
        public string tstructtxt = "tstruct.txt";

        public string parameterDate1 = "9/18/2018";
        public string parameterDate2 = "10/10/2018";
        public string versionUpComment = ".Automation Test Version Up";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void CreateMGHedgeFormatParameterSet()
        {
            //Check if Automated Hedge Ops Parameter Set already exist else create
            if (!driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[text()='{1}']", MGHedgeFormatParameterName, parameterDate1))))
            {
                AddMGHedgeFormatParameterSet();
            }
            else
            {
                Console.WriteLine(string.Format("Parameter Set {0} already exist", MGHedgeFormatParameterName));
            }
        }
        public void AddMGHedgeFormatParameterSet()
        {
            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Parameter Set']")));

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).Click();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).SendKeys(MGHedgeFormatParameterName);

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).Click();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).SendKeys(genericTestComment);

            //Enter a Version Date.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_DateEditor_I')]]")).Click();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_DateEditor_I')]]")).SendKeys(parameterDate1);

            //Select MG Hedge Upload Format.
            driver.FindElement(By.XPath("//span[@id[contains(.,'UploadFormatRadio_RB1_I_D')]]")).Click();

            //Select the model
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//label[text() ='Model (?):']"))));
            driver.FindElement(By.XPath("//input[contains(@id,'4_ModelComboBox_I')]")).SendKeys(mgHedgeFormatPXR8ModelTypeValuationVersionName);

            //Upload Param text file 
            driver.FindElement(By.XPath("//input[contains(@id,'ParamUploadControl_TextBox0_Input')]")).SendKeys
                (Path.Combine(mainAutomationDirectory, parameterSetDirectory, parameterSetMGHedgeDirectory, paramtxt));

            //Upload Tstruct text file
            driver.FindElement(By.XPath("//input[contains(@id,'TStructUploadControl_TextBox0_Input')]")).SendKeys
                (Path.Combine(mainAutomationDirectory, parameterSetDirectory, parameterSetMGHedgeDirectory, tstructtxt));

            //Upload SheetInfo text file
            driver.FindElement(By.XPath("//input[contains(@id,'SheetInfoUploadControl_TextBox0_Input')]")).SendKeys
                (Path.Combine(mainAutomationDirectory, parameterSetDirectory, parameterSetMGHedgeDirectory, sheetinfotxt));

            //Click on OK.
            driver.FindElement(By.XPath("//div[@id[contains(.,'CreateNewPopup')]]/span[text()='OK']")).Click();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Parameter Set']")));

            //Expand row.
            driver.FindElement(By.XPath(string.Format
                ("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", MGHedgeFormatParameterName))).Click();

            //Waits for item to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Revision']")));

            //Validate presence of added parameter set file.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[text()='{1}']", MGHedgeFormatParameterName, parameterDate1))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Import']", MGHedgeFormatParameterName))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[1][text()[contains(.,'')]]", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[text()[contains(.,'/')]]", genericTestComment))));
            Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//td[text()[contains(.,'ROOT_MILLIMAN')]]", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[5][text()[contains(.,'')]]", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[6][text()[contains(.,'')]]", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[7][text()[contains(.,'')]]", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Download']", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Void']", genericTestComment))));
        }
        public void CreateHedgeOpsFormatParameterSet()
        {
            //Check if Automated Hedge Ops Parameter Set already exist else create
            if (!driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[text()='{1}']", hedgeOpsFormatParameterName, parameterDate1))))
            {
                AddHedgeOpsFormatParameterSet();
            }
            else
            {
                Console.WriteLine(string.Format("Parameter Set {0} already exist", hedgeOpsFormatParameterName));
            }
        }
        public void AddHedgeOpsFormatParameterSet()
        {
            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Parameter Set']")));

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).Click();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).SendKeys(hedgeOpsFormatParameterName);

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).Click();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).SendKeys(genericTestComment);

            //Enter a Version Date.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_DateEditor_I')]]")).Click();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_DateEditor_I')]]")).SendKeys(parameterDate1);

            //Select file to be uploaded
            driver.FindElement(By.XPath("//input[contains(@id, 'HedgeOpsUploadControl_TextBox0_Input')]")).SendKeys
                (Path.Combine(mainAutomationDirectory, parameterSetDirectory, pxr8HedgeOpsFormatParameterSetFile));

            //Click on OK.
            driver.FindElement(By.XPath("//div[@id[contains(.,'CreateNewPopup')]]/span[text()='OK']")).Click();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Parameter Set']")));

            //Expand row.
            driver.FindElement(By.XPath(string.Format
                ("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", hedgeOpsFormatParameterName))).Click();

            //Waits for item to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Revision']")));

            //Validate presence of added parameter set file.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[text()='{1}']", hedgeOpsFormatParameterName, parameterDate1))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Import']", hedgeOpsFormatParameterName))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[1][text()[contains(.,'')]]", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[text()[contains(.,'/')]]", genericTestComment))));
            Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//td[text()[contains(.,'ROOT_MILLIMAN')]]", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[5][text()[contains(.,'')]]", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[6][text()[contains(.,'')]]", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[7][text()[contains(.,'')]]", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Download']", genericTestComment))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Void']", genericTestComment))));
        }
        public void AddParameterSet()
        {
            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Parameter Set']")));

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            if (importToggle == 1)
            {
                driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).SendKeys(parameterNameBad);
            }
            else
            {
                driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).SendKeys(parameterName1);
            }
            Task.Delay(waitDelay5).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Enter a Version Date.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_DateEditor_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_DateEditor_I')]]")).SendKeys(parameterDate1);
            Task.Delay(waitDelay5).Wait();

            if (importToggle == 1)
            {
                waitDelayCustom = 6500;

                //Select MG Hedge Upload Format.
                driver.FindElement(By.XPath("//span[@id[contains(.,'UploadFormatRadio_RB1_I_D')]]")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Click on Browse button.
                driver.FindElement(By.XPath("//td[@id[contains(.,'ParamUploadControl_Browse0')]]//a[text()='Browse...']")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, parameterSetDirectory, parameterSetMGHedgeMisconfigDirectory, parameterFileBad));
                Task.Delay(waitDelayLongPlus).Wait();
                HitEnterKey();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", parameterFileBad))));

                //Click on OK.
                driver.FindElement(By.XPath("//div[@id[contains(.,'CreateNewPopup')]]/span[text()='OK']")).Click();
                Task.Delay(waitDelayCustom).Wait();
            }
            else
            {
                //Click on Browse button.
                driver.FindElement(By.XPath("//td[@id[contains(.,'HedgeOpsUploadControl_Browse0')]]//a[text()='Browse...']")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, parameterSetDirectory, parameterFile));
                Task.Delay(waitDelayLongPlus).Wait();
                HitEnterKey();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", parameterFile))));

                //Click on OK.
                driver.FindElement(By.XPath("//div[@id[contains(.,'CreateNewPopup')]]/span[text()='OK']")).Click();
                Task.Delay(waitDelaySuper).Wait();

                //Waits for modal to disappear.
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Parameter Set']")));
            }
        }
        public void AddSameNameParameterSets()
        {
            #region Create Parameter Set 1
            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Parameter Set']")));

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).SendKeys(parameterName2);
            Task.Delay(waitDelay5).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Enter a Version Date.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_DateEditor_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_DateEditor_I')]]")).SendKeys(parameterDate1);
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'HedgeOpsUploadControl_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, parameterSetDirectory, parameterFile));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();
            Task.Delay(waitDelayLong).Wait();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", parameterFile))));

            //Click on OK.
            driver.FindElement(By.XPath("//div[@id[contains(.,'CreateNewPopup')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Parameter Set']")));
            #endregion

            #region Create Parameter Set 2
            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Parameter Set']")));

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).SendKeys(parameterName2);
            Task.Delay(waitDelay5).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Enter a Version Date.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_DateEditor_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_DateEditor_I')]]")).SendKeys(parameterDate2);
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'HedgeOpsUploadControl_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, parameterSetDirectory, parameterFile));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();
            Task.Delay(waitDelayLong).Wait();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", parameterFile))));

            //Click on OK.
            driver.FindElement(By.XPath("//div[@id[contains(.,'CreateNewPopup')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Parameter Set']")));
            #endregion
        }
        public void ExpandParameterSet(string parameterSetName, string parameterSetDate)
        {
            //Expand row.
            driver.FindElement(By.XPath(string.Format
                ("//td[text()='{0}']/following-sibling::td[text()='{1}']/preceding-sibling::td[2]/img", parameterSetName, parameterSetDate))).Click();

            //Waits for item to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Revision']")));
        }
        public void CleanupParameterSets()
        {
            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timer2Minute && timer.IsRunning.Equals(true))
            {
                var parameterTable = driver.FindElements(By.XPath("//tr[td[text()[contains(.,'.Automation')]]]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']"));

                if (parameterTable.Any())
                {
                    //Expand row.
                    driver.FindElement(By.XPath("//tr[td[text()[contains(.,'.Automation')]]]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']")).Click();
                    Task.Delay(waitDelayLong).Wait();

                    //Waits for item to appear.
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Revision']")));
                }

                var revisionActive = driver.FindElements(By.XPath("//span[text()='Void']"));

                if (revisionActive.Any())
                {
                    //Void parameter set file.
                    VoidParameterSet();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }
        }
        public void VersionUpParameterSet()
        {
            //Click on Import button.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Import']", parameterName1))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Parameter Set']")));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).SendKeys(versionUpComment);
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'HedgeOpsUploadControl_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, parameterSetDirectory, parameterFile));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", parameterFile))));

            //Click on OK.
            driver.FindElement(By.XPath("//div[@id[contains(.,'CreateNewPopup')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to didappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Parameter Set']")));
        }
        public void VoidParameterSet()
        {
            //Click on Void.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()[contains(.,'{0}')]]]//span[text()='Void']", genericTestComment))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Void Parameter Set...']")));

            //Enter a comment.
            driver.FindElement(By.XPath("//textarea[@id[contains(.,'VoidCommentMemo_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//textarea[@id[contains(.,'VoidCommentMemo_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on OK.
            driver.FindElement(By.XPath("//div[@id[contains(.,'VoidPopup_VoidOkButton')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for New link to load.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='New']")));
        }
        #endregion

        #region Products Tests
        public int productToggle;

        public string productFile = "AutoTestProductsFile.csv";
        public string productLineName = ".Pichu";
        public string productLineDesc = "Pokemon";
        public string productLineDescEdit = "Gotta Catch em All";
        public string productLineNameEdit = ".Pikachu";

        public string productName = ".Pichu Power";
        public string productDesc = "A shocking display of lightning.";
        public string productNameEdit = ".Pikachu Power";
        public string productDescEdit = "Calling down a thunderbolt!";

        public string productNumber = "172";
        public string productSKUDesc = "It is not yet skilled at storing electricity. it may send out a jolt if amused or startled.";
        public string productSKUNumberEdit = "25";
        public string productSKUDescEdit = "When several of these Pokemon gather, their electricity can cause lightning storms.";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void DeleteProduct()
        {
            if (productToggle == 1)
            {
                var productSKUEdit = driver.FindElements(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", productSKUNumberEdit, productNameEdit)));

                if (productSKUEdit.Any())
                {
                    //Delete the Product SKU record.
                    driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", productSKUNumberEdit))).Click();
                    HitEnterKey();
                }

                var productEdit = driver.FindElements(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", productNameEdit, productLineNameEdit)));

                if (productEdit.Any())
                {
                    //Delete the Product record.
                    driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", productNameEdit))).Click();
                    HitEnterKey();
                }

                var productLineEdit = driver.FindElements(By.XPath(string.Format("//tr[td[text()='{0}']]/td[text()='{1}']", productLineNameEdit, productLineDescEdit)));

                if (productLineEdit.Any())
                {
                    //Delete the Product Line record.
                    driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", productLineNameEdit))).Click();
                    HitEnterKey();
                }
            }

            else
            {
                //Delete the Product SKU record.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", productNumber))).Click();
                HitEnterKey();

                //Delete the Product record.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", productName))).Click();
                HitEnterKey();

                //Delete the Product Line record.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", productLineName))).Click();
                HitEnterKey();
            }
        }
        public void EditProduct()
        {
            //Click on the Product edit action.
            driver.FindElement(By.XPath(string.Format("(//tr[td[text()='{0}']]//span[text()='Edit'])[1]", productName))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Name:']")));

            //Edit the Product name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductGridView_DXEFL_DXEditor0_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductGridView_DXEFL_DXEditor0_I')]]")).SendKeys(productNameEdit);
            Task.Delay(waitDelay5).Wait();

            //Edit the Product description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductGridView_DXEFL_DXEditor2_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductGridView_DXEFL_DXEditor2_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductGridView_DXEFL_DXEditor2_I')]]")).SendKeys(productDescEdit);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for field to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//label[text()='Name:']")));
        }
        public void EditProductLine()
        {
            //Click on the Product Line edit action.
            driver.FindElement(By.XPath(string.Format("(//tr[td[text()='{0}']]//span[text()='Edit'])[1]", productLineName))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Name:']")));

            //Edit the Product Line name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductLineGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductLineGridView_DXEFL_DXEditor0_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductLineGridView_DXEFL_DXEditor0_I')]]")).SendKeys(productLineNameEdit);
            Task.Delay(waitDelay5).Wait();

            //Edit the Product Line description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductLineGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductLineGridView_DXEFL_DXEditor1_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductLineGridView_DXEFL_DXEditor1_I')]]")).SendKeys(productLineDescEdit);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for field to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//label[text()='Name:']")));
        }
        public void EditProductSKU()
        {
            //Click on the Product SKU edit action.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Edit']", productNumber))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Number:']")));

            //Edit the Product SKU number.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductSkuGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductSkuGridView_DXEFL_DXEditor0_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductSkuGridView_DXEFL_DXEditor0_I')]]")).SendKeys(productSKUNumberEdit);
            Task.Delay(waitDelay5).Wait();

            //Edit the Product SKU description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductSkuGridView_DXEFL_DXEditor2_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductSkuGridView_DXEFL_DXEditor2_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ProductSkuGridView_DXEFL_DXEditor2_I')]]")).SendKeys(productSKUDescEdit);
            Task.Delay(waitDelay5).Wait();

            //Uncheck the Hedged checkbox.
            driver.FindElement(By.XPath("//span[@id[contains(.,'ProductSkuGridView_DXEFL_DXEditor3_S_D')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            //Uncheck the Restate checkbox.
            driver.FindElement(By.XPath("//span[@id[contains(.,'ProductSkuGridView_DXEFL_DXEditor4_S_D')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for field to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//label[text()='Number:']")));
        }
        public void ImportProductFile()
        {
            //Click on Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'ImportPopupControl_ProductUpload_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, productsDirectory, productFile));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", productFile))));

            //Click OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'ImportPopupControl')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Wait for extracting message to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Extracting data from files...']")));

            //Wait for refresh message to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Import complete. Refreshing page']")));

            //Wait for Import button to reload.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Import']")));
        }
        #endregion

        #region Results Profiles
        public int resultsCustomOverride;

        public static string resultsProfileName = ".AutomationResultsProfile";
        public string resultsProfilenameAuto = resultsProfileName;
        public string resultsProfileStubName = "DefaultResultsProfile";
        public string resultsProfileFile1 = "config" + extXML;

        public string resultsCustomConfig1 = "Automation RP1", resultsCustomConfig2 = "Automation RP2", resultsCustomConfig3 = "Automation RP3", resultsCustomConfig4 = "Automation RP4",
            resultsCustomConfig5 = "Automation RP5", resultsCustomConfig6 = "Automation RP6", resultsCustomConfig7 = "Automation RP7", resultsCustomConfig8 = "Automation RP8",
            resultsCustomConfig9 = "Automation RP9";

        public string resultsCustomConfigFile1 = "config_RP1.xml", resultsCustomConfigFile2 = "config_RP2.xml", resultsCustomConfigFile3 = "config_RP3.xml", resultsCustomConfigFile4 = "config_RP4.xml",
             resultsCustomConfigFile5 = "config_RP5.xml", resultsCustomConfigFile6 = "config_RP6.xml", resultsCustomConfigFile7 = "config_RP7.xml", resultsCustomConfigFile8 = "config_RP8.xml",
             resultsCustomConfigFile9 = "config_RP9.xml";

        public string resultsCustomDBTable1 = "tbl_Results1_PV", resultsCustomDBTable2 = "tbl_Results2_CF", resultsCustomDBTable3 = "tbl_Results3_SSR", resultsCustomDBTable4 = "tbl_Results4_PV_Proj",
            resultsCustomDBTable5 = "tbl_Results5_CF_Proj", resultsCustomDBTable6 = "tbl_Results6_SSR_Proj", resultsCustomDBTable7 = "tbl_Results7_PV", resultsCustomDBTable8 = "tbl_Results8_CF",
            resultsCustomDBTable9 = "tbl_Results9_SSR", resultsCustomDBSchema = "inforce";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void AddResultsProfile()
        {
            if (testVariation != 1)
            {
                var dataPresent = driver.FindElements(By.XPath(string.Format("//td[text()='{0}']", resultsProfileName)));

                if (dataPresent.Any())
                {
                    //Expand row.
                    driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", resultsProfileName))).Click();
                    Task.Delay(waitDelayMega).Wait();

                    //Waits for row to expand.
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Revision']")));

                    //Void Results Profile.
                    VoidResultsProfile();
                }
            }

            if (resultsCustomOverride == 1)
            {
                resultsProfileName = configName;
            }

            if (testVariation == 3)
            {
                resultsProfileName = resultsProfilenameAuto;

            }

            else
            {
                resultsProfileName = resultsProfileStubName;
            }

            //Click on New.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for modal to load.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Results Profile']")));

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).Click();
            Task.Delay(waitDelay6).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_NameTextBox_I')]]")).SendKeys(resultsProfileName);
            Task.Delay(waitDelay6).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).Click();
            Task.Delay(waitDelay6).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_CommentTextBox_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay6).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'FileUploadControl_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, resultsProfileDirectory, resultsProfileFile1));
            Task.Delay(waitDelayLongPlus).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@title[contains(.,'config')]]")));

            waitDelayCustom = 6000;

            //Click OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'CreateNewPopup')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelayCustom).Wait();

            //Wait for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Results Profile']")));
        }
        public void VoidResultsProfile()
        {
            var dataPresent = driver.FindElements(By.XPath(string.Format("//td[text()='{0}']", resultsProfileName)));

            if (!dataPresent.Any())
            {
                //Toggle a variation of method test steps.
                testVariation = 3;

                //Add Results Profile.
                AddResultsProfile();
            }

            var rowCollapse = driver.FindElements(By.XPath(string.Format("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", resultsProfileName)));

            if (rowCollapse.Any())
            {
                //Expand row.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", resultsProfileName))).Click();
                Task.Delay(waitDelayMega).Wait();
            }

            //Waits for row to expand.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Revision']")));

            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerMinutePlus && timer.IsRunning.Equals(true))
            {
                var nonVoided = driver.FindElements(By.XPath("//span[text()='Void']"));

                if (nonVoided.Any())
                {
                    //Click on Void.
                    driver.FindElement(By.XPath("//span[text()='Void']")).Click();
                    Task.Delay(waitDelayLongPlus).Wait();

                    //Waits for void modal to appear.
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Void Results Profile...']")));

                    //Enter a comment.
                    driver.FindElement(By.XPath("//textarea[@id[contains(.,'VoidCommentMemo_I')]]")).Click();
                    Task.Delay(waitDelay5).Wait();
                    driver.FindElement(By.XPath("//textarea[@id[contains(.,'VoidCommentMemo_I')]]")).SendKeys(genericTestComment);
                    Task.Delay(waitDelay5).Wait();

                    //Click on OK.
                    driver.FindElement(By.XPath("//div[@id[contains(.,'VoidPopup_VoidOkButton')]]//span[text()='OK']")).Click();
                    Task.Delay(waitDelayLong).Wait();

                    //Waits for New link to load.
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='New']")));
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }
        }
        #endregion

        #region Results Processors
        public void AddResultsProcessor()
        {
            //Click on New.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CreateNewPopup_NameTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CreateNewPopup_NameTextBox_I')]]")).SendKeys(modelTypeResultProcName);
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'ASPxUploadControl2_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(string.Format(@"{0}{1}""{2}""""{3}""", mainAutomationDirectory, resultsProcessorsDirectory, defaultStubResultsProc, defaultStubResultsProcXML));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title[contains(.,'{0}')]]", defaultStubResultsProc))));

            //Click on OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'UploadAccept_CD')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Wait for File Upload popup window to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id[contains(.,'CreateNewPopup_PW-1')]]")));
            Task.Delay(waitDelayLong).Wait();
        }
        #endregion

        #region Risk Taxonomy Tests
        public string riskSaveAsVersionName = ".AutomationNewSaveRiskTaxonomy";

        public string riskTaxonomyCreditRating = "A";
        public string riskTaxonomyCurrency = "USD";
        public string riskTaxonomyDisplayName = "XOP US Equity";
        public string riskTaxonomyField = "DAY_TO_DAY_TOT_Return_NET_DVDS";
        public string riskTaxonomyMoneyness = "$";
        public string riskTaxonomyTickerTest = "TickerTest";
        public string riskTaxonomyInvalid = "Invalid";

        public string riskTaxonomyReference = "XOP US Equity";
        public string riskTaxonomyReturn = "M";
        public string riskTaxonomyRiskFactor = "USD Equity";
        public string riskTaxonomyRiskGroup = "Market";
        public string riskTaxonomyRiskType = "Equity";
        public string riskTaxonomyRiskVariable = "XOP US Equity";

        public string riskTaxonomySource = "Bloomberg";
        public string riskTaxonomyTargetCurrency = "USD";
        public string riskTaxonomyTenor = "4 days";
        public string riskTaxonomyTerm = "3 days";
        public string riskTaxonomyOrdinal = "1";

        public string riskTaxonomyTickerTestFile = "TickerTest-RiskTaxonomy.csv";
        public string riskTaxonomyInvalidFile = "Invalid_RiskTaxonomy.csv";
        public string shocksFile = "shocks.csv";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void AddRiskTaxonomyTickerRow()
        {
            //Click on New link.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXCBtn0")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for Edit Form popup window to load.
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_PW-1")));

            //Enter a Display Name.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor0_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor0_I")).SendKeys(riskTaxonomyDisplayName);
            Task.Delay(waitDelay5).Wait();

            //Enter a Risk Type.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor2_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor2_I")).SendKeys(riskTaxonomyRiskType);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Enter a Risk Variable.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor4_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor4_I")).SendKeys(riskTaxonomyRiskVariable);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Enter a Reference.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor6_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor6_I")).SendKeys(riskTaxonomyReference);
            Task.Delay(waitDelay5).Wait();

            //Enter a Credit Rating.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor8_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor8_I")).SendKeys(riskTaxonomyCreditRating);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Enter a Target Currency.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor10_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor10_I")).SendKeys(riskTaxonomyTargetCurrency);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Enter a Return.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor13_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor13_I")).SendKeys(riskTaxonomyReturn);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Enter a Moneyness.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor15_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor15_I")).SendKeys(riskTaxonomyMoneyness);
            Task.Delay(waitDelay5).Wait();

            //Enter a Risk Group.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor1_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor1_I")).SendKeys(riskTaxonomyRiskGroup);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Enter a Risk Factor.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor3_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor3_I")).SendKeys(riskTaxonomyRiskFactor);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Enter a Source.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor5_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor5_I")).SendKeys(riskTaxonomySource);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Enter a Field.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor7_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor7_I")).SendKeys(riskTaxonomyField);
            Task.Delay(waitDelay5).Wait();

            //Enter a Currency.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor9_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor9_I")).SendKeys(riskTaxonomyCurrency);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Enter a Term.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor11_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor11_I")).SendKeys(riskTaxonomyTerm);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Enter a Tenor.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor14_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor14_I")).SendKeys(riskTaxonomyTenor);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Enter an Ordinal.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor16_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_DXEFL_DXEditor16_I")).SendKeys(riskTaxonomyOrdinal);
            Task.Delay(waitDelay5).Wait();

            //Click on Update link.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_pcInputImport_Panel1_ASPxButton1")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Wait for File Upload popup window to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_RiskGridView_DXPEForm_PW-1")));

            //Wait for Import button to reload.
            wait.Until(ExpectedConditions.ElementExists(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_RiskTax1_ctl00")));
        }
        public void CreateRiskTaxonomy()
        {
            //Click on Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Import Input File']")));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'txtInputComment_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'txtInputComment_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'cmbInputRiskVersionName_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'cmbInputRiskVersionName_I')]]")).SendKeys(riskTaxonomyTickerTest);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'Panel1_ucRiskTax_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, riskTaxonomyDirectory, riskTaxonomyTickerTestFile));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", riskTaxonomyTickerTestFile))));

            //Click on Save button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'Panel1_ASPxButton1_CD')]]/span[text()='Save']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Import Input File']")));

            //Wait for Import button to reload.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Import']")));
        }
        public void CreateTickerRiskTaxonomy()
        {
            //Click on Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Import Input File']")));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'txtInputComment_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'txtInputComment_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'cmbInputRiskVersionName_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'cmbInputRiskVersionName_I')]]")).SendKeys(riskTaxonomyTickerTest);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'Panel1_ucRiskTax_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, riskTaxonomyDirectory, riskTaxonomyTickerTestFile));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", riskTaxonomyTickerTestFile))));

            //Click on Save button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'Panel1_ASPxButton1_CD')]]/span[text()='Save']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Import Input File']")));

            //Wait for Import button to reload.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Import']")));
        }
        public void ImportRiskTaxonomy()
        {
            //Click on Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Import Input File']")));

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'txtInputComment_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'txtInputComment_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Enter a Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'cmbInputRiskVersionName_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            if (importToggle == 1)
            {
                driver.FindElement(By.XPath("//input[@id[contains(.,'cmbInputRiskVersionName_I')]]")).SendKeys(riskTaxonomyInvalid);
                Task.Delay(waitDelay5).Wait();

                //Click on Browse button.
                driver.FindElement(By.XPath("//td[@id[contains(.,'ucRiskTax_Browse0')]]")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, riskTaxonomyDirectory, riskTaxonomyInvalidFile));
                Task.Delay(waitDelaySuper).Wait();
                HitEnterKey();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", riskTaxonomyInvalidFile))));

                //Click on Save button.
                driver.FindElement(By.XPath("//div[@id[contains(.,'ASPxButton1_CD')]]//span[text()='Save']")).Click();
                Task.Delay(waitDelaySuper).Wait();
            }
            else
            {
                driver.FindElement(By.XPath("//input[@id[contains(.,'cmbInputRiskVersionName_I')]]")).SendKeys(riskTaxonomyTickerTest);
                Task.Delay(waitDelay5).Wait();

                //Click on Browse button.
                driver.FindElement(By.XPath("//td[@id[contains(.,'ucRiskTax_Browse0')]]")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                if (File.Exists(string.Format(@"{0}{1}", downloadDirectory, riskTaxonomyTickerTestFile)))
                {
                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(Path.Combine(downloadDirectory, riskTaxonomyTickerTestFile));
                }

                else
                {
                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(Path.Combine(mainAutomationDirectory, riskTaxonomyDirectory, riskTaxonomyTickerTestFile));
                }

                Task.Delay(waitDelaySuper).Wait();
                HitEnterKey();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", riskTaxonomyTickerTestFile))));

                //Click on Save button.
                driver.FindElement(By.XPath("//div[@id[contains(.,'ASPxButton1_CD')]]//span[text()='Save']")).Click();
                Task.Delay(waitDelaySuper).Wait();

                //Waits for modal to disappear.
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Import Input File']")));
            }
        }
        public void SaveNewRiskTaxonomy()
        {
            //Click on Save As button.
            driver.FindElement(By.XPath("(//span[text()='Save As...'])[1]")).Click();
            Task.Delay(waitDelayLong).Wait();

            var existingNamespace = driver.FindElements(By.XPath("//input[@value='Working Version']"));

            //Check for populated Namespace field.
            if (!existingNamespace.Any())
            {
                driver.FindElement(By.XPath("//input[@id[contains(.,'NamespaceComboBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();

                driver.FindElement(By.XPath("//td[text()='Working Version']")).Click();
                Task.Delay(waitDelay5).Wait();
            }

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ForkPopup_ForkCommentTxt_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ForkPopup_ForkCommentTxt_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Enter a New Version Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ForkPopup_ForkNameTxt_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ForkPopup_ForkNameTxt_I')]]")).SendKeys(riskSaveAsVersionName);
            Task.Delay(waitDelay5).Wait();

            //Click on OK button.
            driver.FindElement(By.XPath("(//span[text()='OK'])[2]")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for Import button to load.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Import']")));
        }
        #endregion

        #region Settings Tests
        public int toggle = 0;

        public string maxActiveGeneratingDefaultName = "MaxActive.Default";
        public string maxActiveGeneratingDefaultValue = "6";
        public string maxActiveGeneratingInforceName = "MaxActive.GeneratingInforce";
        public string maxActiveGeneratingInforceValue = "1";
        public string maxActiveGeneratingParametersName = "MaxActive.GeneratingParameter";
        public string maxActiveGeneratingParametersValue = "3";
        public string maxActiveGeneratingReportName = "MaxActive.GeneratingReport";
        public string maxActiveGeneratingReportValue = "15";

        public string settingDataTypeBool = "Bool";
        public string settingDataTypeString = "String";
        public string settingDataTypeInt = "Integer";

        public string settingDescription = "Allow the DateContext to ignore the specific Inforce it is using and seek through all available inforce dates.";

        public string settingSetting1 = ".AutomationTestSetting";
        public string settingSetting2 = "DateContext.UseLegacySeeking";

        public string settingValue1 = "1";
        public string settingValueFalse = "False";
        public string settingValueTrue = "True";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void CreateNewSetting()
        {
            //Create a generic setting for testing.
            if (toggle == 0)
            {
                //Click New link.
                driver.FindElement(By.XPath("//span[text()='New']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Enter a Description.
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor3_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor3_I')]]")).SendKeys(genericTestComment);
                Task.Delay(waitDelay5).Wait();

                //Enter a Setting.
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor1_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor1_I')]]")).SendKeys(settingSetting1);
                Task.Delay(waitDelay5).Wait();

                //Enter a Value.
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor4_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor4_I')]]")).SendKeys(settingValue1);
                Task.Delay(waitDelay5).Wait();

                //Enter a Data Type.
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor2_I')]]")).Click();
                Task.Delay(waitDelayLong).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor2_I')]]")).SendKeys(settingDataTypeInt);
                Task.Delay(waitDelayLong).Wait();

                //Hit the Tab key.
                HitTabKey();
            }

            //Create a specific valid setting --> DateContext.UseLegacySeeking
            if (toggle == 1)
            {
                //Click New link.
                driver.FindElement(By.XPath("//span[text()='New']")).Click();
                Task.Delay(waitDelay5).Wait();

                //Enter a Data Type.
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor2_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor2_I')]]")).SendKeys(settingDataTypeBool);
                Task.Delay(waitDelay5).Wait();

                //Hit the Enter key.
                HitEnterKey();

                //Enter a Description.
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor3_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor3_I')]]")).SendKeys(settingDescription);
                Task.Delay(waitDelay5).Wait();

                //Enter a Setting.
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor1_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor1_I')]]")).SendKeys(settingSetting2);
                Task.Delay(waitDelay5).Wait();

                //Enter a Value.
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor4_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'SettingsGridView_DXEFL_DXEditor4_I')]]")).SendKeys(settingValueFalse);
                Task.Delay(waitDelay5).Wait();
            }

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayMega).Wait();
        }
        public void DeleteNewSetting()
        {
            //Delete new setting.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", settingSetting1))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Hit the Enter Key.
            HitEnterKey();
            Task.Delay(waitDelayMega).Wait();
        }

        public void SetMaxActiveGeneratingDefaultValue()
        {
            //Click on empty setting field and enter setting name.            
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).SendKeys(maxActiveGeneratingDefaultName);
            Task.Delay(waitDelayLong).Wait();

            //Click on Edit.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXCBtn1")).Click();
            Task.Delay(waitDelay5).Wait();

            wait.Until(ExpectedConditions.ElementExists(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXCBtn1"))); //Waits for Update link to load.

            //Enter a MaxActive.GeneratingReport Value.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).SendKeys(maxActiveGeneratingDefaultValue);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXCBtn1")).Click();
            Task.Delay(waitDelayLong).Wait();
        }
        public void SetMaxActiveGeneratingInforceValue()
        {
            //Click on empty setting field and enter setting name.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).SendKeys(maxActiveGeneratingInforceName);
            Task.Delay(waitDelayLong).Wait();

            //Click on Edit.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXCBtn1")).Click();
            Task.Delay(waitDelay5).Wait();
            wait.Until(ExpectedConditions.ElementExists(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXCBtn1"))); //Waits for Update link to load.

            //Enter a MaxActive.GeneratingReport Value.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).SendKeys(maxActiveGeneratingInforceValue);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXCBtn1")).Click();
            Task.Delay(waitDelayLong).Wait();
        }
        public void SetMaxActivegeneratingParametersValue()
        {
            //Click on empty setting field and enter setting name.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).SendKeys(maxActiveGeneratingParametersName);
            Task.Delay(waitDelayLong).Wait();

            //Click on Edit.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXCBtn1")).Click();
            Task.Delay(waitDelay5).Wait();
            wait.Until(ExpectedConditions.ElementExists(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXCBtn1"))); //Waits for Update link to load.

            //Enter a MaxActive.GeneratingParameters Value.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).SendKeys(maxActiveGeneratingParametersValue);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXCBtn1")).Click();
            Task.Delay(waitDelayLong).Wait();
        }
        public void SetMaxActiveGeneratingReportValue()
        {
            //Click on empty setting field and enter setting name.

            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXFREditorcol1_I")).SendKeys(maxActiveGeneratingReportName);
            Task.Delay(waitDelayLong).Wait();

            //Click on Edit.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXCBtn1")).Click();
            Task.Delay(waitDelay5).Wait();
            wait.Until(ExpectedConditions.ElementExists(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXCBtn1"))); //Waits for Update link to load.

            //Enter a MaxActive.GeneratingReport Value.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXEditor4_I")).SendKeys(maxActiveGeneratingReportValue);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_SettingsGridView_DXEFL_DXCBtn1")).Click();
            Task.Delay(waitDelayLong).Wait();
        }
        #endregion

        #region Shock Definition Tests
        public string shockDefCompositeNumber = "36";
        public string shockDefStressNumber = "100";
        public string shockDefBasis = "Test";
        public string shockDefRiskType = "Equity";
        public string shockDefRiskVariable = "XP1 Index";

        public string shockDefDirection = "N/A";
        public string shockDefRiskGroup = "Market";
        public string shockDefRiskFactor = "USD Equity";
        public string shockDefSetName = "Stress Set Test";
        public string shockDefStressesName = "Stresses Test";

        public string shockDefCompStressName = "Stress Composite Test";
        public string shockDefTemplate = "JM1";
        public string shockDefType = "Additive - Single";
        public string shockDefValue = "1";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void Create_Composite_Stresses_Record()
        {
            //Click on Composite Stresses tab.
            driver.FindElement(By.XPath("//a[@id[contains(.,'UserControlShocks_Tabs_T2T')]]/span[text()='Composite Stresses']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on New link.
            driver.FindElement(By.XPath("//a[@id[contains(.,'CompositeStressesGridView_DXCBtn0')]]/span[text()='New']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for Number field to load.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor0_I')]]")));

            //Enter a Cross-Stress Number.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor7_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor7_I')]]")).SendKeys(shockDefStressNumber);
            Task.Delay(waitDelay5).Wait();

            //Enter a Stress Number.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor5_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor5_I')]]")).SendKeys(shockDefStressNumber);
            Task.Delay(waitDelay5).Wait();

            //Enter a Basis.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor3_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor3_I')]]")).SendKeys(shockDefBasis);
            Task.Delay(waitDelay5).Wait();

            //Enter a Number.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor0_I')]]")).SendKeys(shockDefCompositeNumber);
            Task.Delay(waitDelay5).Wait();

            //Enter a Set.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor1_I')]]")).SendKeys(shockDefSetName);
            Task.Delay(waitDelay5).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor2_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'CompositeStressesGridView_DXEFL_DXEditor2_I')]]")).SendKeys(shockDefCompStressName);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//a[@id[contains(.,'CompositeStressesGridView_DXEFL_DXCBtn1')]]//span[text()='Update']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for Name entry to appear in table.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Stress Composite Test']")));
        }
        public void Create_Shock_Definition()
        {
            //Create new Stress Set record.
            Create_Stress_Sets_Record();

            //Create new Stresses record.
            Create_Stresses_Record();

            //Create new Composite Stresses record.
            Create_Composite_Stresses_Record();
        }
        public void Create_Stresses_Record()
        {
            //Click on Stresses tab.
            driver.FindElement(By.XPath("//a[@id[contains(.,'UserControlShocks_Tabs_T1T')]]/span[text()='Stresses']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on New link.
            driver.FindElement(By.XPath("//a[@id[contains(.,'StressesGridView_DXCBtn0')]]/span[text()='New']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for Number field to load.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor0_I')]]")));

            //Enter a Value.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor13_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor13_I')]]")).SendKeys(shockDefValue);
            Task.Delay(waitDelay5).Wait();

            //Enter a Number.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor0_I')]]")).SendKeys(shockDefStressNumber);
            Task.Delay(waitDelay5).Wait();

            //Enter a Set.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor1_I')]]")).SendKeys(shockDefSetName);
            Task.Delay(waitDelay5).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor2_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor2_I')]]")).SendKeys(shockDefStressesName);
            Task.Delay(waitDelay5).Wait();

            //Enter a Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor3_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor3_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Enter a Basis.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor4_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor4_I')]]")).SendKeys(shockDefBasis);
            Task.Delay(waitDelay5).Wait();

            //Enter a Risk Group.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor5_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor5_I')]]")).SendKeys(shockDefRiskGroup);
            Task.Delay(waitDelay5).Wait();

            //Enter a Risk Type.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor6_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor6_I')]]")).SendKeys(shockDefRiskType);
            Task.Delay(waitDelay5).Wait();

            //Enter a Risk Factor.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor7_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor7_I')]]")).SendKeys(shockDefRiskFactor);
            Task.Delay(waitDelay5).Wait();

            //Enter a Risk Variable.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor9_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor9_I')]]")).SendKeys(shockDefRiskVariable);
            Task.Delay(waitDelay5).Wait();

            //Enter a Type.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor10_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor10_I')]]")).SendKeys(shockDefType);
            Task.Delay(waitDelay5).Wait();

            //Enter a Direction.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor11_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor11_I')]]")).SendKeys(shockDefDirection);
            Task.Delay(waitDelay5).Wait();

            ////Enter a Template.
            //driver.FindElement(By.Id("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor12_I')]]")).Click();
            //Task.Delay(waitDelay4).Wait();
            //driver.FindElement(By.Id("//input[@id[contains(.,'StressesGridView_DXEFL_DXEditor12_I')]]")).SendKeys(shockDefTemplate);
            //Task.Delay(waitDelay4).Wait();                

            //Click on Update.
            driver.FindElement(By.XPath("//a[@id[contains(.,'StressesGridView_DXEFL_DXCBtn1')]]//span[text()='Update']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for Set name entry to appear in table.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//tr[td[text()='.Automation Test']]//td[text()='Stress Set Test'])[2]")));
        }
        public void Create_Stress_Sets_Record()
        {
            //Click on New.
            driver.FindElement(By.XPath("//a[@id[contains(.,'StressSetsGridView_DXCBtn0')]]/span[text()='New']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressSetsGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressSetsGridView_DXEFL_DXEditor0_I')]]")).SendKeys(shockDefSetName);
            Task.Delay(waitDelay5).Wait();

            //Enter a Description.
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressSetsGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'StressSetsGridView_DXEFL_DXEditor1_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//a[@id[contains(.,'StressSetsGridView_DXEFL_DXCBtn1')]]//span[text()='Update']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for Description entry to appear in table.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='.Automation Test']")));
        }
        public void Delete_Shocks()
        {
            //Delete Composite Stresses record.
            //Click on Composite Stresses tab.
            driver.FindElement(By.XPath("//a[@id[contains(.,'UserControlShocks_Tabs_T2T')]]/span[text()='Composite Stresses']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Delete Composite Stresses.
            driver.FindElement(By.XPath("//tr[td[text()='Stress Composite Test']]//span[text()='Delete']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Delete Stresses record.
            //Click on Stresses tab.
            driver.FindElement(By.XPath("//a[@id[contains(.,'UserControlShocks_Tabs_T1T')]]/span[text()='Stresses']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Delete Stresses.
            driver.FindElement(By.XPath("(//tr[td[text()='.Automation Test']]//span[text()='Delete'])[2]")).Click();
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Delete Stress Set record.
            //Click on Stress Sets tab.
            driver.FindElement(By.XPath("//a[@id[contains(.,'UserControlShocks_Tabs_T0T')]]/span[text()='Stress Sets']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Delete Stress Sets.
            driver.FindElement(By.XPath("(//tr[td[text()='.Automation Test']]//span[text()='Delete'])[1]")).Click();
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();
        }
        #endregion
        //--INPUT AND ASSUMPTIONS-------------------------------------------------------------------------------------oo

        //--RISK FRAMEWORK--------------------------------------------------------------------------------------------oo
        #region Scenarios Tests
        public int scenarioAssertVolOverride;

        public string scenarioDate = "01/02/1989";
        public string scenarioFile = "TestScenarioFile.csv";
        public string scenarioName = ".Automation Test Scenario";
        public string scenarioMultiFile1 = "AutoRocket.csv";
        public string scenarioMultiFile2 = "AutoSurf.csv";
        public string scenarioZipName = "Scenarios.zip";

        public static string sPrefix = "AutoVolumeTest";
        public string scenarioFileVol1 = sPrefix + "1.csv", scenarioFileVol2 = sPrefix + "2.csv", scenarioFileVol3 = sPrefix + "3.csv", scenarioFileVol4 = sPrefix + "4.csv", scenarioFileVol5 = sPrefix + "5.csv",
            scenarioFileVol6 = sPrefix + "6.csv", scenarioFileVol7 = sPrefix + "7.csv", scenarioFileVol8 = sPrefix + "8.csv", scenarioFileVol9 = sPrefix + "9.csv", scenarioFileVol10 = sPrefix + "10.csv",
            scenarioFileVol11 = sPrefix + "11.csv", scenarioFileVol12 = sPrefix + "12.csv", scenarioFileVol13 = sPrefix + "13.csv", scenarioFileVol14 = sPrefix + "14.csv", scenarioFileVol15 = sPrefix + "15.csv",
            scenarioFileVol16 = sPrefix + "16.csv", scenarioFileVol17 = sPrefix + "17.csv", scenarioFileVol18 = sPrefix + "18.csv", scenarioFileVol19 = sPrefix + "19.csv", scenarioFileVol20 = sPrefix + "20.csv",
            scenarioFileVol21 = sPrefix + "21.csv", scenarioFileVol22 = sPrefix + "22.csv", scenarioFileVol23 = sPrefix + "23.csv", scenarioFileVol24 = sPrefix + "24.csv", scenarioFileVol25 = sPrefix + "25.csv",
            scenarioFileVol26 = sPrefix + "26.csv", scenarioFileVol27 = sPrefix + "27.csv", scenarioFileVol28 = sPrefix + "28.csv", scenarioFileVol29 = sPrefix + "29.csv", scenarioFileVol30 = sPrefix + "30.csv",
            scenarioFileVol31 = sPrefix + "31.csv", scenarioFileVol32 = sPrefix + "32.csv", scenarioFileVol33 = sPrefix + "33.csv", scenarioFileVol34 = sPrefix + "34.csv", scenarioFileVol35 = sPrefix + "35.csv",
            scenarioFileVol36 = sPrefix + "36.csv", scenarioFileVol37 = sPrefix + "37.csv", scenarioFileVol38 = sPrefix + "38.csv", scenarioFileVol39 = sPrefix + "39.csv", scenarioFileVol40 = sPrefix + "40.csv",
            scenarioFileVol41 = sPrefix + "41.csv", scenarioFileVol42 = sPrefix + "42.csv", scenarioFileVol43 = sPrefix + "43.csv", scenarioFileVol44 = sPrefix + "44.csv", scenarioFileVol45 = sPrefix + "45.csv",
            scenarioFileVol46 = sPrefix + "46.csv", scenarioFileVol47 = sPrefix + "47.csv", scenarioFileVol48 = sPrefix + "48.csv", scenarioFileVol49 = sPrefix + "49.csv", scenarioFileVol50 = sPrefix + "50.csv",
            scenarioFileVol51 = sPrefix + "51.csv";

        public string scenarioFile1_HOPS_796 = "Scenario01.csv", scenarioFile2_HOPS_796 = "Scenario02.csv", scenarioFile3_HOPS_796 = "Scenario03.csv", scenarioFile4_HOPS_796 = "Scenario04.csv",
            scenarioFile5_HOPS_796 = "Scenario05.csv", scenarioFile6_HOPS_796 = "Scenario06.csv", scenarioFile7_HOPS_796 = "Scenario07.csv", scenarioFile8_HOPS_796 = "Scenario08.csv",
            scenarioFile9_HOPS_796 = "Scenario09.csv";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void AddScenario()
        {
            //Click on Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            if (testVariation != 1)
            {
                //Check Use File Name checkbox.
                driver.FindElement(By.XPath("//span[@id[contains(.,'UseFileNameChk_S_D')]]")).Click();
                Task.Delay(waitDelay5).Wait();

                //Enter a Name.
                driver.FindElement(By.XPath("//input[@id[contains(.,'ImportPopupControl_VersionNameTxt_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'ImportPopupControl_VersionNameTxt_I')]]")).SendKeys(scenarioName);
                Task.Delay(waitDelay5).Wait();
            }

            //Enter a Date.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ImportPopupControl_VersionDateEdit_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ImportPopupControl_VersionDateEdit_I')]]")).SendKeys(scenarioDate);
            Task.Delay(waitDelay5).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'ImportPopupControl_VersionCommentTxt_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'ImportPopupControl_VersionCommentTxt_I')]]")).SendKeys(genericTestComment);
            Task.Delay(waitDelay5).Wait();

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'MarketFileUpload_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Navigate and select file in file explorer.
            SendKeys.SendWait(Path.Combine(mainAutomationDirectory, scenarioDirectory, scenarioFile));
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", scenarioFile))));

            //Click OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'ImportPopupControl')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
            Task.Delay(waitDelaySuper).Wait();

            if (scenarioAssertVolOverride != 1)
            {
                //>This override removes import assertions due to UI loading max of 30 records at a time. 
                //>(all records in increments of 30 beyond the 30th record do exist but are not loaded until the UI is scrolled far enough to load each bulk increment.)
                //Validate presence of scenario record.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']]//td[text()='{1}']", scenarioName, scenarioDate))));
            }
        }
        public void VoidScenario()
        {
            //Click on Void link
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Void']", scenarioName))).Click();
            Task.Delay(waitDelayLongPlus).Wait();

            //Waits for loading modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Loading…']")));
            Task.Delay(waitDelayLongPlus).Wait();
        }

        public void ImportScenarioMulti_HOPS_796()
        {
            char[] fileExt = { '.', 'c', 's', 'v' };

            #region Create List of Files
            List<string> scenarioFiles = new List<string>
            {
                scenarioFile1_HOPS_796,
                scenarioFile2_HOPS_796,
                scenarioFile3_HOPS_796,
                scenarioFile4_HOPS_796,
                scenarioFile5_HOPS_796,
                scenarioFile6_HOPS_796,
                scenarioFile7_HOPS_796,
                scenarioFile8_HOPS_796,
                scenarioFile9_HOPS_796
            };
            #endregion

            //Import multiple files.
            foreach (string file in scenarioFiles)
            {
                scenarioFile = file;
                scenarioName = file.TrimEnd(fileExt);

                //Toggle a variation of method test steps.
                testVariation = 1;

                //Import scenario file.
                AddScenario();
            }
        }
        #endregion
        //--RISK FRAMEWORK--------------------------------------------------------------------------------------------oo

        //--RUNS------------------------------------------------------------------------------------------------------oo
        #region Grid & Run History Tests
        public string filterRunNameContains = "Hedge";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        #endregion

        #region Notification Tests
        public string notificationName = "AutomationTestNotifGroup";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void AddNotificationGroup()
        {
            //Click on New button.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Name:']")));

            //Add a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NotificationsGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NotificationsGridView_DXEFL_DXEditor0_I')]]")).SendKeys(notificationName);
            Task.Delay(waitDelayLong).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //>Hit the Enter key again (accomodates weird cloud issue)
            HitEnterKey();

            //Waits for record to appear.
            wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format("//td[text()='{0}']", notificationName))));

            //Expand the group.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", notificationName))).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Address']")));

            //Click on New button.
            driver.FindElement(By.XPath("//a[@id[contains(.,'NotificationListGridView_DXCBtn')]]/span[text()='New']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Address:']")));

            //Add a Recipient Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NotificationListGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NotificationListGridView_DXEFL_DXEditor0_I')]]")).SendKeys(userNameFirst);
            Task.Delay(waitDelay5).Wait();

            //Add an Email Address.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NotificationListGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NotificationListGridView_DXEFL_DXEditor1_I')]]")).SendKeys(userEmailAddress);
            Task.Delay(waitDelay5).Wait();

            //Click Update button.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for loading modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table[@id[contains(.,'JobsGridView_DXPFCForm_DXPFC_LPV')]]//span[text()='Loading…']")));
        }
        public void AssignNotificationToRunGroup()
        {
            //Expand the group. (.AutomationTestGroup)
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", runGroup))).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for tab to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@id[contains(.,'pageControl_T1T')]]//span[text()='Schedules']")));

            //Click the Edit button.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Edit']", runInstanceName))).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Edit Run']")));

            var notifGroup = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", notificationName)));

            if (notifGroup.Any())
            {
                //Remove the notification group.
                driver.FindElement(By.XPath(string.Format("//span[span[text()='{0}']]/span[@title='Remove']", notificationName))).Click();
                Task.Delay(waitDelay5).Wait();
            }

            //Assign a notification group.
            driver.FindElement(By.XPath("//input[@id[contains(.,'NotificationGroupsTokenBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'NotificationGroupsTokenBox_I')]]")).SendKeys(notificationName);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table[@id[contains(.,'JobsGridView_DXPFCForm_DXPFC_LPV')]]//span[text()='Loading…']")));

            //Waits for item to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Edit']", runInstanceName))));
        }
        public void RemoveNotificationFromRunGroup()
        {
            //Click the Delete button.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", notificationName))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Hit the ENTER key. (this interacts with the windows popup form and closes it)
            HitEnterKey();
        }
        #endregion

        #region Report Testing
        public int adhoc, adhocApproval = 1, cancelApproval, downloadReportVal, overriddenReport, rliQuantity, reportVal;

        public string accessLevelKeyword = "All";
        public string adhocFileName1 = "AdHocFile1" + extTXT;
        public string adhocFileName2 = "AdHocFile2" + extTXT;
        public string reportHistFileName = "Report_Ver_History_Validation1" + extTXT;

        public string reportName = ".AutomationTestReport";
        public string reportName2 = "Report Ver History Adhoc";
        public string resourceKeyword = "Approve";

        public string downloadFileName, outputFileName, reportFile, reportInforcedate;
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void ApproveReport()
        {
            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                if (reportVal == 2)
                {
                    //Validate presence of control attribute.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()='test-1']")));

                    //Validate presence of self validation report message.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()='This report provides its own validation.']")));
                }

                if (cancelApproval == 1)
                {
                    //Validate presence of PendingApproval status prior to approving report.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath("(//span[text()='PendingApproval'])[1]")));
                }
                else
                {
                    //Click on Approve.
                    driver.FindElement(By.XPath("//button[text()='Approve']")).Click();
                    Task.Delay(waitDelayMega).Wait();

                    //Waits for item to appear.
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Approved']")));

                    //Validate presence of Approved state after approving report.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()='Approved']")));

                    //>Removed due to extreeme length of time an approved report may stay in Approved state before transitioning to Complete. The wait necessary for this transition is longer than practical for this automation test.
                    ////Restart stopwatch.
                    //timer.Restart();

                    ////Wait for Complete run state.
                    //while (timer.Elapsed.TotalSeconds < timerMinute && timer.IsRunning.Equals(true))
                    //{
                    //    var report1Complete = driver.FindElements(By.XPath("//span[text()='Complete']"));

                    //    if (!report1Complete.Any())
                    //    {
                    //        //Refresh browser.
                    //        RefreshBrowser();

                    //        //Waits for item to appear.
                    //        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Overview']")));
                    //    }

                    //    else
                    //    {
                    //        //Stop stopwatch.
                    //        timer.Stop();
                    //    }
                    //}

                    //Validate absence of all 3 report actions.
                    Assert.IsFalse(driver.VerifyAsserts(By.XPath("//button[text()='Approve']")));
                    Assert.IsFalse(driver.VerifyAsserts(By.XPath("//button[text()='Deny']")));
                    Assert.IsFalse(driver.VerifyAsserts(By.XPath("//span[text()='Override']")));
                }
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                if (adhoc == 1)
                {
                    //Click on Approve.
                    driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Approve']", reportFile))).Click();
                    Task.Delay(waitDelayLong).Wait();

                    //Validate presence of Approved Review Result after approving report.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("(//tr[td[text()='{0}']][1]//td[text()='Approved'])[1]", reportFile))));

                    //Validate presence of Approved Status after approving report.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("(//tr[td[text()='{0}']][1]//td[text()='Approved'])[2]", reportFile))));

                    //Validate presence of detailed Reviewed By log after approving report.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("(//tr[td[text()='{0}']][1]//td[text()[contains(.,'.')]])[1]", reportFile))));

                    //Validate Overridden box is checked.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[@class[contains(.,'edtCheckBoxChecked')]]", reportFile))));
                }
                else
                {
                    //Click on Approve.
                    driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Approve']", reportFile))).Click();
                    Task.Delay(waitDelayLong).Wait();

                    //Hit the Enter Key.
                    HitEnterKey();
                    Task.Delay(waitDelaySuper).Wait();

                    if (reportVal == 1)
                    {
                        //Waits for modal to appear.
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Approval']")));

                        //Validate presence of control attribute.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath("//label[text()='test-1']")));

                        //Validate presence of associated validation report.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[@id[contains(.,'ApprovalPopup_PW-1')]]//a[text()='{0}']", outputFileName))));

                        if (downloadReportVal == 1)
                        {
                            //Click on validation report.
                            driver.FindElement(By.XPath(string.Format("//div[span[@id[contains(.,'ApprovalPopup_ApprovalCallbackPanel_ctl30')]]]/a[text()='{0}']", outputFileName))).Click();
                            Task.Delay(waitDelaySuper).Wait();

                            if (!File.Exists(downloadFileName))
                            {
                                Assert.Fail(string.Format(@"Expected file(s) are not present in folder {0}", downloadDirectory));
                            }
                        }

                        if (cancelApproval == 1)
                        {
                            //Click on Cancel button.
                            driver.FindElement(By.XPath("//div[@id[contains(.,'ApprovalCallbackPanel_btnApproveCancel_CD')]]/span[text()='Cancel']")).Click();
                            Task.Delay(waitDelayLong).Wait();
                        }
                        else
                        {
                            //Click on OK button.
                            driver.FindElement(By.XPath("//div[@id[contains(.,'ApprovalCallbackPanel_btnApproveOK_CD')]]/span[text()='OK']")).Click();
                            Task.Delay(waitDelaySuper).Wait();
                        }

                        //Waits for modal to disappear.
                        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Approval']")));
                    }

                    if (cancelApproval == 1)
                    {
                        //Validate presence of PendingApproval status prior to approving report.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//td[text()='PendingApproval']", reportFile))));

                        //Validate absence of Reviewed by record.
                        Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]/td[6][text()='{1}']", reportFile, targetUserName))));
                    }
                    else
                    {
                        //Waits for item to appear.
                        wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format("//tr[td[text()='{0}']][1]//td[8][text()='Approved']", reportFile))));

                        //Validate presence of Approved Review Result after approving report.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//td[8][text()='Approved']", reportFile))));

                        //Validate presence of Reviewed By record in correct "first & last" format.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]/td[6][text()='{1}']", reportFile, targetUserName))));

                        //Validate absence of top level directory in user record.
                        Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]/td[6][contains(.,'ROOT_MILLIMAN\')]", reportFile))));

                        //Validate absence of all 3 report actions.
                        Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Approve']", reportFile))));
                        Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Denied']", reportFile))));
                        Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportFile))));
                    }
                }
            }
            #endregion

            //Validate presence of correct Reviewed by record after approving report.
            try
            {
                if (cancelApproval != 1)
                {
                    if (targetTestingLocation == 0 && targetChameleon == 1)
                    {
                        //Validate presence of Report Validation user email.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//span[text()='{0}']", userOnPremRecord))));
                    }

                    if (targetTestingLocation == 1 && targetChameleon == 1)
                    {
                        //Validate presence of Report Validation user email.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//span[text()='{0}']", userEmailAddress))));
                    }

                    if (targetChameleon != 1)
                    {
                        //Validate presence of Reviewed By record in correct "first & last" format.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]/td[6][text()='{1}']", reportFile, targetUserName))));
                    }
                }
            }

            catch (Exception)
            {
                Assert.Fail("Unexpected Result: Recorded report validation user name is incorrect.");
            }

            #region HedgeOps 2.9-
            if (targetChameleon != 1)
            {
                if (cancelApproval != 1)
                {
                    //Restart stopwatch.
                    timer.Restart();

                    //Wait for Complete run state.
                    while (timer.Elapsed.TotalSeconds < timerMinute && timer.IsRunning.Equals(true))
                    {
                        var report1Complete = driver.FindElements(By.XPath(string.Format("//tr[td[text()='{0}']][1]/td[9][text()='Complete']", reportFile)));

                        if (!report1Complete.Any())
                        {
                            //Click on Search button.
                            driver.FindElement(By.XPath("//span[text()='Search']")).Click();
                            Task.Delay(waitDelayLong).Wait();
                        }

                        else
                        {
                            //Stop stopwatch.
                            timer.Stop();
                        }
                    }

                    //Validate presence of Complete status.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]/td[9][text()='Complete']", reportFile))));

                    if (overriddenReport == 1)
                    {
                        //Validate presence of checked Overridden checkbox after overriding report.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("(//tr[td[text()='{0}']]//span[@class[contains(.,'CheckBoxChecked')]])[1]", reportFile))));
                    }
                    else
                    {
                        //Validate presence of unchecked Overridden checkbox after approving report.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("(//tr[td[text()='{0}']]//span[@class[contains(.,'CheckBoxUnchecked')]])[1]", reportFile))));
                    }
                }
            }
            #endregion
        }
        public void AssignReportPermissions()
        {
            //Click on Name columns (this orders the list in ascending order alphabetically).
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_grid_col1")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Administrators option.
            driver.FindElement(By.Id("clickElement")).Click();

            //Click into Resource field.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_I")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Enter criteria.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_I")).SendKeys(resourceKeyword);
            Task.Delay(waitDelay5).Wait();

            //Click Menu selection field.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_DDD_L_LBI74T0")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Edit button.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXCBtn1")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Access Level field.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXPEForm_DXEFL_DXEditor1_I")).Click();
            Task.Delay(waitDelay5).Wait();

            //Enter criteria.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXPEForm_DXEFL_DXEditor1_I")).SendKeys(accessLevelKeyword);
            Task.Delay(waitDelay5).Wait();

            //Collapse Access Level field.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXPEForm_DXEFL_DXEditor1_I")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Update button.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXPEForm_DXEFL_DXCBtn1")).Click();
            Task.Delay(waitDelay5).Wait();
        }
        public void CreateAdhocReport()
        {
            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Click on Ad-Hoc Report button.
                driver.FindElement(By.XPath("//span[text()='Upload Ad hoc Report']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Upload an Ad hoc Report']")));

                //Enter a report name.
                driver.FindElement(By.XPath("//input[@class[contains(.,'StyledTextInput-sc-1x30a0s-0 jSJjFr')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@class[contains(.,'StyledTextInput-sc-1x30a0s-0 iZaImG')]]")).SendKeys(reportFile);
                Task.Delay(waitDelay5).Wait();

                //Click on Valuation Date drop down.
                driver.FindElement(By.XPath("//span[text()='Select a date']")).Click();
                Task.Delay(waitDelay5).Wait();

                var todayButton = driver.FindElements(By.XPath("//span[text()='Today']"));

                if (todayButton.Any())
                {
                    //Click on Today button.
                    driver.FindElement(By.XPath("//span[text()='Today']")).Click();
                    Task.Delay(waitDelay5).Wait();
                }
                else
                {
                    //Enter a Valuation Date.
                    driver.FindElement(By.XPath("//input[@class[contains(.,'hdgAdhocValuationDateInput')]]")).SendKeys(scenarioDate);
                    Task.Delay(waitDelay5).Wait();

                    //Click on Valuation Date field (this clears away the calendar drop down).
                    driver.FindElement(By.XPath("//input[@class[contains(.,'hdgAdhocValuationDateInput')]]")).Click();
                    Task.Delay(waitDelay5).Wait();
                }

                //Uncheck Send to Another Location. (this minimizes additional potential errors based on setting configs)
                driver.FindElement(By.XPath("(//div[div[span[text()='Send to Another Location']]]//div[@class[contains(.,'StyledCheckBox__')]])[2]")).Click();
                Task.Delay(waitDelayLong).Wait();

                if (adhocApproval == 0)
                {
                    var requiresApproval = driver.FindElements(By.XPath("(//div[div[span[text()='Requires Approval']]]//div[@class[contains(.,'StyledCheckBox__')]])[1]"));

                    if (requiresApproval.Any())
                    {
                        //Uncheck Requires Approval.
                        driver.FindElement(By.XPath("(//div[div[span[text()='Requires Approval']]]//div[@class[contains(.,'StyledCheckBox__')]])[1]")).Click();
                        Task.Delay(waitDelay5).Wait();
                    }
                }

                if (adhocApproval == 1)
                {
                    var requiresApproval = driver.FindElements(By.XPath("(//div[div[span[text()='Requires Approval']]]//div[@class[contains(.,'StyledCheckBox__')]])[1]"));

                    if (!requiresApproval.Any())
                    {
                        //Check Requires Approval.
                        driver.FindElement(By.XPath("(//div[div[span[text()='Requires Approval']]]//div[@class[contains(.,'StyledCheckBox__')]])[1]")).Click();
                        Task.Delay(waitDelay5).Wait();
                    }
                }

                //Click on Attach File button.
                driver.FindElement(By.XPath("//span[text()='Attach File']")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, reportDirectory, adhocFileName1));
                Task.Delay(waitDelayLongPlus).Wait();
                HitEnterKey();
                Task.Delay(waitDelayLongPlus).Wait();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//span[text()='AdHocFile1.txt']", adhocFileName1))));

                //Click on Upload button.
                driver.FindElement(By.XPath("//button[text()='Upload']")).Click();
                Task.Delay(waitDelaySuper).Wait();

                //Restart stopwatch.
                timer.Restart();

                //Attempt to check for run item completion until timer expires.
                while (timer.Elapsed.TotalSeconds < timerMinute && timer.IsRunning.Equals(true))
                {
                    var uploading = driver.FindElements(By.XPath("//span[text()='We are uploading your report.']"));

                    if (!uploading.Any())
                    {
                        //Stop stopwatch.
                        timer.Stop();
                    }
                }

                try
                {
                    //Verify report success.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()='Success!']")));
                }
                catch (Exception)
                {
                    Assert.Fail("Unexpected Result: Report failed to upload.");
                }

                //Click on Close button.
                driver.FindElement(By.XPath("//span[text()='Close']")).Click();
                Task.Delay(waitDelaySuper).Wait();

                //Waits for modal to disappear.
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Upload an Ad hoc Report']")));

                //Click on Refresh button.
                driver.FindElement(By.XPath("//span[text()='Refresh']")).Click();
                Task.Delay(waitDelaySuper).Wait();
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Click on Ad-Hoc Report button.
                driver.FindElement(By.XPath("(//span[text()='Ad-Hoc Report'])[2]")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Report Name:']")));

                //Enter an report name.
                driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_txtReportName_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_txtReportName_I')]]")).SendKeys(reportName);
                Task.Delay(waitDelay5).Wait();

                //Click on Inforce Date drop down.
                driver.FindElement(By.XPath("//img[@id[contains(.,'FormLayout_deInforceDate_B-1Img')]]")).Click();
                Task.Delay(waitDelay5).Wait();

                //Click on Today button.
                driver.FindElement(By.XPath("//td[@id[contains(.,'FormLayout_deInforceDate_DDD_C_BT')]]")).Click();
                Task.Delay(waitDelay5).Wait();

                //Click on Browse button.
                driver.FindElement(By.XPath("//td[@id[contains(.,'AdhocUploadControl_Browse0')]]//a[text()='Browse...']")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, reportDirectory, adhocFileName1));
                Task.Delay(waitDelayLongPlus).Wait();
                HitEnterKey();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", adhocFileName1))));

                //Enter a Notification Group.
                driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_tbNotificationGroups_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'FormLayout_tbNotificationGroups_I')]]")).SendKeys(notificationName);
                Task.Delay(waitDelay5).Wait();

                if (adhocApproval == 0)
                {
                    var requiresApproval = driver.FindElements(By.XPath("//span[@id[contains(.,'AdhocPopupControl_FormLayout_cbRequiresApproval')]]//span[@class[contains(.,'dxWeb_edtCheckBoxChecked_SoftOrange')]]"));

                    if (requiresApproval.Any())
                    {
                        //Uncheck Requires Approval.
                        driver.FindElement(By.XPath("//span[@id[contains(.,'AdhocPopupControl_FormLayout_cbRequiresApproval')]]//span[@class[contains(.,'edtCheckBoxChecked')]]")).Click();
                        Task.Delay(waitDelay5).Wait();
                    }
                }

                if (adhocApproval == 1)
                {
                    var requiresApproval = driver.FindElements(By.XPath("//span[@id[contains(.,'AdhocPopupControl_FormLayout_cbRequiresApproval')]]//span[@class[contains(.,'edtCheckBoxChecked')]]"));

                    if (!requiresApproval.Any())
                    {
                        //Check Requires Approval.
                        driver.FindElement(By.XPath("//span[@id[contains(.,'AdhocPopupControl_FormLayout_cbRequiresApproval')]]//span[@class[contains(.,'edtCheckBoxUnchecked')]]")).Click();
                        Task.Delay(waitDelay5).Wait();
                    }
                }

                //Click on Submit button.
                driver.FindElement(By.XPath("//span[text()='Submit']")).Click();
                Task.Delay(waitDelaySuper).Wait();

                //Waits for modal to disappear.
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//label[text()='Report Name:']")));
            }
            #endregion
        }
        public void DefineReportInforceDate()
        {
            #region Aquire RunListInstanceIds
            String textValue1 = driver.FindElement(By.XPath("//tr[@id[contains(.,'RunListInstanceGridView_DXDataRow0')]]//td[@class='dxgv dx-al'][1]")).Text;
            runListInstId1 = textValue1;

            if (rliQuantity == 1)
            {
                String textValue2 = driver.FindElement(By.XPath("//tr[@id[contains(.,'RunListInstanceGridView_DXDataRow1')]]//td[@class='dxgv dx-al'][1]")).Text;
                runListInstId2 = textValue2;
            }
            #endregion


            //~SQL DATABASE:-----------------------------------------------------------------------------------------------------------------------------------------------

            //Connect to SQL DB.
            SQLConnect();

            #region DB RunList Inforce EndDate for Report 1
            try
            {
                string sql1Query = string.Format("SELECT runlistinstance_inforce_enddate FROM tbl_RunListInstance WHERE runlistinstance_id = {0}", runListInstId1);
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        var data = myReader.GetValue(i);
                        string actual = data.ToString();
                        sqlQueryResult1 = actual;
                    }
                }

                myReader.Close();
            }

            catch (Exception)
            {
                Assert.Fail("Unexpected Result: No inforce date was obtained.");
            }
            #endregion

            if (rliQuantity == 1)
            {
                #region DB RunList Inforce EndDate for Report 2
                try
                {
                    string sql1Query = string.Format("SELECT runlistinstance_inforce_enddate FROM tbl_RunListInstance WHERE runlistinstance_id = {0}", runListInstId2);
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        for (int i = 0; i < myReader.FieldCount; i++)
                        {
                            var data = myReader.GetValue(i);
                            string actual = data.ToString();
                            sqlQueryResult2 = actual;
                        }
                    }

                    myReader.Close();
                }

                catch (Exception)
                {
                    Assert.Fail("Unexpected Result: No inforce date was obtained.");
                }
                #endregion
            }

            //Close connection to SQL DB.
            SQLClose();


            //~STATUS DASHBOARD PAGE:----------------------------------------------------------------------------------------------------------------------------------------
            #region Restructure and Define Report Inforce Date
            reportInforcedate = sqlQueryResult1;

            DateTime date = DateTime.Parse(reportInforcedate);
            reportInforcedate = date.ToString("MM/dd/yyyy");
            #endregion

        }
        public void DenyReport()
        {
            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Click on Deny.
                driver.FindElement(By.XPath("//button[text()='Deny']")).Click();
                Task.Delay(waitDelayMega).Wait();

                //Waits for item to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Denied']")));

                //Validate presence of Denied Overview after approving report.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("(//span[text()='Denied'])[1]")));

                //Validate presence of Denied Report Validation after approving report.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("(//span[text()='Denied'])[2]")));

                //Validate absence of all 3 report actions.
                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//button[text()='Approve']")));
                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//button[text()='Deny']")));
                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//span[text()='Override']")));
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Click on Denied.
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Denied']", reportFile))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for item to appear.
                wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format("//tr[td[text()='{0}']][1]//td[text()='Denied'][1]", reportFile))));

                //Validate presence of Denied Status.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//td[8][text()='Denied'][1]", reportFile))));

                //Validate presence of Denied Review Result.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//td[9][text()='Denied'][1]", reportFile))));

                //Validate presence of Reviewed By record in correct "first & last" format.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]/td[6][text()='{1}']", reportFile, targetUserName))));

                //Validate absence of top level directory in user record.
                Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]/td[6][contains(.,'ROOT_MILLIMAN\')]", reportFile))));

                //Validate absence of all 3 report actions.
                Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Approve']", reportFile))));
                Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Denied']", reportFile))));
                Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportFile))));
            }
            #endregion

            //Validate presence of correct Reviewed by record after approving report.
            try
            {
                if (cancelApproval != 1)
                {
                    if (targetChameleon == 1)
                    {
                        //Validate presence of Report Validation user.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format(@"//span[text()='ROOT_MILLIMAN\{0}']", targetUserName))));
                    }
                    else
                    {
                        //Validate presence of Reviewed By record in correct "first & last" format.
                        Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]/td[6][text()='{1}']", reportFile, targetUserName))));
                    }
                }
            }

            catch (Exception)
            {
                Assert.Fail("Unexpected Result: Recorded report validation user name is incorrect.");
            }

            #region HedgeOps 2.9-
            if (targetChameleon != 1)
            {
                if (overriddenReport == 1)
                {
                    //Validate presence of checked Overridden checkbox after overriding report.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("(//tr[td[text()='{0}']]//span[@class[contains(.,'CheckBoxChecked')]])[1]", reportFile))));
                }
                else
                {
                    //Validate presence of unchecked Overridden checkbox after approving report.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("(//tr[td[text()='{0}']]//span[@class[contains(.,'CheckBoxUnchecked')]])[1]", reportFile))));
                }
            }
            #endregion
        }

        public void GenericOverrideReport()
        {
            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Override Report']")));

                //Click on Attach File button.
                driver.FindElement(By.XPath("//span[text()='Attach File']")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                //Isolate the file name for future use.
                importName = importFile;

                //Navigate and select file in file explorer.
                importFile = Path.Combine(mainAutomationDirectory, reportDirectory, importFile);
                SendKeys.SendWait(importFile);
                Task.Delay(waitDelayMega).Wait();
                HitEnterKey();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//span[text()='{0}']", importName))));

                //Click Upload button.
                driver.FindElement(By.XPath("//button[text()='Upload']")).Click();
                Task.Delay(waitDelaySuper).Wait();

                //Waits for item to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Success!']")));

                //Click Close button.
                driver.FindElement(By.XPath("//span[text()='Close']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to disappear.
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Override Report']")));

                //Validate presence of PendingApproval status after overriding report.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[div[div[span[text()='{0}']]]][1]//span[text()='PendingApproval']", reportFile))));

                if (reportFile != reportApprovals1Name + " 2")
                {
                    //Validate presence of Approve button.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath("//button[text()='Approve']")));
                }

                //Validate presence of Deny button.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//button[text()='Deny']")));

                //Validate presence of Override button.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()='Override']")));

                //Validate presence of newly uploaded file in Report column.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//span[text()='{0}']", reportFile))));
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Report Override']")));

                //Click on Browse button.
                driver.FindElement(By.XPath("//td[@id[contains(.,'OverrideForm_UploadControl_Browse0')]]/a[text()='Browse...']")).Click();
                Task.Delay(waitDelayBrowse).Wait();

                //Isolate the file name for future use.
                importName = importFile;

                //Navigate and select file in file explorer.
                importFile = Path.Combine(mainAutomationDirectory, reportDirectory, importFile);
                SendKeys.SendWait(importFile);
                Task.Delay(waitDelayMega).Wait();
                HitEnterKey();

                //Waits for file to appear in field (sometimes theres a few second delay)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", importName))));

                //Click OK button.
                driver.FindElement(By.XPath("//div[@id[contains(.,'OverrideForm_ctl14_CD')]]/span[text()='OK']")).Click();
                Task.Delay(waitDelay5).Wait();

                //Hit the Enter key.
                HitEnterKey();
                Task.Delay(waitDelayMega).Wait();

                //Waits for modal to disappear.
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Report Override']")));

                //Validate presence of PendingApproval status and overridden report.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//td[text()='PendingApproval']", reportFile))));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//a[text()='{1}']", reportFile, reportName))));

                //Validate presence of checked Overridden checkbox after overriding report.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("(//tr[td[text()='{0}']]//span[@class[contains(.,'CheckBoxChecked')]])[1]", reportFile))));

                //Validate absence of Reviewed by record.
                Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]/td[6][text()='{1}']", reportFile, targetUserName))));
            }
            #endregion
        }
        public void OutputDashSortByInforceDateToday()
        {
            #region HedgeOps 2.9-
            if (targetChameleon != 1)
            {
                //Click on Inforce date picker.
                driver.FindElement(By.XPath("//td[@id[contains(.,'InforceDatePicker_B-1')]]")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Click on Today button.
                driver.FindElement(By.XPath("//tr[td[@id[contains(.,'InforceDatePicker_DDD_C')]]]/td[text()='Today']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Click on Search button.
                ClickSearchButton();
            }
            #endregion
        }
        public void OverrideAdhocReport()
        {
            //Toggle a variation of method test steps.
            //importToggle = 1;

            importFile = adhocFileName2;

            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Click on Override.        
                driver.FindElement(By.XPath("//span[text()='Override']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Override Report']")));
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Click on Override.        
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportName))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Report Override']")));
            }
            #endregion

            //Override a report.
            GenericOverrideReport();
        }
        public void OutputDashReportIdentification()
        {
            #region HedgeOps 2.9-
            if (targetChameleon != 1)
            {
                //Filter by Inforce Date.
                driver.FindElement(By.XPath("//input[@id[contains(.,'MainContent_InforceDatePicker_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'MainContent_InforceDatePicker_I')]]")).Clear();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'MainContent_InforceDatePicker_I')]]")).SendKeys(reportInforcedate);
                Task.Delay(waitDelay5).Wait();

                //Click on Search button.
                ClickSearchButton();

                //Sort by Run Name.
                driver.FindElement(By.XPath("//input[@id[contains(.,'ReportsByInforceDateGridView_DXFREditorcol2_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'ReportsByInforceDateGridView_DXFREditorcol2_I')]]")).Clear();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'ReportsByInforceDateGridView_DXFREditorcol2_I')]]")).SendKeys(reportFile);
                Task.Delay(waitDelayExtreme).Wait();

                //Sort by latest Run Instance ID. (click twice to sort by descending)
                driver.FindElement(By.XPath("//td[text()='ID']")).Click();
                Task.Delay(waitDelayMega).Wait();
                driver.FindElement(By.XPath("//td[text()='ID']")).Click();
                Task.Delay(waitDelayMega).Wait();
            }
            #endregion
        }
        public void OutputDashViewReportDetails()
        {
            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                if (adhocApproval == 0)
                {
                    //Restart stopwatch.
                    timer.Restart();

                    waitDelayCustom = 6000;

                    //Attempt to check for report completion until timer expires.
                    while (timer.Elapsed.TotalSeconds < timerReport && timer.IsRunning.Equals(true))
                    {
                        var reportStatus = driver.FindElements(By.XPath(string.Format("((//div[div[div[div[span[text()='{0}']]]]][1])//span[text()='Complete'])[1]", reportFile)));

                        if (!reportStatus.Any())
                        {
                            Task.Delay(waitDelayCustom).Wait();

                            //Refresh browser.
                            RefreshBrowser();
                        }

                        else
                        {
                            //Stop stopwatch.
                            timer.Stop();
                        }
                    }

                    //Validate presence of Complete status.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("((//div[div[div[div[span[text()='{0}']]]]][1])//span[text()='Complete'])[1]", reportFile))));

                    //Click on report row.
                    driver.FindElement(By.XPath(string.Format("((//div[div[div[div[span[text()='{0}']]]]][1])//span[text()='Complete'])[1]", reportFile))).Click();
                    Task.Delay(waitDelaySuper).Wait();

                    //Waits for item to appear.
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Overview']")));
                    Task.Delay(waitDelaySuper).Wait();
                }
                else
                {
                    Task.Delay(waitDelayLong).Wait();

                    //Validate presence of Pending Approval status.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("((//div[div[div[div[span[text()='{0}']]]]])[1]//span[text()='Pending Approval'])[1]", reportFile))));

                    //Click on report row.
                    driver.FindElement(By.XPath(string.Format("((//div[div[div[div[span[text()='{0}']]]]])[1]//span[text()='Pending Approval'])[1]", reportFile))).Click();
                    Task.Delay(waitDelaySuper).Wait();

                    //Waits for item to appear.
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Resolution Comments']")));
                    Task.Delay(waitDelaySuper).Wait();
                }
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Validate presence of PendingApproval status.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//td[text()='PendingApproval']", reportFile))));
            }
            #endregion
        }
        #endregion

        #region Run Groups & Run Type Suite Tests
        public int checkDetails1_HOPS796;

        public static string badass = "Basic Badass", barker = "Basic Barker", bloomberg = "Basic Bloomberg", genVal = "Basic Generic Valuation", marketData = "Basic Get MarketData",
            tickerItem = "Basic Get TickerItem", inforce = "Basic Inforce", hedge6 = "Basic MGHedge - PXR6", hedge7 = "Basic MGHedge - PXR7", hedge8 = "Basic MGHedge - PXR8",
            hedge8OverlayAll = "MGHedge PXR8 (All with Overlay)", hedge8OverlayNone = "MGHedge PXR8 (None with Overlay)", hedgeAllAux = "MGHedge PXR6,7,8 - Auxillary (With Overlay)", hedgeNoAux = "MGHedge PXR6,7,8 - Decomp Types",
            report = "Basic Report - No Approvals", repCopyType = "Basic Report - Copy Type", repNotif = "Basic Report Notification", scenario = "Basic Scenario", split = "Basic Split", sync = "Basic Sync",
            mghedgeFormatParameterSetpxr8 = "MGHedge Format Parameter Set Run - PXR8",
            mghedgeHedgeOpsFormatParameterSetpxr8 = "MGHedge and HedgeOps Format Parameter Set Run - PXR8",
            parameterFilePostRunGroup = "Parameter File Post Run Group";

        public static string genValRuns1 = "Generic Valuation Test Runs", genValRunsHeader = "Generic Valuation Run", genValInforce1 = "Generic Valuation Inforce Runs", genValInforceHeader = "Inforce Run";
        public static string cloudImportAppend = " - Cloud", importFile, runListInstance, runName;

        public static string runHedgeHOPS796_Inforces = "HOPS-796 - Inforces", runHedgeHOPS796_1 = "HOPS-796 - PXR8 MGHedge Run 1 - Mix 1", runHedgeHOPS796_2 = "HOPS-796 - PXR8 MGHedge Run 1 - Mix 2",
            runHedgeHOPS796_3 = "HOPS-796 - PXR8 MGHedge Run 2 - Mix 1", runHedgeHOPS796_4 = "HOPS-796 - PXR8 MGHedge Run 3 - Mix 1";
        public static string run1_Hops796 = "R1 - PV - Inforce - Lines", run2_Hops796 = "R2 - PV - Scenario - Column", run3_Hops796 = "R3 - CF - Inforce - Lines", run4_Hops796 = "R4 - CF - Scenario - Lines",
            run5_Hops796 = "R5 - SSR - Inforce - Column", run6_Hops796 = "R6 - SSR - Scenario - Column", run7_Hops796 = "R7 - PV - Task - Lines", run8_Hops796 = "R8 - CF - Task - Column", run9_Hops796 = "R9 - SSR - Task - ColumnGross",
            run10_Hops796 = "R10 - PV (proj) - Inforce - Lines", run11_Hops796 = "R11 - PV (proj) - Scenario - Column", run12_Hops796 = "R12 - PV (proj) - Task - Lines", run13_Hops796 = "R13 - CF (proj) - Inforce - Column",
            run14_Hops796 = "R14 - CF (proj) - Scenario - Lines", run15_Hops796 = "R15 - CF (proj) - Task - Column", run16_Hops796 = "R16 - SSR (proj) - Inforce - ColumnGross", run17_Hops796 = "R17 - SSR (proj) - Scenario - ColumnGross",
            run18_Hops796 = "R18 - SSR (proj) - Task - ColumnGross", run19_Hops796 = "R19 - PXR6 - Inforce - Lines", run20_Hops796 = "R20 - PXR6 - Scenario - Column", run21_Hops796 = "R21 - PXR6 - Task - Lines",
            run22_Hops796 = "R22 - PXR6 - Inforce - Column", run23_Hops796 = "R23 - PXR6 - Scenario - Lines", run24_Hops796 = "R24 - PXR6 - Task - Column", run25_Hops796 = "R25 - PXR6 - Inforce - ColumnGross",
            run26_Hops796 = "R26 - PXR6 - Scenario - ColumnGross", run27_Hops796 = "R27 - PXR6 - Task - ColumnGross";

        public string dateTokenFile1 = "DT 01 - 11 Basic MGHedge Regression" + extXLSX;
        public string dateTokenFile2 = "All-runtypes-with-inforce" + extXLSX;
        public string dummyRunGroup = ".DummyGroupForTesting" + extXLSX;
        public string deactivatedRunGroup = ".DeactivatedTestGroup";
        public string deactivatedRunGroupFile = "DeactivatedTestGroup" + extXLSX;

        public string runItemCopyType = "FileSystem";
        public string runItemNameInforce = "Inforce Auto Test";
        public string runItemOutputFileNameInforce = "Inforce Auto Test Report.txt";
        public string runItemPriority = "500";
        public string runItemTimeout = "1";
        public string runItemTypeInforce = "Inforce";

        public string runDataSetActionNone = "None";
        public string runDataSetDate = "12/31/2014";
        public string runDataSetMethod = "ForceRebase|ForceOverwrite";
        public string runDataSetStep = "StubStep2 Replacement";
        public string runDataSetVerTypeFundMap = "FundMapping";
        public string runDataSetVerTypeInforce = "LiabilityInforce";

        public string runValDate1 = "2021-03-04";

        public static string AnyRunFile()
        {
            importFile = runGroup + extXLSX;

            return importFile;
        }
        public static string BadassRunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = badass + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = badass + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public static string BarkerRunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = barker + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = barker + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public static string BloombergRunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = bloomberg + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = bloomberg + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public static string GenericValRunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = genVal + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = genVal + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public static string InforceRunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = inforce + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = inforce + cloudImportAppend + extXLSX;
            }

            return importFile;
        }

        public string mghedgePxrAuxiliaryFile = hedgeAllAux + extXLSX;
        public string mghedgePxrNoAuxiliaryFile = hedgeNoAux + extXLSX;
        public static string MghedgePxr6RunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = hedge6 + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = hedge6 + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public static string MghedgePxr7RunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = hedge7 + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = hedge7 + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public static string GenerateImportFile(string importFileName)
        {
            if (targetTestingLocation == 0)
            {
                importFile = importFileName + extXLSX;
            }
            if (targetTestingLocation == 1)
            {
                importFile = importFileName + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public static string MGHedgeHedgeOpsFormatParameterSetPXR8RunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = mghedgeHedgeOpsFormatParameterSetpxr8 + extXLSX;
            }

            return importFile;
        }
        public static string MGHedgeFormatParameterSetPXR8RunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = mghedgeFormatParameterSetpxr8 + extXLSX;
            }

            return importFile;
        }
        public static string MghedgePxr8RunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = hedge8 + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = hedge8 + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public string reportNotifRunFile = repNotif + extXLSX;

        public static string ReportRunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = report + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = report + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public static string ReportCopyTypeRunFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = repCopyType + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = repCopyType + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public string scenarioRunFile = scenario + extXLSX;
        public string splitHedgeTempRunFile = split + extXLSX;
        public string syncRunFile = sync + extXLSX;

        public static string GetTickerItemFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = tickerItem + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = tickerItem + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public static string getTickerItemReportFileName = "Ticker_Report.txt";
        public static string getTickerItemReportFileNameCloud = "Ticker_Report_Cloud.txt";
        public string reportTickerItem = Path.Combine(fileCopyToLocationOnPrem, getTickerItemReportFileName);

        public static string GetMarketDataFile()
        {
            if (targetTestingLocation == 0)
            {
                importFile = marketData + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = marketData + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public static string getMarketDataReportFileName = "Market_Report.txt";
        public static string getMarketDataReportFileNameCloud = "Market_Report_Cloud.txt";
        public string reportMarketData = Path.Combine(fileCopyToLocationOnPrem, getMarketDataReportFileName);
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void ChooseTodayScheduleDate()
        {
            //Click on run schedule date drop down.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_CutoffDatePicker_B-1")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Today button.
            driver.FindElement(By.XPath("//td[text()='Today']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Refresh button.
            driver.FindElement(By.XPath("//span[text()='Refresh']")).Click();

            //Waits for date picker button to load.
            wait.Until(ExpectedConditions.ElementExists(By.Id("ctl00_ctl00_ASPxSplitter4_Content_ContentSplitter_MainContent_CutoffDatePicker_B-1")));
            Task.Delay(waitDelay5).Wait();
        }
        public void CreateScratchInforceRunItem()
        {
            //Wait for row to be expanded.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Data Sets']")));

            //~CONFIGURE - BASIC:--------------------------------------------------------------------------------------------------------------------------------------------
            //Click Active checkbox.
            driver.FindElement(By.XPath("//span[@id[contains(.,'Main_EF_RunListActive_')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click Email Status Updates checkbox.
            driver.FindElement(By.XPath("//span[@id[contains(.,'Main_EF_RunListEmailStatusUpdates_')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            //Enter a Notification group.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_NotificationGroupsTokenBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_NotificationGroupsTokenBox_I')]]")).SendKeys(notificationName);
            Task.Delay(waitDelay5).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListName_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListName_I')]]")).SendKeys(runItemNameInforce);
            Task.Delay(waitDelay5).Wait();

            //~CONFIGURE - COPY:---------------------------------------------------------------------------------------------------------------------------------------------
            //Enter a Copy To location.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListPostLocation_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            if (targetTestingLocation == 0)
            {
                driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListPostLocation_I')]]")).SendKeys(fileCopyToLocationOnPrem);
                Task.Delay(waitDelay5).Wait();
            }

            if (targetTestingLocation == 1)
            {
                driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListPostLocation_I')]]")).SendKeys(fileCopyToLocationCloud);
                Task.Delay(waitDelay5).Wait();
            }

            //Enter a Copy Type.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListPostMedium_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListPostMedium_I')]]")).SendKeys(runItemCopyType);
            Task.Delay(waitDelay5).Wait();

            //~CONFIGURE - OUTPUT:-------------------------------------------------------------------------------------------------------------------------------------------
            //Enter an Output File Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListFileName_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListFileName_I')]]")).SendKeys(runItemOutputFileNameInforce);
            Task.Delay(waitDelay5).Wait();

            //Click Email Copy of Output checkbox.
            driver.FindElement(By.XPath("//span[@id[contains(.,'Main_EF_RunListEmailOutput')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            //~CONFIGURE - EXECUTION:----------------------------------------------------------------------------------------------------------------------------------------
            //Enter a Launch Timeout.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListLaunchTimeout_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListLaunchTimeout_I')]]")).SendKeys(runItemTimeout);
            Task.Delay(waitDelay5).Wait();

            //Enter an Execution Timeout.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListExecutionTimeout_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListExecutionTimeout_I')]]")).SendKeys(runItemTimeout);
            Task.Delay(waitDelay5).Wait();

            //Enter a Priority.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListPriority_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_EF_RunListPriority_I')]]")).SendKeys(runItemPriority);
            Task.Delay(waitDelay5).Wait();

            //~CONFIGURE - DATASET 1:----------------------------------------------------------------------------------------------------------------------------------------
            //Create a new Dataset.
            CreateNewDataset();

            //Enter a Version Type.
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionType_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionType_I')]]")).SendKeys(runDataSetVerTypeFundMap);

            //Hit the Enter key.
            HitEnterKey();
            Task.Delay(waitDelayLong).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionName_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionName_I')]]")).SendKeys(fundmapName2);

            //Hit the Enter key.
            HitEnterKey();
            Task.Delay(waitDelayLong).Wait();

            //Enter a Date.
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionDate_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionDate_I')]]")).SendKeys(runDataSetDate);
            Task.Delay(waitDelay5).Wait();

            var actionPresent = driver.FindElements(By.XPath("(//td[@class='dxic']/input[@value='None'])[2]"));

            if (!actionPresent.Any())
            {
                //Enter an Action.
                driver.FindElement(By.XPath("//input[@id[contains(.,'Main_Action_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'Main_Action_I')]]")).SendKeys(runDataSetActionNone);
                Task.Delay(waitDelay5).Wait();
            }

            //Click on Update button.
            driver.FindElement(By.XPath("//a[@id[contains(.,'DataSetGridView')]]/span[text()='Update']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //~CONFIGURE - DATASET 2:----------------------------------------------------------------------------------------------------------------------------------------
            //Create a new Dataset.
            CreateNewDataset();

            //Enter a Version Type.
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionType_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionType_I')]]")).SendKeys(runDataSetVerTypeInforce);
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("(//em[text()='{0}'])[2]", runDataSetVerTypeInforce))).Click();

            //Hit the Enter key.
            HitEnterKey();
            Task.Delay(waitDelayLong).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionName_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionName_I')]]")).SendKeys(inforceDTName1);

            //Hit the Enter key.
            HitEnterKey();
            Task.Delay(waitDelayLong).Wait();

            //Enter a Date.
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionDate_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'PrimaryVersionDate_I')]]")).SendKeys(runDataSetDate);
            Task.Delay(waitDelay5).Wait();

            //Enter a Step.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_Step_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_Step_I')]]")).SendKeys(runDataSetStep);
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("(//em[text()='{0}'])[2]", runDataSetStep))).Click();

            //Enter a Method.
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_Method_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'Main_Method_I')]]")).SendKeys(runDataSetMethod);
            Task.Delay(waitDelay5).Wait();

            var actionPresent2 = driver.FindElements(By.XPath("(//td[@class='dxic']/input[@value='None'])[2]"));

            if (!actionPresent2.Any())
            {
                //Enter an Action.
                driver.FindElement(By.XPath("//input[@id[contains(.,'Main_Action_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'Main_Action_I')]]")).SendKeys(runDataSetActionNone);
                Task.Delay(waitDelay5).Wait();
            }

            //Click on Dataset Update button.
            driver.FindElement(By.XPath("//a[@id[contains(.,'DataSetGridView')]]/span[text()='Update']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //~UPDATE RUN TYPE:----------------------------------------------------------------------------------------------------------------------------------------------
            //Click on Edit Run Update button.
            driver.FindElement(By.XPath("//a[@id[contains(.,'RunListGridView')]]/span[text()='Update']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Wait for Edit Run window to close.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//tbody[tr[td[text()='{0}']]]//span[text()='Edit']", runItemNameInforce))));
        }
        public void CreateNewDataset()
        {
            //Click on dataset New link.
            driver.FindElement(By.XPath("//a[@id[contains(.,'RunList_RunListGridView_DXPEForm_efnew_EF_Main_DataSetCtrl_DataSetGridView_DXCBtn0')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            //waits for dataset edit modal to expand.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id[contains(.,'RunList_RunListGridView_DXPEForm_efnew_EF_Main_DataSetCtrl_DataSetGridView_DXPEForm_HCB-1')]]")));
        }
        public void DatasetDeleteTest()
        {
            //Expand run group.
            driver.FindElement(By.XPath("//tr[td[text()='.DummyGroupForTesting']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for tab to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@id[contains(.,'pageControl_T1T')]]//span[text()='Schedules']")));

            //Click the Edit button.
            driver.FindElement(By.XPath("//tr[td[text()='Dummy MGHedge (do not use)']]//span[text()='Edit']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Edit Run']")));

            //Click the Delete button for Model dataset.
            driver.FindElement(By.XPath("(//tr[td[text()='Model']]//a[span[text()='Delete']])[2]")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Hit the Esc key.
            SendKeys.SendWait(@"{Esc}");
            Task.Delay(waitDelay5).Wait();

            //Close the Edit modal.
            driver.FindElement(By.XPath("(//img[@class='dxWeb_pcCloseButton_SoftOrange'])[4]")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table[@id[contains(.,'JobsGridView_DXPFCForm_DXPFC_LPV')]]//span[text()='Loading…']")));

            //Waits for item to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[td[text()='Dummy MGHedge (do not use)']]//span[text()='Edit']")));

            //Click the Edit button.
            driver.FindElement(By.XPath("//tr[td[text()='Dummy MGHedge (do not use)']]//span[text()='Edit']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Edit Run']")));
        }
        public void GenericImportRunGroup()
        {
            //Click on Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'RunListUpload_Browse0')]]/a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            //Isolate the file name for future use.
            importName = importFile;

            //For GENERAL run groups:
            if (importToggle == 1)
            {
                //Navigate and select file in file explorer.
                importFile = Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryNew, importFile);
            }
            //For DATE TOKEN run groups:
            if (importToggle == 2)
            {
                //Navigate and select file in file explorer.
                importFile = Path.Combine(mainAutomationDirectory, dateTokenDirectory, dateTokensubDirectory1, importFile);
            }
            //For RUN TYPE SUITE groups & all others:
            else
            {
                if (targetChameleon == 1)
                {
                    //Navigate and select file in file explorer.
                    importFile = Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryNew, importFile);
                }
                else
                {
                    //Navigate and select file in file explorer.
                    importFile = Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryOld, importFile);
                }
            }

            SendKeys.SendWait(importFile);
            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();
            Task.Delay(waitDelayLong).Wait();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", importName))));

            //Click OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'ImportPopupControl')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelayLongPlus).Wait();

            //Waits for extracting message to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Extracting data from file...']")));

            if (importFile.Contains(badRunGroup) == false)
            {
                //Waits for modal to disappear.
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
            }
        }

        public void IdentifyScheduledRuns() //>Primarily used for test of full regression suite scheduled runs
        {
            //Restart stopwatch.
            timer.Restart();

            //Check for appearance of scheduled runs.
            while (timer.Elapsed.TotalSeconds < timer2Minute && timer.IsRunning.Equals(true))
            {
                var runsPresent = driver.FindElements(By.XPath(string.Format("//tr[td[text()='{0}']][15]//td[text()[contains(.,'Basic')]]", scheduleBasicRegression)));

                if (!runsPresent.Any())
                {
                    //Refresh browser.
                    RefreshBrowser();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Restart stopwatch.
            timer.Restart();

            //Check for Open states of scheduled runs.
            while (timer.Elapsed.TotalSeconds < timerMinute && timer.IsRunning.Equals(true))
            {
                var runOpen = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}']/td[text()[contains(.,'Open')]][1]", runGroup)));

                if (!runOpen.Any())
                {
                    //Refresh browser.
                    RefreshBrowser();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }
        }
        public void IdentifySubmittedRuns()
        {
            //Restart stopwatch.
            timer.Restart();

            //Check for appearance of submitted run.
            while (timer.Elapsed.TotalSeconds < timerMinute && timer.IsRunning.Equals(true))
            {
                var runPresent = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}'][1]", runGroup)));

                if (!runPresent.Any())
                {
                    //Refresh browser.
                    RefreshBrowser();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Restart stopwatch.
            timer.Restart();

            //Check for Open state of submitted run.
            while (timer.Elapsed.TotalSeconds < timerMinute && timer.IsRunning.Equals(true))
            {
                var runOpen = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}']/td[text()[contains(.,'Open')]][1]", runGroup)));

                if (!runOpen.Any())
                {
                    //Refresh browser.
                    RefreshBrowser();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Expand run group row.
            driver.FindElement(By.XPath(string.Format("//tr[td/text()='{0}'][1]//img[@class[contains(.,'DetailCollapsedButton')]]", runGroup))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for item appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='ID']")));

            //Click on Refresh button. 
            //>(This action locks the expansion of the group table upon subsequent refreshes)
            ClickRefreshButton();
        }
        public void IdentifySubmittedRunsReact() //>This is for new react run status page
        {
            //Restart stopwatch.
            timer.Restart();

            //Check for appearance of submitted run.
            while (timer.Elapsed.TotalSeconds < timerMinute && timer.IsRunning.Equals(true))
            {
                var runPresent = driver.FindElements(By.XPath(string.Format("(//span[text()='{0}'])[1]", runGroup)));

                if (!runPresent.Any())
                {
                    //Refresh browser.
                    RefreshBrowser();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Restart stopwatch.
            timer.Restart();

            //Check for Open state of submitted run.
            while (timer.Elapsed.TotalSeconds < timerMinute && timer.IsRunning.Equals(true))
            {
                var runOpen = driver.FindElements(By.XPath(string.Format("(//div[div[div[span[text()='{0}']]]])[1]//span[text()='In Progress']", runGroup)));

                if (!runOpen.Any())
                {
                    //Refresh browser.
                    RefreshBrowser();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Click on run group row.
            driver.FindElement(By.XPath(string.Format("(//div[div[div[span[text()='{0}']]]])[1]", runGroup))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for item to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//span[text()='Status:'])[1]")));
        }

        public void ImportDateTokenRuns1()
        {
            if (goldImports != 1)
            {
                //Toggle a variation of method test steps.
                importToggle = 2;

                importFile = dateTokenFile1;

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportDateTokenRuns2()
        {
            if (goldImports != 1)
            {
                //Toggle a variation of method test steps.
                importToggle = 2;

                importFile = dateTokenFile2;

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportDeactivatedRunGroupFile()
        {
            runGroup = deactivatedRunGroup;
            importFile = deactivatedRunGroupFile;

            //Import a run group.
            GenericImportRunGroup();
        }

        public void ImportDummyRun()
        {
            importFile = dummyRunGroup;

            //Import a run group.
            GenericImportRunGroup();
        }
        public void ImportGetTickerItem()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = tickerItem;
            runGroupCloud = tickerItem + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                GetTickerItemFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportGetMarketData()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = marketData;
            runGroupCloud = marketData + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                GetMarketDataFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }

        public void ImportBadassRun()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = badass;
            runGroupCloud = badass + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                BadassRunFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportBarkerRun()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = barker;
            runGroupCloud = barker + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                BarkerRunFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportBloombergRun()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = bloomberg;
            runGroupCloud = bloomberg + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                BloombergRunFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportGenericValRun()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = genVal;
            runGroupCloud = genVal + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                GenericValRunFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportInforceRun()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = inforce;
            runGroupCloud = inforce + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                InforceRunFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportAnyRun()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = runName;
            runGroupCloud = runName + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                AnyRunFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }

        public void ImportMghedgePxrAuxiliaryRun()
        {
            runGroup = hedgeAllAux;

            if (goldImports != 1)
            {
                importFile = mghedgePxrAuxiliaryFile;

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportMghedgePxrNoAuxiliaryRun()
        {
            runGroup = hedgeNoAux;

            if (goldImports != 1)
            {
                importFile = mghedgePxrNoAuxiliaryFile;

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportMghedgePxr6Run()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = hedge6;
            runGroupCloud = hedge6 + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                MghedgePxr6RunFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportMghedgePxr7Run()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = hedge7;
            runGroupCloud = hedge7 + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                MghedgePxr7RunFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportParameterFilePostRun()
        {
            runGroupOnPrem = parameterFilePostRunGroup;
            runListName = "MGHedge Run - PV-PXR8";

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }
            //Generate import file.
            GenerateImportFile(parameterFilePostRunGroup);

            //Import a run group.
            GenericImportRunGroup();
        }
        public void ImportMGHedgeHedgeOpsFormatParameterSetPXR8Run()
        {
            runGroupOnPrem = mghedgeHedgeOpsFormatParameterSetpxr8;
            runListName = "MGHedge Run - PV-PXR8";

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }
            //Generate import file.
            MGHedgeHedgeOpsFormatParameterSetPXR8RunFile();

            //Import a run group.
            GenericImportRunGroup();
        }
        public void ImportMGHedgeFormatParameterSetPXR8Run()
        {
            runGroupOnPrem = mghedgeFormatParameterSetpxr8;
            runListName = "MGHedge Run - PV-PXR8";

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }
            //Generate import file.
            MGHedgeFormatParameterSetPXR8RunFile();

            //Import a run group.
            GenericImportRunGroup();
        }
        public void ImportMghedgePxr8Run()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = hedge8;
            runGroupCloud = hedge8 + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                MghedgePxr8RunFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ClickEditButtonOnRunListJob(string runListJobName)
        {
            //click edit on a run list job
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format
                ("//td[text()='{0}']/following-sibling::td[4]/a", runListJobName))));
            driver.FindElement(By.XPath(string.Format("//td[text()='{0}']/following-sibling::td[4]/a", runListJobName))).Click();
        }
        public void ExpandRunGroup(string runGroupName)
        {
            //Expand the run group
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format
                ("//*[text()='{0}']/preceding-sibling::td/img", runGroupName))));
            driver.FindElement(By.XPath(string.Format
                ("//*[text()='{0}']/preceding-sibling::td/img", runGroupName))).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[text()='Loading…']")));
        }
        public void ImportNotificationRun()
        {
            //>Listed as such for ease of use.
            runGroup = repNotif;

            if (goldImports != 1)
            {
                importFile = reportNotifRunFile;

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportReportRun()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = report;
            runGroupCloud = report + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Generate import file.
                ReportRunFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportReportCopyTypeRun()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = repCopyType;
            runGroupCloud = repCopyType + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Toggle a variation of method test steps.
                importToggle = 1;

                //Generate import file.
                ReportCopyTypeRunFile();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void RemoveFolderOnRemoteMachine(string targetMachine, string directoryPath, string folderName)
        {
            var winrsProcess = new Process
            {
                StartInfo = {
                FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\winrs.exe"),
                Arguments = string.Format("-r:{0} /directory:{1} cmd", targetMachine, directoryPath),
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true
                }
            };
            winrsProcess.Start();
            winrsProcess.StandardInput.WriteLine("rmdir /s /q {0}", folderName);
            Thread.Sleep(1000);//Gives the process a chance to finish deleteing the folder
            winrsProcess.StandardInput.WriteLine("exit");
            winrsProcess.Close();

            //Verify folders are deleted
            var errors = new StringBuilder();
            winrsProcess.ErrorDataReceived += (s, d) => {
                errors.Append(d.Data);
            };
            winrsProcess.Start();
            winrsProcess.StandardInput.WriteLine("dir {0}", folderName);
            winrsProcess.BeginErrorReadLine();
            winrsProcess.StandardInput.WriteLine("exit");
            winrsProcess.WaitForExit();
            Assert.AreEqual("File Not Found", errors.ToString(), folderName + " was not deleted");
        }
        public void CreateFolderOnRemoteMachine(string targetMachine, string directoryPath, string folderName)
        {
            var winrsProcess = new Process
            {
                StartInfo = {
                FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\winrs.exe"),
                Arguments = string.Format("-r:{0} /directory:{1} cmd", targetMachine, directoryPath),
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true
                }
            };
            winrsProcess.Start();
            winrsProcess.StandardInput.WriteLine("rmdir /s /q {0}", folderName);
            winrsProcess.StandardInput.WriteLine("mkdir {0}", folderName);
            winrsProcess.StandardInput.WriteLine("exit");
            winrsProcess.Close();

            //Verify folders are created
            var output = new StringBuilder();
            winrsProcess.OutputDataReceived += (s, d) =>
            {
                output.Append(d.Data);
            };
            winrsProcess.Start();
            winrsProcess.StandardInput.WriteLine("dir {0}", folderName);
            winrsProcess.BeginOutputReadLine();
            winrsProcess.StandardInput.WriteLine("exit");
            winrsProcess.WaitForExit();
            Assert.IsTrue(output.ToString().Contains(folderName), folderName + " was not created");
        }
        public void ImportScenarioRun()
        {
            if (goldImports != 1)
            {
                runGroup = scenario;
                importFile = scenarioRunFile;

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportSplitRun()
        {
            if (goldImports != 1)
            {
                runGroup = split;
                importFile = splitHedgeTempRunFile;

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportSyncRun()
        {
            if (goldImports != 1)
            {
                runGroup = sync;
                importFile = syncRunFile;

                //Import a run group.
                GenericImportRunGroup();
            }
        }

        public void VerifyFileInRunListFolder(string fileName)
        {
            //Validate the presence of file.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[@title[contains(.,'{0}')]]", fileName))));
        }
        public void VerifyFilesInDataStore(string runListInstanceID)
        {
            //Expand RunList folder.
            driver.FindElement(By.XPath("(//li[div[span[text()='RunList']]]//img[@alt='Expand'])[1]")).Click();

            //Waits for list to expand.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//li[div[span[text()='RunList']]]//img[@alt='Collapse'])[1]")));

            //Expand runlistinstanceID folder.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//span[text()[contains(.,'{0}')]]", runListInstanceID))));
            driver.FindElement(By.XPath(string.Format("//span[text()[contains(.,'{0}')]]", runListInstanceID))).Click();

            //Waits for list to expand.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//tr[@title[contains(.,'{0}')]]", runListInstanceID))));

            //Verify tstruct.txt
            VerifyFileInRunListFolder(tstructtxt);

            //Verify sheetinfo.txt
            VerifyFileInRunListFolder(sheetinfotxt);

            //Verify param.txt
            VerifyFileInRunListFolder(paramtxt);
        }
        public string GetRunListInstanceID(string runListName)
        {
            //Gets RunList instance ID
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Refresh']")));
            string runListINstanceID = driver.FindElement(By.XPath(string.Format
                ("//table[@id[contains(.,'RunListInstanceGridView_DXMainTable')]]//td[text()='{0}']/preceding-sibling::td[1]", runListName))).Text;
            return runListINstanceID;
        }
        private string GetRunListStatus(string runListName)
        {
            //Returns the status of run list name that is passed
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//tr[td/text()='{0}']", runListName))));
            return driver.FindElement(By.XPath(string.Format("//tr[td/text()='{0}']/td[7]", runListName))).Text;
        }
        public void WaitForRunListToComplete(string runListName)
        {
            //Wait until run is completed successfully 
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Refresh']"))); //Waits for Refresh button to load.

            //Identify then expand submitted run group.
            IdentifySubmittedRuns();

            //Restart stopwatch.
            timer.Restart();

            Func<bool> isCompleteStatus = () => GetRunListStatus(runListName).Equals("Complete");
            WaitUntilTrueOrTimeout(isCompleteStatus, TimeSpan.FromMinutes(20), TimeSpan.FromSeconds(30));
        }
        public void WaitForRunListIsOnGridStatus(string runListName)
        {
            //Wait until run has Generating Parameter statusy 
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Refresh']"))); //Waits for Refresh button to load.

            //Identify then expand submitted run group.
            IdentifySubmittedRuns();

            //Restart stopwatch.
            timer.Restart();

            Func<bool> isOnGridStatus = () => GetRunListStatus(runListName).Equals("OnGrid");
            WaitUntilTrueOrTimeout(isOnGridStatus, TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(5));
        }

        public void RerunAndCompleteRun()
        {
            //Rerun the run instance.
            driver.FindElement(By.XPath(string.Format("(//tr[td[text()='{0}']][1]//span[text()='ReRun'])[1]", runGroup))).Click();
            Task.Delay(waitDelayMega).Wait();

            //Identify then expand submitted run group.
            IdentifySubmittedRuns();

            //Restart stopwatch.
            timer.Restart();

            //Attempt to check for run item completion until timer expires.
            while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
            {
                var reportComplete = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}']//td[text()='Complete']", runListInstance)));

                if (!reportComplete.Any())
                {
                    //Refresh browser.
                    RefreshBrowser();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Validate that run instance completes.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td/text()='{0}']//td[text()='Complete']", runListInstance))));
        }
        public void SubmitRunGroup()
        {
            if (straightSubmit == 1)
            {
                //>Listed as such for ease of use.
                runGroupOnPrem = runName;
                runGroupCloud = runName + cloudImportAppend;

                if (targetTestingLocation == 0)
                {
                    runGroup = runGroupOnPrem;
                }

                if (targetTestingLocation == 1)
                {
                    runGroup = runGroupCloud;
                }
            }

            //Click on Run Now.
            driver.FindElement(By.XPath(string.Format("//tr[td/text()='{0}']//a[span/text()='Run Now']", runGroup))).Click();
            Task.Delay(waitDelay5).Wait();

            //Wait for override window to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id[contains(.,'RunNowDatePopupControl_PW-1')]]")));

            if (testVariation == 1)
            {
                //Clear the Attribution Date field.
                driver.FindElement(By.XPath("//input[@id[contains(.,'RunNowDatePopupControl_AttributionDateOverrideDateEdit_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'RunNowDatePopupControl_AttributionDateOverrideDateEdit_I')]]")).Clear();
                Task.Delay(waitDelay5).Wait();
            }

            //Click on OK.
            driver.FindElement(By.XPath("//div[@id[contains(.,'RunNowDatePopupControl')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Wait for override window to close.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id[contains(.,'RunNowDatePopupControl_PW-1')]]")));

            Task.Delay(waitDelayMega).Wait();

            //Navigate to Status Dashboard page.
            driver.FindElement(By.XPath("(//span[text()='Status Dashboard'])[2]")).Click();
        }
        public void SubmitAndCompleteRun()
        {
            //Toggle a variation of method test steps.
            straightSubmit = 1;

            //Run the run group.
            SubmitRunGroup();


            //~STATUS DASHBOARD PAGE:----------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Refresh']"))); //Waits for Refresh button to load.

            //Identify then expand submitted run group.
            IdentifySubmittedRuns();

            //Restart stopwatch.
            timer.Restart();

            //Attempt to check for run item completion until timer expires.
            while (timer.Elapsed.TotalSeconds < timer3MinutePlus && timer.IsRunning.Equals(true))
            {
                var reportComplete = driver.FindElements(By.XPath(string.Format("//tr[td/text()='{0}']//td[text()='Complete']", runListInstance)));

                if (!reportComplete.Any())
                {
                    //Refresh browser.
                    RefreshBrowser();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Validate that run instance completes.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td/text()='{0}']//td[text()='Complete']", runListInstance))));
        }

        public void Setup_HOPS796()
        {
            #region Obtain Grid Username & Password
            //Connect to SQL DB.
            SQLConnect();

            string sqlQuery = string.Format("SELECT [Password] FROM tbl_GridEnvironment WHERE[Name] = '{0}'", targetGridMachine);
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand(sqlQuery, connectionLocation);

            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                for (int i = 0; i < myReader.FieldCount; i++)
                {
                    var data = myReader.GetValue(i);
                    string actual = data.ToString();

                    GridPassword = actual;
                }
            }
            myReader.Close();

            string sqlQuery1 = string.Format("SELECT Username FROM tbl_GridEnvironment WHERE[Name] = '{0}'", targetGridMachine);
            SqlDataReader myReader1 = null;
            SqlCommand myCommand1 = new SqlCommand(sqlQuery1, connectionLocation);

            myReader1 = myCommand1.ExecuteReader();
            while (myReader1.Read())
            {
                for (int i = 0; i < myReader1.FieldCount; i++)
                {
                    var data = myReader1.GetValue(i);
                    string actual = data.ToString();

                    GridUser = actual;
                }
            }
            myReader1.Close();

            //Close connection to SQL DB.
            SQLClose();

            //Verify that grid user and password are located for targetGridMachine entry.
            if (GridPassword == null || GridUser == null)
            {
                Assert.Fail(string.Format("Grid credentials not found. Please create HedgeOps grid environment configuration for {0} or verify that target grid machine is entered correctly.", targetGridMachine));
            }
            #endregion

            //Create a list of table names.
            List<string> tableNames = new List<string>
            {
                resultsCustomDBTable1,
                resultsCustomDBTable2,
                resultsCustomDBTable3,
                resultsCustomDBTable4,
                resultsCustomDBTable5,
                resultsCustomDBTable6,
                resultsCustomDBTable7,
                resultsCustomDBTable8,
                resultsCustomDBTable9
            };

            //Create necessary DB tables.
            foreach (string table in tableNames)
            {
                #region Create Custom Tables With Schema
                //Connect to SQL DB.
                SQLConnect();

                string sqlQuery2 = string.Format("IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}')) " +
                    "BEGIN " +
                    "CREATE TABLE " +
                    "{0}(runlistinstance_id INT,[group] VARCHAR(MAX),cell VARCHAR(MAX),shock VARCHAR(MAX),pv_claims VARCHAR(MAX), pv_premiums FLOAT, pv_av FLOAT, pv_claimseeb VARCHAR(MAX)) " +
                    "END " +

                    "IF (NOT EXISTS (SELECT * " +
                    "FROM INFORMATION_SCHEMA.TABLES " +
                    "WHERE TABLE_NAME = '{0}' " +
                    "AND TABLE_SCHEMA = '{1}')) " +

                    "ALTER SCHEMA [inforce] TRANSFER {0} ", table, resultsCustomDBSchema);

                SqlDataReader myReader2 = null;
                SqlCommand myCommand2 = new SqlCommand(sqlQuery2, connectionLocation);

                myReader2 = myCommand2.ExecuteReader();
                myReader2.Close();

                //Close connection to SQL DB.
                SQLClose();
                #endregion
            }

            #region Clear All Custom Table Data
            //Connect to SQL DB.
            SQLConnect();

            string sqlQuery3 = string.Format("DELETE FROM [inforce].{0} " +
                "DELETE FROM[inforce].{1} " +
                "DELETE FROM[inforce].{2} " +
                "DELETE FROM[inforce].{3} " +
                "DELETE FROM[inforce].{4} " +
                "DELETE FROM[inforce].{5} " +
                "DELETE FROM[inforce].{6} " +
                "DELETE FROM[inforce].{7} " +
                "DELETE FROM[inforce].{8} ", resultsCustomDBTable1, resultsCustomDBTable2, resultsCustomDBTable3, resultsCustomDBTable4, resultsCustomDBTable5, resultsCustomDBTable6, resultsCustomDBTable7, resultsCustomDBTable8, resultsCustomDBTable9);

            SqlDataReader myReader3 = null;
            SqlCommand myCommand3 = new SqlCommand(sqlQuery3, connectionLocation);

            myReader3 = myCommand3.ExecuteReader();
            myReader3.Close();

            //Close connection to SQL DB.
            SQLClose();
            #endregion

            //Navigate to Results Profiles page.
            NavigateToResultsProfilesPage();


            //~RESULTS PROFILES PAGE:----------------------------------------------------------------------------------------------------------------------------------------
            //Create a list of results profile configurations.
            List<string> configFile = new List<string>
            {
                resultsCustomConfigFile1,
                resultsCustomConfigFile2,
                resultsCustomConfigFile3,
                resultsCustomConfigFile4,
                resultsCustomConfigFile5,
                resultsCustomConfigFile6,
                resultsCustomConfigFile7,
                resultsCustomConfigFile8,
                resultsCustomConfigFile9
            };

            //Import necessary results profiles configurations.
            foreach (string file in configFile)
            {
                if (file == resultsCustomConfigFile1)
                {
                    configName = resultsCustomConfig1;
                }

                if (file == resultsCustomConfigFile2)
                {
                    configName = resultsCustomConfig2;
                }

                if (file == resultsCustomConfigFile3)
                {
                    configName = resultsCustomConfig3;
                }

                if (file == resultsCustomConfigFile4)
                {
                    configName = resultsCustomConfig4;
                }

                if (file == resultsCustomConfigFile5)
                {
                    configName = resultsCustomConfig5;
                }

                if (file == resultsCustomConfigFile6)
                {
                    configName = resultsCustomConfig6;
                }

                if (file == resultsCustomConfigFile7)
                {
                    configName = resultsCustomConfig7;
                }

                if (file == resultsCustomConfigFile8)
                {
                    configName = resultsCustomConfig8;
                }

                if (file == resultsCustomConfigFile9)
                {
                    configName = resultsCustomConfig9;
                }

                #region Import Necessary Results Profiles
                //Connect to SQL DB.
                SQLConnect();

                string sqlQuery4 = string.Format("SELECT TOP(1) version_name FROM tbl_version WHERE versiontype_id = 19 AND version_name = '{0}' AND version_void IS NULL ", configName);
                SqlDataReader myReader4 = null;
                SqlCommand myCommand4 = new SqlCommand(sqlQuery4, connectionLocation);

                myReader4 = myCommand4.ExecuteReader();
                while (myReader4.Read())
                {
                    for (int i = 0; i < myReader4.FieldCount; i++)
                    {
                        var data = myReader4.GetValue(i);
                        string actual = data.ToString();

                        if (configName != actual)
                        {
                            //Toggle a variation of method test steps.
                            resultsCustomOverride = 1;

                            //Import results profile config.
                            AddResultsProfile();
                        }
                    }
                }
                myReader4.Close();

                //Close connection to SQL DB.
                SQLClose();
                #endregion
            }
        }
        #endregion

        #region Run Groups & Report Approval/Dependencies Tests
        public static string repHistPop1 = "Basic Report - Ver & Report History Popup 1", repHistPop2 = "Basic Report - Ver & Report History Popup 2", repAppr1 = "Report Approvals Test 1", repAppr2 = "Report Approvals Test 2",
            repDeny1 = "Report Denials Test 1", repDep1 = "Report Dependencies Test 1", repDep2 = "Report Dependencies Test 2", repDep3 = "Report Dependencies Test 3";

        public static string fileName, runGroupOnPrem, runGroupCloud, runGroup, runListName;
        public static string testRunGroup = ".AutomationTestGroup";
        public string testRunGroupFile = testRunGroup + extXLSX;
        public string testFileName1 = ".AutomationTest";
        public string testPichuFile = "pichu";
        public string testPichuFile2 = "PIcHu";

        public static string reportFileName1 = "Report1_";
        public static string reportFileName2 = "Report2_";
        public static string reportFileName3 = "Report3_";
        public string reportFileName4 = "Report_Run_";
        public static string reportFileName5 = "report-test-";

        public static string reportFileName6 = reportFileName5 + "mooshroom";
        public static string reportFileName7 = reportFileName5 + "sheep";
        public static string reportFileName8 = reportFileName5 + "enderman";
        public static string reportFileName9 = reportFileName5 + "blaze";
        public static string reportFileName10 = reportFileName5 + "creeper";

        public string reportOverrideFile1 = reportFileName6 + extPNG;
        public string reportOverrideFile2 = reportFileName7 + extPNG;
        public string reportOverrideFile3 = reportFileName8 + extPNG;
        public string reportOverrideFile4 = reportFileName9 + extPNG;
        public string reportOverrideFile5 = reportFileName10 + extPNG;

        public string reportApprovals1Name = "Report 1 Approvals Run";
        public static string reportApprovals1FileName = reportFileName1 + "Approvals_Run";
        public string reportApprovals2Name = "Report 2 Approvals Run";
        public static string reportApprovals2FileName = reportFileName2 + "Approvals_Run";
        public string reportDenials1Name = "Report 1 Denials Run";
        public static string reportDenials1FileName = reportFileName1 + "Denials_Run";

        public static string reportDependencyFileName1 = reportFileName1 + "Run1";
        public static string reportDependencyFileName2 = reportFileName1 + "Run2";
        public static string reportDependencyFileName3 = reportFileName2 + "Run1";
        public static string reportDependencyFileName4 = reportFileName2 + "Run2";
        public static string reportDependencyFileName5 = reportFileName3 + "Run1";
        public static string reportDependencyFileName6 = reportFileName3 + "Run2";

        public static string reportDependency1header = "Report 1 Dependency ";
        public static string reportDependency2header = "Report 2 Dependency ";
        public static string reportDependency3header = "Report 3 Dependency ";

        public string reportDependency1Name = reportDependency1header + "Run";
        public string reportDependency2Name = reportDependency2header + "Run";
        public string reportDependency3Name = reportDependency3header + "Run";

        public string reportHistoryPopupName1 = "Report Ver History Run 1";
        public string reportHistoryPopupName2 = "Report Ver History Validation Run 1";

        public string reportInforce1Filename = reportFileName1 + "Inforce - Complete Run" + extTXT;
        public string reportInforce2Filename = reportFileName2 + "Inforce - Complete Run" + extTXT;
        public string reportInforce3Filename = reportFileName3 + "Inforce - Complete Run" + extTXT;

        public string reportInforce1RunName = reportDependency1header + "Inforce Run";
        public string reportInforce2RunName = reportDependency2header + "Inforce Run";
        public string reportInforce3RunName = reportDependency3header + "Inforce Run";

        public string reportMGHedge1RunName = reportDependency1header + "MGHedge Run - PXR7";
        public string reportMGHedge2RunName = reportDependency2header + "MGHedge Run - PXR7";
        public string reportMGHedge3RunName = reportDependency3header + "MGHedge Run - PXR7";

        public static string outputFileDefaultExt = "_Default";
        public string outputFile1 = reportApprovals1FileName + "1" + outputFileDefaultExt + extTXT;
        public string outputFile2 = reportApprovals1FileName + "2" + outputFileDefaultExt + extTXT;
        public string outputFile3 = reportApprovals2FileName + outputFileDefaultExt + extTXT;
        public string outputFile4 = reportDenials1FileName + outputFileDefaultExt + extTXT;
        public string outputFile5 = reportDependencyFileName1 + outputFileDefaultExt + extTXT;
        public string outputFile6 = reportDependencyFileName2 + outputFileDefaultExt + extTXT;
        public string outputFile7 = reportDependencyFileName3 + outputFileDefaultExt + extTXT;
        public string outputFile8 = reportDependencyFileName4 + outputFileDefaultExt + extTXT;
        public string outputFile9 = reportDependencyFileName5 + outputFileDefaultExt + extTXT;
        public string outputFile10 = reportDependencyFileName6 + outputFileDefaultExt + extTXT;

        public string badRunGroup = "AutoBadRunGroupExample" + extXLSX;
        public string goodRunGroup = "AutoGoodRunGroupExample" + extXLSX;

        public string ReportDepend1File()
        {
            if (targetTestingLocation == 0)
            {
                importFile = repDep1 + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = repDep1 + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public string ReportDepend2File()
        {
            if (targetTestingLocation == 0)
            {
                importFile = repDep2 + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = repDep2 + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public string ReportDepend3File()
        {
            if (targetTestingLocation == 0)
            {
                importFile = repDep3 + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = repDep3 + cloudImportAppend + extXLSX;
            }

            return importFile;
        }

        public string ReportApprove1File()
        {
            if (targetTestingLocation == 0)
            {
                importFile = repAppr1 + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = repAppr1 + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public string ReportApprove2File()
        {
            if (targetTestingLocation == 0)
            {
                importFile = repAppr2 + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = repAppr2 + cloudImportAppend + extXLSX;
            }

            return importFile;
        }

        public string ReportDeny1File()
        {
            if (targetTestingLocation == 0)
            {
                importFile = repDeny1 + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = repDeny1 + cloudImportAppend + extXLSX;
            }

            return importFile;
        }

        public string ReportHistoryPopup1File()
        {
            if (targetTestingLocation == 0)
            {
                importFile = repHistPop1 + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = repHistPop1 + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        public string ReportHistoryPopup2File()
        {
            if (targetTestingLocation == 0)
            {
                importFile = repHistPop2 + extXLSX;
            }

            if (targetTestingLocation == 1)
            {
                importFile = repHistPop2 + cloudImportAppend + extXLSX;
            }

            return importFile;
        }
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void GenericDataStoreFileDeletion()
        {
            //Click on report.
            driver.FindElement(By.XPath(string.Format("//tr[@title[contains(.,'{0}')]]", fileName))).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for delete button to enable.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//img[@class='dxWeb_fmDeleteButton_SoftOrange dxm-image dx-vam']")));

            //Click on the delete button.
            driver.FindElement(By.XPath("(//img[@alt='Delete (Del)'])[1]")).Click();
            Task.Delay(waitDelay6).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Wait for deletion to take effect.
            Task.Delay(waitDelayExtreme).Wait();
        }
        public void ImportAllReportDependencyGroups()
        {
            if (goldImports != 1)
            {
                //Import Report Dependency 1 group.
                ImportReportDependencyGroup1();

                //Verify presence of imported run group.
                Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", repDep1))));

                //Import Report Dependency 2 group.
                ImportReportDependencyGroup2();

                //Verify presence of imported run group.
                Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", repDep2))));

                //Import Report Dependency 3 group.
                ImportReportDependencyGroup3();

                //Verify presence of imported run group.
                Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//td[text()='{0}']", repDep3))));
            }
        }

        public void ImportBadRunGroupFile()
        {
            importFile = badRunGroup;

            //Import a run group.
            GenericImportRunGroup();
        }
        public void ImportGoodRunGroupFile()
        {
            runGroup = testRunGroup;
            importFile = testRunGroupFile;

            //Import a run group.
            GenericImportRunGroup();
        }

        public void ImportReportApprovalGroup1()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = repAppr1;
            runGroupCloud = repAppr1 + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Toggle a variation of method test steps.
                importToggle = 1;

                //Generate import file.
                ReportApprove1File();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportReportApprovalGroup2()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = repAppr2;
            runGroupCloud = repAppr2 + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Toggle a variation of method test steps.
                importToggle = 1;

                //Generate import file.
                ReportApprove2File();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportReportDenialGroup1()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = repDeny1;
            runGroupCloud = repDeny1 + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Toggle a variation of method test steps.
                importToggle = 1;

                //Generate import file.
                ReportDeny1File();

                //Import a run group.
                GenericImportRunGroup();
            }
        }

        public void ImportReportDependencyGroup1()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = repDep1;
            runGroupCloud = repDep1 + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Toggle a variation of method test steps.
                importToggle = 1;

                //Generate import file.
                ReportDepend1File();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportReportDependencyGroup2()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = repDep2;
            runGroupCloud = repDep2 + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Toggle a variation of method test steps.
                importToggle = 1;

                //Generate import file.
                ReportDepend2File();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportReportDependencyGroup3()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = repDep3;
            runGroupCloud = repDep3 + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Toggle a variation of method test steps.
                importToggle = 1;

                //Generate import file.
                ReportDepend3File();

                //Import a run group.
                GenericImportRunGroup();
            }
        }

        public void ImportReportHistoryPopupGroup1()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = repHistPop1;
            runGroupCloud = repHistPop1 + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Toggle a variation of method test steps.
                importToggle = 1;

                //Generate import file.
                ReportHistoryPopup1File();

                //Import a run group.
                GenericImportRunGroup();
            }
        }
        public void ImportReportHistoryPopupGroup2()
        {
            //>Listed as such for ease of use.
            runGroupOnPrem = repHistPop2;
            runGroupCloud = repHistPop2 + cloudImportAppend;

            if (targetTestingLocation == 0)
            {
                runGroup = runGroupOnPrem;
            }

            if (targetTestingLocation == 1)
            {
                runGroup = runGroupCloud;
            }

            if (goldImports != 1)
            {
                //Toggle a variation of method test steps.
                importToggle = 1;

                //Generate import file.
                ReportHistoryPopup2File();

                //Import a run group.
                GenericImportRunGroup();
            }
        }

        public void Report1ApprovalOverride()
        {
            importFile = reportOverrideFile1;

            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Validate presence of all 3 report actions.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//button[text()='Approve']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//button[text()='Deny']")));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()='Override']")));

                //Click on Override.        
                driver.FindElement(By.XPath("//span[text()='Override']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Override Report']")));
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Validate presence of all 3 report actions.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Approve']", reportFile))));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Denied']", reportFile))));
                Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportFile))));

                //Click on Override.        
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportFile))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Report Override']")));
            }
            #endregion

            //Override a report.
            GenericOverrideReport();
        }
        public void Report2ApprovalOverride()
        {
            importFile = reportOverrideFile2;

            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Click on Override.        
                driver.FindElement(By.XPath("//span[text()='Override']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Override Report']")));
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Click on Override.        
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportFile))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Report Override']")));
            }
            #endregion

            //Override a report.
            GenericOverrideReport();
        }
        public void Report3ApprovalOverride()
        {
            importFile = reportOverrideFile3;

            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Click on Override.        
                driver.FindElement(By.XPath("//span[text()='Override']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Override Report']")));
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Click on Override.        
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportFile))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Report Override']")));
            }
            #endregion

            //Override a report.
            GenericOverrideReport();
        }
        public void Report4ApprovalOverride()
        {
            importFile = reportOverrideFile4;

            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Click on Override.        
                driver.FindElement(By.XPath("//span[text()='Override']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Override Report']")));
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Click on Override.        
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportFile))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Report Override']")));
            }
            #endregion

            //Override a report.
            GenericOverrideReport();
        }
        public void Report5ApprovalOverride()
        {
            importFile = reportOverrideFile5;

            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Click on Override.        
                driver.FindElement(By.XPath("//span[text()='Override']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Override Report']")));
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Click on Override.        
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportFile))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Report Override']")));
            }
            #endregion

            //Override a report.
            GenericOverrideReport();
        }

        public void Report1DependencyApprove()
        {
            //Approve report.
            driver.FindElement(By.XPath("//tr[td[text()='Report 1 Dependency Run 1']]//span[text()='Approve']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();
            Task.Delay(waitDelaySuper).Wait();
        }
        public void Report1DependencyOverride()
        {
            importFile = reportOverrideFile1;

            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Click on Override.        
                driver.FindElement(By.XPath("//span[text()='Override']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Override Report']")));
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Click on Override.        
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportFile))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Report Override']")));
            }
            #endregion

            //Override a report.
            GenericOverrideReport();
        }
        public void Report2DependencyOverride()
        {
            importFile = reportOverrideFile2;

            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Click on Override.        
                driver.FindElement(By.XPath("//span[text()='Override']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Override Report']")));
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Click on Override.        
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportFile))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Report Override']")));
            }
            #endregion

            //Override a report.
            GenericOverrideReport();
        }
        public void Report3DependencyOverride()
        {
            importFile = reportOverrideFile3;

            #region Chameleon 2.10+
            if (targetChameleon == 1)
            {
                //Click on Override.        
                driver.FindElement(By.XPath("//span[text()='Override']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Override Report']")));
            }
            #endregion

            #region HedgeOps 2.9-
            else
            {
                //Click on Override.        
                driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']][1]//span[text()='Override']", reportFile))).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Report Override']")));
            }
            #endregion

            //Override a report.
            GenericOverrideReport();
        }
        #endregion

        #region Run Group/List Lock Tests
        public string lockGroupRun = ".RunGroupLockingTest";
        public string lockGroupRunEdit = "EditedRunGroupLockingTest.xlsx";
        public string lockGroupRunItem = ".RunItemLockingTest";
        public string lockGroupRunItemEdit = "EditedRunItemLockingTest.xlsx";
        public string lockRunItemFile = "RunItemLockingTest.xlsx";

        public string lockRunItem1 = "RunLockReportTest";
        public string lockRunItem2 = "RunLockInforceTest";
        public string lockRunGroup = "RunGroupLockingTest.xlsx";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void EditLockedRunGroupExport()
        {
            //Click on Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'RunListUpload_Browse0')]]/a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            if (targetTestingLocation == 1)
            {
                if (targetChameleon == 1)
                {
                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryNew, lockGroupRunEdit));
                }
                else
                {
                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryOld, lockGroupRunEdit));
                }
            }
            else
            {
                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryOld, lockGroupRunEdit));
            }

            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", lockGroupRunEdit))));

            //Click OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'ImportPopupControl')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
        }
        public void EditUnlockedRunGroupExport()
        {
            //Click on Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'RunListUpload_Browse0')]]/a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            if (targetTestingLocation == 1)
            {
                if (targetChameleon == 1)
                {
                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryNew, lockGroupRunItemEdit));
                }
                else
                {
                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryOld, lockGroupRunItemEdit));
                }
            }
            else
            {
                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryOld, lockGroupRunItemEdit));
            }

            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", lockGroupRunItemEdit))));

            //Click OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'ImportPopupControl')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
        }
        public void ImportRunGroupLock()
        {
            //Click on Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'RunListUpload_Browse0')]]/a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            if (targetTestingLocation == 1)
            {
                if (targetChameleon == 1)
                {
                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryNew, lockRunGroup));
                }
                else
                {
                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryOld, lockRunGroup));
                }
            }
            else
            {
                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryOld, lockRunGroup));
            }

            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@title[contains(.,'Run Group Locking Test')]]")));

            //Click OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'ImportPopupControl')]]/span[text()='OK']")).Click();
            Task.Delay(waitDelayLong).Wait();

            if (testVariation != 2)
            {
                //Waits for modal to disappear.
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
            }
        }
        public void ImportRunItemLockFile()
        {
            //Click on Import button.
            driver.FindElement(By.XPath("//span[text()='Import']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File Upload']")));

            //Click on Browse button.
            driver.FindElement(By.XPath("//td[@id[contains(.,'RunListUpload_Browse0')]]//a[text()='Browse...']")).Click();
            Task.Delay(waitDelayBrowse).Wait();

            if (targetTestingLocation == 1)
            {
                if (targetChameleon == 1)
                {
                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryNew, lockRunItemFile));
                }
                else
                {
                    //Navigate and select file in file explorer.
                    SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryOld, lockRunItemFile));
                }
            }
            else
            {
                //Navigate and select file in file explorer.
                SendKeys.SendWait(Path.Combine(mainAutomationDirectory, runGroupDirectory, runTypeSubDirectoryOld, lockRunItemFile));
            }

            Task.Delay(waitDelayLongPlus).Wait();
            HitEnterKey();

            //Waits for file to appear in field (sometimes theres a few second delay)
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[@title='{0}']", lockRunItemFile))));

            //Click OK button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'ImportPopupControl_ctl16_CD')]]//span[text()='OK']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='File Upload']")));
        }
        public void LockRunGroup()
        {
            //Click New.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Group Name:']")));

            //Enter a Group Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'LockGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'LockGridView_DXEFL_DXEditor0_I')]]")).SendKeys(runGroup);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayExtreme).Wait();

            //Waits for item to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//td[text()='{0}']", runGroup))));
        }
        public void RemoveRunGroupLock()
        {
            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerTiny && timer.IsRunning.Equals(true))
            {
                var lockName = driver.FindElements(By.XPath("//td[text()[contains(.,'LockingTest')]]"));

                if (lockName.Any())
                {
                    //Click on Unlock.
                    driver.FindElement(By.XPath("//tr[td[text()[contains(.,'LockingTest')]]]//span[text()='Unlock']")).Click();
                    Task.Delay(waitDelayLong).Wait();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }
        }
        #endregion

        #region Schedule Tests
        public string scheduleFrequency = "One Time";
        public string scheduleHolidayName = ".AutomationTestHolidaySchedule";
        public string scheduleDateName = ".AutomationTestDateSchedule";
        public string scheduleName_HOPS796 = ".HOPS-796 AutomationTestSchedule";
        public string scheduleFileName = ".AutomationTestFileSchedule";
        public string scheduleBasicRegression = ".Basic Regression Suite";

        public string scheduleDateNameDaily = ".Automation Schedule: Daily";
        public string scheduleDateNameWeekly = ".Automation Schedule: Weekly";
        public string scheduleDateNameMonthly = ".Automation Schedule: Monthly";
        public string scheduleDateNameQuarterly = ".Automation Schedule: Quarterly";
        public string scheduleDateNameHoliday = ".Automation Schedule: Holiday";
        public string scheduleDateNameOneTime = ".Automation Schedule: OneTime";

        public string schedule, scheduleTime = "12:00PM", scheduleTimeEdit = "07:11AM", scheduleDate = "01/02/2021";
        public string CurrentTimeBuilder()
        {
            string currentTime = DateTime.Now.ToShortTimeString();
            return currentTime = currentTime.Replace(" ", String.Empty);
        }
        public string CurrentTimePlusMinuteBuilder()
        {
            DateTime currentTime = DateTime.Now.AddMinutes(1);
            string currentTimePlus1 = currentTime.ToShortTimeString();
            return currentTimePlus1 = currentTimePlus1.Replace(" ", String.Empty);
        }
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void CreateDateSchedule_Daily()
        {
            //Click on Create New Schedule button.
            driver.FindElement(By.XPath("//button[text()='Create New Schedule']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for drawer to open.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Create a schedule']")));

            //Add a Name.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).SendKeys(scheduleDateNameDaily);
            Task.Delay(waitDelay5).Wait();

            var frequency = driver.FindElements(By.XPath("//input[@value='Daily']"));

            if (!frequency.Any())
            {
                //Add a Frequency.
                driver.FindElement(By.XPath("//div[div[span[text()='Frequency']]]//input[@class[contains(.,'Select__SelectTextInput')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//span[text()='Daily']")).Click();
                Task.Delay(waitDelayLong).Wait();
            }

            //Add a Time of Day.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).SendKeys(scheduleTime);
            Task.Delay(waitDelay5).Wait();

            //Add an Exception day.
            driver.FindElement(By.XPath("//div[div[span[text()='Except On']]]//input[@class[contains(.,'Select__SelectTextInput')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//span[text()='First Business']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Clear. (this test that the clear action is functional)
            driver.FindElement(By.XPath("//span[text()='Clear']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Re-add an Exception day.
            driver.FindElement(By.XPath("//div[div[span[text()='Except On']]]//input[@class[contains(.,'Select__SelectTextInput')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//span[text()='First Business']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Create button.
            driver.FindElement(By.XPath("//button[text()='Create']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for successful creation of schedule.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Schedule created.']")));
            Task.Delay(waitDelayLongPlus).Wait();

            //Click on Close button.
            driver.FindElement(By.XPath("//span[text()='Close']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for drawer to close.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Create a schedule']")));

            //Validate presence of schedule.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[div[span[text()='{0}']]]//div[div[span[text()='Daily'] and span[text()='at'] and span[text()='12:00 pm']]//div[span[text()='except'] and span[text()='First Business']]]", scheduleDateNameDaily))));
        }
        public void CreateDateSchedule_Weekly()
        {
            //Click on Create New Schedule button.
            driver.FindElement(By.XPath("//button[text()='Create New Schedule']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for drawer to open.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Create a schedule']")));

            //Add a Name.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).SendKeys(scheduleDateNameWeekly);
            Task.Delay(waitDelay5).Wait();

            //Add a Frequency.
            driver.FindElement(By.XPath("//div[div[span[text()='Frequency']]]//input[@class[contains(.,'Select__SelectTextInput')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//span[text()='Weekly']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Add a Time of Day.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).SendKeys(scheduleTime);
            Task.Delay(waitDelay5).Wait();

            //Add a Days of Week.
            driver.FindElement(By.XPath("//input[@class[contains(.,'undefined4')]]")).Click(); //>Picks Thursday
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'undefined6')]]")).Click(); //>Picks Saturday
            Task.Delay(waitDelay5).Wait();

            //Click on Holiday radio button.
            driver.FindElement(By.XPath("//label[span[text()='Holiday']]//input[@id='Holiday']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Add an Exception day.
            driver.FindElement(By.XPath("//div[div[span[text()='Except On']]]//input[@class[contains(.,'Select__SelectTextInput')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("//span[text()='{0}']", holidayGroupTest))).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Create button.
            driver.FindElement(By.XPath("//button[text()='Create']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for successful creation of schedule.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Schedule created.']")));
            Task.Delay(waitDelayLongPlus).Wait();

            //Click on Close button.
            driver.FindElement(By.XPath("//span[text()='Close']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for drawer to close.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Create a schedule']")));

            //>Currently broken. add validation when fixed ------- selecting a holiday as an exception day causes an error and aborts schedule creation.
            //Validate presence of schedule.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[div[span[text()='{0}']]]//div[div[span[text()='Weekly'] and span[text()='at'] and span[text()='12:00 pm']]//div[span[text()='except'] and span[text()='First Business']]]", scheduleDateNameWeekly))));
        }
        public void CreateDateSchedule_Monthly()
        {
            //Click on Create New Schedule button.
            driver.FindElement(By.XPath("//button[text()='Create New Schedule']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for drawer to open.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Create a schedule']")));

            //Add a Name.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).SendKeys(scheduleDateNameMonthly);
            Task.Delay(waitDelay5).Wait();

            //Add a Frequency.
            driver.FindElement(By.XPath("//div[div[span[text()='Frequency']]]//input[@class[contains(.,'Select__SelectTextInput')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//span[text()='Weekly']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Add a Time of Day.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).SendKeys(scheduleTime);
            Task.Delay(waitDelay5).Wait();

            //Add a Day of Month.
            driver.FindElement(By.XPath("//div[div[span[text()='Day of Month']]]//button[@class[contains(.,'Select')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("(//span[text()='First Business'])[2]")).SendKeys(scheduleTime);
            Task.Delay(waitDelay5).Wait();

            //Click on Create button.
            driver.FindElement(By.XPath("//button[text()='Create']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for successful creation of schedule.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Schedule created.']")));
            Task.Delay(waitDelayLongPlus).Wait();

            //Click on Close button.
            driver.FindElement(By.XPath("//span[text()='Close']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for drawer to close.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Create a schedule']")));

            //Validate presence of schedule.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[div[span[text()='{0}']]]//div[div[span[text()='Monthly on First Business'] and span[text()='at'] and span[text()='12:00 pm']]]", scheduleDateNameMonthly))));
        }
        public void CreateDateSchedule_Quarterly()
        {
            //Click on Create New Schedule button.
            driver.FindElement(By.XPath("//button[text()='Create New Schedule']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for drawer to open.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Create a schedule']")));

            //Add a Name.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).SendKeys(scheduleDateNameQuarterly);
            Task.Delay(waitDelay5).Wait();

            //Add a Frequency.
            driver.FindElement(By.XPath("//div[div[span[text()='Frequency']]]//input[@class[contains(.,'Select__SelectTextInput')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//span[text()='Weekly']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Add a Time of Day.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).SendKeys(scheduleTime);
            Task.Delay(waitDelay5).Wait();

            //Click on Create button.
            driver.FindElement(By.XPath("//button[text()='Create']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for successful creation of schedule.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Schedule created.']")));
            Task.Delay(waitDelayLongPlus).Wait();

            //Click on Close button.
            driver.FindElement(By.XPath("//span[text()='Close']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for drawer to close.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Create a schedule']")));

            //Validate presence of schedule.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[div[span[text()='{0}']]]//div[div[span[text()='at'] and span[text()='12:00 pm']]]", scheduleDateNameQuarterly))));
        }
        public void CreateDateSchedule_Holiday()
        {
            //Click on Create New Schedule button.
            driver.FindElement(By.XPath("//button[text()='Create New Schedule']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for drawer to open.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Create a schedule']")));

            //Add a Name.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).SendKeys(scheduleDateNameHoliday);
            Task.Delay(waitDelay5).Wait();

            //Add a Frequency.
            driver.FindElement(By.XPath("//div[div[span[text()='Frequency']]]//input[@class[contains(.,'Select__SelectTextInput')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//span[text()='Weekly']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Add a Time of Day.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).SendKeys(scheduleTime);
            Task.Delay(waitDelay5).Wait();

            //Add a Holiday Group.
            driver.FindElement(By.XPath("//div[div[span[text()='Holiday Group']]]//button[@class[contains(.,'Select')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("//span[text()='{0}']", holidayGroupTest))).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Create button.
            driver.FindElement(By.XPath("//button[text()='Create']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for successful creation of schedule.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Schedule created.']")));
            Task.Delay(waitDelayLongPlus).Wait();

            //Click on Close button.
            driver.FindElement(By.XPath("//span[text()='Close']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for drawer to close.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Create a schedule']")));

            //Validate presence of schedule.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[div[span[text()='{0}']]]//div[div[span[text()='{1}'] and span[text()='at'] and span[text()='12:00 pm']]]", scheduleDateNameHoliday, holidayGroupTest))));
        }
        public void CreateDateSchedule_OneTime()
        {
            //Click on Create New Schedule button.
            driver.FindElement(By.XPath("//button[text()='Create New Schedule']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for drawer to open.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Create a schedule']")));

            //Add a Name.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleName')]]")).SendKeys(scheduleDateNameOneTime);
            Task.Delay(waitDelay5).Wait();

            //Add a Frequency.
            driver.FindElement(By.XPath("//div[div[span[text()='Frequency']]]//input[@class[contains(.,'Select__SelectTextInput')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//span[text()='Weekly']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Add a Time of Day.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).SendKeys(scheduleTime);
            Task.Delay(waitDelay5).Wait();

            //Add a Date.
            driver.FindElement(By.XPath("//div[div[span[text()='Date']]]//input[@class[contains(.,'Styled')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//div[div[span[text()='Date']]]//input[@class[contains(.,'Styled')]]")).SendKeys(scheduleDate);
            Task.Delay(waitDelay5).Wait();

            //Click on Create button.
            driver.FindElement(By.XPath("//button[text()='Create']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for successful creation of schedule.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Schedule created.']")));
            Task.Delay(waitDelayLongPlus).Wait();

            //Click on Close button.
            driver.FindElement(By.XPath("//span[text()='Close']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for drawer to close.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Create a schedule']")));

            //Validate presence of schedule.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[div[span[text()='{0}']]]//div[div[span[text()='01-02-2021'] and span[text()='at'] and span[text()='12:00 pm']]]", scheduleDateNameOneTime))));
        }
        public void CreateDateSchedules()
        {
            //Create a Daily date schedule.
            CreateDateSchedule_Daily();

            //Create a Weekly date schedule.
            CreateDateSchedule_Weekly();

            //Create a Monthly date schedule.
            CreateDateSchedule_Monthly();

            //Create a Quarterly date schedule.
            CreateDateSchedule_Quarterly();

            //Create a Holiday date schedule.
            CreateDateSchedule_Holiday();

            //Create a OneTime date schedule.
            CreateDateSchedule_OneTime();
        }

        public void AddSchedule()
        {
            //Steps for Date-Based Schedules
            if (testVariation == 0)
            {
                //Click on New Schedule button.
                driver.FindElement(By.XPath("//span[text()='New Schedule']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Schedule']")));

                //Add a Frequency.
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_FrequencyComboBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_FrequencyComboBox_I')]]")).SendKeys(scheduleFrequency);
                Task.Delay(waitDelay5).Wait();

                //Add a Name.
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_NameTextBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_NameTextBox_I')]]")).SendKeys(scheduleDateName);
                Task.Delay(waitDelay5).Wait();

                //Add a Time of Day.
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit_I')]]")).SendKeys(scheduleTime);
                Task.Delay(waitDelay5).Wait();

                //Add a Date.
                driver.FindElement(By.XPath("//td[@id[contains(.,'DateSchedulePopup_SpecificDayDateEdit_B-1')]]")).Click();
                Task.Delay(waitDelay6).Wait();

                if (targetChameleon == 1)
                {
                    driver.FindElement(By.XPath("//button[text()='Today']")).Click();
                }
                else
                {
                    driver.FindElement(By.XPath("//td[text()='Today']")).Click();
                }
                Task.Delay(waitDelay6).Wait();

                //Click OK button.
                driver.FindElement(By.XPath("(//span[text()='OK'])[2]")).Click();
                Task.Delay(waitDelayMega).Wait();
            }

            //Steps for File-Based Schedules
            if (testVariation == 1)
            {
                //Click on New.
                driver.FindElement(By.XPath("//span[text()='New']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Enter a Name.
                driver.FindElement(By.XPath("//input[@id[contains(.,'FileScheduleGrid_DXEFL_DXEditor0_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'FileScheduleGrid_DXEFL_DXEditor0_I')]]")).SendKeys(scheduleFileName);
                Task.Delay(waitDelay5).Wait();

                //Click the Update button.
                driver.FindElement(By.XPath("//span[text()='Update']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Expand the schedule row.
                driver.FindElement(By.XPath("//tr[td[text()='.AutomationTestFileSchedule']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Click on Add File button.
                driver.FindElement(By.XPath("//span[text()='Add File']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Enter an ETL Type.
                driver.FindElement(By.XPath("//input[@id[contains(.,'FileSchedulePopup_ETLTypeComboBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'FileSchedulePopup_ETLTypeComboBox_I')]]")).SendKeys(etlTypeAsset);
                Task.Delay(waitDelay5).Wait();

                //Hit the Enter key.
                HitEnterKey();

                //Enter a File Mask.
                driver.FindElement(By.XPath("//input[@id[contains(.,'FileSchedulePopup_FileMaskTextBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'FileSchedulePopup_FileMaskTextBox_I')]]")).SendKeys(etlTypeAssetMask);
                Task.Delay(waitDelay5).Wait();

                //Click the OK button
                driver.FindElement(By.XPath("(//span[text()='OK'])[3]")).Click();
                Task.Delay(waitDelayMega).Wait();
            }

            //Steps for Long Holiday Group Name.
            if (testVariation == 2)
            {
                //>Use of this frequency does not require a date to be assigned.
                //Click on New Schedule button.
                driver.FindElement(By.XPath("//span[text()='New Schedule']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Schedule']")));

                //Add a Frequency.
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_FrequencyComboBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_FrequencyComboBox_I')]]")).SendKeys(holidayGroup30PlusTrunc);
                Task.Delay(waitDelay5).Wait();

                //Add a Name.
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_NameTextBox')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_NameTextBox')]]")).SendKeys(scheduleHolidayName);
                Task.Delay(waitDelay5).Wait();

                //Add a Time of Day.
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit')]]")).SendKeys(scheduleTime);
                Task.Delay(waitDelay5).Wait();

                //Click OK button.
                driver.FindElement(By.XPath("(//span[text()='OK'])[2]")).Click();
                Task.Delay(waitDelayMega).Wait();
            }

            //Steps for Full Basic Regression Schedule Submission.
            if (testVariation == 3)
            {
                //Click on New Schedule button.
                driver.FindElement(By.XPath("//span[text()='New Schedule']")).Click();
                Task.Delay(waitDelayLong).Wait();

                //Waits for modal to appear.
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Schedule']")));

                //Add a Frequency.
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_FrequencyComboBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_FrequencyComboBox_I')]]")).SendKeys(scheduleFrequency);
                Task.Delay(waitDelay5).Wait();

                //Add a Name.
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_NameTextBox_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_NameTextBox_I')]]")).SendKeys(scheduleBasicRegression);
                Task.Delay(waitDelay5).Wait();

                //Add a Time of Day.
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit_I')]]")).Click();
                Task.Delay(waitDelay5).Wait();
                driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit_I')]]")).SendKeys(CurrentTimeBuilder());
                Task.Delay(waitDelay5).Wait();

                //Add a Date.
                driver.FindElement(By.XPath("//td[@id[contains(.,'DateSchedulePopup_SpecificDayDateEdit_B-1')]]")).Click();
                Task.Delay(waitDelay6).Wait();

                if (targetChameleon == 1)
                {
                    driver.FindElement(By.XPath("//button[text()='Today']")).Click();
                }
                else
                {
                    driver.FindElement(By.XPath("//td[text()='Today']")).Click();
                }
                Task.Delay(waitDelay6).Wait();

                //Click OK button.
                driver.FindElement(By.XPath("(//span[text()='OK'])[2]")).Click();
                Task.Delay(waitDelayMega).Wait();
            }

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Schedule']")));
            Task.Delay(waitDelay6).Wait();

            //Waits for loading modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table[@id[contains(.,'JobsGridView_DXPFCForm_DXPFC_LPV')]]//span[text()='Loading…']")));
        }
        public void AddSchedule_HOPS796()
        {
            //Click on New Schedule button.
            driver.FindElement(By.XPath("//span[text()='New Schedule']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Schedule']")));

            //Add a Frequency.
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_FrequencyComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_FrequencyComboBox_I')]]")).SendKeys(scheduleFrequency);
            Task.Delay(waitDelay5).Wait();

            //Add a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_NameTextBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_NameTextBox_I')]]")).SendKeys(scheduleName_HOPS796);
            Task.Delay(waitDelay5).Wait();

            //Add a Time of Day.
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit_I')]]")).SendKeys(CurrentTimePlusMinuteBuilder());
            Task.Delay(waitDelay5).Wait();

            //Add a Date.
            driver.FindElement(By.XPath("//td[@id[contains(.,'DateSchedulePopup_SpecificDayDateEdit_B-1')]]")).Click();
            Task.Delay(waitDelay6).Wait();

            if (targetChameleon == 1)
            {
                driver.FindElement(By.XPath("//button[text()='Today']")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("//td[text()='Today']")).Click();
            }
            Task.Delay(waitDelay6).Wait();

            //Click OK button.
            driver.FindElement(By.XPath("(//span[text()='OK'])[2]")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Schedule']")));
            Task.Delay(waitDelay6).Wait();

            //Waits for loading modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table[@id[contains(.,'JobsGridView_DXPFCForm_DXPFC_LPV')]]//span[text()='Loading…']")));
        }
        public void AssignScheduleToRunGroup()
        {
            //Expand run group. (.AutomationTestGroup)
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//img[@class='dxGridView_gvDetailCollapsedButton_SoftOrange']", testRunGroup))).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for tab to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@id[contains(.,'GroupGridView_dxdt0_pageControl_T1T')]]//span[text()='Schedules']")));

            //Click the Schedules button.
            driver.FindElement(By.XPath("//a[@id[contains(.,'pageControl_T1T')]]/span[text()='Schedules']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for loading modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table[@id[contains(.,'JobsGridView_DXPFCForm_DXPFC_LPV')]]//span[text()='Loading…']")));

            //Click on New.
            driver.FindElement(By.XPath("//a[@id[contains(.,'GroupScheduleGridView_DXCBtn0')]]/span[text()='New']")).Click();
            Task.Delay(waitDelay6).Wait();

            //Waits for field to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Schedule Name:']")));

            //Assign a schedule.
            driver.FindElement(By.XPath("//input[@id[contains(.,'GroupScheduleGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'GroupScheduleGridView_DXEFL_DXEditor1_I')]]")).SendKeys(scheduleDateName);
            Task.Delay(waitDelayLong).Wait();

            //Hit the Enter key.
            HitEnterKey();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for item to appear.
            wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format("//td[text()='{0}']", scheduleDateName))));
        }
        public void DeleteRunSchedule()
        {
            if (testVariation == 1)
            {
                schedule = scheduleFileName;
            }
            else
            {
                schedule = scheduleHolidayName;
            }

            //Delete schedule.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", schedule))).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Are you sure you want to delete this schedule?']")));
            Task.Delay(waitDelayExtreme).Wait();

            //Delete schedule.
            driver.FindElement(By.XPath("(//span[text()='Confirm'])[1]")).Click();
            Task.Delay(waitDelayLongPlus).Wait();

            //Waits for item to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(string.Format("//td[text()='{0}']", schedule))));
            Task.Delay(waitDelayLongPlus).Wait();
        }
        public void EditSchedule()
        {
            //>Steps for Full Basic Regression Schedule Submission.
            //Click on Edit.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Edit']", scheduleBasicRegression))).Click();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Schedule']")));

            //Add a Frequency.
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_FrequencyComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            HitHomeKey();
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_FrequencyComboBox_I')]]")).SendKeys("One Time");
            Task.Delay(waitDelay5).Wait();
            HitTabKey();

            //Add a Date.
            driver.FindElement(By.XPath("//td[@id[contains(.,'DateSchedulePopup_SpecificDayDateEdit_B-1')]]")).Click();
            Task.Delay(waitDelay6).Wait();
            driver.FindElement(By.XPath("//td[text()='Today']")).Click();
            Task.Delay(waitDelay6).Wait();

            //Add a Time of Day.
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            HitHomeKey();
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit_I')]]")).SendKeys(CurrentTimeBuilder());
            Task.Delay(waitDelay5).Wait();

            //Click OK button.
            driver.FindElement(By.XPath("(//span[text()='OK'])[2]")).Click();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Schedule']")));
            Task.Delay(waitDelay6).Wait();

            //Waits for loading modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table[@id[contains(.,'JobsGridView_DXPFCForm_DXPFC_LPV')]]//span[text()='Loading…']")));
        }
        public void EditDateSchedules()
        {
            //>Steps for Full Basic Regression Schedule Submission.
            //Click on Edit.
            driver.FindElement(By.XPath(string.Format("//div[div[span[text()='{0}']]]//div[div[span[text()='Daily'] and span[text()='at'] and span[text()='12:00 pm']]//div[span[text()='except'] and span[text()='First Business']]]", scheduleDateNameDaily))).Click();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Schedule Details']")));

            //Click on Edit.
            driver.FindElement(By.XPath("//span[text()='Edit']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Edit the Frequency.
            driver.FindElement(By.XPath("//div[div[span[text()='Frequency']]]//input[@class[contains(.,'Select__SelectTextInput')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//span[text()='Weekly']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Add a Time of Day.
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'hdgScheduleTimeOfDay')]]")).SendKeys(scheduleTimeEdit);
            Task.Delay(waitDelay5).Wait();

            //Add a Days of Week.
            driver.FindElement(By.XPath("//input[@class[contains(.,'undefined4')]]")).Click(); //>Picks Thursday
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@class[contains(.,'undefined6')]]")).Click(); //>Picks Saturday
            Task.Delay(waitDelay5).Wait();

            //Click on Holiday radio button.
            driver.FindElement(By.XPath("//label[span[text()='Holiday']]//input[@id='Holiday']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Add an Exception day.
            driver.FindElement(By.XPath("//div[div[span[text()='Except On']]]//input[@class[contains(.,'Select__SelectTextInput')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath(string.Format("//span[text()='{0}']", holidayGroupTest))).Click();
            Task.Delay(waitDelay5).Wait();

            //Click on Update button.
            driver.FindElement(By.XPath("//button[text()='Update']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for successful creation of schedule.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Schedule created.']")));
            Task.Delay(waitDelayLongPlus).Wait();

            //Click on Close button.
            driver.FindElement(By.XPath("//span[text()='Close']")).Click();
            Task.Delay(waitDelayMega).Wait();

            //Waits for drawer to close.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Create a schedule']")));

            //>Currently broken. add validation when fixed ------- selecting a holiday as an exception day causes an error and aborts schedule creation.
            //Validate presence of schedule.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[div[span[text()='{0}']]]//div[div[span[text()='Weekly'] and span[text()='at'] and span[text()='7:11 am']]//div[span[text()='except'] and span[text()='First Business']]]", scheduleDateNameWeekly))));
        }
        public void EditSchedule_HOPS796()
        {
            //Click on Edit.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Edit']", scheduleBasicRegression))).Click();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Schedule']")));

            //Add a Date.
            driver.FindElement(By.XPath("//td[@id[contains(.,'DateSchedulePopup_SpecificDayDateEdit_B-1')]]")).Click();
            Task.Delay(waitDelay6).Wait();
            driver.FindElement(By.XPath("//td[text()='Today']")).Click();
            Task.Delay(waitDelay6).Wait();

            //Add a Time of Day.
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            HitHomeKey();
            driver.FindElement(By.XPath("//input[@id[contains(.,'DateSchedulePopup_TimeOfDayDateEdit_I')]]")).SendKeys(CurrentTimePlusMinuteBuilder());
            Task.Delay(waitDelay5).Wait();

            //Click OK button.
            driver.FindElement(By.XPath("(//span[text()='OK'])[2]")).Click();

            //Waits for modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Schedule']")));
            Task.Delay(waitDelay6).Wait();

            //Waits for loading modal to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table[@id[contains(.,'JobsGridView_DXPFCForm_DXPFC_LPV')]]//span[text()='Loading…']")));
        }
        public void RemoveScheduleFromRunGroup()
        {
            //~SQL DATABASE:-----------------------------------------------------------------------------------------------------------------------------------------------    

            //Connect to SQL DB.
            SQLConnect();

            #region DB Remove Erroneously Linked Voided Run Groups From Schedule"
            try
            {
                string sql1Query = string.Format("DECLARE @setProgram VARCHAR(MAX) " + "DECLARE @versionID VARCHAR(30); " + "DECLARE @versionName VARCHAR(30); " + "DECLARE @runList TABLE(RunName VARCHAR(MAX)); " + "DECLARE @sVerId TABLE(Id2 VARCHAR(MAX)); " +
                    "SET @setProgram = '{0}' " + "SET @versionName = '{1}' " +
                    "SET @versionID = (SELECT TOP (1) version_id FROM tbl_Version WITH ( NOLOCK ) WHERE version_name = @versionName AND programversion_guid = @setProgram ORDER BY version_updated DESC) " +

                    "INSERT INTO @runList(RunName) " +
                    "SELECT i1.version_name FROM tbl_Version i1 WITH ( NOLOCK ) " +
                    "WHERE version_name in ('Basic Badass','Basic Barker','Basic Bloomberg','Basic Generic Valuation','Basic Get MarketData','Basic Get TickerItem','Basic Inforce','Basic MGHedge - PXR6','Basic MGHedge - PXR7','Basic MGHedge - PXR8','Basic Report','Basic Report - No Approvals','Basic Report Notification','Basic Scenario','Basic Split','Basic Sync','MGHedge PXR8 (All with Overlay)','MGHedge PXR8 (None with Overlay)') " +
                    "AND programversion_guid = @setProgram AND version_active = 1 " +

                    "INSERT INTO @sVerId(Id2) " +
                    "SELECT i1.version_id FROM tbl_RunListSchedule i1 " +
                    "INNER JOIN tbl_Version i2 ON i1.version_id = i2.version_id " +
                    "WHERE runschedule_id = @versionID AND version_name NOT IN (SELECT RunName FROM @runList)" +

                    "DELETE FROM tbl_RunListSchedule " +
                    "WHERE runschedule_id = @versionID AND version_id IN (SELECT Id2 FROM @sVerId)", targetProgramGuid, scheduleDateName);

                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(sql1Query, connectionLocation);

                myReader = myCommand.ExecuteReader();
                myReader.Close();
            }

            catch (Exception)
            {
                Assert.Fail("Unexpected Result: Query failed.");
            }
            #endregion

            //Close connection to SQL DB.
            SQLClose();


            //~SQL DATABASE:-----------------------------------------------------------------------------------------------------------------------------------------------    

            //Click on the Delete button for created schedule.
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Delete']", scheduleDateName))).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Waits for modal to appear.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Are you sure you want to delete this schedule?']")));
            Task.Delay(waitDelayLongPlus).Wait();

            //Click on Confirm button.
            driver.FindElement(By.XPath("//div[@id[contains(.,'DeleteCallbackPanel_DeleteConfirmButton_CD')]]/span[text()='Confirm']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for item to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(string.Format("//td[text()='{0}']", scheduleDateName))));
        }
        public void VoidDateSchedules()
        {
            //Restart stopwatch.
            timer.Restart();

            //Void all test schedules.
            while (timer.Elapsed.TotalSeconds < timer2Minute && timer.IsRunning.Equals(true))
            {
                var schedulesPresent = driver.FindElements(By.XPath("//span[text()[contains(.,'.Automation Schedule:')]]"));

                if (schedulesPresent.Any())
                {
                    //Void test schedules.
                    driver.FindElement(By.XPath("(//div[div[span[text()[contains(.,'.Automation Schedule:')]]]]//button[@aria-label='Open Menu'])[1]")).Click();
                    Task.Delay(waitDelayLong).Wait();
                    driver.FindElement(By.XPath("//div[text()='Void']")).Click();
                    Task.Delay(waitDelayLong).Wait();

                    //Waits for Delete Schedule modal to appear.
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Delete Schedule']")));

                    //Click on Delete Schedule button.
                    driver.FindElement(By.XPath("//button[text()='Delete Schedule']")).Click();
                    Task.Delay(waitDelayLong).Wait();

                    //Waits for Delete Schedule modal to disappear.
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Delete Schedule']")));
                }
                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }
        }
        #endregion
        //--RUNS------------------------------------------------------------------------------------------------------oo

        //--REPORT CENTER---------------------------------------------------------------------------------------------oo
        #region Manage Role Permissions Tests
        public void ReportGrantAccess()
        {
            //Hit the Enter key.
            HitEnterKey();

            //Click on Edit.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXCBtn1")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for x button to load.
            wait.Until(ExpectedConditions.ElementExists(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXPEForm_HCB-1")));

            //Double-click on Access Level field and enter an access level.
            new Actions(driver).DoubleClick(driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXPEForm_DXEFL_DXEditor1_I"))).Perform();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXPEForm_DXEFL_DXEditor1_I")).SendKeys(roleAccessGrant);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();
            Task.Delay(waitDelayLong).Wait();

            //Click on Update link.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXPEForm_DXEFL_DXCBtn1")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for Access Level to display as ALL (Has access).
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//tr[@id='ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXDataRow0']//td[text()='All']")));

            //Clear Resource search field.
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_B-100Img")).Click();
            Task.Delay(waitDelayLong).Wait();
        }
        public void ReportGrantApprovalPerm()
        {
            //Enter a resource and search. (Report Center - Approve Reports)
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_I")).SendKeys(resourceReportDashApprove);
            Task.Delay(waitDelay5).Wait();

            //Remove resource access.
            ReportGrantAccess();
        }
        public void ReportGrantOverridePerm()
        {
            //Enter a resource and search. (Report Center - Override Reports)
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_I")).SendKeys(resourceReportDashOverride);
            Task.Delay(waitDelay5).Wait();

            //Remove resource access.
            ReportGrantAccess();
        }
        #endregion
        //--REPORT CENTER---------------------------------------------------------------------------------------------oo

        //--ADMINISTRATION--------------------------------------------------------------------------------------------oo
        #region Engine Management Tests
        public void RestartNysaEngine()
        {
            //Click on Restart link. (this will restart the engine, temporarily halt processes, then allow processes to resume in HedgeOps.)
            driver.FindElement(By.XPath(string.Format("//tr[td[text()='{0}']]//span[text()='Restart']", nysaServiceName))).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerMinutePlus && timer.IsRunning.Equals(true))
            {
                //Check for engine status listed as Running.
                var status = driver.FindElements(By.XPath(string.Format("//tr[td[text()='{0}']]//td[text()='Running']", nysaServiceName)));

                if (!status.Any())
                {
                    Task.Delay(waitDelaySuper).Wait();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }
        }
        public void StartNysaEngine()
        {
            if (targetChameleon == 1)
            {
                xpath2 = "//span[text()='Started']";
            }
            else
            {
                xpath2 = "//td[text()='Running']";
            }

            //Click on Start button. (this will start the engine and allow processes in HedgeOps.)
            driver.FindElement(By.XPath("//span[text()='Start']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerMinutePlus && timer.IsRunning.Equals(true))
            {
                //Check for engine status listed as Running.
                var status = driver.FindElements(By.XPath(string.Format("{0}", xpath2)));

                if (!status.Any())
                {
                    Task.Delay(waitDelaySuper).Wait();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }
        }
        public void StopNysaEngine()
        {
            if (targetChameleon == 1)
            {
                xpath2 = "//span[text()='Stopped']";
            }
            else
            {
                xpath2 = "//td[text()='Stopped']";
            }

            //Click on Stop button. (this will stop the engine and halt processes in HedgeOps.)
            driver.FindElement(By.XPath("//span[text()='Stop']")).Click();
            Task.Delay(waitDelaySuper).Wait();

            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerMinutePlus && timer.IsRunning.Equals(true))
            {
                //Check for engine status listed as Stopped.
                var status = driver.FindElements(By.XPath(string.Format("{0}", xpath2)));

                if (!status.Any())
                {
                    Task.Delay(waitDelaySuper).Wait();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Waits until the engine status is listed as Stopped.
            wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format("{0}", xpath2))));
        }
        #endregion

        #region Grid Management Tests
        public string gridAllowedPrograms = "SP";
        public static string gridEngine = "grid-gsop-003";
        public string gridHost = string.Format("https://{0}.milliman.com/C2/servlet/C2Request/", gridEngine);
        public string gridPassword = "guest8910";
        public string gridUserName = "guest";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void AddGrid()
        {
            //Click on the New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Waits for field to expand.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Name:']")));

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'GridEnvironmentGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'GridEnvironmentGridView_DXEFL_DXEditor0_I')]]")).SendKeys(gridName);
            Task.Delay(waitDelay5).Wait();

            //Enter a UserName.
            driver.FindElement(By.XPath("//input[@id[contains(.,'GridEnvironmentGridView_DXEFL_DXEditor2_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'GridEnvironmentGridView_DXEFL_DXEditor2_I')]]")).SendKeys(gridUserName);
            Task.Delay(waitDelay5).Wait();

            //Check SSL Error checkbox.
            driver.FindElement(By.XPath("//span[@id[contains(.,'GridEnvironmentGridView_DXEFL_DXEditor4_S_D')]]")).Click();
            Task.Delay(waitDelay5).Wait();

            //Select an Allowed Program.
            driver.FindElement(By.XPath("//input[@id[contains(.,'GridEnvironmentGridView_DXEFL_DXEditor5_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'GridEnvironmentGridView_DXEFL_DXEditor5_I')]]")).SendKeys(envProgram);
            Task.Delay(waitDelay5).Wait();

            //Enter a Host.
            driver.FindElement(By.XPath("//input[@id[contains(.,'GridEnvironmentGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'GridEnvironmentGridView_DXEFL_DXEditor1_I')]]")).SendKeys(gridHost);
            Task.Delay(waitDelay5).Wait();

            //Enter a Password.
            driver.FindElement(By.XPath("//input[@id[contains(.,'GridEnvironmentGridView_DXEFL_DXEditor3_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'GridEnvironmentGridView_DXEFL_DXEditor3_I')]]")).SendKeys(gridPassword);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for field to disappear.
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//label[text()='Name:']")));
        }
        #endregion

        #region Manage Site Permissions Tests
        public string roleAccessGrant = "All";
        public string roleAccessRemove = "-";
        public string roleAdminDescription = "Administrative functions";
        public string roleAdminName = "Administrator";
        public string roleDescription = "Automation role permission testing - DO NOT USE";
        public string roleName = "AutomationTesting";

        public string roleOnPremGroupName = "FTP_HdgeOp_QA";
        public string roleCloudGroupName = "0317ZRM1960-qa";

        #region Inputs and Assumptions strings
        public string resourceInputsAndAssumptions = "Menu|Inputs and Assumptions";
        public string resourceBalanceSheet = "Inputs and Assumptions->Balance Sheet";
        public string resourceConfigNamespaces = "Configuration->Namespaces";
        public string resourceConfigSettings = "Configuration->Settings";
        public string resourceETL = "ETL->Validation";

        public string resourceModels = "Models->External Models";
        public string resourceParameters = "Parameters->Manage Parameter Sets";
        public string resourceProgSettingsDelete = "Program Settings->Delete";
        public string resourceProgSettingsEdit = "Program Settings->Edit";

        public string resourceSetupApprovals = "Setup->Approvals";
        public string resourceSetupEntityStr = "Setup->Entity Structure";
        public string resourceSetupFundMap = "Setup->Fund Mapping";
        public string resourceSetupHolidays = "Setup->Holidays";
        public string resourceSetupInfoSteps = "Setup->Inforce Steps";
        public string resourceSetupProducts = "Setup->Products";
        public string resourceSetupRiskTax = "Setup->Risk Taxonomy";
        public string resourceSetupShockDef = "Setup->Shock Definitions";
        #endregion

        #region Risk Framework strings
        public string resourceRiskFramework = "Market Data->Scenarios";
        #endregion

        #region Runs strings
        public string resourceStatusDashJobReconnect = "Job Status -> Reconnect";
        public string resourceRunConfigNotifGroups = "Run Configuration->Notification Groups";
        public string resourceRunConfigGroupLocks = "Run Configuration->Run Group Locks";
        public string resourceRunConfigRunList = "Run Configuration->Run List";
        public string resourceRunConfigRunSchedules = "Run Configuration->Run Schedules";

        public string resourceRunManageGridHistory = "Run Management->Grid History";
        public string resourceRunManageOutputDash = "Run Management->Output Dashboard";
        public string resourceRunManageStatusDash = "Run Management->Status Dashboard";
        #endregion

        #region Report Center strings
        public string resourceReportDashApprove = "Report Dashboard->Approve";
        public string resourceReportDashOverride = "Report Dashboard->Override";
        #endregion

        #region Administration strings
        public string resourceAdminDataStore = "Data Store->Edit";
        public string resourceAdminLogs = "File System->Logs";
        public string resourceAdminGridEnv = "Administration->Grid Environments";
        public string resourceAdminManageEngine = "Administration->Manage Engine";
        public string resourceAdminRoleMapping = "Administration->Role Mapping";
        public string resourceAdminAccessControl = "Administration->Access Control";
        #endregion
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void CreateRole()
        {
            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor0_I')]]")).SendKeys(roleName);
            Task.Delay(waitDelay5).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor1_I')]]")).SendKeys(roleDescription);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Validate presence of added role.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='AutomationTesting']]/td[text()='Automation role permission testing - DO NOT USE']")));

            //Click on Role to Group Mapping.
            driver.FindElement(By.XPath("(//span[text()='Role to Group Mapping'])[2]")).Click();


            //~ROLE TO GROUP MAPPING PAGE:-----------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for Name column to load.

            //Enter a group.
            driver.FindElement(By.XPath("//input[@id[contains(.,'GroupComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'GroupComboBox_I')]]")).SendKeys(roleOnPremGroupName);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            var roleActive = driver.FindElements(By.XPath("//tr[td[text()='AutomationTesting']]//span[@class[contains(.,'dxWeb_edtCheckBoxUnchecked')]]"));

            if (roleActive.Any())
            {
                //Click on Automation Testing Mapped checkbox.
                driver.FindElement(By.XPath("//tr[td[text()='AutomationTesting']]//span[@class[contains(.,'dxWeb_edtCheckBoxUnchecked')]]")).Click();
                Task.Delay(waitDelay5).Wait();

                //Validate Automation Testing role is checked.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='AutomationTesting']]//span[@class[contains(.,'dxWeb_edtCheckBoxChecked')]]")));
            }

            var roleAdminActive = driver.FindElements(By.XPath("//tr[td[text()='Administrator']]//span[@class[contains(.,'dxWeb_edtCheckBoxChecked')]]"));

            if (roleAdminActive.Any())
            {
                //Click on Administrator Mapped checkbox.
                driver.FindElement(By.XPath("//tr[td[text()='Administrator']]//span[@class[contains(.,'dxWeb_edtCheckBoxChecked')]]")).Click();
                Task.Delay(waitDelay5).Wait();

                //Validate Administrator role is unchecked.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Administrator']]//span[@class[contains(.,'dxWeb_edtCheckBoxUnchecked')]]")));
            }

            //Click on Save changes.
            driver.FindElement(By.XPath("//span[text()='Save changes']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Validate AutomationTesting role is linked to FTP_HdgeOp_QA.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='FTP_HdgeOp_QA']]/td[text()='AutomationTesting']")));

            //Click on Securable Access by Role link.
            driver.FindElement(By.XPath("(//span[text()='Securable Access by Role'])[2]")).Click();


            //~SECURABLE ACCESS BY ROLE PAGE:-----------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for Name column to load.
        }
        public void CreateRole2()
        {
            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor0_I')]]")).SendKeys(roleName);
            Task.Delay(waitDelay5).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor1_I')]]")).SendKeys(roleDescription);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Validate presence of added role.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='AutomationTesting']]/td[text()='Automation role permission testing - DO NOT USE']")));

            //Click on Role to Group Mapping.
            driver.FindElement(By.XPath("(//span[text()='Role to Group Mapping'])[2]")).Click();


            //~ROLE TO GROUP MAPPING PAGE:-----------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for Name column to load.

            //Enter a group.
            driver.FindElement(By.XPath("//input[@id[contains(.,'GroupComboBox_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'GroupComboBox_I')]]")).SendKeys(roleOnPremGroupName);
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key.
            HitEnterKey();

            var roleActive = driver.FindElements(By.XPath("//tr[td[text()='AutomationTesting']]//span[@class[contains(.,'dxWeb_edtCheckBoxUnchecked')]]"));

            if (roleActive.Any())
            {
                //Click on Automation Testing Mapped checkbox.
                driver.FindElement(By.XPath("//tr[td[text()='AutomationTesting']]//span[@class[contains(.,'dxWeb_edtCheckBoxUnchecked')]]")).Click();
                Task.Delay(waitDelay5).Wait();

                //Validate Automation Testing role is checked.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='AutomationTesting']]//span[@class[contains(.,'dxWeb_edtCheckBoxChecked')]]")));
            }

            //Click on Save changes.
            driver.FindElement(By.XPath("//span[text()='Save changes']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Validate AutomationTesting role is linked to FTP_HdgeOp_QA.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='FTP_HdgeOp_QA']]/td[text()='AutomationTesting']")));

            //Click on Securable Access by Role link.
            driver.FindElement(By.XPath("(//span[text()='Securable Access by Role'])[2]")).Click();


            //~SECURABLE ACCESS BY ROLE PAGE:-----------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for Name column to load.
        }
        public void CreateAdminRole()
        {
            //Click on New link.
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Enter a Name.
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor0_I')]]")).SendKeys(roleAdminName);
            Task.Delay(waitDelay5).Wait();

            //Enter a Comment.
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor1_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleGridView_DXEFL_DXEditor1_I')]]")).SendKeys(roleAdminDescription);
            Task.Delay(waitDelay5).Wait();

            //Click on Update.
            driver.FindElement(By.XPath("//span[text()='Update']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Validate presence of added role.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Administrator']]/td[text()='Administrative functions']")));
        }

        public void GenericAccessReadOnly()
        {
            var roleSecurable = driver.FindElements(By.XPath("//td[3]/span[@class[contains(.,'dxWeb_edtCheckBoxUnchecked')]]"));

            //Check if the ReadOnly checkbox is unchecked.
            if (roleSecurable.Any())
            {
                //Click on the None checkbox.
                driver.FindElement(By.XPath("//td[3]/span[@class[contains(.,'dxWeb_edtCheckBoxUnchecked')]]")).Click();
            }

            //Waits for ReadOnly checkbox to become checked.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//td[3]//span[@class[contains(.,'dxWeb_edtCheckBoxChecked')]])[1]")));

            //Click on Save changes.
            driver.FindElement(By.XPath("//span[text()='Save changes']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Clear Resource search field.
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
        }
        public void GenericAccessRemoval()
        {
            var roleSecurable = driver.FindElements(By.XPath("(//td[2]//span[@class[contains(.,'dxWeb_edtCheckBoxUnchecked')]])[1]"));

            //Check if the None checkbox is unchecked.
            if (roleSecurable.Any())
            {
                //Click on the None checkbox.
                driver.FindElement(By.XPath("//td[2]/span[@class[contains(.,'dxWeb_edtCheckBoxUnchecked')]]")).Click();
            }

            //Waits for None checkbox to become checked.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//td[2]//span[@class[contains(.,'dxWeb_edtCheckBoxChecked')]])[1]")));

            //Click on Save changes.
            driver.FindElement(By.XPath("//span[text()='Save changes']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Clear Resource search field.
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Clear();
            Task.Delay(waitDelay5).Wait();
        }
        public void GenericNonePermissionCleanup()
        {
            //Filter by None checked checkboxes.
            driver.FindElement(By.XPath("(//td[@id[contains(.,'RoleSecurableGridView_DXFREditorcol1_B-1')]])[2]")).Click();
            Task.Delay(waitDelay6).Wait();
            driver.FindElement(By.XPath("//table[@id[contains(.,'RoleSecurableGridView_DXFREditorcol1_DDD_L_LBT')]]//td[text()='Checked']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerShort && timer.IsRunning.Equals(true))
            {
                var accessRevoked = driver.FindElements(By.XPath("//td[2]//span[@class[contains(.,'dxWeb_edtCheckBoxChecked')]]"));

                if (accessRevoked.Any())
                {
                    //Set revoked access back to allowed for all tested resources.
                    GenericResourceReset();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Click on Save changes.
            driver.FindElement(By.XPath("//span[text()='Save changes']")).Click();
            Task.Delay(waitDelayLong).Wait();
        }
        public void GenericReadOnlyPermissionCleanup()
        {
            //Filter by ReadOnly checked checkboxes.
            driver.FindElement(By.XPath("(//td[@id[contains(.,'RoleSecurableGridView_DXFREditorcol2_B-1')]])[2]")).Click();
            Task.Delay(waitDelay6).Wait();
            driver.FindElement(By.XPath("//table[@id[contains(.,'RoleSecurableGridView_DXFREditorcol2_DDD_L_LBT')]]//td[text()='Checked']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerShort && timer.IsRunning.Equals(true))
            {
                var accessRevoked = driver.FindElements(By.XPath("//td[@class='dxgv dx-ac']//span[@class='dxWeb_edtCheckBoxChecked_SoftOrange dxICheckBox_SoftOrange dxichSys']"));

                if (accessRevoked.Any())
                {
                    //Set revoked access back to allowed for all tested resources.
                    GenericResourceReset();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Click on Save changes.
            driver.FindElement(By.XPath("//span[text()='Save changes']")).Click();
            Task.Delay(waitDelayLong).Wait();
        }

        public void GenericResourceReset()
        {
            //Click on ReadWrite checkbox.       
            driver.FindElement(By.XPath("//td[4]//span[@class='dxWeb_edtCheckBoxUnchecked_SoftOrange dxICheckBox_SoftOrange dxichSys']")).Click();
            Task.Delay(waitDelay5).Wait();

            //Hit the Enter key. (this allows the checkbox span element to register the current status of the checkbox. For whatever reason, this doesnt update on click.)
            SendKeys.SendWait(@"{Enter}");
            Task.Delay(waitDelay5).Wait();
        }
        public void RoleNavigation()
        {
            var rolePresent = driver.FindElements(By.XPath("//tr[td[text()='AutomationTesting']]/td[text()='Automation role permission testing - DO NOT USE']"));

            if (!rolePresent.Any())
            {
                //Create new Role.
                CreateRole();
            }

            //Click on AutomationTesting role row.
            driver.FindElement(By.XPath("//tr[td[text()='AutomationTesting']]")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Validate that the correct role is being edited.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[@class[contains(.,'dxgvFocusedRow_SoftOrange')]]/td[text()='AutomationTesting']")));
        }
        public void RoleAccessControlNavigation()
        {
            var roleAdminPresent = driver.FindElements(By.XPath("//tr[td[text()='Administrator']]/td[text()='Administrative functions']"));

            if (!roleAdminPresent.Any())
            {
                //Create new Role.
                CreateAdminRole();
            }

            var roleAutomationPresent = driver.FindElements(By.XPath("//tr[td[text()='AutomationTesting']]/td[text()='Automation role permission testing - DO NOT USE']"));

            if (!roleAutomationPresent.Any())
            {
                //Create new Role.
                CreateRole2();
            }

            //Click on AutomationTesting role row.
            driver.FindElement(By.XPath("//tr[td[text()='AutomationTesting']]")).Click();
            Task.Delay(waitDelay5).Wait();

            //Validate that the correct role is being edited.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[@class[contains(.,'dxgvFocusedRow_SoftOrange')]]/td[text()='AutomationTesting']")));
        }
        public void SPRoleTemplateNavigation()
        {
            var rolePresent = driver.FindElements(By.XPath("//tbody[tr/td/a/text()='StubRole']//td[text()='The role for running stub programs']"));

            if (rolePresent.Any())
            {
                //Click on StubRole link.
                driver.FindElement(By.XPath("//td/a[text()='StubRole']")).Click();
                Task.Delay(waitDelay5).Wait();

                //Validate that the correct role is being edited.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//div[@class='accountHeader']/span[text()='StubRole']")));
            }
        }

        #region Inputs and Assumptions
        public void AccessRemoveInputsAndAssMenu()
        {
            //Enter a resource and search. (Inputs and Assumptions)
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_I")).SendKeys(resourceInputsAndAssumptions);
            Task.Delay(waitDelay5).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveConfigNamespacesSub()
        {
            //Enter a resource and search. (Namespaces)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceConfigNamespaces);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveConfigSettingsSub()
        {
            //Enter a resource and search. (Settings)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceConfigSettings);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }

        public void AccessRemoveETLSub()
        {
            //Enter a resource and search. (ETL)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceETL);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveBalanceSheetSub()
        {
            //Enter a resource and search. (Balance Sheet)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceBalanceSheet);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveModelsSub()
        {
            //Enter a resource and search. (Models)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceModels);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveParametersSub()
        {
            //Enter a resource and search. (Parameters)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceParameters);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }

        public void AccessRemoveProgSettingsDelete()
        {
            //Enter a resource and search. (Program Settings --> Delete)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceProgSettingsDelete);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveProgSettingsEdit()
        {
            //Enter a resource and search. (Program Settings --> Edit)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceProgSettingsEdit);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }

        public void AccessRemoveSetupApprovalsSub()
        {
            //Enter a resource and search. (Approvals)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupApprovals);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveSetupEntityStrSub()
        {
            //Enter a resource and search. (Entity Structure)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupEntityStr);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveSetupFundMapSub()
        {
            //Enter a resource and search. (Fund Mapping)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupFundMap);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveSetupHolidaysSub()
        {
            //Enter a resource and search. (Holidays)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupHolidays);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveSetupInfoStepSub()
        {
            //Enter a resource and search. (Inforce Steps)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupInfoSteps);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveSetupProductsSub()
        {
            //Enter a resource and search. (Products)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupProducts);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveSetupRiskTaxSub()
        {
            //Enter a resource and search. (Risk Taxonomy)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupRiskTax);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveSetupShockDefSub()
        {
            //Enter a resource and search. (Shock Definitions)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupShockDef);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }

        public void AccessReadOnlyInputsAndAssMenu()
        {
            //Enter a resource and search. (Inputs and Assumptions)
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_I")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.Id("ctl00_ctl00_ASPxSplitter4_Content_MainContent_gvRolePermissions_DXFREditorcol0_I")).SendKeys(resourceInputsAndAssumptions);
            Task.Delay(waitDelay5).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyConfigNamespacesSub()
        {
            //Enter a resource and search. (Namespaces)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceConfigNamespaces);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyConfigSettingsSub()
        {
            //Enter a resource and search. (Settings)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceConfigSettings);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }

        public void AccessReadOnlyETLSub()
        {
            //Enter a resource and search. (ETL)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceETL);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyBalanceSheetSub()
        {
            //Enter a resource and search. (Balance Sheet)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceBalanceSheet);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyModelsSub()
        {
            //Enter a resource and search. (Models)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceModels);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyParametersSub()
        {
            //Enter a resource and search. (Parameters)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceParameters);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }

        public void AccessReadOnlyProgSettingsDelete()
        {
            //Enter a resource and search. (Program Settings --> Delete)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceProgSettingsDelete);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyProgSettingsEdit()
        {
            //Enter a resource and search. (Program Settings --> Edit)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceProgSettingsEdit);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }

        public void AccessReadOnlySetupApprovalsSub()
        {
            //Enter a resource and search. (Approvals)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupApprovals);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlySetupEntityStrSub()
        {
            //Enter a resource and search. (Entity Structure)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupEntityStr);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlySetupFundMapSub()
        {
            //Enter a resource and search. (Fund Mapping)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupFundMap);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlySetupHolidaysSub()
        {
            //Enter a resource and search. (Holidays)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupHolidays);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlySetupInfoStepSub()
        {
            //Enter a resource and search. (Inforce Steps)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupInfoSteps);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlySetupProductsSub()
        {
            //Enter a resource and search. (Products)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupProducts);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlySetupRiskTaxSub()
        {
            //Enter a resource and search. (Risk Taxonomy)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupRiskTax);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlySetupShockDefSub()
        {
            //Enter a resource and search. (Shock Definitions)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceSetupShockDef);
            Task.Delay(waitDelayLong).Wait();

            //Set ReadOnly resource access.
            GenericAccessReadOnly();
        }
        #endregion

        #region Risk Framework
        public void AccessRemoveRiskFrameworkScenariosSub()
        {
            //Enter a resource and search. (Scenarios)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRiskFramework);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessReadOnlyRiskFrameworkScenariosSub()
        {
            //Enter a resource and search. (Scenarios)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRiskFramework);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        #endregion

        #region Runs
        public void AccessRemoveJobStatusReconnect()
        {
            //Enter a resource and search. (Job Status -> Reconnect)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceStatusDashJobReconnect);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveRunConfigNotifGroupsSub()
        {
            //Enter a resource and search. (Notification Groups)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunConfigNotifGroups);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveRunConfigGroupLocksSub()
        {
            //Enter a resource and search. (Run Group Locks)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunConfigGroupLocks);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveRunConfigRunListSub()
        {
            //Enter a resource and search. (Run List)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunConfigRunList);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveRunConfigRunSchedulesSub()
        {
            //Enter a resource and search. (Run Schedules)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunConfigRunSchedules);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }

        public void AccessRemoveRunManageGridHistorySub()
        {
            //Enter a resource and search. (Grid History)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunManageGridHistory);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveRunManageOutputDashSub()
        {
            //Enter a resource and search. (Output)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunManageOutputDash);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveRunManageStatusDashSub()
        {
            //Enter a resource and search. (Status)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunManageStatusDash);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }

        public void AccessReadOnlyJobStatusReconnect()
        {
            //Enter a resource and search. (Job Status -> Reconnect)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceStatusDashJobReconnect);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyRunConfigNotifGroupsSub()
        {
            //Enter a resource and search. (Notification Groups)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunConfigNotifGroups);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyRunConfigGroupLocksSub()
        {
            //Enter a resource and search. (Run Group Locks)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunConfigGroupLocks);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyRunConfigRunListSub()
        {
            //Enter a resource and search. (Run List)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunConfigRunList);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyRunConfigRunSchedulesSub()
        {
            //Enter a resource and search. (Run Schedules)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunConfigRunSchedules);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }

        public void AccessReadOnlyRunManageGridHistorySub()
        {
            //Enter a resource and search. (Grid History)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunManageGridHistory);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyRunManageOutputDashSub()
        {
            //Enter a resource and search. (Output)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunManageOutputDash);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyRunManageStatusDashSub()
        {
            //Enter a resource and search. (Status)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceRunManageStatusDash);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        #endregion

        #region Report Center
        public void AccessRemoveReportApprovePerm()
        {
            //Enter a resource and search. (Report Center - Approve Reports)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceReportDashApprove);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveReportOverridePerm()
        {
            //Enter a resource and search. (Report Center - Override Reports)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceReportDashOverride);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }

        public void AccessReadOnlyReportApprovePerm()
        {
            //Enter a resource and search. (Report Center - Approve Reports)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceReportDashApprove);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyReportOverridePerm()
        {
            //Enter a resource and search. (Report Center - Override Reports)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceReportDashOverride);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        #endregion

        #region Administration
        public void AccessRemoveAdminDataStore()
        {
            //Enter a resource and search. (Data Store-Edit)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminDataStore);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveAdminLogs()
        {
            //Enter a resource and search. (Logs)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminLogs);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveAdminGridEnv()
        {
            //Enter a resource and search. (Grid Environments)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminGridEnv);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveAdminManageEngine()
        {
            //Enter a resource and search. (Manage Engine)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminManageEngine);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveAdminRoleMapping()
        {
            //Enter a resource and search. (Manage Roles)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminRoleMapping);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }
        public void AccessRemoveAdminSecureAccessByRole()
        {
            //Enter a resource and search. (Manage Role Templates)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminAccessControl);
            Task.Delay(waitDelayLong).Wait();

            //Remove resource access.
            GenericAccessRemoval();
        }

        public void AccessReadOnlyAdminDataStore()
        {
            //Enter a resource and search. (Data Store-Edit)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminDataStore);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyAdminLogs()
        {
            //Enter a resource and search. (Logs)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminLogs);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyAdminGridEnv()
        {
            //Enter a resource and search. (Grid Environments)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminGridEnv);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyAdminManageEngine()
        {
            //Enter a resource and search. (Manage Engine)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminManageEngine);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyAdminRoleMapping()
        {
            //Enter a resource and search. (Manage Roles)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminRoleMapping);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        public void AccessReadOnlyAdminSecureAccessByRole()
        {
            //Enter a resource and search. (Manage Role Templates)
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id[contains(.,'RoleSecurableGridView_DXFREditorcol0_I')]]")).SendKeys(resourceAdminAccessControl);
            Task.Delay(waitDelayLong).Wait();

            //Set resource access.
            GenericAccessReadOnly();
        }
        #endregion
        #endregion
        //--ADMINISTRATION--------------------------------------------------------------------------------------------oo

        //~║·AUTOMATION CORE TESTING·╠═════════════════════════════════════════════════════════════════════════════════════════════════╝

        //UI INTERACTIONS-------------------------------------------------------------------------------------------------------------<>
        #region UI Global Items/Interactions
        public XmlDocument doc = new XmlDocument();
        public DateTime TodaysDateTime = DateTime.Today;
        public static Stopwatch timer = new Stopwatch();

        public string parentWindowHandle, lastWindowHandle;
        public string groupName, envProgram, testDate, todaysDate, todayMonthNum, todayMonth, todayFullDay, todayYear;
        public int todayDay = 0, clickHoldToggle, refreshToggle, refreshDelay = 1000;
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void ClearCache()
        {
            //Clear browser cache. 
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
        }
        public void ClickHold()
        {
            //Used to interact with the "Type" approval grid view in the HedgeOps Approvals page.
            if (clickHoldToggle == 1)
            {
                Actions action = new Actions(driver);
                Actions release = new Actions(driver);
                var elementWindow = driver.FindElement(By.XPath("//img[@class[contains(.,'WindowResizer')]]"));
                action.ClickAndHold(elementWindow).Perform();
                action.MoveByOffset(0, 170).Perform();
                release.Release(elementWindow).Perform();
                Task.Delay(waitDelay5).Wait();
            }
        }
        public void CleanUpRunGroupClones()
        {
            //Restart stopwatch.
            timer.Restart();

            while (timer.Elapsed.TotalSeconds < timerMinute && timer.IsRunning.Equals(true))
            {
                var cloneGroup = driver.FindElements(By.XPath(string.Format("//td[text()[contains(.,'Clone of {0}')]]", runGroup)));

                if (cloneGroup.Any())
                {
                    //Delete run groups that are specified.
                    driver.FindElement(By.XPath(string.Format("//tr[td[text()[contains(.,'Clone of {0}')]]]//span[text()='Delete']", runGroup))).Click();
                    Task.Delay(waitDelay5).Wait();

                    //Hit the Enter key.
                    HitEnterKey();
                    Task.Delay(waitDelaySuper).Wait();
                }

                else
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            Assert.IsFalse(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()[contains(.,'Clone of {0}')]]]//span[text()='Delete']", runGroup))));
        }
        public void ClickRefreshButton()
        {
            //>Applicable to the Status Dashboard page.
            //Click on Refresh button.
            driver.FindElement(By.XPath("//span[text()='Refresh']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for Refresh button to load.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Refresh']")));
        }
        public void ClickSearchButton()
        {
            //>Applicable to the Output Dashboard page.
            //Click on Search button.
            driver.FindElement(By.XPath("//span[text()='Search']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Waits for Search button to load.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Search']")));
        }

        public void DetermineDateTimeFormat()
        {
            string dateMonth = TodaysDateTime.ToString("MM");
            string dateDay = TodaysDateTime.ToString("dd");

            int dateMonthRange = Int32.Parse(dateMonth);

            if (dateMonthRange >= 10 && dateMonthRange <= 12)
            {
                int dateDayRange = Int32.Parse(dateDay);

                if (dateDayRange >= 1 && dateDayRange <= 9)
                {
                    todaysDate = TodaysDateTime.ToString("MM/d/yyyy");
                }

                else
                {
                    todaysDate = TodaysDateTime.ToString("MM/dd/yyyy");
                }
            }

            else
            {
                int dateDayRange = Int32.Parse(dateDay);

                if (dateDayRange >= 1 && dateDayRange <= 9)
                {
                    todaysDate = TodaysDateTime.ToString("M/d/yyyy");
                }

                else
                {
                    todaysDate = TodaysDateTime.ToString("M/dd/yyyy");
                }
            }
        }
        public void DetermineDateTime()
        {
            todayMonthNum = TodaysDateTime.ToString("MM");
            todayFullDay = TodaysDateTime.ToString("dd");
            todayYear = TodaysDateTime.ToString("yyyy");

            if (testVariation == 1)
            {
                #region Month Num Conversion
                if (todayMonthNum == "01")
                {
                    todayMonth = "1";
                }
                if (todayMonthNum == "02")
                {
                    todayMonth = "2";
                }
                if (todayMonthNum == "03")
                {
                    todayMonth = "3";
                }
                if (todayMonthNum == "04")
                {
                    todayMonth = "4";
                }
                if (todayMonthNum == "05")
                {
                    todayMonth = "5";
                }
                if (todayMonthNum == "06")
                {
                    todayMonth = "6";
                }
                if (todayMonthNum == "07")
                {
                    todayMonth = "7";
                }
                if (todayMonthNum == "08")
                {
                    todayMonth = "8";
                }
                if (todayMonthNum == "09")
                {
                    todayMonth = "9";
                }
                if (todayMonthNum == "10")
                {
                    todayMonth = "10";
                }
                if (todayMonthNum == "11")
                {
                    todayMonth = "11";
                }
                if (todayMonthNum == "12")
                {
                    todayMonth = "12";
                }
                #endregion
            }

            else
            {
                if (testVariation == 2)
                {
                    todayMonthNum = testDateTrunc;
                }

                #region Month Num/Name Conversion
                if (todayMonthNum == "01" || todayMonthNum == "1")
                {
                    if (testVariation == 2)
                    {
                        todayMonth = "January";
                    }
                    else
                    {
                        todayMonth = "Jan";
                    }

                    testDate = todayMonth;
                }
                if (todayMonthNum == "02" || todayMonthNum == "2")
                {
                    if (testVariation == 2)
                    {
                        todayMonth = "February";
                    }
                    else
                    {
                        todayMonth = "Feb";
                    }

                    testDate = todayMonth;
                }
                if (todayMonthNum == "03" || todayMonthNum == "3")
                {
                    if (testVariation == 2)
                    {
                        todayMonth = "March";
                    }
                    else
                    {
                        todayMonth = "Mar";
                    }

                    testDate = todayMonth;
                }
                if (todayMonthNum == "04" || todayMonthNum == "4")
                {
                    if (testVariation == 2)
                    {
                        todayMonth = "April";
                    }
                    else
                    {
                        todayMonth = "Apr";
                    }

                    testDate = todayMonth;
                }
                if (todayMonthNum == "05" || todayMonthNum == "5")
                {
                    todayMonth = "May";

                    testDate = todayMonth;
                }
                if (todayMonthNum == "06" || todayMonthNum == "6")
                {
                    if (testVariation == 2)
                    {
                        todayMonth = "June";
                    }
                    else
                    {
                        todayMonth = "Jun";
                    }

                    testDate = todayMonth;
                }
                if (todayMonthNum == "07" || todayMonthNum == "7")
                {
                    if (testVariation == 2)
                    {
                        todayMonth = "July";
                    }
                    else
                    {
                        todayMonth = "Jul";
                    }

                    testDate = todayMonth;
                }
                if (todayMonthNum == "08" || todayMonthNum == "8")
                {
                    if (testVariation == 2)
                    {
                        todayMonth = "August";
                    }
                    else
                    {
                        todayMonth = "Aug";
                    }

                    testDate = todayMonth;
                }
                if (todayMonthNum == "09" || todayMonthNum == "9")
                {
                    if (testVariation == 2)
                    {
                        todayMonth = "September";
                    }
                    else
                    {
                        todayMonth = "Sep";
                    }

                    testDate = todayMonth;
                }
                if (todayMonthNum == "10")
                {
                    if (testVariation == 2)
                    {
                        todayMonth = "October";
                    }
                    else
                    {
                        todayMonth = "Oct";
                    }

                    testDate = todayMonth;
                }
                if (todayMonthNum == "11")
                {
                    if (testVariation == 2)
                    {
                        todayMonth = "November";
                    }
                    else
                    {
                        todayMonth = "Nov";
                    }

                    testDate = todayMonth;
                }
                if (todayMonthNum == "12")
                {
                    if (testVariation == 2)
                    {
                        todayMonth = "December";
                    }
                    else
                    {
                        todayMonth = "Dec";
                    }

                    testDate = todayMonth;
                }
                #endregion
            }

            todayDay = Int32.Parse(todayFullDay);
        }
        public void DetermineProgramFileTag()
        {
            if (targetProgram == 1)
            {
                programTag = programTagSecondary;
            }

            if (targetProgram == 2)
            {
                programTag = programTagTertiary;
            }

            else
            {
                programTag = programTagSP;
            }
        }
        public void FileCompareBinary()
        {
            byte[] item1 = File.ReadAllBytes(compareFile);
            byte[] item2 = File.ReadAllBytes(sourceFile);
            if (item1.Length != item2.Length)
            {
                Assert.Fail(@"Downloaded file is not binary equal to source file.");
            }
        }
        public void IdentifyEnvProgram()
        {
            envProgram = driver.FindElement(By.XPath("//td[text()[contains(.,'Program:')]]/b[1]")).Text;
            char[] trimChars = { ' ' };
            envProgram = envProgram.Trim(trimChars);
        }

        public void HandleMultiBrowsers()
        {
            //Store all opened windows into a list.
            List<string> openedWindows = driver.WindowHandles.ToList();

            foreach (var handle in openedWindows)
            {
                driver.SwitchTo().Window(handle);
                lastWindowHandle = handle;
            }

            if (testVariation == 1)
            {
                //Switch to the parent window and close it.
                driver.SwitchTo().Window(parentWindowHandle);
                driver.Close();

                foreach (var handle in openedWindows)
                {
                    if (handle != parentWindowHandle && handle != lastWindowHandle)
                    {
                        driver.SwitchTo().Window(handle);

                        //Validate presence of Auxiliary files.
                        AssertGridAuxiliaryFiles();

                        //Close the focused browser window.
                        driver.Close();
                    }
                }

                //Switch to the last window to focus on it.
                driver.SwitchTo().Window(lastWindowHandle);
            }

            if (testVariation == 2)
            {
                //Switch to the last window and close it.
                driver.SwitchTo().Window(lastWindowHandle);
                driver.Close();

                //Switch to the parent window to focus on it.
                driver.SwitchTo().Window(parentWindowHandle);
            }

            if (checkDetails1_HOPS796 == 1)
            {
                //Switch to the last window.
                driver.SwitchTo().Window(lastWindowHandle);

                foreach (var handle in openedWindows)
                {
                    if (handle != parentWindowHandle)
                    {
                        driver.SwitchTo().Window(handle);

                        #region Assess Grid Details for Run 6
                        var runDesc6 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run6_Hops796)));

                        if (runDesc6.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run6_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run6_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 5
                        var runDesc5 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run5_Hops796)));

                        if (runDesc5.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run5_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run5_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 4
                        var runDesc4 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run4_Hops796)));

                        if (runDesc4.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run4_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run4_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 3
                        var runDesc3 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run3_Hops796)));

                        if (runDesc3.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run3_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run3_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 2
                        var runDesc2 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run2_Hops796)));

                        if (runDesc2.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run2_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run2_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 1
                        var runDesc1 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run1_Hops796)));

                        if (runDesc1.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run1_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run1_Hops796));
                            }
                        }
                        #endregion

                        //Close the focused browser window.
                        driver.Close();
                    }
                }

                //Switch to the last window to focus on it.
                driver.SwitchTo().Window(lastWindowHandle);
            }

            if (checkDetails1_HOPS796 == 2)
            {
                //Switch to the last window.
                driver.SwitchTo().Window(lastWindowHandle);

                foreach (var handle in openedWindows)
                {
                    if (handle != parentWindowHandle)
                    {
                        driver.SwitchTo().Window(handle);

                        #region Assess Grid Details for Run 9
                        var runDesc9 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run9_Hops796)));

                        if (runDesc9.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run9_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run9_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 8
                        var runDesc8 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run8_Hops796)));

                        if (runDesc8.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run8_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run8_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 7
                        var runDesc7 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run7_Hops796)));

                        if (runDesc7.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run7_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run7_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 6
                        var runDesc6 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run6_Hops796)));

                        if (runDesc6.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run6_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run6_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 5
                        var runDesc5 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run5_Hops796)));

                        if (runDesc5.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run5_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run5_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 4
                        var runDesc4 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run4_Hops796)));

                        if (runDesc4.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run4_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run4_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 3
                        var runDesc3 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run3_Hops796)));

                        if (runDesc3.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run3_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run3_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 2
                        var runDesc2 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run2_Hops796)));

                        if (runDesc2.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run2_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run2_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 1
                        var runDesc1 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run1_Hops796)));

                        if (runDesc1.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run1_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario2.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run1_Hops796));
                            }
                        }
                        #endregion

                        //Close the focused browser window.
                        driver.Close();
                    }
                }

                //Switch to the last window to focus on it.
                driver.SwitchTo().Window(lastWindowHandle);
            }

            if (checkDetails1_HOPS796 == 3)
            {
                //Switch to the last window.
                driver.SwitchTo().Window(lastWindowHandle);

                foreach (var handle in openedWindows)
                {
                    if (handle != parentWindowHandle)
                    {
                        driver.SwitchTo().Window(handle);

                        #region Assess Grid Details for Run 18
                        var runDesc9 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run18_Hops796)));

                        if (runDesc9.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run18_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Scenario09.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run18_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 17
                        var runDesc8 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run17_Hops796)));

                        if (runDesc8.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run17_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run17_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 16
                        var runDesc7 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run16_Hops796)));

                        if (runDesc7.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run16_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Scenario07.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run16_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 15
                        var runDesc6 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run15_Hops796)));

                        if (runDesc6.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run15_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//a[text()='Scenario06.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run15_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 14
                        var runDesc5 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run14_Hops796)));

                        if (runDesc5.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run14_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run14_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 13
                        var runDesc4 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run13_Hops796)));

                        if (runDesc4.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run13_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsFalse(driver.VerifyAsserts(By.XPath("//a[text()='Scenario04.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run13_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 12
                        var runDesc3 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run12_Hops796)));

                        if (runDesc3.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run12_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Scenario03.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run12_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 11
                        var runDesc2 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run11_Hops796)));

                        if (runDesc2.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run11_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='input.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run11_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 10
                        var runDesc1 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run10_Hops796)));

                        if (runDesc1.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='1']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run10_Hops796));
                            }

                            //Verify presence and/or absence of runtime files.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='scenario.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Scenario01.csv']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='Overlay1_param.txt']")));
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//a[text()='param.txt']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: One or more expected runtime files are missing or an unexpected runtime file is present for {0}.", run10_Hops796));
                            }
                        }
                        #endregion

                        //Close the focused browser window.
                        driver.Close();
                    }
                }

                //Switch to the last window to focus on it.
                driver.SwitchTo().Window(lastWindowHandle);
            }

            if (checkDetails1_HOPS796 == 4)
            {
                //Switch to the last window.
                driver.SwitchTo().Window(lastWindowHandle);

                foreach (var handle in openedWindows)
                {
                    if (handle != parentWindowHandle)
                    {
                        driver.SwitchTo().Window(handle);

                        #region Assess Grid Details for Run 26
                        var runDesc6 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run26_Hops796)));

                        if (runDesc6.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='18']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run26_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 25
                        var runDesc5 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run25_Hops796)));

                        if (runDesc5.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='334']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run25_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 23
                        var runDesc4 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run23_Hops796)));

                        if (runDesc4.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='3334']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run23_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 22
                        var runDesc3 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run22_Hops796)));

                        if (runDesc3.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='334']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run22_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 20
                        var runDesc2 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run20_Hops796)));

                        if (runDesc2.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='18']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run20_Hops796));
                            }
                        }
                        #endregion

                        #region Assess Grid Details for Run 19
                        var runDesc1 = driver.FindElements(By.XPath(string.Format("//span[text()='{0}']", run19_Hops796)));

                        if (runDesc1.Any())
                        {
                            //Verify correct total checkout quantity.
                            try
                            {
                                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[text()='Total']]//span[text()='334']")));
                            }
                            catch (Exception)
                            {
                                Assert.Fail(string.Format("Unexpected Result: Total checkouts on grid do not match expected for {0}.", run19_Hops796));
                            }
                        }
                        #endregion

                        //Close the focused browser window.
                        driver.Close();
                    }
                }

                //Switch to the last window to focus on it.
                driver.SwitchTo().Window(lastWindowHandle);
            }
        }
        public void HitEnterKey()
        {
            //Hit the Enter key.
            SendKeys.SendWait(@"{Enter}");
            Task.Delay(waitDelayLong).Wait();
        }
        public void HitEscKey()
        {
            //Hit the Esc key.
            SendKeys.SendWait(@"{Esc}");
            Task.Delay(waitDelay5).Wait();
        }
        public void HitHomeKey()
        {
            //Hit the Enter key.
            SendKeys.SendWait(@"{Home}");
            Task.Delay(waitDelay5).Wait();
        }
        public void HitTabKey()
        {
            //Hit the Enter key.
            SendKeys.SendWait(@"{Tab}");
            Task.Delay(waitDelay5).Wait();
        }

        public void InteractWithJavascriptWindow()
        {
            Actions keyEnter = new Actions(driver);
            keyEnter.SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
        }
        public void RefreshBrowser()
        {
            if (refreshDelay == 1)
            {
                refreshDelay = 10000;
            }

            //Refresh browser.
            driver.Navigate().Refresh();
            Task.Delay(refreshDelay).Wait();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()[contains(.,'Welcome')]]|//span[text()='Working Version']")));
            Task.Delay(refreshDelay).Wait();
        }
        #endregion

        #region UI Granular Navigation
        public void AdminMenuHover()
        {
            //Hover over Administration menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Administration']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void BalanceSheetMenuHover()
        {
            //Hover over Balance Sheet sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Balance Sheet']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void ConfigInputMenuHover()
        {
            //Hover over Configuration (Input) sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//span[text()='Configuration'])[1]")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void ConfigRunMenuHover()
        {
            //Hover over Configuration (Run) sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id[contains(.,'TopNavigationMenu_DXI3i0_T')]]/span[text()='Configuration']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void ETLMenuHover()
        {
            //Hover over ETL sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='ETL']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }

        public void EngineMenuHover()
        {
            //Hover over Engine sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Engine']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void FileSystemMenuHover()
        {
            //Hover over File System sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='File System']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void GridMenuHover()
        {
            //Hover over Grid sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Grid']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void InputAndAssumptionsMenuHover()
        {
            //Hover over Inputs and Assumptions menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Inputs and Assumptions']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void ManagementMenuHover()
        {
            //Hover over Management sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Management']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }

        public void ModelsMenuHover()
        {
            //Hover over Models sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Models']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void ParametersMenuHover()
        {
            //Hover over Parameters sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Parameters']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void ResultsMenuHover()
        {
            //Hover over Results menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Results']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();

        }
        public void RiskFrameworkMenuHover()
        {
            //Hover over Risk Framework menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Risk Framework']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void RunMenuHover()
        {
            //Hover over Runs menu.
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Runs']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }

        public void SecurityMenuHover()
        {
            //Hover over Security sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Security']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        public void SetupMenuHover()
        {
            //Hover over Setup sub menu.            
            var elementSetup = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Setup']")));
            Actions actionRun = new Actions(driver);
            actionRun.MoveToElement(elementSetup).Perform();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@style[contains(.,'visibility: visible;')]][2]"))); //Waits for sub menu to open
            Task.Delay(waitDelay6).Wait();
        }
        #endregion

        #region UI GridStep Navigation
        public int gridLoginOverride;
        public string gridId1, gridId2, gridId3, gridId4, gridId5, gridId6, gridId7, gridId8, gridId9;
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void AssertGridAuxiliaryFiles()
        {
            //Validate presence of auxiliary files.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//td/a[text()='File1.txt']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//td/a[text()='File2.txt']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//td/a[text()='File3.txt']")));
        }
        public void AssertNoGridInforceFiles()
        {
            //Validate absence of inforce files.
            Assert.IsFalse(driver.VerifyAsserts(By.XPath("//td/a[text()='input.csv']")));
        }

        public void LoginGridStep()
        {
            if (gridLoginOverride == 1)
            {
                gridUserName = GridUser;
                gridPassword = GridPassword;
            }

            //Enter grid username.
            driver.FindElement(By.XPath("//input[@id='UserName']")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id='UserName']")).SendKeys(gridUserName);
            Task.Delay(waitDelay5).Wait();

            //Enter grid password.
            driver.FindElement(By.XPath("//input[@id='Password']")).Click();
            Task.Delay(waitDelay5).Wait();
            driver.FindElement(By.XPath("//input[@id='Password']")).SendKeys(gridPassword);
            Task.Delay(waitDelay5).Wait();

            //Click on Log In button.
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Click on Jobs menu.
            driver.FindElement(By.XPath("//a[text()='Jobs']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //Click on Jobs ID.
            driver.FindElement(By.XPath(string.Format("//td/a[text()='{0}']", gridId1))).Click();
            Task.Delay(waitDelaySuper).Wait();
        }
        public void NavigateToGridStep()
        {
            //>Check for Security Warning Page---------------------------------------------------------
            var warning = driver.FindElements(By.XPath("//button[text()[contains(.,'Advanced')]]"));

            if (warning.Any())
            {
                //Click Advanced button.
                driver.FindElement(By.XPath("//button[text()[contains(.,'Advanced')]]")).Click();
                Task.Delay(waitDelay5).Wait();

                //Click proceed link.
                driver.FindElement(By.XPath("//a[@id='proceed-link']")).Click();
                Task.Delay(waitDelayLong).Wait();
            }

            //Wait for About action to load.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[text()='About']")));

            //Assess whether a user login is needed.
            var gridLogin = driver.FindElements(By.XPath("//input[@value='Log in']"));

            if (gridLogin.Any())
            {
                //Log in and navigate to job details page.
                LoginGridStep();
            }
        }
        #endregion

        #region UI Navigation
        public void NavigateToApprovalsPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Setup sub menu. 
            SetupMenuHover();

            //Click on Approvals.
            driver.FindElement(By.CssSelector("[href*='Inputs/VersionApprovals.aspx']")).Click();


            //~APPROVALS PAGE:------------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for the Name column to load.
        }
        public void NavigateToClassicSite()
        {
            //Navigate to Classic Site.
            driver.FindElement(By.XPath("//span[text()='Classic Site']")).Click();
            Task.Delay(waitDelayLong).Wait();

            //~HOME PAGE:----------------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[text()[contains(.,'Welcome to the Milliman FRM MG-Hedge')]]"))); //Waits for home page to load.
        }
        public void NavigateToDataStorePage()
        {
            //Hover over Administration menu.
            AdminMenuHover();

            //Hover over Engine sub menu.
            EngineMenuHover();

            //Click on Data Store.
            driver.FindElement(By.CssSelector("[href*='Administration/DataStore.aspx']")).Click();


            //~DATA STORE PAGE:----------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h3[text()='Data Store']"))); //Waits for Data Store header to load.
        }
        public void NavigateToEntityStructurePage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Setup sub menu.
            SetupMenuHover();

            //Click on External Models.
            driver.FindElement(By.CssSelector("[href*='Inputs/EntityStructure.aspx']")).Click();


            //~ENTITY STRUCTURE PAGE:----------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//th[text()='Name']"))); //Waits for the Name column to load.
        }
        public void NavigateToETLConfigurationPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over ETL sub menu. 
            ETLMenuHover();

            //Click on Configuration.
            driver.FindElement(By.XPath("//*[contains(@href, 'ETLConfiguration.aspx')]")).Click();


            //~CONFIGURATION PAGE:-------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for the Nem column to load.           
        }

        public void NavigateToETLValidationPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over ETL sub menu. 
            ETLMenuHover();

            //Click on Validation.
            driver.FindElement(By.XPath("//a[contains(@href,'ETLValidation/ETLValidation.aspx')]")).Click();


            //~VALIDATION PAGE:----------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Status']"))); //Waits for Status column to load.
        }
        public void NavigateToExternalModelsPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Models sub menu.
            ModelsMenuHover();

            //Click on External Models.
            driver.FindElement(By.XPath("//a[contains(@href,'/Models.aspx')]")).Click();


            //~EXTERNAL MODELS PAGE:-----------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='File Name']"))); //Waits for the File Name column to load.
        }
        public void NavigateToFundMappingPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Setup sub menu.
            SetupMenuHover();

            //Click on Fund Mapping.
            driver.FindElement(By.CssSelector("[href*='Inputs/FundMap.aspx']")).Click();


            //~FUND MAPPING PAGE:--------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for Name column to load.
        }
        public void NavigateToGridEnvironmentsPage()
        {
            //Hover over Administration menu.
            AdminMenuHover();

            //Hover over Grid sub menu.
            GridMenuHover();

            //Click on Grid Environments.
            driver.FindElement(By.XPath("//a[@href[contains(.,'GridEnvironments')]]")).Click();


            //~GRID ENVIRONEMNTS PAGE:---------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for Name column to load.
        }
        public void NavigateToGridHistoryPage()
        {
            //Hover over Runs menu.
            RunMenuHover();

            //Hover over Management sub menu. 
            ManagementMenuHover();

            //Click on Grid History.
            driver.FindElement(By.CssSelector("[href*='Jobs/JobGrid.aspx']")).Click();


            //~GRID HISTORY PAGE:--------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Schedule Name']"))); //Waits for Schedule Name column to load.
        }

        public void NavigateToHolidaysPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Setup sub menu. 
            SetupMenuHover();

            //Click on Holidays.
            driver.FindElement(By.CssSelector("[href*='Inputs/Holidays.aspx']")).Click();


            //~HOLIDAYS PAGE:------------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Month']"))); //Waits for the Month column to load.
        }
        public void NavigateToHomePage()
        {
            //Click on Home.
            driver.FindElement(By.CssSelector("[href*='/Default.aspx']")).Click();

            //~HOME PAGE:----------------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[text()[contains(.,'Welcome to the Milliman FRM MG-Hedge')]]"))); //Waits for home page to load.
        }
        public void NavigateToInforceStepsPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Setup sub menu.
            SetupMenuHover();

            //Click on Inforce Steps.
            driver.FindElement(By.CssSelector("[href*='Inputs/InforceSteps.aspx']")).Click();


            //~INFORCE STEPS PAGE:-------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Step']"))); //Waits for the Step column to load.
        }
        public void NavigateToLiabilityDataPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Balance Sheet sub menu.
            BalanceSheetMenuHover();

            //Click on Liability Data.
            driver.FindElement(By.CssSelector("[href*='Inputs/BalanceSheetStructure.aspx']")).Click();


            //~LIABILITY DATA PAGE:------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for the Name column to load.            
        }
        public void NavigateToLogsPage()
        {
            //Hover over Administration menu.
            AdminMenuHover();

            //Hover over Engine sub menu.
            EngineMenuHover();

            //Click on Grid Environments.
            driver.FindElement(By.XPath("//a[@href[contains(.,'LogFiles')]]")).Click();


            //~LOGS PAGE:----------------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//h3[text()='Log Files']"))); //Waits for the Log Files header to load.
        }

        public void NavigateToManageAssumptionDataPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Parameters sub menu.
            ParametersMenuHover();

            //Click on Manage Parameter Sets.
            driver.FindElement(By.XPath("//*[contains(@href, 'AssumptionManager/AssumptionData.aspx')]")).Click();


            //~MANAGE ASSUMPTION DATA PAGE:----------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for the Nem column to load.           
        }
        public void NavigateToManageEnginePage()
        {
            //Hover over Administration menu.
            AdminMenuHover();

            //Hover over Engine sub menu.
            EngineMenuHover();

            //Click on Manage Engine.
            driver.FindElement(By.XPath("//span[text()='Manage Engine']")).Click();
            Task.Delay(waitDelayMega).Wait();


            //~MANAGE ENGINE PAGE:-------------------------------------------------------------------------------------------------------------------------------------------
            if (targetChameleon == 1)
            {
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Engine:']"))); //Waits for Engine title to load.
            }
            else
            {
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Control Panel']"))); //Waits for Control Panel column to load.
            }
        }
        public void NavigateToManageParameterSetsPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Parameters sub menu.
            ParametersMenuHover();

            //Click on Manage Parameter Sets.
            driver.FindElement(By.XPath("//a[contains(@href, 'Parameters/ParameterSets.aspx')]")).Click();


            //~MANAGE PARAMETER SETS PAGE:-----------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for the Name column to load.
        }
        public void NavigateToNamespacesPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Configuration sub menu.
            ConfigInputMenuHover();

            //Click on Namespaces.
            driver.FindElement(By.CssSelector("[href*='Inputs/Versions.aspx']")).Click();


            //~NAMESPACES PAGE:------------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for the Name column to load.
        }
        public void NavigateToNotificationGroupsPage()
        {
            //Hover over Runs menu.
            RunMenuHover();

            //Hover over Configuration sub menu. 
            ConfigRunMenuHover();

            //Click on Notification Groups.
            driver.FindElement(By.CssSelector("[href*='Jobs/Notifications.aspx']")).Click();


            //~NOTIFICATION GROUPS PAGE:-------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for Name column to load.
        }

        public void NavigateToOutputDashboard()
        {
            //Hover over the Run menu.
            RunMenuHover();

            //Hover over the Management sub menu.
            ManagementMenuHover();

            if (targetChameleon == 1)
            {
                //>This accounts for the extremely slow page load time, unrelaible variations of element visibility, and randomness of LOADING wheel element overlap
                waitDelayCustom = 6000;

                //Navigate to Output Dashboard.
                driver.FindElement(By.XPath("//a[@href[contains(.,'/Reports')]]")).Click();
                Task.Delay(waitDelayCustom).Wait();

                //~OUTPUT DASHBOARD PAGE:----------------------------------------------------------------------------------------------------------------------------------------
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Upload Ad hoc Report']"))); //Waits for the upload adhoc report button to load.
            }
            else
            {
                //Click on Output.
                driver.FindElement(By.CssSelector("[href*='Jobs/Dashboard.aspx']")).Click();

                //~OUTPUT DASHBOARD PAGE:----------------------------------------------------------------------------------------------------------------------------------------
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Search']"))); //Waits for the Search button to load.
            }
        }
        public void NavigateToProductsPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Setup sub menu.
            SetupMenuHover();

            //Click on Products.
            driver.FindElement(By.CssSelector("[href*='Inputs/Products.aspx']")).Click();


            //~PRODUCTS PAGE:------------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for the Name column to load.
        }
        public void NavigateToResultsProcessorsPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Models sub menu.
            ModelsMenuHover();

            //Click on Results Processors.
            driver.FindElement(By.CssSelector("[href*='Inputs/ResultsProcessing/ResultsProcessor.aspx']")).Click();


            //~RESULTS PROCESSORS PAGE:--------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for the Name column to load.
        }
        public void NavigateToResultsProfilesPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            var siteVer = driver.FindElements(By.XPath("//span[text()[contains(.,'Version 2.9.1')]]"));

            if (siteVer.Any())
            {
                //Hover over Setup sub menu.
                SetupMenuHover();

                //Click on Results Profiles.
                driver.FindElement(By.XPath("//span[text()='Results Profiles']")).Click();
            }
            else
            {
                //Hover over Results sub menu.
                ResultsMenuHover();

                //Click on Results Profiles.
                driver.FindElement(By.XPath("//span[text()='Manage Results Profiles']")).Click();
            }

            //~RESULTS PROFILES PAGE:----------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for the Source column to load.
        }
        public void NavigateToRiskTaxonomyPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Setup sub menu.
            SetupMenuHover();

            //Click on Risk Taxonomy.
            driver.FindElement(By.CssSelector("[href*='Inputs/RiskTaxonomy.aspx']")).Click();


            //~RISK TAXONOMY PAGE:-------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Source']"))); //Waits for the Source column to load.
        }

        public void NavigateToRoleToGroupMappingPage()
        {
            //Hover over Administration menu.
            AdminMenuHover();

            //Hover over Security sub menu.
            SecurityMenuHover();

            //Click on Securable Access By Role.
            driver.FindElement(By.CssSelector("[href*='Administration/RoleMapping.aspx']")).Click();


            //~ROLE TO GROUP MAPPING PAGE:-----------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for Name column to load.
        }
        public void NavigateToRunGroupLocksPage()
        {
            //Hover over Runs menu.
            RunMenuHover();

            //Hover over Configuration sub menu. 
            ConfigRunMenuHover();

            //Click on Run Group Locks.
            driver.FindElement(By.CssSelector("[href*='Jobs/RunGroupLocks.aspx']")).Click();


            //~RUN GROUP LOCKS PAGE:-----------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Group Name']"))); //Waits for the Group Name column to load.
        }
        public void NavigateToRunHistoryPage()
        {
            //Hover over Runs menu.
            RunMenuHover();

            //Hover over Management sub menu. 
            ManagementMenuHover();

            //Click on Run History.
            driver.FindElement(By.CssSelector("[href*='Jobs/JobQueue.aspx']")).Click();


            //~RUN HISTORY PAGE:---------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Schedule Name']"))); //Waits for Schedule Name column to load.
        }
        public void NavigateToRunListPage()
        {
            //Hover over Runs menu.
            RunMenuHover();

            //Hover over Configuration sub menu. 
            ConfigRunMenuHover();

            //Click on Run List.
            driver.FindElement(By.CssSelector("[href*='Jobs/JobList.aspx']")).Click();


            //~RUN LIST PAGE:------------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Group Name']"))); //Waits for the Group Name column to load.
        }
        public void NavigateToRunSchedulesPage()
        {
            //Hover over Runs menu.
            RunMenuHover();

            //Hover over Configuration sub menu. 
            ConfigRunMenuHover();

            //Click on Schedules.
            driver.FindElement(By.CssSelector("[href*='Schedules']")).Click();


            //~RUN SCHEDULES PAGE:-------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Schedule Name (A-Z)']"))); //Waits for Schedules Name sort button to load.
        }

        public void NavigateToScenariosPage()
        {
            //Hover over Risk Framework menu.
            RiskFrameworkMenuHover();

            //Click on Scenarios.
            driver.FindElement(By.CssSelector("[href*='MarketData/Scenarios.aspx']")).Click();


            //~SCENARIOS PAGE:-----------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for the Name column to load.
        }
        public void NavigateToSecurableAccessByRolePage()
        {
            //Hover over Administration menu.
            AdminMenuHover();

            //Hover over Security sub menu.
            SecurityMenuHover();

            //Click on Securable Access By Role.
            driver.FindElement(By.XPath("//span[text()='Securable Access by Role']")).Click();


            //~SECURABLE ACCESS BY ROLE PAGE:--------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Name']"))); //Waits for the Name column to load.
        }
        public void NavigateToSettingsPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Configuration sub menu.
            ConfigInputMenuHover();

            //Click on Settings.
            driver.FindElement(By.CssSelector("[href*='Inputs/Settings.aspx']")).Click();


            //~SETTINGS PAGE:------------------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//td[text()='Setting']"))); //Waits for the Setting column to load.
        }
        public void NavigateToShockDefinitionsPage()
        {
            //Hover over Input and Assumptions menu.
            InputAndAssumptionsMenuHover();

            //Hover over Setup sub menu.
            SetupMenuHover();

            //Click on Shock Definitions.
            driver.FindElement(By.CssSelector("[href*='Inputs/Shocks.aspx']")).Click();


            //~SHOCK DEFINITIONS PAGE:---------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Download']"))); //Waits for Download button to load.
        }
        public void NavigateToStatusDashboardPage()
        {
            //Hover over Runs menu.
            RunMenuHover();

            //Hover over Management sub menu. 
            ManagementMenuHover();

            //Click on Status.
            driver.FindElement(By.CssSelector("[href*='Jobs/JobStatus.aspx']")).Click();


            //~STATUS DASHBOARD PAGE:----------------------------------------------------------------------------------------------------------------------------------------
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Refresh']"))); //Waits for Refresh button to load.
        }
        #endregion
        //UI INTERACTIONS-------------------------------------------------------------------------------------------------------------<>

        //GRIDSTEP INTERACTIONS-------------------------------------------------------------------------------------------------------<>
        #region GridStep Miscellaneous
        //public static int jobID = 808;

        public static string BaseUrl = "https://";
        public static string RequestUrl = "/C2/servlet/C2Request";
        public static string GridUser, GridPassword;
        public static string Machine = "grid-temp-2019b";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        #endregion
        //GRIDSTEP INTERACTIONS-------------------------------------------------------------------------------------------------------<>
    }

    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }

    public static class WebElementAsserts
    {
        public static bool VerifyAsserts(this IWebDriver driver, By by)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(50);
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}