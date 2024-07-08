using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject_MarsProject.Pages
{
    [Binding]
    internal class AddSkill
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
            Thread.Sleep(10000);
        }
        public void AssertCreateSkill(IWebDriver driver, string Skill)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That(newSkill.Text == Skill, "New time record has not been created. Test failed!");
        }
        
        
    }
}
