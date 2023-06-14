//using JMSeleniumExcercise.CommonObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using UIDMain = Automation.UI_Decernis_Main;

namespace Automation.Tests
{
    [TestFixture]
    public class Challenges : BaseProjectSettings
    {
        //>║·SYNOPSIS·╠═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════─
        //Click_Button: A dummy test to verify that a button on a sample website can be clicked.
        //Access_Craqen_Dashboard: A test to verify that a user can sign into CRAQEN and access the dashboard.
        //Access_Decernis_Dashboard: A test to verify that a user can sign into Decernis and access the dashboard.
        //Access_gComply_Dashboard: A test to verify that a user can sign into Decernis and access the gComply dashboard.
        //Access_gComplyPlus_Dashboard: A test to verify that a user can sign into Decernis and access the gComply Plus dashboard.
        //gComplyPlus_Country_Name_Matches_Citation_Name: A test to verify that an Analysis can performed and viewed in matrix and tabular view.
        //gComplyPlus_Landscape_Analysis_Threshold_Values_Correct: A test to verify that regulation threshold values are accurate.
        //gComplyPlus_Berry_Fruit_Filling_USA_Permitted: A test to verify that berry fruit fillings in the USA are permitted
        //>║·SYNOPSIS·╠═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════─

        #region SetUp & TearDown
        [SetUp]
        public void Initialize()
        {
            //Start session.
            StartUp();
        }

        [TearDown]
        public void Dismantle()
        {
            //End session.
            CloseDown();
        }
        #endregion
        
        [Test]//!Ready---
        public void Click_Button()
        {
            //Access Site.
            UIDMain.ClickTimeZoneButton();

            //Validate direction to time zone page.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//h1[text()[contains(.,'Time Zone in UTC')]]")));
        }

        [Test]//!Ready---
        public void Access_Craqen_Dashboard()
        {
            //Access Site.
            CraqenActiveLogin();

            //Validate access to CRAQEN dashboard.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()='Capture']")));
        }

        [Test]//!Ready---
        public void Access_Decernis_Dashboard()
        {
            //Access Site.
            DecernisActiveLogin();

            //Validate access to Dcernis dashboard.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//div[@class='fd_chn_wrap']")));
        }

        [Test]//!Ready---
        public void Access_gComply_Dashboard()
        {
            //Access Site.
            gComplyActiveLogin();

            //Validate access to gComply dashboard.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()=' Upload Search Terms ']")));
        }

        [Test]//!Ready---
        public void Access_gComplyPlus_Dashboard()
        {
            //Access Site.
            gComplyPlusActiveLogin();

            //Validate access to gComply dashboard.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()='Module']")));
        }

        [Test]//>Ready---
        public void gComplyPlus_Country_Name_Matches_Citation_Name() //~ID 47646
        {
            //Access Site.
            gComplyPlusActiveLogin();

            //Validate fields in Search Parameters view. (high level to ensure the view is open)
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()='Module']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//mat-label[text()='Usage']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//mat-label[text()='Function']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//gcplus-theme-countries-select[@id='landscape-country']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//mat-label[text()='Recipe']")));

            //Validate that Usage field, Function field, and Run Analysis button are disabled at this point.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//div[mat-select[@aria-disabled='true']]//mat-label[text()='Usage']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//div[mat-select[@aria-disabled='true']]//mat-label[text()='Function']")));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//button[@disabled='true']//span[text()[contains(.,'Run analysis')]]")));

            //Perform a Landscape search. (module, country, usage, function, recipe)
            UIDMain.PerformLandscapeSearch(UIDMain.moduleFoodAdditives, UIDMain.countryUSA, UIDMain.usageColors, UIDMain.functionAnticaking);

            //Validate that each usage option is available in the Useage and Function dropdowns.
            UIDMain.AssertUsageOptions();
            UIDMain.AssertFunctionOptions();

            //Collapse Search Parameters and click Tabular button.
            UIDMain.CollapseSearchParametersAndClickTabularButton();

            //Validate that the correct Function, Usage, Country, and Citation are present.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//span[text()[contains(.,'{0}')]]", UIDMain.function))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//span[text()[contains(.,'{0}')]]", UIDMain.usage))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", UIDMain.country))));
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//a[text()[contains(.,'{0}')]]", UIDMain.module))));

            //Scroll to Comment Filter
            //RepeatAction(9, HitDownKey); //This is ugly. Avoid use if possible.

            //Enter a Comment Filter.
            UIDMain.EnterCommentFilter();
            //>---add assertion here (find out what needs validating)

            //Clear the Comment Filter.
            UIDMain.ClearCommentFilter();

            //Enter a tabular Country search.
            UIDMain.EnterTabularCountrySearch(UIDMain.countryUSA);

            //Validate correct returned records.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", UIDMain.country))));

