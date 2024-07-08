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
    internal class DeleteLanguage
    {
        public void Deletelanguage(IWebDriver driver, string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            
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
                            var deleteButton = row.FindElement(By.CssSelector("td.right.aligned .remove.icon")); // Replace with actual selector
                            deleteButton.Click();
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

        public void AssertDeletelanguage(IWebDriver driver, string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-tab='first'] .ui.fixed.table")));

            var rows = driver.FindElements(By.CssSelector("div[data-tab='first'] .ui.fixed.table tbody tr"));

            if (rows.Count == 0)
            {
                Assert.Pass("All records have been successfully deleted.");
                return;
            }

            bool isLanguageDeleted = true;
            foreach (var row in rows)
            {
                var cell = row.FindElement(By.CssSelector("td:first-child"));
                if (cell.Text.Equals(language, StringComparison.OrdinalIgnoreCase))
                {
                    isLanguageDeleted = false;
                    break;
                }
            }

            Assert.That(isLanguageDeleted, $"Record '{language}' hasn't been deleted successfully. Test Failed");
        }
    }
}