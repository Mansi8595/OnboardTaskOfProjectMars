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
    public class AddLanguagewithEmptyName
    {
        public void CreateLanguagewithEmpty(IWebDriver driver, string Language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target' and @data-tab='first']//div[contains(@class, 'ui teal button') and text()='Add New']")));
            IWebElement AddNewButton = driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target' and @data-tab='first']//div[contains(@class, 'ui teal button') and text()='Add New']"));
            AddNewButton.Click();
            IWebElement language = driver.FindElement(By.Name("name"));
            language.SendKeys(Language);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Add']")));
            IWebElement Add = driver.FindElement(By.XPath("//input[@value='Add']"));
            Add.Click();
        }
        public void GetErrorMessage(IWebDriver driver)
        {
            // Get the error message displayed
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Please enter language and level')]")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Please enter language and level')]"));
            string errorMessageText = errorMessage.Text;
            string expectedMessage = "Please enter language and level";
            Assert.That(errorMessage.Text == expectedMessage, "Record has not been created. Test failed!");
        }

    }
}
