using Mars_SpecFlowProject1.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Mars_SpecFlowProject1.Utils;
using NUnit.Framework;
using SpecFlowProject_MarsProject.Utils;
using OnboardTaskProjectMars.Pages;

namespace ProjecrMarsOnboardingtask.StepDefinitions
{
    [Binding, Scope(Feature = "Feature1_Language")]
    public class Feature1_LanguageStepDefinitions : HookBase
    {
        private readonly LoginPage loginPageObj;
        private readonly AddLanguageTab languageTabObj;
        private readonly EditLanguage editLanguageObj;
        private readonly DeleteLanguage deleteLanguageObj;
        private readonly AddLanguagewithEmptyName addLanguagewithEmptyNameObj;
        private readonly AddlanguagewithDuplicateEntry addLanguagewithDuplicateEntryObj;
        private readonly AddMultipleLanguageRecord AddMultipleLanguageRecordObj;
        private readonly EditLanguageWithEmptyName editLanguageWithEmptyNameObj;
        private readonly EditLanguageWithDuplicateEntry editLanguageWithDuplicateEntryObj;
        private readonly CleanLanguageData cleanLanguageDataObj;
        public Feature1_LanguageStepDefinitions()
        {
            loginPageObj = new LoginPage();
            languageTabObj = new AddLanguageTab();
            editLanguageObj = new EditLanguage();
            deleteLanguageObj = new DeleteLanguage();
            addLanguagewithEmptyNameObj = new AddLanguagewithEmptyName();
            addLanguagewithDuplicateEntryObj = new AddlanguagewithDuplicateEntry();
            AddMultipleLanguageRecordObj = new AddMultipleLanguageRecord();
            editLanguageWithEmptyNameObj = new EditLanguageWithEmptyName();
            editLanguageWithDuplicateEntryObj = new EditLanguageWithDuplicateEntry();
            cleanLanguageDataObj = new CleanLanguageData();

        }
       
        [Given(@"User Logs into Mars portal and navigates to language tab")]
        public void GivenUserLogsIntoMarsPortalAndNavigatesToLanguageTab()
        {
            loginPageObj.login(driver);
        }
        // Clean data
        [When(@"User deletes All languages record")]
        public void WhenUserDeletesAllLanguagesRecord()
        {
            cleanLanguageDataObj.Deletelanguage(driver);
        }

        [Then(@"All Languages record should be successfully deleted")]
        public void ThenAllLanguagesRecordShouldBeSuccessfullyDeleted()
        {
            cleanLanguageDataObj.AssertDeletelanguage(driver);
        }

        //Add language
        [Given(@"Clean the data before test")]
        public void GivenCleanTheDataBeforeTest()
        {
            cleanLanguageDataObj.Deletelanguage(driver);
        }

        [When(@"User creates a new Language record '([^']*)'")]
        public void WhenUserCreatesANewLanguageRecord(string language)
        {
            languageTabObj.CreateLanguage(driver, language);
        }

        [Then(@"new Language record should be successfully created '([^']*)'")]
        public void ThenNewLanguageRecordShouldBeSuccessfullyCreated(string language)
        {
            languageTabObj.AssertCreateLanguage(driver, language);
        }

      
        [When(@"User tries to create a new Language record with an empty name '([^']*)'")]
        public void WhenUserTriesToCreateANewLanguageRecordWithAnEmptyName(string language)
        {
          addLanguagewithEmptyNameObj.CreateLanguagewithEmpty(driver, language);   
        }

        [Then(@"an error message ""([^""]*)"" should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            addLanguagewithEmptyNameObj.GetErrorMessage(driver);
        }

        [Given(@"Craete A new data '([^']*)'")]
        public void GivenCraeteANewData(string language)
        {
            languageTabObj.CreateLanguage(driver, language);
        }

        [When(@"User tries to create a new Language record which is already created before in record '([^']*)'")]
        public void WhenUserTriesToCreateANewLanguageRecordWhichIsAlreadyCreatedBeforeInRecord(string language)
        {
            addLanguagewithDuplicateEntryObj.CreateLanguagewithDuplicate(driver, language);
        }

        [Then(@"Duplicate entry error message ""([^""]*)"" should be displayed")]
        public void ThenDuplicateEntryErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            addLanguagewithDuplicateEntryObj.GetErrorMessage(driver);
        }

      
        [When(@"User creates a new Language records")]
        public void WhenUserCreatesANewLanguageRecords(Table table)
        {                     
            foreach (var row in table.Rows)
            {
                string languages = row["Language"];
                AddMultipleLanguageRecordObj.CreateMultipleLanguage(driver, languages);
            }
        }

