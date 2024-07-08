Feature: Feature1_Language

A short summary of the feature

@tag1
Scenario: 1 Clean The Data
Given User Logs into Mars portal and navigates to language tab
When User deletes All languages record
Then All Languages record should be successfully deleted

Scenario: 2 Verify user can able to create new "Language" to the profile
Given User Logs into Mars portal and navigates to language tab
And Clean the data before test
When User creates a new Language record 'French'
Then new Language record should be successfully created 'French'

Scenario: 3 Verify user cannot create a language with an empty name
Given User Logs into Mars portal and navigates to language tab
And Clean the data before test
When User tries to create a new Language record with an empty name ''
Then an error message "Please enter language and level" should be displayed

Scenario: 4 Verify user cannot create duplicate entries for "Language" data based on existing records
Given User Logs into Mars portal and navigates to language tab
And Clean the data before test
And Craete A new data 'French'
When User tries to create a new Language record which is already created before in record 'French'
Then Duplicate entry error message "This language is already exist in your language list." should be displayed

Scenario: 5 Verify use can able to create multiple language record to the profile
Given User Logs into Mars portal and navigates to language tab 
And Clean the data before test 
When User creates a new Language records
      | Language  |
      | French    |
      | Spanish   |
      | German    |
      | Japanese  |
Then All Language record should be successfully created
      | Language  |
      | French    |
      | Spanish   |
      | German    |
      | Japanese  |

Scenario: 6 Verify user can able to edit "Language" to the profile
Given User Logs into Mars portal and navigates to language tab
And Clean the data before test
And Craete A new data 'French'
When User edits language record 'Hindi'
Then new Language record should be successfully updated 'Hindi'

Scenario: 7Verify user can not able to edit "Language" Data with mandatory data are left blank.
Given User Logs into Mars portal and navigates to language tab
And Clean the data before test
And Craete A new data 'French'
When User tries to edit a new Language record with an empty name ''
Then Error message "This language is already added to your language list." should be displayed

Scenario: 8. Verify user cannot edit Lanuage name with duplicate entries for "Language" data based on existing records
Given User Logs into Mars portal and navigates to language tab
And Clean the data before test
And Craetes a new Language record 'English'
When User tries to edit Language record which is already created before in record 'English'
Then Duplicate data error message "This language is already added to your language list." should be displayed

Scenario: 9. Verify user can not creating 5th Record in "Language"
Given User Logs into Mars portal and navigates to language tab
And Clean the data before test
And User creates a new Language records
      | Language  |
      | French    |
      | Spanish   |
      | German    |
      | Japanese  |
When User attempts to add a 5th language record
Then User should not see Add button to add another language record

Scenario: 10 Verify user can able to delete "Language" to the profile which is already in the list
Given User Logs into Mars portal and navigates to language tab
And Clean the data before test
And Create a new Language record 'English'
When User deletes language record 'English'
Then new Language record should be successfully deleted 'English'

Scenario: 11 Verify user can not able to delete "Language" to the profile which is not in the list
Given User Logs into Mars portal and navigates to language tab
And Clean the data before test
And Create a new Language record 'English'
When User a deletes language record 'Hindi'
Then Language record should not displyed in the list 'Hindi'