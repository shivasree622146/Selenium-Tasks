Feature: SauceDemo application

This will add, verify and checkout the products in application

@tag1
Scenario Outline: Verify the products with same price and checkout the product
	Given I launch the https://www.saucedemo.com/
	Then login page is displayed
	When I enter the <UserName> 
	And I also enter the <Password>
	And Click the login button
	Then list of products page is displayed
	Then select item and verify the price
	When I click the add to cart button
	Then product is added at the cart is displayed
	When I click shopping cart icon
	Then Cart page is displayed
	Then verify the price noted as before 
	When I click checkout button
	Then checkout page is displayed
	When I enter following details
	| Key        | Value     |
	| Firstname  | shivasree |
	| Lastname   | Ambavaram |
	| PostalCode | 500055    |
	And click continue button
	Then checkout overview page is displayed
	Then verify the item and price on checkout page
	When I click finish button
	Then checkout complete page will display
Examples: 
| UserName      | Password     |
| standard_user | secret_sauce |
