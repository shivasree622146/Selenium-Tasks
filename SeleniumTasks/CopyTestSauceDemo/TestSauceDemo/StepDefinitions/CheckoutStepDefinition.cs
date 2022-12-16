using POMSauceDemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestSauceDemo.Utilities;

namespace TestSauceDemo.StepDefinitions
{
    [Binding]
    public class CheckoutStepDefinition
    {
        CartPage cartPage = new CartPage();
        CheckoutPage checkoutPage = new CheckoutPage();
        bool itemPriceAfterCart;
        [Given(@"I am in cart page")]
        public void GivenIAmInCartPage()
        {
            LoginSteps loginSteps = new LoginSteps();
 
            loginSteps.Cart();
            itemPriceAfterCart=cartPage.GetPriceAfterAddToCart();
        }
        [When(@"I click checkout button")]
        public void WhenIClickCheckoutButton()
        {
            cartPage.CheckoutButton();
        }
        [Then(@"checkout page is displayed")]
        public void ThenCheckoutPageIsDisplayed()
        {
            Assert.That(checkoutPage.GetCheckOutPageText(), Is.EqualTo("CHECKOUT: YOUR INFORMATION"));
        }
        [When(@"I enter following details")]
        public void WhenIEnterFollowingDetails(Table table)
        {
            var dictionary =TableExtensions.ToDictionary(table);
            checkoutPage.FirstName(dictionary["Firstname"]);
            checkoutPage.LastName(dictionary["Lastname"]);
            checkoutPage.ZipCode(dictionary["PostalCode"]);

        }
        [When(@"click continue button")]
        public void WhenClickContinueButton()
        {
            checkoutPage.ClickContinue();
        }
        [Then(@"checkout overview page is displayed")]
        public void ThenCheckoutOverviewPageIsDisplayed()
        {
            Assert.That(checkoutPage.CheckoutPageOverview(), Is.EqualTo("CHECKOUT: OVERVIEW"));
        }
        [Then(@"verify the total price on checkout page")]
        public void ThenVerifyTheTotalPriceOnCheckoutPage()
        {
            string totalCost = checkoutPage.CheckTotalCost();
            Assert.False(totalCost.Equals(itemPriceAfterCart));
        }
        [When(@"I click finish button")]
        public void WhenIClickFinishButton()
        {
            checkoutPage.ClickFinish();
        }
        [Then(@"checkout complete page will display")]
        public void ThenCheckoutCompletePageWillDisplay()
        {
            Assert.That(checkoutPage.CheckoutCompletePageTitle(), Is.EqualTo("CHECKOUT: COMPLETE!"));
        }

        [Then(@"error message should display")]
        public void ThenErrorMessageShouldDisplay()
        {
            Assert.IsTrue(checkoutPage.CheckErrorMessageDisplayed());
        }

    }
}
