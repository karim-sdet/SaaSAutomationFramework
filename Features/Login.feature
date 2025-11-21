Feature: Login to SauceDemo
  As a registered user of the SauceDemo application
  I want to log in with valid and invalid credentials
  So that I can access or be blocked from the products page

  @smoke
  Scenario: Successful login with valid credentials
    Given I am on the SauceDemo login page
    When I log in with valid credentials
    Then I should be navigated to the products page

  Scenario: Login fails with invalid credentials
    Given I am on the SauceDemo login page
    When I log in with invalid credentials
    Then I should see a login error message
