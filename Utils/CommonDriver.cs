
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjecrMarsOnboardingtask.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardTaskProjectMars.Utils
{
    public class CommonDriver
    {
        CommonDriver commonDriverObj;
        public static IWebDriver driver;
        Language languageObj;


        public void Initialization()
        {
            // Initialize WebDriver (Chrome in this case)
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            languageObj = new Language();
        }

        [AfterScenario]
        public void Cleanup()
        {
            driver.Quit();
            driver.Dispose();

            // Cleanup WebDriver

        }

    }
}
