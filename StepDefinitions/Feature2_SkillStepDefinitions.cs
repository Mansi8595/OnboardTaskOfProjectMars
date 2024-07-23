using Mars_SpecFlowProject1.Pages;
using NUnit.Framework;
using OnboardTaskProjectMars.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProjecrMarsOnboardingtask.Pages;
using System;
using TechTalk.SpecFlow;

namespace ProjecrMarsOnboardingtask.StepDefinitions
{
    [Binding, Scope(Feature = "Feature2_Skill")]
    public class Feature2_SkillStepDefinitions : CommonDriver
    {
        private readonly ScenarioContext _scenarioContext;
        Skill skillObj;
        LoginPage LoginPageObj;
        public Feature2_SkillStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            skillObj = new Skill();
        }

        [Given(@"User Logs into Mars")]
        public void GivenUserLogsIntoMars()
        {
            LoginPageObj = new LoginPage();
            LoginPageObj.login();
        }


        [Given(@"User navigate to Skill tab")]
        public void GivenUserNavigateToSkillTab()
        {
            skillObj.ClickAnyTab("Skills");
        }


        [When(@"User add a new Skill record '([^']*)' '([^']*)'")]
        public void WhenUserAddANewSkillRecord(string skill, string skillLevel)
        {
            skillObj.CreateSkill(skill, skillLevel);
            if (_scenarioContext.ContainsKey("Skills"))
            {
                var Skills = _scenarioContext["Skills"] as List<string>;

                if (Skills != null)
                {
                    Skills.Add(skill);
                }
                else
                {
                    _scenarioContext["Skills"] = new List<string> { skill };
                }
            }
            else
            {
                _scenarioContext["Skills"] = new List<string> { skill };
            }
        }

        [Then(@"new record should be successfully created '([^']*)'")]
        public void ThenNewRecordShouldBeSuccessfullyCreated(string skill)
        {

            string message = skillObj.GetSuccessMessage();
            string assertMessage = skill + " has been added to your skills";
            Assert.That(message == assertMessage, "Actual message and Expected message do not match");

            //check language and language level are created successfully
            string addedskill = skillObj.GetSkill();
            Assert.That(addedskill == skill, "Actual language and Expected language do not match");

        }

        [When(@"User deletes All Skills record")]
        public void WhenUserDeletesAllSkillsRecord()
        {
            skillObj.CleanSkillData();
        }

        [Then(@"All Skills record should be successfully deleted")]
        public void ThenAllSkillsRecordShouldBeSuccessfullyDeleted()
        {
            var rows = driver.FindElements(By.CssSelector("div[data-tab='second'] .ui.fixed.table tbody tr"));
            Assert.That(rows.Count == 0, "All records have been successfully deleted.");
        }
        [Then(@"Error message ""([^""]*)"" should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed(string errorMessage)
        {
            string actualErrorMessage = skillObj.GetErrorMessage();
            string expectedErrorMessage = errorMessage;
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"Expected error message: '{expectedErrorMessage}', but got: '{actualErrorMessage}'");
        }
        [When(@"User tries to create a new Skill record which is already created before in record '([^']*)' '([^']*)'")]
        public void WhenUserTriesToCreateANewSkillRecordWhichIsAlreadyCreatedBeforeInRecord(string skill, string skillLevel)
        {
            skillObj.CreateSkill(skill, skillLevel);
            if (_scenarioContext.ContainsKey("Skills"))
            {
                var Skills = _scenarioContext["Skills"] as List<string>;

                if (Skills != null)
                {
                    Skills.Add(skill);
                }
                else
                {
                    _scenarioContext["Skills"] = new List<string> { skill };
                }
            }
            else
            {
                _scenarioContext["Skills"] = new List<string> { skill };
            }
        }

        [Then(@"Error message for duplicate entry ""([^""]*)"" should be displayed")]
        public void ThenErrorMessageForDuplicateEntryShouldBeDisplayed(string errorMessage)
        {
            string actualErrorMessage = skillObj.GetErrorMessage();
            string expectedErrorMessage = errorMessage;
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"Expected error message: '{expectedErrorMessage}', but got: '{actualErrorMessage}'");
        }
        [When(@"User add multiple Skills record")]
        public void WhenUserAddMultipleSkillsRecord(Table table)
        {
            List<string> Skills = new List<string>();

            foreach (var row in table.Rows)
            {
                string skill = row["Skill"];
                string Skilllevel = row["Level"];
                skillObj.CreateSkill(skill, Skilllevel);
                Skills.Add(skill);
            }

            _scenarioContext["Skills"] = Skills;
        }

        [Then(@"All Skill record should be successfully created")]
        public void ThenAllSkillRecordShouldBeSuccessfullyCreated()
        {
            if (!_scenarioContext.ContainsKey("Skills"))
            {
                throw new InvalidOperationException("No skills were stored in scenario context.");
            }

            var expectedSkills = (List<string>)_scenarioContext["Skills"];

            // Ensure the list is not empty
            if (expectedSkills == null || !expectedSkills.Any())
            {
                throw new InvalidOperationException("Expected skills list is empty.");
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var actualSkills = new List<string>();

            for (int i = 0; i < expectedSkills.Count; i++)
            {
                // Wait for each language element to be visible
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]")));

                // Get the actual language text
                IWebElement skillElement = driver.FindElement(By.XPath($"/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]"));
                actualSkills.Add(skillElement.Text.Trim());
            }

            // Compare actual languages with expected languages
            for (int i = 0; i < expectedSkills.Count; i++)
            {
                string expectedSkill = expectedSkills[i];
                string actualSkill = actualSkills[i];

                if (!string.Equals(actualSkill, expectedSkill, StringComparison.OrdinalIgnoreCase))
                {
                    throw new AssertionException($"Expected skill '{expectedSkill}' at row {i + 1}, but found '{actualSkill}'. Test failed!");
                }
            }

        }

