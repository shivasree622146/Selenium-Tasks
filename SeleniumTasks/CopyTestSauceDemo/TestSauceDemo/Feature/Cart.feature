Feature: Cart Functionality

@tag1
Scenario: Verify the items before and after added to cart
Given I am in inventory page
Given I click add to cart button 
When I click cart icon
Then cart page should displayed
Then I verify the item price 
And verify the item name in the cart
Then I click checkout button
