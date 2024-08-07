using Mars_SpecFlowProject1.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OnboardTaskProjectMars.Utils;
using ProjecrMarsOnboardingtask.Pages;
using OpenQA.Selenium.Support.UI;

namespace ProjecrMarsOnboardingtask.StepDefinitions
{
    [Binding, Scope(Feature = "Feature1_Language")]
    public class Feature1_LanguageStepDefinitions : CommonDriver
    {
        private readonly ScenarioContext _scenarioContext;
        Language languageObj;
        LoginPage LoginPageObj;
        public Feature1_LanguageStepDefinitions(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
            languageObj = new Language();
        }

        [Given(@"User Logs into Mars")]
        public void GivenUserLogsIntoMars()
        {

            LoginPageObj = new LoginPage();
            LoginPageObj.login();
        }

        [Given(@"User navigate to language tab")]
        public void GivenUserNavigateToLanguageTab()
        {
            languageObj.ClickAnyTab("Languages");
        }

        [When(@"User add a new Language record '([^']*)' '([^']*)'")]
        public void WhenUserAddANewLanguageRecord(string language, string languageLevel)
        {
            languageObj.CreateLanguage(language, languageLevel);
            if (_scenarioContext.ContainsKey("Languages"))
            {
                var languages = _scenarioContext["Languages"] as List<string>;

                if (languages != null)
                {
                    languages.Add(language);
                }
                else
                {
                    _scenarioContext["Languages"] = new List<string> { language };
                }
            }
            else
            {
                _scenarioContext["Languages"] = new List<string> { language };
            }
        }


        [Then(@"new record should be successfully created '([^']*)'")]
        public void ThenNewRecordShouldBeSuccessfullyCreated(string language)
        {

            string message = languageObj.GetSuccessMessage();
            string assertMessage = language + " has been added to your languages";
            Assert.That(message == assertMessage, "Actual message and Expected message do not match");

            //check language and language level are created successfully
            string addedLanguage = languageObj.GetLanguage();
            Assert.That(addedLanguage == language, "Actual language and Expected language do not match");

        }

        [When(@"User deletes All languages record")]
        public void WhenUserDeletesAllLanguagesRecord()
        {
            languageObj.CleanLanguageData();
        }

        [Then(@"All Languages record should be successfully deleted")]
        public void ThenAllLanguagesRecordShouldBeSuccessfullyDeleted()
        {
            var rows = driver.FindElements(By.CssSelector("div[data-tab='first'] .ui.fixed.table tbody tr"));
            Assert.That(rows.Count == 0, "All records have been successfully deleted.");

        }

        [When(@"User adds a new Language record '([^']*)' '([^']*)'")]
        public void WhenUserAddsANewLanguageRecord(string language, string languageLevel)
        {
            languageObj.CreateLanguage(language, languageLevel);
            if (_scenarioContext.ContainsKey("Languages"))
            {
                var languages = _scenarioContext["Languages"] as List<string>;

                if (languages != null)
                {
                    languages.Add(language);
                }
                else
                {
                    _scenarioContext["Languages"] = new List<string> { language };
                }
            }
            else
            {
                _scenarioContext["Languages"] = new List<string> { language };
            }
        }

        [Then(@"Error message ""([^""]*)"" should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed(string message)
        {
            string actualErrorMessage = languageObj.GetErrorMessage();
            string expectedErrorMessage = message;
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"Expected error message: '{expectedErrorMessage}', but got: '{actualErrorMessage}'");
        }

        [When(@"User tries to create a new Language record which is already created before in record '([^']*)' '([^']*)'")]
        public void WhenUserTriesToCreateANewLanguageRecordWhichIsAlreadyCreatedBeforeInRecord(string language, string languageLevel)
        {
            languageObj.CreateLanguage(language, languageLevel);
            if (_scenarioContext.ContainsKey("Languages"))
            {
                var languages = _scenarioContext["Languages"] as List<string>;

                if (languages != null)
                {
                    languages.Add(language);
                }
                else
                {
                    _scenarioContext["Languages"] = new List<string> { language };
                }
            }
            else
            {
                _scenarioContext["Languages"] = new List<string> { language };
            }
        }

        [Then(@"Error message for duplicate entry ""([^""]*)"" should be displayed")]
        public void ThenErrorMessageForDuplicateEntryShouldBeDisplayed(string errorMessage)
        {
            string actualErrorMessage = languageObj.GetErrorMessage();
            string expectedErrorMessage = errorMessage;
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"Expected error message: '{expectedErrorMessage}', but got: '{actualErrorMessage}'");
        }