        [Then(@"All Language record should be successfully created")]
        public void ThenAllLanguageRecordShouldBeSuccessfullyCreated(Table table)
        {
            var expectedLanguages = table.Rows.Select(row => row["Language"]).ToArray();
            AddMultipleLanguageRecordObj.AssertAllLanguages(driver, expectedLanguages);
        }

        [When(@"User edits language record '([^']*)'")]
        public void WhenUserEditsLanguageRecord(string language)
        {
            editLanguageObj.Editlanguage(driver, language);
        }

        [Then(@"new Language record should be successfully updated '([^']*)'")]
        public void ThenNewLanguageRecordShouldBeSuccessfullyUpdated(string language)
        {
            editLanguageObj.AssertEditlanguage(driver, language);
        }

        [When(@"User tries to edit a new Language record with an empty name '([^']*)'")]
        public void WhenUserTriesToEditANewLanguageRecordWithAnEmptyName(string language)
        {
            editLanguageWithEmptyNameObj.EditlanguagewithEmptyName(driver, language);
        }

        [Then(@"Error message ""([^""]*)"" should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            editLanguageWithEmptyNameObj.GetErrorMessage(driver);
        }

        [Given(@"Craetes a new Language record '([^']*)'")]
        public void GivenCraetesANewLanguageRecord(string language)
        {
            languageTabObj.CreateLanguage(driver, language);
        }

        [When(@"User tries to edit Language record which is already created before in record '([^']*)'")]
        public void WhenUserTriesToEditLanguageRecordWhichIsAlreadyCreatedBeforeInRecord(string language)
        {
            editLanguageWithDuplicateEntryObj.EditlanguageWithDuplicate(driver, language);
        }

        [Then(@"Duplicate data error message ""([^""]*)"" should be displayed")]
        public void ThenDuplicateDataErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            editLanguageWithDuplicateEntryObj.GetErrorMessage(driver);
        }

        [Given(@"User creates a new Language records")]
        public void GivenUserCreatesANewLanguageRecords(Table table)
        {
            foreach (var row in table.Rows)
            {
                string language = row["Language"];
                AddMultipleLanguageRecordObj.CreateMultipleLanguage(driver, language);
                Thread.Sleep(5000);
            }
        }

        [When(@"User attempts to add a (.*)th language record")]
        public void WhenUserAttemptsToAddAThLanguageRecord(int p0)
        {
            try
            {
                bool isAddButtonPresent = driver.FindElements(By.XPath("//input[@value='Add']")).Count > 0;
                Assert.IsFalse(isAddButtonPresent, "Add button should not be present or enabled after adding 4th record.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
                throw;
            }
        }

        [Then(@"User should not see Add button to add another language record")]
        public void ThenUserShouldNotSeeAddButtonToAddAnotherLanguageRecord()
        {
            try
            {
                bool isAddButtonPresent = driver.FindElements(By.XPath("//button[contains(text(), 'Add')]")).Count > 0;
                Assert.IsFalse(isAddButtonPresent, "Add button should not be present after attempting to add 5th record.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
                throw;
            }
        }

        [Given(@"Create a new Language record '([^']*)'")]
        public void GivenCreateANewLanguageRecord(string language)
        {
            languageTabObj.CreateLanguage(driver, language);
        }

        [When(@"User deletes language record '([^']*)'")]
        public void WhenUserDeletesLanguageRecord(string language)
        {
            deleteLanguageObj.Deletelanguage(driver, language);
        }

        [Then(@"new Language record should be successfully deleted '([^']*)'")]
        public void ThenNewLanguageRecordShouldBeSuccessfullyDeleted(string language)
        {
            deleteLanguageObj.AssertDeletelanguage(driver, language);
        }
        
        [When(@"User a deletes language record '([^']*)'")]
        public void WhenUserADeletesLanguageRecord(string language)
        {
            deleteLanguageObj.Deletelanguage(driver, language);
        }

       
        [Then(@"Language record should not displyed in the list '([^']*)'")]
        public void ThenLanguageRecordShouldNotDisplyedInTheList(string language)
        {
           deleteLanguageObj.AssertDeletelanguage(driver, language);
        }

    }
}
