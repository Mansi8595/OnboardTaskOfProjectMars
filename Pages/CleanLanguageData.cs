using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mars_SpecFlowProject1.Utils;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Mars_SpecFlowProject1.Pages
{
    internal class CleanLanguageData
    {
        public void Deletelanguage(IWebDriver driver)
        {
             WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
          
            while (true)
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")));

                    // Find the delete button for the last record
                    IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
                    deleteButton.Click();
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
        public void AssertDeletelanguage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-tab='first'] .ui.fixed.table")));

            var rows = driver.FindElements(By.CssSelector("div[data-tab='first'] .ui.fixed.table tbody tr"));
            Assert.That(rows.Count == 0, "All records have been successfully deleted.");

        }

    }
}
