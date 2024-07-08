using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace OnboardTaskProjectMars.Pages
{
    public class AddMultipleLanguageRecord
    {
        public void CreateMultipleLanguage(IWebDriver driver, string Language)
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
         public void AssertAllLanguages(IWebDriver driver, string[] languages)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr")));
            for (int i = 0; i < languages.Length; i++)
            {
                string language = languages[i];
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]")));
                IWebElement languageElement = driver.FindElement(By.XPath($"/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]"));
                string actualLanguageText = languageElement.Text.Trim();
                if (!string.Equals(actualLanguageText, language, StringComparison.OrdinalIgnoreCase))
                {
                    throw new AssertionException($"Expected language '{language}' at row {i + 1}, but found '{actualLanguageText}'. Test failed!");
                }
            }
        }
    }
}
