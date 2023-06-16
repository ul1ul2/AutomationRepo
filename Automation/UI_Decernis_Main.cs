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
using Google.Protobuf.WellKnownTypes;

namespace Automation
{
    public class UI_Decernis_Main : BaseProjectSettings
    {
        public static string decernisUser = "gc-active";
        public static string decernisPassword = "D3c3rn!s";
        public static string companyDecernis = "Decernis";
        public static string moduleFoodAdditives = "Food Additives";
        public static string usageAntioxidants = "Antioxidants";
        public static string usageColors = "Colors";
        public static string usageFlavorings = "Flavorings";
        public static string functionAnticaking = "Anticaking Agent";
        public static string functionAntioxidant = "Antioxidant";
        public static string countryAfrica = "Africa";
        public static string countryUSA = "United States";
        public static string countryKorea = "Korea";
        public static string countryYemen = "Yemen";
        public static string recipeDrink = "Test 2 Canada Energy Drink Peach";
        public static string recipeBerryFilling = "Berry Fruit Filling - test recipe ta";
        public static string recipeAlluraRed = "allura red colors - test4";
        public static string gComplyPlusLandscapeFileXLS1 = "landscape_31-05-2023--15-59-00.xlsx";
        public static string gComplyPlusLandscapeFileXLS1Copy = "landscape_31-05-2023--15-59-001.xlsx";
        public static string gComplyPlusLandscapeFileXLS2 = "landscape_31-05-2023--15-52-08.xlsx";
        public static string gComplyPlusLandscapeFilePDF1 = "landscape_05-06-2023--19-54-52.pdf";

        public static string company, country, function, module, recipe, regulation, text, usage;

        #region old strings
        //public static string accountCity = "Fun Town";
        //public static string accountZipCode = "123456";
        //public static string accountPhoneNumber = "7778889999";
        //public static string accountBusinessPhoneNumber = "4445556666";
        //public static string accountBusinessExt = "2";
        //public static string accountCompanyName = "Fun Company Inc.";
        //public static string accountJobTitle = "Master of Puppets";
        //public static string accountJobRoleOther = "Puppeteer";
        //public static string accountPassword = "Password123@";
        #endregion

        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        //Webelements
        public static IWebElement decernisUsernameField => driver.FindElement(By.XPath("//input[@id='id_username']"));
        public static IWebElement decernisPasswordField => driver.FindElement(By.XPath("//input[@id='id_password']"));
        public static IWebElement decernisSigninWithSSOButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        public static IWebElement decernisSigninWithPasswordButton => driver.FindElement(By.XPath("//button[text()[contains(.,'Sign in with Password')]]"));
        public static IWebElement decernisSigninAccountPick => driver.FindElement(By.XPath(string.Format("//small[text()='{0}']", emailAddress)));
        public static IWebElement decernisCompanyName => driver.FindElement(By.XPath("//input[@name='company']"));
        public static IWebElement decernisSignInCompanyNameButton => driver.FindElement(By.XPath("//button[@data-id='id_company']"));
        public static IWebElement decernisSignInCompanyName => driver.FindElement(By.XPath(string.Format("//span[text()[contains(.,'{0}')]]", company)));
        public static IWebElement decernisWrapper => driver.FindElement(By.XPath("//div[@class='fd_chn_wrap']"));
        public static IWebElement gcomplyURL => driver.FindElement(By.CssSelector("[href*='gcomply.decernis.com']"));
        public static IWebElement gcomplyPlusURL => driver.FindElement(By.CssSelector("[href*='formula.decernis.com']"));
        public static IWebElement gcomplyUploadSearchTermsButton => driver.FindElement(By.XPath("//span[text()=' Upload Search Terms ']"));
        public static IWebElement gcomplyPlusModuleField => driver.FindElement(By.XPath("//span[text()='Module']"));
        public static IWebElement gcomplyPlusUsageField => driver.FindElement(By.XPath("//div[span[label[mat-label[text()='Usage']]]]//div[@class[contains(.,'arrow-wrapper')]]"));
        public static IWebElement gcomplyPlusFunctionField => driver.FindElement(By.XPath("//div[span[label[mat-label[text()='Function']]]]//div[@class[contains(.,'arrow-wrapper')]]"));
        public static IWebElement gcomplyPlusCountriesField => driver.FindElement(By.XPath("//input[@placeholder='Select country']"));
        public static IWebElement gcomplyPlusRecipeField => driver.FindElement(By.XPath("//div[span[label[mat-label[text()='Recipe']]]]//span[@class[contains(.,'mat-select')]]"));
        public static IWebElement gcomplyPlusModuleFoodAdditives => driver.FindElement(By.XPath("//span[text()[contains(.,'Food Additives')]]"));
        public static IWebElement gcomplyPlusSpanDynamic => driver.FindElement(By.XPath(string.Format("//span[text()[contains(.,'{0}')]]", text)));
        public static IWebElement gcomplyPlusLabelDynamic => driver.FindElement(By.XPath(string.Format("//mat-label[text()[contains(.,'{0}')]]", text)));
        public static IWebElement gcomplyPlusUsageSearchField => driver.FindElement(By.XPath("//input[@data-placeholder='Type to search']"));
        public static IWebElement gcomplyPlusRunAnalysisButton => driver.FindElement(By.XPath("//div[button[span[text()[contains(.,'Run analysis')]]]]//button[@color='primary']"));
        public static IWebElement gcomplyPlusRunEvaluateButton => driver.FindElement(By.XPath("//div[button[span[text()[contains(.,'Run evaluate')]]]]//button[@class[contains(.,'-stroked')]]"));
        public static IWebElement gcomplyPlusIngredientTableMaxrixRow => driver.FindElement(By.XPath("//td[@class[contains(.,'-ingredient')]]"));
        public static IWebElement gcomplyPlusSearchParametersHeader => driver.FindElement(By.XPath("//span[text()='Search parameters']"));
        public static IWebElement gcomplyPlusMatrixButton => driver.FindElement(By.XPath("//mat-button-toggle[@value='matrix']"));
        public static IWebElement gcomplyPlusTabularButton => driver.FindElement(By.XPath("//mat-button-toggle[@value='tabular']"));
        public static IWebElement gcomplyPlusCommentsFilterField => driver.FindElement(By.XPath("//div[span[label[mat-label[text()='Comments filter']]]]//input"));
        public static IWebElement gcomplyPlusTabularIngrediantSearchField => driver.FindElement(By.XPath("(//input[@name[contains(.,'filter:')]])[1]"));
        public static IWebElement gcomplyPlusTabularDIDSearchField => driver.FindElement(By.XPath("(//input[@name[contains(.,'filter:')]])[2]"));
        public static IWebElement gcomplyPlusTabularCASSearchField => driver.FindElement(By.XPath("(//input[@name[contains(.,'filter:')]])[3]"));
        public static IWebElement gcomplyPlusTabularFunctionSearchField => driver.FindElement(By.XPath("(//input[@name[contains(.,'filter:')]])[4]"));
        public static IWebElement gcomplyPlusTabularUsageSearchField => driver.FindElement(By.XPath("(//input[@name[contains(.,'filter:')]])[5]"));
        public static IWebElement gcomplyPlusTabularCountrySearchField => driver.FindElement(By.XPath("(//input[@name[contains(.,'filter:')]])[6]"));
        public static IWebElement gcomplyPlusTabularResultIndicatorSearchField => driver.FindElement(By.XPath("(//input[@name[contains(.,'filter:')]])[7]"));
        public static IWebElement gcomplyPlusTabularThresholdSearchField => driver.FindElement(By.XPath("(//input[@name[contains(.,'filter:')]])[8]"));
        public static IWebElement gcomplyPlusTabularCitationSearchField => driver.FindElement(By.XPath("(//input[@name[contains(.,'filter:')]])[9]"));
        public static IWebElement gcomplyPlusClearAllFiltersButton => driver.FindElement(By.XPath("//span[text()[contains(.,'Clear all filters')]]"));
        public static IWebElement gcomplyPlusPDFButton => driver.FindElement(By.XPath("//button[span[text()[contains(.,'PDF')]]]"));
        public static IWebElement gcomplyPlusCitationLink => driver.FindElement(By.XPath("(//a[@href[contains(.,'reference')]])[1]"));
        public static IWebElement gcomplyPlusMatrixCountryRegulationDynamic => driver.FindElement(By.XPath(string.Format("//td[@role='gridcell']//span[text()[contains(.,'{0}')]]", regulation)));
        public static IWebElement gcomplyPlusMatrixCountryRegulationPermitted => driver.FindElement(By.XPath("(//tr[td[div[span[span[text()[contains(.,'Permitted')]]]]]]//td[@role='gridcell'])[2]"));
        public static IWebElement gcomplyPlusMatrixCountryRegulationRestricted => driver.FindElement(By.XPath("(//tr[td[div[span[span[text()[not(contains(.,'-Restricted'))]and text()[contains(.,'Restricted')]]]]]]//td[@role='gridcell'])[2]"));
        public static IWebElement gcomplyPlusMatrixCountryRegulationProhibited => driver.FindElement(By.XPath("(//tr[td[div[span[span[text()[contains(.,'Prohibited')]]]]]]//td[@role='gridcell'])[2]"));
        public static IWebElement gcomplyPlusMatrixPopupToggleDetailsButton => driver.FindElement(By.XPath("(//span[text()[contains(.,'Toggle details')]])[2]"));
        public static IWebElement gcomplyPlusMatrixPopupCloseButton => driver.FindElement(By.XPath("//button[text()[(contains(.,'Close'))]]"));
        public static IWebElement gcomplyPlusLandscapeNavButton => driver.FindElement(By.XPath("//a[text()='Landscape']"));
        public static IWebElement gcomplyPlusRecipesListNavButton => driver.FindElement(By.XPath("//a[text()='Recipes/Lists']"));
        public static IWebElement gcomplyPlusAnalysisNavButton => driver.FindElement(By.XPath("//a[text()='Analysis']"));
        public static IWebElement gcomplyPlusCertificatesNavButton => driver.FindElement(By.XPath("//a[text()='Certificates']"));
        public static IWebElement gcomplyPlusBypassesNavButton => driver.FindElement(By.XPath("//a[text()='Bypasses']"));
        public static IWebElement gcomplyPlusReportsNavButton => driver.FindElement(By.XPath("//a[text()='Reports']"));
        public static IWebElement gcomplyPlusSettingsNavButton => driver.FindElement(By.XPath("//a[text()='Settings']"));
        public static IWebElement gcomplyPlusResourcesNavButton => driver.FindElement(By.XPath("//a[text()='Resources']"));



