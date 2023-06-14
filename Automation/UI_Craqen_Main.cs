using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing.Imaging;

namespace Automation
{
    public class UI_Craqen_Main : BaseProjectSettings
    {


        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        //Webelements
        private static IWebElement craqenCaptureMenu => driver.FindElement(By.XPath("//span[text()='Capture']"));
        private static IWebElement craqenResearchMenu => driver.FindElement(By.XPath("//span[text()='Research']"));
        private static IWebElement craqenLinkingMenu => driver.FindElement(By.XPath("//span[text()='Linking']"));
        private static IWebElement craqenDashboardMenu => driver.FindElement(By.XPath("//span[text()='Dashboard']"));
        private static IWebElement craqenAssignmentsMenu => driver.FindElement(By.XPath("//span[text()='My Assignments']"));
        private static IWebElement craqenDocumentsMenu => driver.FindElement(By.XPath("//span[text()='Documents']"));
        private static IWebElement craqengComplyFilesMenu => driver.FindElement(By.XPath("//span[text()='gComply Files']"));



        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        //Minor Methods
        public static void ClickCaptureButton()
        {
            craqenCaptureMenu.Click();
        }
        public static void ClickResearchButton()
        {
            craqenResearchMenu.Click();
        }
        public static void ClickLinkingButton()
        {
            craqenLinkingMenu.Click();
        }
        public static void ClickDashboardButton()
        {
            craqenDashboardMenu.Click();
        }
        public static void ClickMyAssignmentsButton()
        {
            craqenAssignmentsMenu.Click();
        }
        public static void ClickDocumentsButton()
        {
            craqenDocumentsMenu.Click();
        }
        public static void ClickgComplyFilesButton()
        {
            craqengComplyFilesMenu.Click();
        }
        public static void NavigateToDashboardPage()
        {
            ClickCaptureButton();
            ClickDashboardButton();
        }
        public static void NavigateToMyAssignmentsPage()
        {
            ClickCaptureButton();
            ClickMyAssignmentsButton();
        }
        public static void NavigateToDocumentsPage()
        {
            ClickResearchButton();
            ClickDocumentsButton();
        }
        public static void NavigateTogCompleyFilesPage()
        {
            ClickResearchButton();
            ClickgComplyFilesButton();
        }
        public static void WaitForCraqenDashboard()
        {
            //Restart stopwatch.
            timer.Restart();

            //Check for appearance of menu.
            while (timer.Elapsed.TotalSeconds < waitDelayLong && timer.IsRunning.Equals(true))
            {
                var menu = driver.FindElements(By.XPath("//span[text()='Capture']"));

                if (menu.Any())
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }
        }

        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        //Major Methods
        //public static void NavigateCraqenSSO(string username)
        //{
        //    //Enter username, password, and sign in.
        //    NavigateCraqenSSOUsername(username);
        //    NavigateCraqenSSOAccountPick();
        //}
    }
}