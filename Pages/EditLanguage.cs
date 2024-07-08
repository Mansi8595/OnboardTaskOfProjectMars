using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_SpecFlowProject1.Pages
{
    internal class EditLanguage
    {
        public void Editlanguage(IWebDriver driver, string Language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i")));
            IWebElement editrecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
           
            editrecord.Click();
            IWebElement editlanguage = driver.FindElement(By.Name("name"));
            editlanguage.Clear();
            editlanguage.SendKeys(Language);
            // Select Level 
            IWebElement level = driver.FindElement(By.XPath("//select[@name='level']"));
            level.Click();
            // Enter code
            IWebElement levelvalue = driver.FindElement(By.XPath("//div[@class='five wide field']/select[@name='level']/option[@value='Fluent']"));
            levelvalue.Click();

            //Click update
            IWebElement update = driver.FindElement(By.XPath("//input[@value='Update']"));
            update.Click();
            Thread.Sleep(10000);

        }
        public void AssertEditlanguage(IWebDriver driver, string language)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            IWebElement newlanguage = driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            Assert.That(newlanguage.Text == language, "New time record has not been created. Test failed!");
        }
    } 
}