            //Access the citiation document file.
            UIDMain.AccessCitationDocument(); 
            //>for whatever reason, the file does not open when running automation because the initial reference URL is not being redirected to the file url.
            //>this is peculiar because the file DOES open correctly outside of automation. as a result, the automation failure at this part is currently a false positive.

            //Validate presence of citation text.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//span[text()[contains(.,'tit')]]"))); //yes, this is hilarious but its atually the way some documents present the word 'title' broken into two parts.
        }

        [Test]//!Ready---
        public void gComplyPlus_Landscape_Analysis_Threshold_Values_Correct() //~ID 47650
        {
            //Access Site.
            gComplyPlusActiveLogin();

            //Perform a Landscape search. (module, country, usage, function, recipe)
            UIDMain.PerformLandscapeSearch(UIDMain.moduleFoodAdditives, UIDMain.countryYemen, UIDMain.usageColors, nullValue);

            ScrollToElement("//span[text()[contains(.,'Prohibited')]]");
            RepeatAction(3, HitDownKey); //This is ugly. Avoid use if possible. Its here because scroll does not move down far enough to clear bottom landscape action bar.

            //Click regulation cell.
            UIDMain.ClickMatrixCountryRegulationProhibited();

            //Validate correct Threshold value.
            //>This assertion will fail due to a known bug.
            Assert.IsFalse(driver.VerifyAsserts(By.XPath("//tr[td[div[text()[contains(.,'Prohibited')]]]]//div[text()[contains(.,'0 - 0')]]")));

            //Close popup.
            UIDMain.ClickMatrixPopupCloseButton();
            HitHomeKey();

            //Click regulation cell.
            UIDMain.ClickMatrixCountryRegulationPermitted();

            //Validate correct Threshold value.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[div[text()[contains(.,'Permitted')]]]]//td[@class[contains(.,'threshold')]]//div[text()[not(contains(.,'0'))]]")));

            //Close popup.
            UIDMain.ClickMatrixPopupCloseButton();

            ScrollToElement("//span[text()[not(contains(.,'-Restricted'))]and text()[contains(.,'Restricted')]]");
            RepeatAction(3, HitDownKey); //This is ugly. Avoid use if possible. Its here because scroll does not move down far enough to clear bottom landscape action bar.

            //Click regulation cell.
            UIDMain.ClickMatrixCountryRegulationRestricted();

            //Validate correct Threshold value.
            Assert.IsTrue(driver.VerifyAsserts(By.XPath("//tr[td[div[text()[contains(.,'Restricted')]]]]//div[text()[(contains(.,'<='))]]")));
        }