        [When(@"User add multiple Languages record")]
        public void WhenUserAddMultipleLanguagesRecord(Table table)
        {
            List<string> languages = new List<string>();

            foreach (var row in table.Rows)
            {
                string language = row["Language"];
                string languageLevel = row["Level"];
                languageObj.CreateLanguage(language, languageLevel);
                languages.Add(language);
            }

            _scenarioContext["Languages"] = languages;
        }

        [Then(@"All Language record should be successfully created")]
        public void ThenAllLanguageRecordShouldBeSuccessfullyCreated()
        {

            if (!_scenarioContext.ContainsKey("Languages"))
            {
                throw new InvalidOperationException("No languages were stored in scenario context.");
            }

            var expectedLanguages = (List<string>)_scenarioContext["Languages"];

            // Ensure the list is not empty
            if (expectedLanguages == null || !expectedLanguages.Any())
            {
                throw new InvalidOperationException("Expected languages list is empty.");
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var actualLanguages = new List<string>();

            for (int i = 0; i < expectedLanguages.Count; i++)
            {
                // Wait for each language element to be visible
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]")));

                // Get the actual language text
                IWebElement languageElement = driver.FindElement(By.XPath($"/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[{i + 1}]/tr/td[1]"));
                actualLanguages.Add(languageElement.Text.Trim());
            }

            // Compare actual languages with expected languages
            for (int i = 0; i < expectedLanguages.Count; i++)
            {
                string expectedLanguage = expectedLanguages[i];
                string actualLanguage = actualLanguages[i];

                if (!string.Equals(actualLanguage, expectedLanguage, StringComparison.OrdinalIgnoreCase))
                {
                    throw new AssertionException($"Expected language '{expectedLanguage}' at row {i + 1}, but found '{actualLanguage}'. Test failed!");
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
                    string actualMessage = languageObj.GetErrorMessage();
                    actualMessages.Add(actualMessage);

                    if (actualMessage != expectedMessage)
                    {
                        Assert.Fail($"Validation error message mismatch: Expected '{expectedMessage}' but got '{actualMessage}'");
                    }
                }

                Assert.That(actualMessages, Is.EquivalentTo(expectedMessages), "Actual messages do not match expected messages.");
            }
        }


        [Then(@"User should not see Add button to add (.*)th language record")]
        public void ThenUserShouldNotSeeAddButtonToAddThLanguageRecord(int p0)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                // Wait until the element is either visible or the timeout is reached
                var addButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-tab='first']//div[contains(@class, 'ui teal button')]")));

