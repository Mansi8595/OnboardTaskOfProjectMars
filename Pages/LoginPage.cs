using Mars_SpecFlowProject1.Utils;
using OnboardTaskProjectMars.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject_MarsProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_SpecFlowProject1.Pages
{
    public class LoginPage : CommonDriver
    {
        LoginPage LoginPageObj;
        public void login()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a")));
            driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a")).Click();
            driver.FindElement(By.Name("email")).SendKeys("mansisolanki1995@gmail.com");
            driver.FindElement(By.Name("password")).SendKeys("4321@Point");
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button")).Click();
        }
    }
}
