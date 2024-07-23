using Mars_SpecFlowProject1.Utils;
using NUnit.Framework;
using OnboardTaskProjectMars.Utils;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecrMarsOnboardingtask.Pages 
{ 
    public class Skill : CommonDriver
    {

    private IWebElement addNewSkillButton => driver.FindElement(By.XPath("//div[@data-tab='second']//div[@class ='ui teal button']"));
    private IWebElement addskillName => driver.FindElement(By.XPath("//input[contains(@placeholder, 'Add')]"));
    private IWebElement dropdownSkill => driver.FindElement(By.XPath("//div[@data-tab='second']//select[@class='ui fluid dropdown']"));
    private IWebElement AddButton => driver.FindElement(By.XPath(e_AddButton));
    private IWebElement skill => driver.FindElement(By.XPath(e_Skill));
    private IWebElement SkillLevel => driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[last()]/tr/td[2]"));
    private IWebElement editSkillButton => driver.FindElement(By.XPath(e_editSkillButton));
    private IWebElement editLanuage => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
    private IWebElement buttonUpdate => driver.FindElement(By.XPath(e_updateButton));

    private IWebElement cancelButton => driver.FindElement(By.XPath(e_cancelButton));
    private IWebElement buttonDelete => driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[last()]/tr/td[3]/span[2]/i"));
    private IWebElement errormessage => driver.FindElement(By.XPath(e_errormessage));
    private IWebElement successmessage => driver.FindElement(By.XPath(e_successmessage));
    private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[2]"));

    private string e_Skill = "//div[@data-tab='second']//tbody[last()]/tr/td[1]";
    private string e_editSkillButton = "//div[@data-tab='second']//tbody[last()]/tr/td[3]/span[1]/i";
    private string e_deletebutton = "//div[@data-tab='second']//tbody[last()]/tr/td[3]/span[2]/i";
    private string e_errormessage = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']";
    private string e_successmessage = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']";
    private string e_waitForTab = "//div[@class='ui top attached tabular menu']";
    private string e_AddButton = "//input[@value='Add']";
    private string e_AddSkillName = "//input[contains(@placeholder, 'Add')]";
    private string e_AddSkillbutton = "//div[@data-tab='second']//div[@class ='ui teal button']";
    private string e_updateButton = "//input[@value='Update']";
    private string e_cancelButton = "//input[@value='Cancel']";

    public void CreateSkill(string Skill, string Skilllevel)
    {
        WaitForPopupToDisappear();
        WaitUtils.WaitToBeClickable(driver, "XPath", e_AddSkillbutton, 10);
        //Click Add New
        addNewSkillButton.Click();

        WaitUtils.WaitToBeClickable(driver, "XPath", e_AddSkillName, 10);
        //Enter Skill
        addskillName.SendKeys(Skill);

        //Choose Lanuage Level
        var selectSkillDropdown = new SelectElement(dropdownSkill);
        selectSkillDropdown.SelectByValue(Skilllevel);

        WaitUtils.WaitToBeClickable(driver, "XPath", e_AddButton, 10);

        //Click Add
        AddButton.Click();

    }
    public void UpdateSkill(string Skill, string Skilllevel)
    {
        WaitUtils.WaitToBeClickable(driver, "XPath", e_editSkillButton, 20);
        WaitForPopupToDisappear();
        //Click edit button
        editSkillButton.Click();


        //Edit Skill
        editLanuage.Clear();
        editLanuage.SendKeys(Skill);

        //Edit Lanuage Level
        var selectSkill = new SelectElement(dropdownSkill);
        selectSkill.SelectByValue(Skilllevel);

        WaitUtils.WaitToBeClickable(driver, "XPath", e_updateButton, 20);
        //Click Update
        buttonUpdate.Click();

        WaitForPopupToDisappear();

        cancelButton.Click();
    }
    public string GetSkill()
    {
        //Get last record Skill text
        try
        {

            WaitUtils.WaitToBeVisible(driver, "XPath", e_Skill, 10);
            return skill.Text;
        }
        catch (Exception)
        {
            return "locator not found";
        }
    }
    public void DeleteSkill(string Skill)
    {

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        bool isSkillFound = false;

        while (true)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr")));

                var rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));

                foreach (var row in rows)
                {
                    var cell = row.FindElement(By.CssSelector("td:first-child"));
                    if (cell.Text.Equals(Skill, StringComparison.OrdinalIgnoreCase))
                    {
                        isSkillFound = true;
                        buttonDelete.Click();
                        Thread.Sleep(2000); // Wait for deletion to process
                        break;
                    }
                }

                if (!isSkillFound)
                {
                    break;
                }
            }
            catch (NoSuchElementException)
            {
                // No more delete buttons found, break the loop
                break;
            }
            catch (WebDriverTimeoutException)
            {
                // Delete button not found within wait time, break the loop
                break;
            }
        }
    }

    public string GetErrorMessage()
    {
        WaitUtils.WaitToBeVisible(driver, "XPath", e_errormessage, 3);
        return errormessage.Text;
    }
        public string GetSuccessMessage()
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", e_successmessage , 3);
            return successmessage.Text;
        }
        public void ClickAnyTab(string tab)
    {
        //Wait for tabs to be visible
        WaitUtils.WaitToBeVisible(driver, "XPath", e_waitForTab, 3);

        //Click on specified tab
        tabOption.Click();
    }
    public void CleanSkillData()
    {

        while (true)
        {
            try
            {
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")));
                WaitUtils.WaitToBeVisible(driver, "XPath", e_deletebutton, 10);
                // Find the delete button for the last record
                buttonDelete.Click();
                Thread.Sleep(6000);
            }
            catch (NoSuchElementException)
            {
                // Break the loop if no more delete buttons are found
                break;
            }
            catch (WebDriverTimeoutException)
            {
                // Break the loop if the delete button is not found within the wait time
                break;
            }
        }


    }


    private void WaitForPopupToDisappear()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        try
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='ns-box-inner']")));
        }
        catch (WebDriverTimeoutException)
        {
            // Handle the case where the popup does not disappear within the timeout
            Assert.Fail("The popup did not disappear within the expected time.");
        }
    }
}
   
}
