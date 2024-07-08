using Mars_SpecFlowProject1.Pages;
using ProjecrMarsOnboardingtask.Pages;
using SpecFlowProject_MarsProject.Pages;
using SpecFlowProject_MarsProject.Utils;
using System;
using TechTalk.SpecFlow;

namespace ProjecrMarsOnboardingtask.StepDefinitions
{
    [Binding, Scope(Feature = "Feature2_Skill")]
    public class Feature2_SkillStepDefinitions : HookBase
    {
        private readonly LoginPage loginPageObj;
        private readonly AddSkill addSkillObj;
        private readonly EditSkill editSkillObj;
        private readonly CleanSkillData cleanSkillDataObj;
        private readonly AddSkillwithEmptyName addSkillwithEmptyNameObj;
        private readonly AddSkillWithDuplicateEntry addSkillWithDuplicateEntryObj;
        private readonly DeleteSkill deleteSkillObj;
        private readonly EditSkillWithEmptyName editSkillWithEmptyNameObj;
        private readonly EditSkillWithDuplicateEntry editSkillWithDuplicateEntryObj;
        private readonly AddMultipleSkillRecord addMultipleSkillRecordObj;
        public Feature2_SkillStepDefinitions() 
        {
            loginPageObj = new LoginPage();
            addSkillObj = new AddSkill();
            editSkillObj = new EditSkill();
            cleanSkillDataObj = new CleanSkillData();
            addSkillwithEmptyNameObj = new AddSkillwithEmptyName();
            addSkillWithDuplicateEntryObj = new AddSkillWithDuplicateEntry();
            deleteSkillObj = new DeleteSkill();
            editSkillWithDuplicateEntryObj = new EditSkillWithDuplicateEntry();
            editSkillWithEmptyNameObj = new EditSkillWithEmptyName();
            addMultipleSkillRecordObj = new AddMultipleSkillRecord();

        }

        [Given(@"User Logs into Mars portal and navigates to Skill tab")]
        public void GivenUserLogsIntoMarsPortalAndNavigatesToSkillTab()
        {
            loginPageObj.login(driver);
        }

        [When(@"User deletes All Skills record")]
        public void WhenUserDeletesAllSkillsRecord()
        {
            cleanSkillDataObj.Deleteskill(driver);
        }

        [Then(@"All Skills record should be successfully deleted")]
        public void ThenAllSkillsRecordShouldBeSuccessfullyDeleted()
        {
            cleanSkillDataObj.AssertDeleteskill(driver);
        }

        [Given(@"Clean the data before test")]
        public void GivenCleanTheDataBeforeTest()
        {
            cleanSkillDataObj.Deleteskill(driver);
        }

        [When(@"User creates a new Skill record '([^']*)'")]
        public void WhenUserCreatesANewSkillRecord(string Skill)
        {
            addSkillObj.CreateSkill(driver, Skill);
        }

        [Then(@"new Skill record should be successfully created '([^']*)'")]
        public void ThenNewSkillRecordShouldBeSuccessfullyCreated(string Skill)
        {
            addSkillObj.AssertCreateSkill(driver, Skill);
        }

        [When(@"User tries to create a new Skill record with an empty name '([^']*)'")]
        public void WhenUserTriesToCreateANewSkillRecordWithAnEmptyName(string Skill)
        {
            addSkillwithEmptyNameObj.CreateSkill(driver, Skill);
        }

        [Then(@"an error message ""([^""]*)"" should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            addSkillwithEmptyNameObj.GetErrorMessage1(driver);
        }

        [Given(@"Craete A new data '([^']*)'")]
        public void GivenCraeteANewData(string Skill)
        {
            addSkillObj.CreateSkill(driver, Skill);
        }

        [When(@"User tries to create a new Skill record which is already created before in record '([^']*)'")]
        public void WhenUserTriesToCreateANewSkillRecordWhichIsAlreadyCreatedBeforeInRecord(string Skill)
        {
            addSkillWithDuplicateEntryObj.CreateSkill(driver, Skill);
        }

        [Then(@"Duplicate entry error message ""([^""]*)"" should be displayed")]
        public void ThenDuplicateEntryErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            addSkillWithDuplicateEntryObj.GetErrorMessage2(driver);
        }

        [When(@"User creates a new Skill records")]
        public void WhenUserCreatesANewSkillRecords(Table table)
        {
            foreach (var row in table.Rows)
            {
                string Skill = row["Skill"];
                addMultipleSkillRecordObj.CreateMultipleSkill(driver, Skill);
            }
        }

        [Then(@"All Skill record should be successfully created")]
        public void ThenAllSkillRecordShouldBeSuccessfullyCreated(Table table)
        {
            var expectedSkills = table.Rows.Select(row => row["Skill"]).ToArray();
            addMultipleSkillRecordObj.AssertCreateSkill(driver, expectedSkills);
        }

        [When(@"User edits Skill record '([^']*)'")]
        public void WhenUserEditsSkillRecord(string Skill)
        {
            editSkillObj.Editskill(driver, Skill);
        }

        [Then(@"new Skill record should be successfully updated '([^']*)'")]
        public void ThenNewSkillRecordShouldBeSuccessfullyUpdated(string Skill)
        {
            editSkillObj.AssertEditskill(driver, Skill);
        }

        [When(@"User tries to edit a new Skill record with an empty name '([^']*)'")]
        public void WhenUserTriesToEditANewSkillRecordWithAnEmptyName(string Skill)
        {
            editSkillWithEmptyNameObj.Editskill(driver, Skill);
        }

        [Then(@"Error message ""([^""]*)"" should be displayed")]
        public void ThenErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            editSkillWithEmptyNameObj.GetErrorMessage1(driver);
        }

        [Given(@"Craetes a new Skill record")]
        public void GivenCraetesANewSkillRecord(Table table)
        {
            foreach (var row in table.Rows)
            {
                string Skill = row["Skill"];
                addMultipleSkillRecordObj.CreateMultipleSkill(driver, Skill);
            }
        }


        [When(@"User tries to edit Skill record which is already created before in record '([^']*)'")]
        public void WhenUserTriesToEditSkillRecordWhichIsAlreadyCreatedBeforeInRecord(string Skill)
        {
            editSkillWithDuplicateEntryObj.Editskill(driver, Skill);
        }

        [Then(@"Duplicate data error message ""([^""]*)"" should be displayed")]
        public void ThenDuplicateDataErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            editSkillWithDuplicateEntryObj.GetErrorMessage2(driver);
        }

        [Given(@"Create a new Skill record '([^']*)'")]
        public void GivenCreateANewSkillRecord(string Skill)
        {
            addSkillObj.CreateSkill(driver, Skill);
        }

        [When(@"User deletes Skill record '([^']*)'")]
        public void WhenUserDeletesSkillRecord(string Skill)
        {
            deleteSkillObj.Deleteskill(driver, Skill);
        }

        [Then(@"new Skill record should be successfully deleted '([^']*)'")]
        public void ThenNewSkillRecordShouldBeSuccessfullyDeleted(string Skill)
        {
            deleteSkillObj.AssertDeleteskill(driver, Skill);
        }

        [When(@"User a deletes Skill record '([^']*)'")]
        public void WhenUserADeletesSkillRecord(string Skill)
        {
            deleteSkillObj.Deleteskill(driver, Skill);
        }

        [Then(@"Skill record should not displyed in the list '([^']*)'")]
        public void ThenSkillRecordShouldNotDisplyedInTheList(string Skill)
        {
            deleteSkillObj.AssertDeleteskill(driver, Skill);
        }
    }
}
