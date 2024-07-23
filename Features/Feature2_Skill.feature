Feature: Feature2_Skill

A short summary of the feature

@tag1
Scenario: 1 Clean The Data
Given User Logs into Mars
And User navigate to Skill tab
When User deletes All Skills record
Then All Skills record should be successfully deleted

Scenario: 2 Verify user can able to Add new "Skill" to the profile
Given User Logs into Mars
And User navigate to Skill tab
When User add a new Skill record 'Leadership' 'Intermediate'
Then new record should be successfully created 'Leadership'

Scenario: 3 Verify user cannot create a Skill with an empty name
Given User Logs into Mars
And User navigate to Skill tab
When User add a new Skill record '' 'Intermediate'
Then Error message "Please enter skill and experience level" should be displayed


Scenario: 4.Verify user cannot create duplicate entries for "Skill" data based on existing records
Given User Logs into Mars
And User navigate to Skill tab
When User add a new Skill record 'Leadership' 'Intermediate'
When User tries to create a new Skill record which is already created before in record 'Leadership' 'Intermediate'
Then Error message for duplicate entry "This skill is already exist in your skill list." should be displayed

Scenario: 5 Verify use can able to create multiple Skill record to the profile
    Given User Logs into Mars
    And User navigate to Skill tab 
  When User add multiple Skills record
      | Skill           | Level   |
      | Computer skills | Expert  |
      | Leadership      | Expert  |
      | Communication   | Expert  |
      | Problem-solving | Expert  |
      | Active listening|  Expert |
 Then All Skill record should be successfully created

 Scenario: 6 Verify user can create multiple Skill records with invalid input
    Given User Logs into Mars
    And User navigate to Skill tab 
    When User add multiple Skills record
        | Skill                                                                  | Level  |
        | %^$####                                                                   | Expert |
        | 46545456                                                                  | Expert  |
        | Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.                  | Expert  |
    Then The following error messages should be displayed
        | Expected Message                               |
        | Special characters are not allowed             |
        | Numbers are not allowed                        |
        | Input is too long                              |


Scenario: 7 Verify user can able to edit "Skill" to the profile
    Given  User Logs into Mars
    And User navigate to Skill tab
    When User add a new Skill record 'LeaderShip' 'Expert'
    When User edits Skill record 'Active listening' 'Intermediate'
    Then Skill record should be successfully updated 'Active listening'

Scenario: 8 Verify user can not able to edit "Skill" Data with mandatory data are left blank.
Given  User Logs into Mars
And User navigate to Skill tab
When User add a new Skill record 'LeaderShip' 'Expert'
When User edits Skill record '' 'Expert'
Then "This skill is already added to your skill list." error should be displayed and 'LeaderShip' Skill is not updated

Scenario: 9 Verify user can not able to edit "Skill" Data with invalid data
Given  User Logs into Mars
And User navigate to Skill tab
When User add a new Skill record 'LeaderShip' 'Expert'
When User edits Skill record '&&&((()' 'Expert'
Then "Special characters are not allowed" error should be displayed and 'LeaderShip' Skill is not updated

Scenario:  10 Verify user cannot edit Lanuage name with duplicate entries for "Skill" data based on existing records
Given  User Logs into Mars
And User navigate to Skill tab
When User add a new Skill record 'LeaderShip' 'Expert'
When User edits Skill record 'LeaderShip' 'Expert'
Then "This skill is already added to your skill list." error should be displayed and 'LeaderShip' Skill is not updated

Scenario: 11 Verify user can able to delete "Skill" to the profile which is already in the list
 Given User Logs into Mars
 And User navigate to Skill tab 
 When User add a new Skill record 'LeaderShip' 'Expert'
 When User delete Skill record 'LeaderShip'   
 Then new Skill record should be successfully deleted

 Scenario: 12 Verify user can not able to delete "Skill" to the profile which is not in the list
 Given User Logs into Mars
 And User navigate to Skill tab 
 When User add a new Skill record 'LeaderShip' 'Expert'
 When User delete Skill record 'TeamWork'    
 Then new Skill record should not deleted 
