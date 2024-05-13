Feature: Login
    As a registered user
    I want to be able to login successfully
    So that I can access my account


@ValidInput
Scenario: Successful login
    Given I am on the login page
    When I enter my username "exampleuser" and password "password123"
    And I click the login button
    Then I should be redirected to the dashboard page
    And I should see the mainpage @page

@InvalidInput
Scenario: Unsuccessful User Login
    Given I am on the login page
    When I enter invalid username "invaliduser" and invalid password "invalidpassword"
    And I click the login button
    Then I should see an error message "Invalid username or password"



