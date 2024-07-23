using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnboardTaskProjectMars.Utils;
using ProjecrMarsOnboardingtask.Pages;

namespace SpecFlowProject_MarsProject.Utils
{
    [Binding]
    public class Hooks1
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly Language languageObj;
        private readonly Skill skillObj;
        private readonly CommonDriver CommonDriverObj;
        private readonly IWebDriver driver;
        public Hooks1(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this.driver = driver;
            languageObj = new Language();
            skillObj = new Skill();
            CommonDriverObj = new CommonDriver();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {

            CommonDriverObj.Initialization();

        }


        [AfterScenario]
        public void AfterScenario()
        {

            try
            {
                // Clean up language data added during the test
                if (_scenarioContext.ContainsKey("Languages"))
                {
                    List<string> Languages = _scenarioContext["Languages"] as List<string>;


                    foreach (var language in Languages)
                    {
                        // Delete the language (assume DeleteLanguage is a method that deletes the language)
                        languageObj.DeleteLanguage(language);

                    }
                }

                if (_scenarioContext.ContainsKey("Skills"))
                {
                    List<string> skills = _scenarioContext["Skills"] as List<string>;

                    foreach (var skill in skills)
                    {
                        // Delete the skill (assuming DeleteSkill is a method that deletes the skill)
                        skillObj.DeleteSkill(skill);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during AfterScenario: " + ex.Message);
            }
            finally
            {
                // Ensure WebDriver cleanup
                CommonDriverObj.Cleanup();
            }
        }
    }
}