        [Test]//!Ready---
        public void gComplyPlus_Berry_Fruit_Filling_USA_Permitted() //~ID 47651
        {
            //Access Site.
            gComplyPlusActiveLogin();

            //Navigate to Analysis page.
            UIDMain.ClickAnalysisNavButton();

            //Perform an Analysis search. (module, country, recipe, usage)
            UIDMain.PerformAnalysisSearch(UIDMain.moduleFoodAdditives, UIDMain.countryUSA, UIDMain.recipeBerryFilling, UIDMain.usageFlavorings);

            #region Assert
            var element1 = driver.FindElement(By.XPath("(//div[@class='ng-star-inserted'])[2]")).Text;
            string text1 = element1.ToString();
            var element2 = driver.FindElement(By.XPath("(//div[@class='ng-star-inserted'])[3]")).Text;
            string text2 = element2.ToString();
            var element3 = driver.FindElement(By.XPath("(//div[@class='ng-star-inserted'])[4]")).Text;
            string text3 = element3.ToString();
            var element4 = driver.FindElement(By.XPath("(//div[@class='ng-star-inserted'])[5]")).Text;
            string text4 = element4.ToString();
            var element5 = driver.FindElement(By.XPath("(//div[@class='ng-star-inserted'])[6]")).Text;
            string text5 = element5.ToString();
            var element6 = driver.FindElement(By.XPath("(//div[@class='ng-star-inserted'])[7]")).Text;
            string text6 = element6.ToString();
            var element7 = driver.FindElement(By.XPath("(//div[@class='ng-star-inserted'])[8]")).Text;
            string text7 = element7.ToString();
            var element8 = driver.FindElement(By.XPath("(//div[@class='ng-star-inserted'])[9]")).Text;
            string text8 = element8.ToString();
            var element9 = driver.FindElement(By.XPath("(//div[@class='ng-star-inserted'])[10]")).Text;
            string text9 = element9.ToString();
            var element10 = driver.FindElement(By.XPath("(//div[@class='ng-star-inserted'])[11]")).Text;
            string text10 = element10.ToString();
            var element11 = driver.FindElement(By.XPath("(//div[@class='ng-star-inserted'])[12]")).Text;
            string text11 = element11.ToString();

            //Create a list of Usage option categories.
            List<string> matrixIngrediants = new List<string>
            {
                #region Variable List                
                 text1, text2, text3, text4, text5, text6, text7, text8, text9, text10, text11
                #endregion
            };

            foreach (string ingrediant in matrixIngrediants)
            {
                try
                {
                    //Validate that each ingrediant is permitted.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tbody[tr[td[div[text()[contains(.,'{0}')]]]]]//span[text()[contains(.,'Permitted')] or text()[contains(.,'PERMITTED')]]", ingrediant))));
                }
                catch (Exception)
                {
                    Assert.Fail(string.Format("Unexpected Result: The ingrediant '{0}' is not listed as permitted in Matrix view.", ingrediant));
                }
            }
            #endregion

            //Click Tabular button
            UIDMain.ClickTabularButton();

            //>Assertion for ingredient citation will fail due to 'Mixed Berry Fruit Puree' missing a citation in Tabular view. Currently unknown if this is an issue or intended.
            #region Assert
            var element01 = driver.FindElement(By.XPath("(//td[@class[contains(.,'-ingredient')]])[1]")).Text;
            string text01 = element01.ToString();
            var element02 = driver.FindElement(By.XPath("(//td[@class[contains(.,'-ingredient')]])[2]")).Text;
            string text02 = element02.ToString();
            var element03 = driver.FindElement(By.XPath("(//td[@class[contains(.,'-ingredient')]])[3]")).Text;
            string text03 = element03.ToString();
            var element04 = driver.FindElement(By.XPath("(//td[@class[contains(.,'-ingredient')]])[4]")).Text;
            string text04 = element04.ToString();
            var element05 = driver.FindElement(By.XPath("(//td[@class[contains(.,'-ingredient')]])[5]")).Text;
            string text05 = element05.ToString();
            var element06 = driver.FindElement(By.XPath("(//td[@class[contains(.,'-ingredient')]])[6]")).Text;
            string text06 = element06.ToString();
            var element07 = driver.FindElement(By.XPath("(//td[@class[contains(.,'-ingredient')]])[7]")).Text;
            string text07 = element07.ToString();
            var element08 = driver.FindElement(By.XPath("(//td[@class[contains(.,'-ingredient')]])[8]")).Text;
            string text08 = element08.ToString();
            var element09 = driver.FindElement(By.XPath("(//td[@class[contains(.,'-ingredient')]])[9]")).Text;
            string text09 = element09.ToString();
            var element010 = driver.FindElement(By.XPath("(//td[@class[contains(.,'-ingredient')]])[10]")).Text;
            string text010 = element010.ToString();
            var element011 = driver.FindElement(By.XPath("(//td[@class[contains(.,'-ingredient')]])[11]")).Text;
            string text011 = element011.ToString();

            //Create a list of Usage option categories.
            List<string> tabularIngrediants = new List<string>
            {
                #region Variable List                
                 text01, text02, text03, text04, text05, text06, text07, text08, text09, text010, text011
                #endregion
            };

            foreach (string ingrediant in tabularIngrediants)
            {
                try
                {
                    //Validate that each ingrediant is permitted.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()[contains(.,'{0}')]]]//div[text()[contains(.,'Permitted')] or text()[contains(.,'PERMITTED')]]", ingrediant))));

                }
                catch (Exception)
                {
                    Assert.Fail(string.Format("Unexpected Result: The ingrediant '{0}' is not listed as permitted in Tabular view.", ingrediant));
                }
                try
                {
                    //Validate that each ingrediant citation is present.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//tr[td[text()[contains(.,'{0}')]]]//a[@href[contains(.,'https://')]]", ingrediant))));

                }
                catch (Exception)
                {
                    Assert.Fail(string.Format("Unexpected Result: The ingrediant '{0}' is missing a citation in Tabular view.", ingrediant));
                }
            }
            #endregion

        }

        [Test]//>WIP---
        public void gComplyPlus_Citation_Dates_Recipe_Analysis_Consistency() //~ID 47649
        {
            //Access Site.
            gComplyPlusActiveLogin();

            //Navigate to Analysis page.
            UIDMain.ClickAnalysisNavButton();

            //Configure an Analysis search. (module, country, recipe, usage)
            UIDMain.ConfigureAnalysisSearch(UIDMain.moduleFoodAdditives, UIDMain.countryAfrica, UIDMain.recipeAlluraRed, UIDMain.usageAntioxidants);

            //Validate correct regional countries.
            UIDMain.AssertCountryRegionAfrica();

            //Click Run Analysis button.
            UIDMain.ClickRunAnalysisButton();

            //Verify presence of warning message popup.
            UIDMain.AssertCountryOverloadWarning();

            //Close warning message.
            UIDMain.ClickMatrixPopupCloseButton();

            //>--step9 -----add rest of test
        }
    }
}