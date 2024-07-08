using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject_MarsProject.Utils
{
    public class HookBase
    {
        protected static IWebDriver driver;
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            // Initialize WebDriver (Chrome in this case)
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Cleanup WebDriver
            driver.Quit();
            driver.Dispose();
        }
    }
}
