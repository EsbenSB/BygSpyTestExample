Feature: Newuser 
As a user 
I want to create a new profile
so that I can log in


@SuccesfulCreation
Scenario: Create new user
	Given I am on the newuser page
	And that my input is valid
	When I press the save button
	Then I will see the login page

