Feature: Feature1_Language

A short summary of the feature

@tag1
Scenario: 1 Clean The Data
Given User Logs into Mars
And User navigate to language tab
When User deletes All languages record
Then All Languages record should be successfully deleted

Scenario: 2 Verify user can able to Add new "Language" to the profile
Given User Logs into Mars
And User navigate to language tab
When User add a new Language record 'French' 'Fluent'
Then new record should be successfully created 'French'

Scenario: 3 Verify user cannot create a language with an empty name
Given User Logs into Mars
And User navigate to language tab
When User adds a new Language record '' 'Fluent'
Then Error message "Please enter language and level" should be displayed

Scenario: 4.Verify user cannot create duplicate entries for "Language" data based on existing records
Given User Logs into Mars
And User navigate to language tab
When User add a new Language record 'French' 'Fluent'
When User tries to create a new Language record which is already created before in record 'French' 'Fluent'
Then Error message for duplicate entry "This language is already exist in your language list." should be displayed

Scenario: 5 Verify use can able to create multiple language record to the profile
    Given User Logs into Mars
    And User navigate to language tab 
  When User add multiple Languages record
      | Language | Level  |
      | French   | Fluent |
      | Spanish  | Fluent |
      | German   | Basic  |
      | Japanese | Basic  |
 Then All Language record should be successfully created
      

Scenario: 6 Verify user can create multiple language records with invalid input
    Given User Logs into Mars
    And User navigate to language tab 
    When User add multiple Languages record
        | Language                                                                  | Level  |
        | %^$####                                                                   | Fluent |
        | 46545456                                                                  | Basic  |
        | Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua                  | Basic  |
    Then The following error messages should be displayed
        | Expected Message                               |
        | Special characters are not allowed             |
        | Numbers are not allowed                        |
        | Input is too long                              |
    

Scenario: 7 user can not creating 5th Record in "Language"
    Given User Logs into Mars
    And User navigate to language tab 
   When User add multiple Languages record
      | Language | Level  |
      | French   | Fluent |
      | Spanish  | Fluent |
      | German   | Basic  |
      | Japanese | Basic  |
     Then User should not see Add button to add 5th language record

Scenario: 8 Verify user can able to edit "Language" to the profile
    Given  User Logs into Mars
    And User navigate to language tab
    When User add a new Language record 'French' 'Fluent'
    When User edits language record 'Hindi' 'Basic'
    Then Language record should be successfully updated 'Hindi'

Scenario: 9 Verify user can not able to edit "Language" Data with mandatory data are left blank.
Given  User Logs into Mars
And User navigate to language tab
When User add a new Language record 'French' 'Fluent'
When User tries to edit a new Language record with '' 'Fluent'
Then "This language is already added to your language list." error should be displayed and 'French' language is not updated

Scenario: 10 Verify user can not able to edit "Language" Data with invalid data
Given  User Logs into Mars
And User navigate to language tab
When User add a new Language record 'French' 'Fluent'
When User tries to edit a new Language record with '&&&((()' 'Fluent'
Then "Special characters are not allowed" error should be displayed and 'French' language is not update

Scenario:  11 Verify user cannot edit Lanuage name with duplicate entries for "Language" data based on existing records
Given  User Logs into Mars
And User navigate to language tab
When User add a new Language record 'French' 'Fluent'
When User tries to edit a new Language record with 'French' 'Fluent'
Then "This language is already added to your language list." error should be displayed and 'French' language is not updated

Scenario: 12 Verify user can able to delete "Language" to the profile which is already in the list
 Given User Logs into Mars
 And User navigate to language tab 
 When User add a new Language record 'French' 'Fluent'
 When User deletes language record 'French'   
 Then new Language record should be successfully deleted

 Scenario: 13 Verify user can not able to delete "Language" to the profile which is not in the list
 Given User Logs into Mars
 And User navigate to language tab 
 When User add new Language record 'French' 'Fluent'
 When User deletes language record 'English'    
 Then new Language record should not deleted 
      