        #region old elements
        //private static IWebElement servsafeLoginButton => ServeCommon.driver.FindElement(By.XPath("(//a[text()='Login / Create Account'])[1]"));
        //private static IWebElement servsafeCreateAccountButton => ServeCommon.driver.FindElement(By.XPath("//a[text()='Create Account']"));
        //private static IWebElement servsafeSubmitButton => ServeCommon.driver.FindElement(By.XPath("//a[text()[contains(.,'Submit')]]"));
        //private static IWebElement servsafeKeepAddressSameButton => ServeCommon.driver.FindElement(By.XPath("(//button[text()[contains(.,'Keep address the same')]])[2]"));

        //private static IWebElement servsafeEmailAddressField => ServeCommon.driver.FindElement(By.XPath("//input[@id='emailToCheck']"));
        //private static IWebElement servsafeFirstNameField => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'First Name')]]][1]//input[@id='givenName']"));
        //private static IWebElement servsafeLastNameField => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'Last Name')]]][1]//input[@id='givenName']"));
        //private static IWebElement servsafeEmailTypeField => ServeCommon.driver.FindElement(By.XPath("//select[@id='emailType']"));
        //private static IWebElement servsafeEmailTypePersonal => ServeCommon.driver.FindElement(By.XPath("//option[text()='Personal']"));
        //private static IWebElement servsafeEmailConfirmField => ServeCommon.driver.FindElement(By.XPath("//input[@id='mail-confirm']"));
        //private static IWebElement servsafeAddressTypeField => ServeCommon.driver.FindElement(By.XPath("//select[@id='addressType']"));
        //private static IWebElement servsafeAddressTypeHome => ServeCommon.driver.FindElement(By.XPath("//option[text()='Home']"));
        //private static IWebElement servsafeAddress1Field => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'Address 1')]]][1]//input[@id='address1']"));
        //private static IWebElement servsafeAddress2Field => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'Address 2')]]][1]//input[@id='address2']"));
        //private static IWebElement servsafeCityField => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'City')]]][1]//input[@id='city']"));
        //private static IWebElement servsafeCountryField => ServeCommon.driver.FindElement(By.XPath("//select[@id='country']"));
        //private static IWebElement servsafeCountryUnitedStates => ServeCommon.driver.FindElement(By.XPath("//option[text()='United States']"));
        //private static IWebElement servsafeStateField => ServeCommon.driver.FindElement(By.XPath("//select[@id='state']"));
        //private static IWebElement servsafeStateIllinois => ServeCommon.driver.FindElement(By.XPath("//option[text()='Illinois']"));
        //private static IWebElement servsafeZipCodeField => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'Zip')]]][1]//input[@id='zipCode']"));
        //private static IWebElement servsafeMobileCountryField => ServeCommon.driver.FindElement(By.XPath("//select[@id='mobileCountry']"));
        //private static IWebElement servsafeMobileCountryUnitedStates => ServeCommon.driver.FindElement(By.XPath("(//option[text()='United States (+1)'])[1]"));
        //private static IWebElement servsafePhoneNumberField => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'Phone')]]][1]//input[@id='phoneNumber']"));
        //private static IWebElement servsafeBusinessCountryField => ServeCommon.driver.FindElement(By.XPath("//select[@id='businessCountry']"));
        //private static IWebElement servsafeBusinessCountryUnitedStates => ServeCommon.driver.FindElement(By.XPath("(//option[text()='United States (+1)'])[3]"));
        //private static IWebElement servsafeBusinessPhoneNumberField => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'Phone')]]][1]//input[@id='businessPhoneNumber']"));
        //private static IWebElement servsafeBusinessExtField => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'Phone')]]][1]//input[@id='businessExt']"));
        //private static IWebElement servsafeCompanyNameField => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'Company')]]][1]//input[@id='companyName']"));
        //private static IWebElement servsafeJopTitleField => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'Job')]]][1]//input[@id='jobTitle']"));
        //private static IWebElement servsafeJobRoleField => ServeCommon.driver.FindElement(By.XPath("//select[@id='jobRole']"));
        //private static IWebElement servsafeJobRoleOther => ServeCommon.driver.FindElement(By.XPath("//option[text()='Other']"));
        //private static IWebElement servsafeJobRoleOtherText => ServeCommon.driver.FindElement(By.XPath("//div[div[text()[contains(.,'Job')]]][1]//input[@id='jobRoleOther']"));
        //private static IWebElement servsafePasswordField => ServeCommon.driver.FindElement(By.XPath("//input[@id='password']"));
        //private static IWebElement servsafePasswordConfirmField => ServeCommon.driver.FindElement(By.XPath("//input[@id='confirmPassword']"));
        //private static IWebElement servsafePasscodeField => ServeCommon.driver.FindElement(By.XPath("//input[@id='Passcode']"));
        #endregion

        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        //Micro Methods
        public static void ClickDecernisUsernameField()
        {
            //Click username field
            decernisUsernameField.Click();
        }
        public static void EnterDecernisUsername(string username)
        {
            //Click username field and enter username.
            ClickDecernisUsernameField();
            decernisUsernameField.SendKeys(username);
        }
        public static void ClickSigninSSOButton()
        {
            //Click sign in button.
            decernisSigninWithSSOButton.Click();
        }
        public static void ClickSigninPasswordButton()
        {
            //Click sign in button.
            decernisSigninWithPasswordButton.Click();
        }
        public static void NavigateDecernisSSOUsername(string username)
        {
            //Enter a username and click sign in button.
            EnterDecernisUsername(username);
            ClickSigninSSOButton();

            wait.Until(ExpectedConditions.ElementToBeClickable(decernisSigninWithPasswordButton));
        }
        public static void ClickDecernisPasswordField()
        {
            //Click password field
            decernisPasswordField.Click();
        }
        public static void EnterDecernisSSOPassword(string password)
        {
            //Click username field and enter password.
            ClickSigninSSOButton();

            wait.Until(ExpectedConditions.ElementToBeClickable(decernisPasswordField));

            ClickDecernisPasswordField();
            decernisPasswordField.SendKeys(password);
        }
        public static void EnterDecernisPassword(string password)
        {
            //Click username field and enter password.
            ClickSigninPasswordButton();

            wait.Until(ExpectedConditions.ElementToBeClickable(decernisPasswordField));

            ClickDecernisPasswordField();
            decernisPasswordField.SendKeys(password);
        }
        public static void NavigateDecernisSSOPassword(string password)
        {
            //Enter a password and click sign in button.
            EnterDecernisSSOPassword(password);
            ClickSigninSSOButton();

            wait.Until(ExpectedConditions.ElementToBeClickable(decernisWrapper));
        }
        public static void NavigateDecernisPassword(string password)
        {
            //Enter a password and click sign in button.
            EnterDecernisPassword(password);
            ClickSigninPasswordButton();

            wait.Until(ExpectedConditions.ElementToBeClickable(decernisWrapper));
        }

