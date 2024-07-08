using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardTaskProjectMars.Pages
{
    public class AddlanguagewithDuplicateEntry
    {
        public void CreateLanguagewithDuplicate(IWebDriver driver, string Language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target' and @data-tab='first']//div[contains(@class, 'ui teal button') and text()='Add New']")));
            IWebElement AddNewButton = driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target' and @data-tab='first']//div[contains(@class, 'ui teal button') and text()='Add New']"));
            AddNewButton.Click();
            IWebElement language = driver.FindElement(By.Name("name"));
            language.SendKeys(Language);
            IWebElement level = driver.FindElement(By.XPath("//select[@name='level']"));
            level.Click();
            IWebElement levelvalue = driver.FindElement(By.XPath("//div[@class='five wide field']/select[@name='level']/option[@value='Fluent']"));
            levelvalue.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Add']")));
            IWebElement Add = driver.FindElement(By.XPath("//input[@value='Add']"));
            Add.Click();
        }
        public void GetErrorMessage(IWebDriver driver)
        {
            // Get the error message displayed
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This language is already exist in your language list.')]")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This language is already exist in your language list.')]"));
            string errorMessageText = errorMessage.Text;
            string expectedMessage = "This language is already exist in your language list.";
            Assert.That(errorMessage.Text == expectedMessage, "Record has not been created. Test failed!");
        }

    }
}
