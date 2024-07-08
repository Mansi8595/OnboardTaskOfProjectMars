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
    internal class AddSkillwithEmptyName
    {
        public void CreateSkill(IWebDriver driver, string Skill)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-tab='second']")));
            IWebElement SkilltabClick = driver.FindElement(By.XPath("//a[@data-tab='second']"));
            SkilltabClick.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")));
            driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            IWebElement skill = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            skill.SendKeys(Skill);
            IWebElement level = driver.FindElement(By.XPath("//select[@name='level']"));
            level.Click();
            IWebElement levelvalue = driver.FindElement(By.XPath("//div[@class='five wide field']/select[@name='level']/option[@value='Intermediate']"));
            levelvalue.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Add']")));
            IWebElement Add = driver.FindElement(By.XPath("//input[@value='Add']"));
            Add.Click();

        }
        public void GetErrorMessage1(IWebDriver driver)
        {
            // Get the error message displayed
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Please enter skill and experience level')]")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'Please enter skill and experience level')]"));
            string errorMessageText = errorMessage.Text;
            string expectedMessage = "Please enter skill and experience level";
            Assert.That(errorMessage.Text == expectedMessage, "Record has not been created. Test failed!");
        }
    }
}