                // If the button is found, fail the test
                Assert.Fail("Add button for additional language records should not be visible.");
            }
            catch (NoSuchElementException)
            {
                // If the button is not found, the test will pass
                // Optionally, log a message or take a screenshot for debugging
            }
            catch (WebDriverTimeoutException)
            {
                // If the button is not found within the wait time, the test will pass
                // Optionally, log a message or take a screenshot for debugging
            }
        }


        [When(@"User edits language record '([^']*)' '([^']*)'")]
        public void WhenUserEditsLanguageRecordBasic(string language, string languageLevel)
        {
            languageObj.UpdateLanguage(language, languageLevel);
            if (_scenarioContext.ContainsKey("Languages"))
            {
                var languages = _scenarioContext["Languages"] as List<string>;

                if (languages != null)
                {
                    languages.Add(language);
                }
                else
                {
                    _scenarioContext["Languages"] = new List<string> { language };
                }
            }
            else
            {
                _scenarioContext["Languages"] = new List<string> { language };
            }
        }

        [Then(@"Language record should be successfully updated '([^']*)'")]
        public void ThenLanguageRecordShouldBeSuccessfullyUpdated(string language)
        {
            string message = languageObj.GetSuccessMessage();
            string assertMessage = language + " has been updated to your languages";
            Assert.That(message == assertMessage, "Actual message and Expected message do not match");
            //check language and language level are created successfully
            string updatedLanguage = languageObj.GetLanguage();
            Assert.That(updatedLanguage == language, "Actual language and Expected language do not match");
        }

        [When(@"User add new Language record '([^']*)' '([^']*)'")]
        public void WhenUserAddNewLanguageRecord(string language, string languageLevel)
        {
            languageObj.CreateLanguage(language, languageLevel);
            if (_scenarioContext.ContainsKey("Languages"))
            {
                var languages = _scenarioContext["Languages"] as List<string>;

                if (languages != null)
                {
                    languages.Add(language);
                }
                else
                {
                    _scenarioContext["Languages"] = new List<string> { language };
                }
            }
            else
            {
                _scenarioContext["Languages"] = new List<string> { language };
            }
        }


        [When(@"User tries to edit a new Language record with '([^']*)' '([^']*)'")]
        public void WhenUserTriesToEditANewLanguageRecordWith(string language, string languageLevel)
        {
            languageObj.UpdateLanguage(language, languageLevel);
            if (_scenarioContext.ContainsKey("Languages"))
            {
                var languages = _scenarioContext["Languages"] as List<string>;

                if (languages != null)
                {
                    languages.Add(language);
                }
                else
                {
                    _scenarioContext["Languages"] = new List<string> { language };
                }
            }
            else
            {
                _scenarioContext["Languages"] = new List<string> { language };
            }

        }

        [Then(@"""([^""]*)"" error should be displayed and '([^']*)' language is not updated")]
        public void ThenErrorShouldBeDisplayedAndLanguageIsNotUpdated(string errorMessage, string language)
        {
            string actualErrorMessage = languageObj.GetErrorMessage();
            string expectedErrorMessage = errorMessage;
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"Expected error message: '{expectedErrorMessage}', but got: '{actualErrorMessage}'");
        }
        [Then(@"""([^""]*)"" error should be displayed and '([^']*)' language is not update")]
        public void ThenErrorShouldBeDisplayedAndLanguageIsNotUpdate(string errorMessage, string language)
        {
            string actualErrorMessage = languageObj.GetErrorMessage();
            string expectedErrorMessage = errorMessage;
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"Expected error message: '{expectedErrorMessage}', but got: '{actualErrorMessage}'");

        }


        [When(@"User deletes language record '([^']*)'")]
        public void WhenUserDeletesLanguageRecord(string language)
        {
            _scenarioContext["Language"] = new
            {
                Language = language
            };
            languageObj.DeleteLanguage(language);

        }
        [Then(@"new Language record should be successfully deleted")]
        public void ThenNewLanguageRecordShouldBeSuccessfullyDeleted()
        {
            if (!_scenarioContext.ContainsKey("Language"))
            {
                throw new InvalidOperationException("No deleted language record was found in scenario context.");
            }

            var deletedLanguage = _scenarioContext["Language"].ToString();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-tab='first'] .ui.fixed.table")));

            var rows = driver.FindElements(By.CssSelector("div[data-tab='first'] .ui.fixed.table tbody tr"));

            bool isLanguageDeleted = true;

            foreach (var row in rows)
            {
                var cell = row.FindElement(By.CssSelector("td:first-child"));
                if (cell.Text.Equals(deletedLanguage, StringComparison.OrdinalIgnoreCase))
                {
                    isLanguageDeleted = false;
                    break;
                }
            }

            Assert.That(isLanguageDeleted, $"Record '{deletedLanguage}' hasn't been deleted successfully. Test Failed");
        }
        [Then(@"new Language record should not deleted")]
        public void ThenNewLanguageRecordShouldNotDeleted()
        {
            if (!_scenarioContext.ContainsKey("Language"))
            {
                throw new InvalidOperationException("No deleted language record was found in scenario context.");
            }

            var deletedLanguage = _scenarioContext["Language"].ToString();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-tab='first'] .ui.fixed.table")));

            var rows = driver.FindElements(By.CssSelector("div[data-tab='first'] .ui.fixed.table tbody tr"));

            bool isLanguageDeleted = true;

            foreach (var row in rows)
            {
                var cell = row.FindElement(By.CssSelector("td:first-child"));
                if (cell.Text.Equals(deletedLanguage, StringComparison.OrdinalIgnoreCase))
                {
                    isLanguageDeleted = false;
                    break;
                }
            }

            Assert.That(isLanguageDeleted, $"Record '{deletedLanguage}' hasn't been deleted successfully. Test Failed");
        }

    }
}
