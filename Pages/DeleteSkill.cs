using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecrMarsOnboardingtask.Pages
{
    internal class DeleteSkill
    {
        public void Deleteskill(IWebDriver driver, string Skill)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement Skilltab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            Skilltab.Click();
            bool isSkillFound = false;

            while (true)
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr")));

                    var rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));

                    foreach (var row in rows)
                    {
                        var cell = row.FindElement(By.CssSelector("td:first-child"));
                        if (cell.Text.Equals(Skill, StringComparison.OrdinalIgnoreCase))
                        {
                            isSkillFound = true;
                            var deleteButton = row.FindElement(By.CssSelector("td.right.aligned .remove.icon")); // Replace with actual selector
                            deleteButton.Click();
                            Thread.Sleep(2000); // Wait for deletion to process
                            break;
                        }
                    }

                    if (!isSkillFound)
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
        public void AssertDeleteskill(IWebDriver driver, string Skill)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-tab='second'] .ui.fixed.table")));

            var rows = driver.FindElements(By.CssSelector("div[data-tab='second'] .ui.fixed.table tbody tr"));

            if (rows.Count == 0)
            {
                Assert.Pass("All records have been successfully deleted.");
                return;
            }

            bool isSkillDeleted = true;
            foreach (var row in rows)
            {
                var cell = row.FindElement(By.CssSelector("td:first-child"));
                if (cell.Text.Equals(Skill, StringComparison.OrdinalIgnoreCase))
                {
                    isSkillDeleted = false;
                    break;
                }
            }

            Assert.That(isSkillDeleted, $"Record '{Skill}' hasn't been deleted successfully. Test Failed");
        }
    }
}
