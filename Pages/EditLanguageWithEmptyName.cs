using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OnboardTaskProjectMars.Pages
{
    public class EditLanguageWithEmptyName
    {
        public void EditlanguagewithEmptyName(IWebDriver driver, string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i")));
            IWebElement editrecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));

            editrecord.Click();
            IWebElement editlanguage = driver.FindElement(By.Name("name"));
            editlanguage.Clear();
            editlanguage.SendKeys(language);
            // Select Level 
            IWebElement level = driver.FindElement(By.XPath("//select[@name='level']"));
            level.Click();
            // Enter code
            IWebElement levelvalue = driver.FindElement(By.XPath("//div[@class='five wide field']/select[@name='level']/option[@value='Fluent']"));
            levelvalue.Click();
            //Click update
            IWebElement update = driver.FindElement(By.XPath("//input[@value='Update']"));
            update.Click();
            Thread.Sleep(1000);
            }
        public void GetErrorMessage(IWebDriver driver)
        {
            // Get the error message displayed
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(0.5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This language is already added to your language list.')]")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This language is already added to your language list.')]"));
            string errorMessageText = errorMessage.Text;
            string expectedMessage = "This language is already added to your language list.";
            Assert.That(errorMessage.Text == expectedMessage, "Record has not been created. Test failed!");
        }
    }
}
