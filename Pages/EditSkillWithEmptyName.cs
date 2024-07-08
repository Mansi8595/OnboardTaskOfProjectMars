using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjecrMarsOnboardingtask.Pages
{
    internal class EditSkillWithEmptyName
    {
        public void Editskill(IWebDriver driver, string Skill)
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i")));
            //IWebElement editrecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement Skilltab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            Skilltab.Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i")));
            IWebElement editrecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
            editrecord.Click();
            IWebElement editlanguage = driver.FindElement(By.Name("name"));
            editlanguage.Clear();
            editlanguage.SendKeys(Skill);
            // Select Level 
            IWebElement level = driver.FindElement(By.XPath("//select[@name='level']"));
            level.Click();
            // Enter code
            IWebElement levelvalue = driver.FindElement(By.XPath("//div[@class='five wide field']/select[@name='level']/option[@value='Intermediate']"));
            levelvalue.Click();

            //Click update
            IWebElement update = driver.FindElement(By.XPath("//input[@value='Update']"));
            update.Click();
            

        }
        public void GetErrorMessage1(IWebDriver driver)
        {
            // Get the error message displayed
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This skill is already added to your skill list.')]")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and contains(text(), 'This skill is already added to your skill list.')]"));
            string errorMessageText = errorMessage.Text;
            string expectedMessage = "This skill is already added to your skill list.";
            Assert.That(errorMessage.Text == expectedMessage, "Record has not been created. Test failed!");
        }
    }
}
