Feature: LoginSaucedemo

A short summary of the feature

@tag1
Scenario Outline: Verify the login functionality with valid credentials
	Given I launch the Saucedemo application
	Then login page is displayed
	When I enter the <UserName> 
	And I also enter the <Password>
	And Click the login button
	Then list of products page is displayed
Examples: 
| UserName                | Password     |
| standard_user           | secret_sauce |
| problem_user            | secret_sauce |
| performance_glitch_user | secret_sauce |



@tag1
Scenario: Verify the login page with invalid credentials
     Given I launch the Saucedemo application
	When I enter the <UserName> 
	And I also enter the <Password>
	 And Click the login button
	 Then error messages should display 
Examples: 
| UserName      | Password |
| shivasree     | secret   |
| Bannu     | 123      | 
