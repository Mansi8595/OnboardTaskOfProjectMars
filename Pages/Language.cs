using Mars_SpecFlowProject1.Utils;
using NUnit.Framework;
using OnboardTaskProjectMars.Utils;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecrMarsOnboardingtask.Pages
{
    public class Language : CommonDriver

    {

        private IWebElement addNewLanguageButton => driver.FindElement(By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']"));
        private IWebElement addLanuageName => driver.FindElement(By.XPath("//input[contains(@placeholder, 'Add')]"));
        private IWebElement dropdownLanguage => driver.FindElement(By.XPath("//div[@data-tab='first']//select[@class='ui dropdown']"));
        private IWebElement AddButton => driver.FindElement(By.XPath(e_AddButton));
        private IWebElement language => driver.FindElement(By.XPath(e_language));
        private IWebElement languageLevel => driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[2]"));
        private IWebElement editLanguageButton => driver.FindElement(By.XPath(e_editLanguageButton));
        private IWebElement editLanuage => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement buttonUpdate => driver.FindElement(By.XPath(e_updateButton));

        private IWebElement cancelButton => driver.FindElement(By.XPath(e_cancelButton));
        private IWebElement buttonDelete => driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[2]/i"));
        private IWebElement errormessage => driver.FindElement(By.XPath(e_errormessage));
        private IWebElement successmessage => driver.FindElement(By.XPath(e_successmessage));

        private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[1]"));

        private string e_language = "//div[@data-tab='first']//tbody[last()]/tr/td[1]";
        private string e_editLanguageButton = "//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[1]/i";
        private string e_deletebutton = "//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[2]/i";
        private string e_errormessage = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']";
        private string e_successmessage = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']";
        private string e_waitForTab = "//div[@class='ui top attached tabular menu']";
        private string e_AddButton = "//input[@value='Add']";
        private string e_AddLanguageName = "//input[contains(@placeholder, 'Add')]";
        private string e_Addlanguagebutton = "//div[@data-tab='first']//div[@class ='ui teal button ']";
        private string e_updateButton = "//input[@value='Update']";
        private string e_cancelButton = "//input[@value='Cancel']";

        public void CreateLanguage(string language, string languagelevel)
        {
            WaitForPopupToDisappear();
            
            WaitUtils.WaitToBeClickable(driver, "XPath", e_Addlanguagebutton, 10);
            //Click Add New
            addNewLanguageButton.Click();

            WaitUtils.WaitToBeClickable(driver, "XPath", e_AddLanguageName, 10);
            //Enter language
            addLanuageName.SendKeys(language);

            //Choose Lanuage Level
            var selectLanguageDropdown = new SelectElement(dropdownLanguage);
            selectLanguageDropdown.SelectByValue(languagelevel);

            WaitUtils.WaitToBeClickable(driver, "XPath", e_AddButton, 10);

            //Click Add
            AddButton.Click();

        }
        public void UpdateLanguage(string language, string languagelevel)
        {
            WaitUtils.WaitToBeClickable(driver, "XPath", e_editLanguageButton, 20);
            WaitForPopupToDisappear();
            //Click edit button
            editLanguageButton.Click();


            //Edit language
            editLanuage.Clear();
            editLanuage.SendKeys(language);

            //Edit Lanuage Level
            var selectLanguage = new SelectElement(dropdownLanguage);
            selectLanguage.SelectByValue(languagelevel);

            WaitUtils.WaitToBeClickable(driver, "XPath", e_updateButton, 20);
            //Click Update
            buttonUpdate.Click();

            WaitForPopupToDisappear();

            cancelButton.Click();
        }
        public string GetLanguage()
        {
            //Get last record language text
            try
            {

                WaitUtils.WaitToBeVisible(driver, "XPath", e_language, 10);
                return language.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public void DeleteLanguage(string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            bool isLanguageFound = false;

            while (true)
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr")));

                    var rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));

                    foreach (var row in rows)
                    {
                        var cell = row.FindElement(By.CssSelector("td:first-child"));
                        if (cell.Text.Equals(language, StringComparison.OrdinalIgnoreCase))
                        {
                            isLanguageFound = true;
                            buttonDelete.Click();
                            Thread.Sleep(2000); // Wait for deletion to process
                            break;
                        }
                    }

                    if (!isLanguageFound)
                    {
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    // No more delete buttons found, break the loop
                    break;
                }
                catch (WebDriverTimeoutException)
                {
                    // Delete button not found within wait time, break the loop
                    break;
                }
            }
        }

        public string GetErrorMessage()
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", e_errormessage, 3);
            return errormessage.Text;
        }
        public string GetSuccessMessage()  
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", e_successmessage, 3);
            return successmessage.Text;
        }
        public void ClickAnyTab(string tab)
        {
            //Wait for tabs to be visible
            WaitUtils.WaitToBeVisible(driver, "XPath", e_waitForTab, 3);

            //Click on specified tab
            tabOption.Click();
        }
        public void CleanLanguageData()
        {

            while (true)
            {
                try
                {
                    //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")));
                    WaitUtils.WaitToBeVisible(driver, "XPath", e_deletebutton, 10);
                    // Find the delete button for the last record
                    buttonDelete.Click();
                    Thread.Sleep(6000);
                }
                catch (NoSuchElementException)
                {
                    // Break the loop if no more delete buttons are found
                    break;
                }
                catch (WebDriverTimeoutException)
                {
                    // Break the loop if the delete button is not found within the wait time
                    break;
                }
            }


        }


        private void WaitForPopupToDisappear()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='ns-box-inner']")));
            }
            catch (WebDriverTimeoutException)
            {
                // Handle the case where the popup does not disappear within the timeout
                Assert.Fail("The popup did not disappear within the expected time.");
            }
        }
    }

}
