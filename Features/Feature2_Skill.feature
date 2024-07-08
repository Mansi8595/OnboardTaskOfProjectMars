Feature: Feature2_Skill

A short summary of the feature

@tag1
Scenario: 1 Clean The Data
Given User Logs into Mars portal and navigates to Skill tab
When User deletes All Skills record
Then All Skills record should be successfully deleted

Scenario: 2 Verify user can able to create new "Skill" to the profile
Given User Logs into Mars portal and navigates to Skill tab
And Clean the data before test
When User creates a new Skill record 'Communication'
Then new Skill record should be successfully created 'Communication'

Scenario: 3 Verify user cannot create a Skill with an empty name
Given User Logs into Mars portal and navigates to Skill tab
And Clean the data before test
When User tries to create a new Skill record with an empty name ''
Then an error message "Please enter Skill and level" should be displayed

Scenario: 4 Verify user cannot create duplicate entries for "Skill" data based on existing records
Given User Logs into Mars portal and navigates to Skill tab
And Clean the data before test
And Craete A new data 'Communication'
When User tries to create a new Skill record which is already created before in record 'Communication'
Then Duplicate entry error message "This Skill is already exist in your Skill list." should be displayed

Scenario: 5 Verify use can able to create multiple Skill record to the profile
Given User Logs into Mars portal and navigates to Skill tab 
And Clean the data before test 
When User creates a new Skill records
      | Skill          |
      | Communication  |
      | LeaderShip     |
      | Problem solving|
      | Teamwork       |
Then All Skill record should be successfully created
      | Skill          |
      | Communication  |
      | LeaderShip     |
      | Problem solving|
      | Teamwork       |

Scenario: 6 Verify user can able to edit "Skill" to the profile
Given User Logs into Mars portal and navigates to Skill tab
And Clean the data before test
And Craete A new data 'Communication'
When User edits Skill record 'Teamwork'
Then new Skill record should be successfully updated 'Teamwork'

Scenario: 7Verify user can not able to edit "Skill" Data with mandatory data are left blank.
Given User Logs into Mars portal and navigates to Skill tab
And Clean the data before test
And Craete A new data 'Teamwork'
When User tries to edit a new Skill record with an empty name ''
Then Error message "This Skill is already added to your Skill list." should be displayed

Scenario: 8. Verify user cannot edit Lanuage name with duplicate entries for "Skill" data based on existing records
Given User Logs into Mars portal and navigates to Skill tab
And Clean the data before test
And Craetes a new Skill record
      | Skill          |
      | Communication  |
      | LeaderShip     |
When User tries to edit Skill record which is already created before in record 'Communication'
Then Duplicate data error message "This Skill is already added to your Skill list." should be displayed

Scenario: 9 Verify user can able to delete "Skill" to the profile which is already in the list
Given User Logs into Mars portal and navigates to Skill tab
And Clean the data before test
And Create a new Skill record 'Teamwork'
When User deletes Skill record 'Teamwork'
Then new Skill record should be successfully deleted 'Teamwork'

Scenario: 10 Verify user can not able to delete "Skill" to the profile which is not in the list
Given User Logs into Mars portal and navigates to Skill tab
And Clean the data before test
And Create a new Skill record 'Teamwork'
When User a deletes Skill record 'LeaderShip'
Then Skill record should not displyed in the list 'LeaderShip'