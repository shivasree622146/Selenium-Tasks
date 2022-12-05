Feature: Verify the tabs and compare price in flipkart

Scenario: Verify all the tabs avaiable in home page and compare item price
	Given I launch https://www.flipkart.com
	Then Login popup window is displayed
	Given I handle login popup winodw to not login to Application
	Then home page is displayed
	When I verify tabname available in home page
	| tabName            |
	| Grocery            |
	| Mobiles            |
	| Fashion            |
	| Electronics        |
	| Home               |
	| Appliances         |
	| Travel             |
	| Top Offers         |
	| Beauty Tous & More |
	| 2-Wheelers         |
	When I click on Electronics tab
	And select the electronics gst store
	Then I navigated to the electronics GST Store page
	When I go to tv and appliances 
	And click on Split ACs
	Then verify the Split ACs result page
	When I click on the result item
	Then I navigated to the item details page
	Then comparing the price before and after clicking on the result item




