Feature: Checkout functionality

Verify the total cost of the product and checkout the product

@tag1
Scenario: Verify and checkout the item by entering details
	Given I am in cart page
	When I click checkout button
	Then checkout page is displayed
	When I enter following details
	| Key        | Value     |
	| Firstname  | shivasree |
	| Lastname   | Ambavaram |
	| PostalCode | 500055    |
	And click continue button
	Then checkout overview page is displayed
	Then verify the total price on checkout page
	When I click finish button
	Then checkout complete page will display


@tag1
Scenario: Verify in the checkout details if user skipped entering details
Given I am in cart page
When I click checkout button
Then checkout page is displayed
When I enter following details
| Key        | Value |
| Firstname  |       |
| Lastname   | sree  |
| PostalCode |       |
And click continue button
Then error message should display