        public static void NavigateDecernisSSOAccountPick()
        {
            //Click username field and enter password.
            ClickSigninSSOButton();
            wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Format("//small[text()='{0}']", emailAddress))));
            decernisSigninAccountPick.Click();
        }
        public static void SelectDecernisSSOCompany(string companyName)
        {
            //Click company name button and select company.
            ClickDecernisSSOCompanyNameButton();
            ClickDecernisSSOCompanyName(companyName);
        }
        public static void ClickDecernisSSOCompanyName(string companyName)
        {
            company = companyName;
            decernisSignInCompanyName.Click();
        }
        public static void ClickDecernisSSOCompanyNameButton()
        {
            decernisSignInCompanyNameButton.Click();
        }
        public static void ClickGComplyLink()
        {
            //Click on gComply link.
            gcomplyURL.Click();

            //This here swicthes driver focus to second browser tab which is created upon gComply click.
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Task.Delay(waitDelayLong).Wait();
            wait.Until(ExpectedConditions.ElementToBeClickable(gcomplyUploadSearchTermsButton));
        }
        public static void ClickGComplyPlusLink()
        {
            //Click on gComplyPlus link.
            gcomplyPlusURL.Click();

            //This here switches driver focus to second browser tab which is created upon gComplyPlus click.
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Task.Delay(waitDelayLong).Wait();
            wait.Until(ExpectedConditions.ElementToBeClickable(gcomplyPlusModuleField));
        }
        public static void ClickLandscapeModuleField()
        {
            gcomplyPlusModuleField.Click();
        }
        public static void ClickLandscapeUsageField()
        {
            gcomplyPlusUsageField.Click();

            //Wait for contents of dropdown to appear. Was seen to take up to 2 seconds.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()[contains(.,'Unrefined sugars')]]")));
        }
        public static void ClickLandscapeFunctionField()
        {
            gcomplyPlusFunctionField.Click();
        }
        public static void ClickLandscapeCountryField()
        {
            gcomplyPlusCountriesField.Click();

            //Wait for contents of dropdown to appear. Was seen to take up to 2 seconds.
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()[contains(.,'United States')]]")));
        }
        public static void ClickLandscapeRecipeField()
        {
            gcomplyPlusRecipeField.Click();
        }
        public static void ClickRunAnalysisButton()
        {
            gcomplyPlusRunAnalysisButton.Click();
        }
        public static void ClickRunEvaluateButton()
        {
            gcomplyPlusRunEvaluateButton.Click();
        }
        public static void EnterLandscapeModule(string moduleName)
        {
            text = moduleName;//this is just a fun and lazy way to dynamically define what module to click on.
            ClickLandscapeModuleField();
            gcomplyPlusSpanDynamic.Click();

            //Wait for Usage field to activate.
            wait.Until(ExpectedConditions.ElementToBeClickable(gcomplyPlusUsageField));
        }
        public static void EnterLandscapeUsage(string usageName)
        {
            text = usageName;//this is just a fun and lazy way to dynamically define what usage to click on.
            ClickLandscapeUsageField();
            gcomplyPlusSpanDynamic.Click();
            HitEscKey();//This is to close the drop down.
        }
        public static void EnterLandscapeFunction(string functionName)
        {
            text = functionName;//this is just a fun and lazy way to dynamically define what function to click on.
            ClickLandscapeFunctionField();
            gcomplyPlusSpanDynamic.Click();
            HitEscKey();//This is to close the drop down.
        }
        public static void EnterLandscapeCountries(string countryName)
        {
            text = countryName;//this is just a fun and lazy way to dynamically define what country to click on.
            ClickLandscapeCountryField();
            gcomplyPlusCountriesField.SendKeys(text);
            gcomplyPlusSpanDynamic.Click();
        }
        public static void EnterLandscapeRecipe(string recipeName)
        {
            text = recipeName;//this is just a fun and lazy way to dynamically define what recipe to click on.
            ClickLandscapeRecipeField();
            gcomplyPlusSpanDynamic.Click();
        }
        public static void ClickMatrixButton()
        {
            //Click the Matrix button.
            gcomplyPlusMatrixButton.Click();

            //Waits for table records to populate.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@class[contains(.,'-ingredient')]]")));
        }
        public static void ClickTabularButton()
        {
            //Click the Tabular button.
            gcomplyPlusTabularButton.Click();

            //Waits for table records to populate.
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='Search']")));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@class[contains(.,'verbose_name')]]")));
        }
        public static void ClickCommentsFilterField()
        {
            gcomplyPlusCommentsFilterField.Click();
        }
        public static void ScrollToElementLocation(string elementPath)
        {
            ScrollToElement(elementPath);
        }
        public static void ClearCommentFilter()
        {
            gcomplyPlusCommentsFilterField.Clear();
        }
        public static void EnterCommentFilter()
        {
            ClickCommentsFilterField();
            gcomplyPlusCommentsFilterField.SendKeys(country);
        }
        public static void ClickTabularCountrySearchField()
        {
            gcomplyPlusTabularCountrySearchField.Click();
        }
        public static void EnterTabularCountrySearch(string countryName)
        {
            ClickTabularCountrySearchField();
            gcomplyPlusTabularCountrySearchField.SendKeys(countryName);
            Task.Delay(waitDelay5).Wait();
        }
        public static void CollapseSearchParametersSection()
        {
            var element = driver.FindElements(By.XPath("//mat-expansion-panel[mat-expansion-panel-header[span[text()='Search parameters']]]//mat-expansion-panel-header[@aria-expanded='true']"));

            if (element.Any())
            {
                //Click Search parameters header to collapse it.
                gcomplyPlusSearchParametersHeader.Click();

                //Wait for Recipe field to appear.
                wait.Until(ExpectedConditions.ElementToBeClickable(gcomplyPlusTabularButton));
            }
            Task.Delay(waitDelay5).Wait();
        }
        public static void CollapseSearchParametersAndClickTabularButton()
        {
            //Collapse Search Parameters and click Tabular button.
            CollapseSearchParametersSection();
            ClickTabularButton();
        }
        public static void ClickCitationLink()
        {
            gcomplyPlusCitationLink.Click();         

            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()[contains(.,'tit')]]"))); //yes, this is hilarious but its atually the way some documents present the word 'title' broken into two parts.
            }
            catch(Exception)
            {
                Assert.Fail("Unexpected Result: The citation document was inaccessible or did not load correctly.");                
            }
        }
        public static void ClickMatrixCountryRegulationDynamic(string regulationType) //Useful for dynamic and flexible regulation identification.
        {
            regulation = regulationType;
            gcomplyPlusMatrixCountryRegulationDynamic.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format("//div[text()[contains(.,'{0}')]]", regulation))));
            Task.Delay(waitDelay5).Wait();
        }
        public static void ClickMatrixCountryRegulationPermitted()
        {
            gcomplyPlusMatrixCountryRegulationPermitted.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(gcomplyPlusMatrixPopupToggleDetailsButton));
            Task.Delay(waitDelay5).Wait();
        }
        public static void ClickMatrixCountryRegulationRestricted()
        {
            gcomplyPlusMatrixCountryRegulationRestricted.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(gcomplyPlusMatrixPopupToggleDetailsButton));
            Task.Delay(waitDelay5).Wait();
        }
        public static void ClickMatrixCountryRegulationProhibited()
        {
            gcomplyPlusMatrixCountryRegulationProhibited.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(gcomplyPlusMatrixPopupToggleDetailsButton));
            Task.Delay(waitDelay5).Wait();
        }
        public static void ClickMatrixPopupCloseButton()
        {
            gcomplyPlusMatrixPopupCloseButton.Click();
            Task.Delay(waitDelay2).Wait();
        }
        public static void ClickLandscapeNavButton()
        {
            gcomplyPlusLandscapeNavButton.Click();
        }
        public static void ClickRecipesListsNavButton()
        {
            gcomplyPlusRecipesListNavButton.Click();
        }
        public static void ClickAnalysisNavButton()
        {
            gcomplyPlusAnalysisNavButton.Click();
            Task.Delay(waitDelay20).Wait();
        }
        public static void ClickCertificatesNavButton()
        {
            gcomplyPlusAnalysisNavButton.Click();
        }
        public static void ClickBypassesNavButton()
        {
            gcomplyPlusAnalysisNavButton.Click();
        }
        public static void ClickReportsNavButton()
        {
            gcomplyPlusAnalysisNavButton.Click();
        }
        public static void ClickSettingsNavButton()
        {
            gcomplyPlusAnalysisNavButton.Click();
        }
        public static void ClickResourcesNavButton()
        {
            gcomplyPlusAnalysisNavButton.Click();
        }


        #region old micro methods
        //public static void ClickOnLoginButton()
        //{
        //    //Click login button.
        //    servsafeLoginButton.Click();

        //    //Waits for Login page to load.
        //    wait.Until(ExpectedConditions.ElementExists(By.XPath(String.Format("{0}", servsafeCreateAccountButton))));
        //}

        //public static void ClickOnCreateAccountButton()
        //{
        //    //Click create account button.
        //    servsafeCreateAccountButton.Click();

        //    //Waits for submit button to load.
        //    wait.Until(ExpectedConditions.ElementExists(By.XPath(String.Format("{0}", servsafeSubmitButton))));
        //}

        //public static void ClickOnKeepAddressSameButton()
        //{
        //    //Click keep address same button.
        //    servsafeKeepAddressSameButton.Click();

        //    //Waits for submit button to load.
        //    wait.Until(ExpectedConditions.ElementExists(By.XPath(String.Format("{0}", servsafeSubmitButton))));
        //}

        //public static void EnterEmailAddress(string emailAddress)
        //{
        //    //Click email address field.
        //    servsafeEmailAddressField.Click();

        //    //Enter email address.
        //    servsafeEmailAddressField.SendKeys(emailAddress);

        //    //Waits for field to be populated.
        //    Task.Delay(waitDelay5).Wait();
        //}

        //public static void ClickOnSubmitButton()
        //{
        //    //Click submit button.
        //    servsafeSubmitButton.Click();

        //    //Waits for first name field to load.
        //    wait.Until(ExpectedConditions.ElementExists(By.XPath(String.Format("{0}", servsafeFirstNameField))));
        //}

        //public static void EnterFirstName()
        //{
        //    //Click on first name field.
        //    servsafeFirstNameField.Click();

        //    //Enter first name.
        //    servsafeFirstNameField.SendKeys(userNameFirst);
        //}
        //public static void EnterLastName()
        //{
        //    //Click on first name field.
        //    servsafeFirstNameField.Click();

        //    //Enter first name.
        //    servsafeFirstNameField.SendKeys(userNameLast);
        //}

        //public static void EnterEmailTypePersonal()
        //{
        //    //Click on email type field.
        //    servsafeEmailTypeField.Click();

        //    //Cick on personal type.
        //    servsafeEmailTypePersonal.Click();
        //}

        //public static void EnterEmailConfirmation(string emailAddress)
        //{
        //    //Click on confirm email address field.
        //    servsafeEmailConfirmField.Click();

        //    //Enter email address.
        //    servsafeEmailConfirmField.SendKeys(emailAddress);
        //}

        //public static void EnterAddressType()
        //{
        //    //Click on address type field.
        //    servsafeAddressTypeField.Click();

        //    //Cick on home type.
        //    servsafeAddressTypeHome.Click();
        //}

        //public static void EnterAddress1()
        //{
        //    //Click on address1 field.
        //    servsafeAddress1Field.Click();

        //    //Enter address1.
        //    servsafeAddress1Field.SendKeys(accountAddress1);
        //}

        //public static void EnterAddress2()
        //{
        //    //Click on address2 field.
        //    servsafeAddress2Field.Click();

        //    //Enter address2.
        //    servsafeAddress2Field.SendKeys(accountAddress2);
        //}

        //public static void EnterCity()
        //{
        //    //Click on first name field.
        //    servsafeCityField.Click();

        //    //Enter first name.
        //    servsafeCityField.SendKeys(accountCity);
        //}

        //public static void EnterCountry()
        //{
        //    //Click on first name field.
        //    servsafeCountryField.Click();

        //    //Cick on a country.
        //    servsafeCountryUnitedStates.Click();
        //}

        //public static void EnterState()
        //{
        //    //Click on first name field.
        //    servsafeStateField.Click();

        //    //Cick on a state.
        //    servsafeStateIllinois.Click();
        //}

        //public static void EnterZipCode()
        //{
        //    //Click on zip code field.
        //    servsafeZipCodeField.Click();

        //    //Enter zip code.
        //    servsafeZipCodeField.SendKeys(accountZipCode);
        //}

        //public static void EnterMobileCountry()
        //{
        //    //Click on mobile country field.
        //    servsafeMobileCountryField.Click();

        //    //Cick on a country.
        //    servsafeMobileCountryUnitedStates.Click();
        //}

        //public static void EnterPhoneNumber()
        //{
        //    //Click on phone number field.
        //    servsafePhoneNumberField.Click();

        //    //Enter phone number.
        //    servsafePhoneNumberField.SendKeys(accountPhoneNumber);
        //}

        //public static void EnterBusinessCountry()
        //{
        //    //Click on business country field.
        //    servsafeBusinessCountryField.Click();

        //    //Cick on a country.
        //    servsafeBusinessCountryUnitedStates.Click();
        //}

        //public static void EnterBusinessPhoneNumber()
        //{
        //    //Click on business phone number field.
        //    servsafeBusinessPhoneNumberField.Click();

        //    //Enter phone number.
        //    servsafeBusinessPhoneNumberField.SendKeys(accountBusinessPhoneNumber);
        //}

        //public static void EnterBusinessExt()
        //{
        //    //Click on business phone number field.
        //    servsafeBusinessExtField.Click();

        //    //Enter zip code.
        //    servsafeBusinessExtField.SendKeys(accountBusinessExt);
        //}

        //public static void EnterCompanyName()
        //{
        //    //Click on company name field.
        //    servsafeCompanyNameField.Click();

        //    //Enter company name.
        //    servsafeCompanyNameField.SendKeys(accountCompanyName);
        //}

        //public static void EnterJobTitle()
        //{
        //    //Click on job title field.
        //    servsafeJopTitleField.Click();

        //    //Enter job title name.
        //    servsafeJopTitleField.SendKeys(accountJobTitle);
        //}

        //public static void EnterJobRole()
        //{
        //    //Click on job role field.
        //    servsafeJobRoleField.Click();

        //    //Cick on a job role.
        //    servsafeJobRoleOther.Click();
        //}

        //public static void EnterJobRoleOther()
        //{
        //    //Click on job role (other) field.
        //    servsafeJobRoleOtherText.Click();

        //    //Enter job role name.
        //    servsafeJobRoleOtherText.SendKeys(accountJobRoleOther);
        //}

        //public static void EnterPassword()
        //{
        //    //Click on password field.
        //    servsafePasswordField.Click();

        //    //Enter job title name.
        //    servsafePasswordField.SendKeys(accountPassword);
        //}

        //public static void EnterPasswordConfirmation()
        //{
        //    //Click on password field.
        //    servsafePasswordConfirmField.Click();

        //    //Enter job title name.
        //    servsafePasswordConfirmField.SendKeys(accountPassword);
        //}
        #endregion

        //├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

        //Major Methods
        public static void NavigateDecernisSSOviaSSO(string username)
        {
            //Enter username, password, and sign in with SSO.
            NavigateDecernisSSOUsername(username);
            NavigateDecernisSSOAccountPick();
        }
        public static void NavigateDecernisSSOviaPassword(string username, string companyName, string password)
        {
            //Enter username, password, and sign in with Password.
            NavigateDecernisSSOUsername(username);
            SelectDecernisSSOCompany(companyName);
            NavigateDecernisPassword(password);
        }
        public static void ConfigureLandscapeSearch(string moduleName, string countryName, string usageName, string functionName)
        {
            //This will be used in a later assertion.
            module = moduleName;
            usage = usageName;
            function = functionName;
            country = countryName;

            //>Note that Module and Country entries are required at a minimum to enable analysis button, HOWEVER, at least 1 useage, function, or recipe is required to actaully run an analysis. (looks like an oversight)
            //Enter criteria into parameter fields.
            EnterLandscapeModule(moduleName);

            if (usage != null)
            {
                EnterLandscapeUsage(usageName);
            }

            if (function != null)
            {
                EnterLandscapeFunction(functionName);
            }

            EnterLandscapeCountries(countryName);
            //>Note that this search is not using a recipe.
            //Wait for Run Analysis button to activate.
            wait.Until(ExpectedConditions.ElementToBeClickable(gcomplyPlusRunAnalysisButton));            
        }
        public static void PerformLandscapeSearch(string moduleName, string countryName, string usageName, string functionName)
        {
            //Configure the Landscape search.
            ConfigureLandscapeSearch(moduleName, countryName, usageName, functionName);            

            //Click Run Analysis button.
            ClickRunAnalysisButton();

            //Restart stopwatch.
            timer.Restart();

            //Check for appearance of message.
            while (timer.Elapsed.TotalSeconds < waitDelay5 && timer.IsRunning.Equals(true))
            {
                var message = driver.FindElements(By.XPath("//div[text()[contains(.,'The analysis is in progress.')]]"));

                if (message.Any())
                {
                    //Stop stopwatch.
                    timer.Stop();
                }              
            }

            //Waits for table records to populate.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@class[contains(.,'-ingredient')]]")));
        }
        public static void ConfigureAnalysisSearch(string moduleName, string countryName, string recipeName, string usageName)
        {
            //This will be used in a later assertion.
            module = moduleName;
            usage = usageName;
            recipe = recipeName;
            country = countryName;

            //>Note that Usage must be entered AFTER recipe. This is because the selected recipe will overwrite the usage field. (looks like an oversight)
            //Enter criteria into parameter fields.
            EnterLandscapeModule(moduleName);
            EnterLandscapeCountries(countryName);
            EnterLandscapeRecipe(recipeName);
            Task.Delay(waitDelay10).Wait();
            EnterLandscapeUsage(usageName);

            //Wait for Run Analysis button to activate.
            wait.Until(ExpectedConditions.ElementToBeClickable(gcomplyPlusRunAnalysisButton));            
        }
        public static void PerformAnalysisSearch(string moduleName, string countryName, string recipeName, string usageName)
        {
            //Configure the Analysis search.
            ConfigureAnalysisSearch(moduleName, countryName, recipeName, usageName);            

            //Click Run Analysis button.
            ClickRunAnalysisButton();

            //Restart stopwatch.
            timer.Restart();

            //Check for appearance of message.
            while (timer.Elapsed.TotalSeconds < waitDelay10 && timer.IsRunning.Equals(true))
            {
                var message = driver.FindElements(By.XPath("//h3[text()='Overall Recipe Conclusion:']"));

                if (message.Any())
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            //Waits for table records to populate.
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class[contains(.,'popoverDisabled')]]")));
        }
        public static void AssertUsageOptions()
        {
            //Check if Search parameters header is closed after run analysis completes.
            var element = driver.FindElements(By.XPath("//mat-expansion-panel[mat-expansion-panel-header[span[text()='Search parameters']]]//mat-expansion-panel-header[@aria-expanded='false']"));

            if (element.Any())
            {
                //Click Search parameters header to open it.
                gcomplyPlusSearchParametersHeader.Click();

                //Wait for Recipe field to appear.
                //Task.Delay(waitDelay2).Wait();
                wait.Until(ExpectedConditions.ElementToBeClickable(gcomplyPlusRecipeField));
            }

            ClickLandscapeUsageField();

            #region Usage Options
            //string u1 = "Acidity Regulator/Buffer/Alkalizing Agents"; //nonexistent option in staging env.
            string u2 = "Antioxidants";
            string u3 = "Chemical leavening agents";
            string u4 = "Colors";
            string u5 = "Emulsifiers";
            string u6 = "Enzymes";
            string u7 = "Flavorings";
            string u8 = "Foam control agents";
            string u9 = "Glazing agents";
            string u10 = "Preservatives";
            string u11 = "Thickening agents";
            string u12 = "Waxes";
            string u13 = "Beer";
            //string u14 = "Low Alcoholic Flavoured Beverages"; //nonexistent option in staging env.
            string u15 = "Other alcoholic beverages (cider, perry, cocktails)";
            string u16 = "Spirits";
            string u17 = "Wine";
            string u18 = "Baking mixes and doughs";
            string u19 = "Fine bakery wares";
            string u20 = "Leavened breads";
            string u21 = "Ordinary bakery products and bread-type products";
            string u22 = "Unleavened breads and crispbreads";
            string u23 = "Batters or breading used as a coating";
            string u24 = "Breakfast foods";
            string u25 = "Cereal bars and other cereal products";
            string u26 = "Flours";
            string u27 = "Malt and products thereof";
            string u28 = "Pasta and noodles";
            string u29 = "Pre-cooked or processed rice products";
            string u30 = "Soybean products excluding soybean-based beverages";
            string u31 = "Starch";
            string u32 = "Whole, broken, or flaked grain, including rice";
            string u33 = "Clear sauces";
            string u34 = "Emulsified sauces";
            string u35 = "Herbs and spices";
            string u36 = "Mixes for sauces and gravies";
            string u37 = "Mustards and pastes";
            string u38 = "Non-emulsified sauces";
            string u39 = "Prepared salads and sandwich spreads";
            string u40 = "Protein products";
            string u41 = "Salt and salt substitutes";
            //string u42 = "Seasonings, Condiments and Household Flavorings"; //nonexistent option in staging env.
            string u43 = "Soups and broths";
            string u44 = "Vinegar";
            string u45 = "Yeast and products thereof";
            string u170 = "Candied fruits and vegetables"; //nonexistent option in prod env.
            string u46 = "Chewing gum";
            string u47 = "Chocolate and products thereof, standardized";
            string u48 = "Chocolate and products thereof, unstandardized";
            string u49 = "Cocoa and products thereof, standardized";
            string u50 = "Cocoa-based spreads, fillings, and syrups";
            string u51 = "Decorations, coating and filling (other than fruit-based)";
            string u171 = "Flavored sugars"; //nonexistent option in prod env.
            string u52 = "Hard candy";
            string u53 = "Mints, microsweets and breath freshening micromints";
            string u54 = "Nougats and marzipans";
            string u55 = "Soft candy";
            //string u56 = "Sugar-free chewing gum"; //nonexistent option in staging env.
            //string u57 = "Beverage whiteners"; //nonexistent option in staging env.
            //string u58 = "Cheese analogues"; //nonexistent option in staging env.
            string u59 = "Condensed milk";
            string u60 = "Cream";
            //string u61 = "Cream analogues"; //nonexistent option in staging env.
            string u61 = "Dairy analogues"; //nonexistent option in prod env.
            string u62 = "Dehydrated milk and cream";
            string u63 = "Fermented milk products";
            string u64 = "Liquid milk";
            //string u65 = "Milk and cream powder analogues"; //nonexistent option in staging env.
            string u66 = "Milk fractions (whey, buttermilk, etc.)";
            string u67 = "Non-fermented dairy-based beverages";
            string u68 = "Processed cheese";
            string u69 = "Ripened cheese";
            string u70 = "Unripened cheese";
            string u71 = "Whey cheese";
            string u72 = "Cereal and starch based desserts";
            string u73 = "Fat-based desserts";
            string u74 = "Fruit-based desserts";
            string u75 = "Gelatin desserts";
            string u76 = "Non-frozen dairy- or egg-based desserts";
            string u77 = "Edible Ice: Frozen dairy-based desserts";
            string u78 = "Edible Ice: Frozen non-dairy-based desserts";
            string u79 = "Egg products";
            string u80 = "Fresh eggs";
            string u81 = "Animal fats and oils";
            string u82 = "Butter";
            //string u83 = "Margarine and fat spreads"; //nonexistent option in staging env.
            //string u84 = "Other emulsions"; //nonexistent option in staging env.
            string u84 = "Emulsions"; //nonexistent option in prod env.
            string u85 = "Vegetable fats and oils";
            //string u86 = "Candied fruits and vegetables"; //nonexistent option in staging env.
            string u87 = "Dried fruits";
            string u88 = "Fillings, purees, spreads and toppings (fruit or vegetable)";
            string u89 = "Fresh fruit";
            string u90 = "Fresh vegetables";
            string u91 = "Mushrooms and products thereof";
            string u92 = "Nuts and seeds";
            string u93 = "Nut spreads";
            string u94 = "Processed fruit";
            string u95 = "Processed vegetables";
            string u96 = "Organic foods";
            string u97 = "Processed foods";
            string u98 = "Canned baby food";
            string u99 = "Complementary foods for infants and young children";
            string u110 = "Follow-up formulae";
            string u111 = "Formulae for special medical purposes for infants";
            string u112 = "Infant formulae";
            string u113 = "Processed meat, poultry and game";
            string u114 = "Processed seafood products";
            string u115 = "Unprocessed meat, poultry and game";
            string u116 = "Unprocessed seafood products";
            string u117 = "Carbonated water-based flavored beverages";
            string u118 = "Coffees";
            string u119 = "Concentrates for fruit and vegetable juices";
            string u120 = "Concentrates for fruit and vegetable nectars";
            string u121 = "Concentrates (liquid or solid) for water-based flavored beverages";
            string u122 = "Drinking water";
            string u123 = "Energy drinks";
            //string u124 = "Enhanced water"; //nonexistent option in staging env.
            string u125 = "Fruit and vegetable juice-based beverages";
            string u126 = "Fruit and vegetable juices";
            string u127 = "Fruit and vegetable nectars";
            //string u128 = "Kombucha"; //nonexistent option in staging env.
            string u129 = "Non-carbonated water-based flavored beverages";
            //string u130 = "Packaged water"; //nonexistent option in staging env.
            string u131 = "Plant-based beverages";
            string u132 = "Soybean-based beverages";
            string u133 = "Sports drinks";
            string u134 = "Teas and Herbal Infusions";
            string u135 = "Processed nuts consumed as a snack";
            string u136 = "Savory salty snacks";
            string u137 = "Food supplements";
            string u138 = "Gluten-free foods";
            string u139 = "Meal Replacement";
            string u140 = "Medical foods";
            string u141 = "Weight loss products";
            string u142 = "Brown sugar";
            string u143 = "Flavored sugars";
            string u144 = "Glucose syrups";
            string u145 = "High intensity sweeteners";
            string u146 = "Honey";
            string u147 = "Powdered sugar";
            string u148 = "Refined sugars";
            string u149 = "Unrefined sugars";
            //----------------------------------------
            string u150 = "Additives";
            string u151 = "Alcoholic Beverages";
            string u152 = "Bakery wares";
            string u153 = "Cereal and Cereal Products";
            string u154 = "Condiments / Salt, spices, soups, sauces, salads & protein products";
            string u155 = "Confectionery";
            string u156 = "Dairy";
            string u157 = "Desserts";
            string u158 = "Edible Ices";
            string u159 = "Eggs";
            string u161 = "Fats and Oils";
            string u162 = "Fruits and Vegetables";
            string u163 = "General";
            string u164 = "Infants and Young Children";
            string u165 = "Meat, Poultry, Game and Fish";
            string u166 = "Non-Alcoholic Beverages";
            string u167 = "Ready-to-eat savouries and snacks";
            string u168 = "Special Nutritional Products";
            string u169 = "Sweeteners";
            #endregion

            //Create a list of Usage options.
            List<string> usageOptions = new List<string>
            {
                #region Variable List
                //u1,
                u2,
                u3,
                u4,
                u5,
                u6,
                u7,
                u8,
                u9,
                u10,
                u11,
                u12,
                u13,
                //u14,
                u15,
                u16,
                u17,
                u18,
                u19,
                u20,
                u21,
                u22,
                u23,
                u24,
                u25,
                u26,
                u27,
                u28,
                u29,
                u30,
                u31,
                u32,
                u33,
                u34,
                u35,
                u36,
                u37,
                u38,
                u39,
                u40,
                u41,
                //u42,
                u43,
                u44,
                u45,
                u170,
                u46,
                u47,
                u48,
                u49,
                u50,
                u51,
                u171,
                u52,
                u53,
                u54,
                u55,
                //u56,
                //u57,
                //u58,
                u59,
                u60,
                u61,
                u62,
                u63,
                u64,
                //u65,
                u66,
                u67,
                u68,
                u69,
                u70,
                u71,
                u72,
                u73,
                u74,
                u75,
                u76,
                u77,
                u78,
                u79,
                u80,
                u81,
                u82,
                //u83,
                u84,
                u85,
                //u86,
                u87,
                u88,
                u89,
                u90,
                u91,
                u92,
                u93,
                u94,
                u95,
                u96,
                u97,
                u98,
                u99,
                u110,
                u111,
                u112,
                u113,
                u114,
                u115,
                u116,
                u117,
                u118,
                u119,
                u120,
                u121,
                u122,
                u123,
                //u124,
                u125,
                u126,
                u127,
                //u128,
                u129,
                //u130,
                u131,
                u132,
                u133,
                u134,
                u135,
                u136,
                u137,
                u138,
                u139,
                u140,
                u141,
                u142,
                u143,
                u144,
                u145,
                u146,
                u147,
                u148,
                u149                
                #endregion
            };

            //Create a list of Usage option categories.
            List<string> usageOptionCategories = new List<string>
            {
                #region Variable List                
                u150,
                u151,
                u152,
                u153,
                u154,
                u155,
                u156,
                u157,
                u158,
                u159,
                u161,
                u162,
                u163,
                u164,
                u165,
                u166,
                u167,
                u168,
                u169
                #endregion
            };

            foreach (string option in usageOptions)
            {
                try
                {
                    //Validate that each usage option is available in the Useage dropdown.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//mat-option[span[@class='mat-option-text']]//span[text()[contains(.,'{0}')]]", option))));
                }                
               catch (Exception) 
                {
                    Assert.Fail(string.Format("Unexpected Result: The option '{0}' is missing from the Usage list.", option));
                }
            }

            foreach (string option in usageOptionCategories)
            {
                try
                {
                    //Validate that each usage option category is available in the Useage dropdown.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//label[span[@class='mat-checkbox-label']]//span[text()[contains(.,'{0}')]]", option))));
                }
                catch (Exception)
                {
                    Assert.Fail(string.Format("Unexpected Result: The option category '{0}' is missing from the Usage list.", option));
                }
            }

            //This is to close the drop down.
            HitEscKey();
        }
        public static void AssertFunctionOptions()
        {
            ClickLandscapeFunctionField();

            #region Function Options
            string u1 = "Anticaking Agent";
            string u2 = "Antioxidant";
            string u3 = "Bleaching Agent (Not for Flour)";
            string u4 = "Bulking Agent";
            string u5 = "Carrier/Solvent";
            string u6 = "Carry-Over";
            string u7 = "Chewing Gum Base";
            string u8 = "Colorant";
            string u9 = "Emulsifier";
            string u10 = "Enzyme/Catalyst";
            string u11 = "Fat Replacer";
            string u12 = "Flavor";
            string u13 = "Flavor Enhancer";
            string u14 = "Flour Treatment Agent";
            string u15 = "Foam Control Agent";
            string u16 = "Food";
            string u17 = "Gases";
            string u18 = "Gelling, Thickening, Stabilizing and Firming Agents";
            string u19 = "Humectant";
            string u20 = "Leavening/Raising Agent";
            string u21 = "Nutrient Supplement";
            string u22 = "Preservative";
            string u23 = "Processing Aid";
            string u24 = "Release Agent";
            string u25 = "Sequestrant/Chelating Agent";
            string u26 = "Surface Finishing/Glazing Agent";
            string u27 = "Sweetener";            
            
            //----------------------------------------
            string u28 = "Function";
            #endregion

            //Create a list of Function options.
            List<string> functionOptions = new List<string>
            {
                #region Variable List
                u1,
                u2,
                u3,
                u4,
                u5,
                u6,
                u7,
                u8,
                u9,
                u10,
                u11,
                u12,
                u13,
                u14,
                u15,
                u16,
                u17,
                u18,
                u19,
                u20,
                u21,
                u22,
                u23,
                u24,
                u25,
                u26,
                u27                
                #endregion
            };

            //Create a list of Function option categories.
            List<string> functionOptionsCategories = new List<string>
            {
                #region Variable List                
                u28                
                #endregion
            };

            foreach (string option in functionOptions)
            {
                try
                {
                    //Validate that each function option is available in the Function dropdown.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//mat-option[span[@class='mat-option-text']]//span[text()[contains(.,'{0}')]]", option))));
                }
                catch (Exception)
                {
                    Assert.Fail(string.Format("Unexpected Result: The option '{0}' is missing from the Function list.", option));
                }
            }

            foreach (string option in functionOptionsCategories)
            {
                try
                {
                    //Validate that each function option category is available in the Function dropdown.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//label[span[@class='mat-checkbox-label']]//span[text()[contains(.,'{0}')]]", option))));
                }
                catch (Exception)
                {
                    Assert.Fail(string.Format("Unexpected Result: The option category '{0}' is missing from the Function list.", option));
                }
            }

            //This is to close the drop down.
            HitEscKey();
        }
        public static void AssertCountryRegionAfrica()
        {
            //Check if Search parameters header is closed after run analysis completes.
            var element = driver.FindElements(By.XPath("//mat-expansion-panel[mat-expansion-panel-header[span[text()='Search parameters']]]//mat-expansion-panel-header[@aria-expanded='false']"));

            if (element.Any())
            {
                //Click Search parameters header to open it.
                gcomplyPlusSearchParametersHeader.Click();

                //Wait for Recipe field to appear.
                //Task.Delay(waitDelay2).Wait();
                wait.Until(ExpectedConditions.ElementToBeClickable(gcomplyPlusRecipeField));
            }

            #region Usage Options
            string u1 = "Algeria";
            string u2 = "Angola";
            string u3 = "Benin";
            string u4 = "Botswana";
            string u5 = "Burkina Faso";
            string u6 = "Burundi";
            string u7 = "Cameroon";
            string u8 = "Cape Verde";
            string u9 = "Central African Republic";
            string u10 = "Chad";
            string u11 = "Comoros";
            string u12 = "Congo";
            string u13 = "Democratic Republic of the Congo";
            string u14 = "Djibouti";
            string u15 = "East African Community";
            string u16 = "ECOWAS";
            string u17 = "Equalatorial Guinea";
            string u18 = "Eritrea";
            string u19 = "Ethiopia";
            string u20 = "Gabon";
            string u21 = "Gambia";
            string u22 = "Ghana";
            string u23 = "Guinea";
            string u24 = "Guinea-Bissau";
            string u25 = "Ivory Coast";
            string u26 = "Kenya";
            string u27 = "Lesotho";
            string u28 = "Liberia";
            string u29 = "Madagascar";
            string u30 = "Malawi";
            string u31 = "Mali";
            string u32 = "Mauritania";
            string u33 = "Mauritius";
            string u34 = "Mayotte";
            string u35 = "Morocco";
            string u36 = "Mozambique";
            string u37 = "Namibia";
            string u38 = "Niger";
            string u39 = "Nigeria";
            string u40 = "Reunion";
            string u41 = "Rwanda";
            string u42 = "Saint Helena";
            string u43 = "Sao Tome and Principe";
            string u44 = "Senegal";
            string u45 = "Seychelles";
            string u46 = "Sierra Leone";
            string u47 = "Somalia";
            string u48 = "South Africa";
            string u49 = "South Sudan";
            string u50 = "Sudan";
            string u51 = "Swaziland";
            string u52 = "Tanzania";
            string u53 = "Togo";
            string u54 = "Tunisia";
            string u55 = "Uganda";
            string u56 = "Zambia";
            string u57 = "Zimbabwe";                        
            #endregion

            //Create a list of Usage options.
            List<string> countryOptions = new List<string>
            {
                #region Variable List
                u1,
                u2,
                u3,
                u4,
                u5,
                u6,
                u7,
                u8,
                u9,
                u10,
                u11,
                u12,
                u13,
                u14,
                u15,
                u16,
                u17,
                u18,
                u19,
                u20,
                u21,
                u22,
                u23,
                u24,
                u25,
                u26,
                u27,
                u28,
                u29,
                u30,
                u31,
                u32,
                u33,
                u34,
                u35,
                u36,
                u37,
                u38,
                u39,
                u40,
                u41,
                u42,
                u43,
                u44,
                u45,
                u46,
                u47,
                u48,
                u49,
                u50,
                u51,
                u52,
                u53,
                u54,
                u55,
                u56,
                u57                                   
                #endregion
            };
            
            foreach (string country in countryOptions)
            {
                try
                {
                    //Validate that each country is available in selected region.
                    Assert.IsTrue(driver.VerifyAsserts(By.XPath(string.Format("//mat-chip[text()[contains(.,'')]]", country))));
                }
                catch (Exception)
                {
                    Assert.Fail(string.Format("Unexpected Result: The country '{0}' is missing from the Countries region list.", country));
                }
            }
        }
        public static void AssertCountryOverloadWarning()
        {
            //Restart stopwatch.
            timer.Restart();

            //Check for appearance of message.
            while (timer.Elapsed.TotalSeconds < waitDelay10 && timer.IsRunning.Equals(true))
            {
                var message = driver.FindElements(By.XPath("//h2[text()[contains(.,'Error')]]"));

                if (message.Any())
                {
                    //Stop stopwatch.
                    timer.Stop();
                }
            }

            try
            {
                //Validate that the warning popup appears with message.
                Assert.IsTrue(driver.VerifyAsserts(By.XPath("//li[text()[contains(.,'You cannot submit more than 20 Countries in one Request.')]]")));
            }
            catch(Exception)
            {
                //Validate that each country is available in selected region.
                Assert.Fail("Unexpected Result: The warning message popup did not contain expected message or did not appear within expected timeframe.");
            }
        }
        public static void AccessCitationDocument()
        {
            Task.Delay(waitDelay5).Wait();
            ClickCitationLink();
        }

        #region old major methods
        //public static void CreateNewAccount(string NewEmailAddress)
        //{
        //    ClickOnLoginButton();
        //    ClickOnCreateAccountButton();
        //    EnterEmailAddress(NewEmailAddress);
        //    ClickOnSubmitButton();

        //    //Personal Information
        //    EnterFirstName();
        //    EnterLastName();
        //    EnterEmailTypePersonal();
        //    //Verify presence of Email Address field.
        //    Assert.IsTrue(driver.VerifyAsserts(By.XPath("//input[@autocomplete='user-email']")));
        //    EnterEmailConfirmation(NewEmailAddress);

        //    //Your Address
        //    EnterAddressType();
        //    EnterAddress1();
        //    EnterAddress2();
        //    EnterCity();
        //    EnterCountry();
        //    EnterState();
        //    EnterZipCode();

        //    //Your Phone Numbers
        //    EnterMobileCountry();
        //    EnterPhoneNumber();
        //    EnterBusinessCountry();
        //    EnterBusinessPhoneNumber();
        //    EnterBusinessExt();

        //    //Your Company and Role
        //    EnterCompanyName();
        //    EnterJobTitle();
        //    EnterJobRole();
        //    EnterJobRoleOther();

        //    //Create your Password
        //    EnterPassword();
        //    EnterPasswordConfirmation();

        //    //Click on create account button.
        //    ClickOnCreateAccountButton();
        //}

        //public static void CreateProfileAddressCheck()
        //{
        //    //Waits for submit button to load.
        //    wait.Until(ExpectedConditions.ElementExists(By.XPath(String.Format("{0}", servsafeKeepAddressSameButton))));

        //    ClickOnKeepAddressSameButton();
        #endregion
    }
}