        [Then(@"The following error messages should be displayed")]
        public void ThenTheFollowingErrorMessagesShouldBeDisplayed(Table table)
        {
            {
                var expectedMessages = table.Rows.Select(row => row["Expected Message"]).ToList();
                var actualMessages = new List<string>();

                foreach (var expectedMessage in expectedMessages)
                {
                    string actualMessage = skillObj.GetErrorMessage();
                    actualMessages.Add(actualMessage);

                    if (actualMessage != expectedMessage)
                    {
                        Assert.Fail($"Validation error message mismatch: Expected '{expectedMessage}' but got '{actualMessage}'");
                    }
                }

                Assert.That(actualMessages, Is.EquivalentTo(expectedMessages), "Actual messages do not match expected messages.");
            }

        }
        [When(@"User edits Skill record '([^']*)' '([^']*)'")]
        public void WhenUserEditsSkillRecord(string skill, string skillLevel)
        {
            skillObj.UpdateSkill(skill, skillLevel);
            if (_scenarioContext.ContainsKey("Skills"))
            {
                var skills = _scenarioContext["Skills"] as List<string>;

                if (skills != null)
                {
                    skills.Add(skill);
                }
                else
                {
                    _scenarioContext["Skills"] = new List<string> { skill };
                }
            }
            else
            {
                _scenarioContext["Skills"] = new List<string> { skill };
            }
        }


        [Then(@"Skill record should be successfully updated '([^']*)'")]
        public void ThenSkillRecordShouldBeSuccessfullyUpdated(string skill)
        {
            string message = skillObj.GetSuccessMessage();
            string assertMessage = skill + " has been updated to your skills";
            Assert.That(message == assertMessage, "Actual message and Expected message do not match");
            //check language and language level are created successfully
            string updatedSkill = skillObj.GetSkill();
            Assert.That(updatedSkill == skill, "Actual language and Expected language do not match");
        }


        [Then(@"""([^""]*)"" error should be displayed and '([^']*)' Skill is not updated")]
        public void ThenErrorShouldBeDisplayedAndSkillIsNotUpdated(string errorMessage, string skill)
        {
            string actualErrorMessage = skillObj.GetErrorMessage();
            string expectedErrorMessage = errorMessage;
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"Expected error message: '{expectedErrorMessage}', but got: '{actualErrorMessage}'");
        }

        [Then(@"""([^""]*)"" error should be displayed")]
        public void ThenErrorShouldBeDisplayed(string errorMessage)
        {
            string actualErrorMessage = skillObj.GetErrorMessage();
            string expectedErrorMessage = errorMessage;
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"Expected error message: '{expectedErrorMessage}', but got: '{actualErrorMessage}'");
        }
        [When(@"User delete Skill record '([^']*)'")]
        public void WhenUserDeletesSkillRecord(string skill)
        {
            _scenarioContext["Skill"] = new
            {
                Skill = skill
            };
            skillObj.DeleteSkill(skill);
        }

        [Then(@"new Skill record should be successfully deleted")]
        public void ThenNewSkillRecordShouldBeSuccessfullyDeleted()
        {
            if (!_scenarioContext.ContainsKey("Skill"))
            {
                throw new InvalidOperationException("No deleted skill record was found in scenario context.");
            }

            var deletedSkill = _scenarioContext["Skill"].ToString();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-tab='second'] .ui.fixed.table")));

            var rows = driver.FindElements(By.CssSelector("div[data-tab='second'] .ui.fixed.table tbody tr"));

            bool isSkillDeleted = true;

            foreach (var row in rows)
            {
                var cell = row.FindElement(By.CssSelector("td:first-child"));
                if (cell.Text.Equals(deletedSkill, StringComparison.OrdinalIgnoreCase))
                {
                    isSkillDeleted = false;
                    break;
                }
            }

            Assert.That(isSkillDeleted, $"Record '{deletedSkill}' hasn't been deleted successfully. Test Failed");
        }


        [Then(@"new Skill record should not deleted")]
        public void ThenNewSkillRecordShouldNotDeleted()
        {
            if (!_scenarioContext.ContainsKey("Skill"))
            {
                throw new InvalidOperationException("No deleted skill record was found in scenario context.");
            }

            var deletedSkill = _scenarioContext["Skill"].ToString();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-tab='second'] .ui.fixed.table")));

            var rows = driver.FindElements(By.CssSelector("div[data-tab='second'] .ui.fixed.table tbody tr"));

            bool isSkillDeleted = true;

            foreach (var row in rows)
            {
                var cell = row.FindElement(By.CssSelector("td:first-child"));
                if (cell.Text.Equals(deletedSkill, StringComparison.OrdinalIgnoreCase))
                {
                    isSkillDeleted = false;
                    break;
                }
            }

            Assert.That(isSkillDeleted, $"Record '{deletedSkill}' hasn't been deleted successfully. Test Failed");
        }
    }
}
