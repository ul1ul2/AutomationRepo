using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Diagnostics;
using System.Xml;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;
using Keys = OpenQA.Selenium.Keys;
using UICMain = Automation.UI_Craqen_Main;
using UIDMain = Automation.UI_Decernis_Main;
using System.Security.Cryptography;
using NUnit.Framework;

namespace Automation
{
    public class BaseProjectSettings
    {
        //~║·AUTOMATION CONTROL CENTER·╠═══════════════════════════════════════════════════════════════════════════════════════════════╗
        //!Who will be running automated tests?
        public static string userName = "John McDonnell"; //>Defines the name of a user which will be referenced in relevant tests
        public static string userAccount = "johmcd06"; //>Defines the account of a user which will be referenced in relevant tests

        //!What is the email address to use?
        public static string emailAddress = "john.mcdonnell.c@foodchainid.com";

        //!Are you targeting DECERNIS (0), CRAQEN (1), or TESTDEMO (2)?
        public static int targetTestingLocation = 0; //>Set to 0, 1, or 2
        //~║·AUTOMATION CONTROL CENTER·╠═══════════════════════════════════════════════════════════════════════════════════════════════╝

        //GLOBAL PROJECT ITEMS--------------------------------------------------------------------------------------------------------<>
        #region Global Bools
        public bool condition = true;

        public static bool AreFileContentsEqual(String path1, String path2) =>
              File.ReadAllBytes(path1).SequenceEqual(File.ReadAllBytes(path2));
        #endregion

        #region Global Integers
        public static int timeoutWait = 35;
        public static int waitDelay1 = 100;
        public static int waitDelay2 = 200;
        public static int waitDelay5 = 500;
        public static int waitDelay10 = 1000;
        public static int waitDelay20 = 2000;
        public static int waitDelayLong = 10000;
        #endregion

        #region Global Strings

        public static string nullValue = null;
        public static string UserName()
        {
            userName = userName.Replace(" ", ".");
            return userName = userName.ToLower();
        }
        public static string userNameFull = userName;
        public static string userNameFirst = userName.Split(' ')[0];
        public static string userNameLast = userName.Split(' ')[0];
        public static string downloadDirectory = string.Format(@"C:\Users\{0}\Downloads\", userAccount);
        //public static string downloadFile1 = string.Format(@"{0}"+"{1}", downloadDirectory, file1);
        //public static string downloadFile2 = string.Format(@"{0}{1}", downloadDirectory, file2);    

        public static string targetUserName;
        #endregion
        //GLOBAL PROJECT ITEMS--------------------------------------------------------------------------------------------------------<>

        //SETUP & TEARDOWN METHODS----------------------------------------------------------------------------------------------------<>
        #region Nunit Test Setup/Teardown
        public static IWebDriver driver;
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
            //driver.Manage().Window.Size = new Size(1740, 1040);
            //Maximize window.
            driver.Manage().Window.Maximize();

            if (targetTestingLocation == 2)
            {
                driver.Url = "https://www.timeanddate.com/worldclock/timezone/utc";
            }
            if (targetTestingLocation == 1)
            {
                driver.Url = "https://craqen-ui-development.azurewebsites.net";
            }
            else
            {
                driver.Url = "https://staging-auth2.decernis.com/";
            }
        }
        public void CloseDown()
        {
            //Close session.
            driver.Quit();

            ////This here switches driver focus to first browser tab.
            //driver.SwitchTo().Window(driver.WindowHandles.First());

            ////Close session.
            //driver.Close();
        }
        #endregion
        //SETUP & TEARDOWN METHODS----------------------------------------------------------------------------------------------------<>

        //~║·AUTOMATION CORE TESTING·╠═════════════════════════════════════════════════════════════════════════════════════════════════╗

        //--LOGINS------------------------------------------------------------------------------------------------------oo
        #region Login Tests
        public string hedgeNamespace = "Working Version";
        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        public void ActiveLogin()
        {
            if (targetTestingLocation == 1)
            {
                //Sign into CRAQEN Dashboard.
                CraqenActiveLogin();
            }            
            else
            {
                //Sign into Decernis Dashboard and click gComplyPlus.
                gComplyPlusActiveLogin();
            }
        }
        public void CraqenActiveLogin()
        {
            //Sign into CRAQEN Dashboard.
            DecernisActiveLogin();
            UICMain.WaitForCraqenDashboard();
        }
        public void DecernisActiveLogin()
        {
            //Sign into Decernis Dashboard.
            UIDMain.NavigateDecernisSSO(emailAddress);
        }
        public void gComplyActiveLogin()
        {
            //Sign into Decernis Dashboard and click gComply.
            DecernisActiveLogin();
            UIDMain.ClickGComplyLink();
        }
        public void gComplyPlusActiveLogin()
        {
            //Sign into Decernis Dashboard and click gComplyPlus.
            DecernisActiveLogin();
            UIDMain.ClickGComplyPlusLink();
        }
        #endregion
        //--LOGINS------------------------------------------------------------------------------------------------------oo

        //~║·AUTOMATION CORE TESTING·╠═════════════════════════════════════════════════════════════════════════════════════════════════╝

        //UI INTERACTIONS-------------------------------------------------------------------------------------------------------------<>
        #region UI Navigation/Interactions
        public static Stopwatch timer = new Stopwatch();

        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
        public static void HitEscKey()
        {
            //Hit the Esc key.
            SendKeys.SendWait(@"{Esc}");
            Task.Delay(waitDelay5).Wait();
        }
        public static void HitHomeKey()
        {
            //Hit the Esc key.
            SendKeys.SendWait(@"{Home}");
        }
        public static void HitDownKey()
        {
            //Hit the Down key.
            Actions action = new Actions(driver);
            action.SendKeys(Keys.ArrowDown).Perform();
            Task.Delay(waitDelay5).Wait();
        }
        public static void RepeatAction(int repeatCount, Action action)
        {
            for (int i = 0; i < repeatCount; i++)
                action();
        }
        public static void ScrollToElement(string elementPath)
        {
            var element = driver.FindElement(By.XPath(string.Format(elementPath)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            //actions.Perform();
        }
        #endregion

        #region Misc
        public static void MD5FileCompare(string file1, string file2)
        {
            //Convert file to FileInfo.
            var sourceFile1 = Path.Combine(downloadDirectory, file1);
            FileInfo downloadFile1 = new FileInfo(sourceFile1);

            var sourceFile2 = Path.Combine(downloadDirectory, file2);
            FileInfo downloadFile2 = new FileInfo(sourceFile2);

            try
            {
                //Compare files.
                Assert.IsTrue(FileMD5AreSame(downloadFile1, downloadFile2));
            }
            catch(Exception)
            {
                Assert.Fail(string.Format("Unexpected Result: The MD5 checksum comparison for {0} and {1} are NOT equal.", file1, file2));
            }
        }
        public static bool FileMD5AreSame(FileInfo file1, FileInfo file2)
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
        #endregion
        //UI INTERACTIONS-------------------------------------------------------------------------------------------------------------<>
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