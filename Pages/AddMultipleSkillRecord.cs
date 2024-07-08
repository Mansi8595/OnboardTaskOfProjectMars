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
    [Binding]
    internal class AddMultipleSkillRecord
    {
        public void CreateMultipleSkill(IWebDriver driver, string Skill)
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
        public void AssertCreateSkill(IWebDriver driver, string[] skills)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]")));
            //IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            //Assert.That(newSkill.Text == Skill, "New time record has not been created. Test failed!");

            for (int i = 0; i < skills.Length; i++)
            {
                string skill = skills[i];
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]")));
                IWebElement skillElement = driver.FindElement(By.XPath($"//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]"));
                string actualSkillText = skillElement.Text.Trim();
                if (!string.Equals(actualSkillText, skill, StringComparison.OrdinalIgnoreCase))
                {
                    throw new AssertionException($"Expected language '{skill}' at row {i + 1}, but found '{actualSkillText}'. Test failed!");
                }
            }
        }
    }
}
