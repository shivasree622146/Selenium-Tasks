Feature: Inventory page

Verify the list of products displayed on the inventory page

@tag1
Scenario: Check the products name and price in the page
		Given I am in inventory page
	#		Given I launch the Saucedemo application
	#Then login page is displayed
	#When I enter the <UserName> 
	#And I also enter the <Password>
	#And Click the login button
	#Then list of products page is displayed
		Then I verify the list of products in the page
		When I click add to cart button
		Then products added to cart
		When I click Cart Icon
		Then Cart page is displayed

Examples: 
| UserName                | Password     |
| standard_user           | secret_sauce |
| problem_user            | secret_sauce |
| performance_glitch_user | secret_sauce |
		

