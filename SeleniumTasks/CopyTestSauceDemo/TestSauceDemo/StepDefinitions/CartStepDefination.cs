using POMSauceDemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestSauceDemo.StepDefinitions
{
    [Binding]
    public class CartStepDefination
    {
        LoginPage loginPage = new LoginPage();
        InventoryPage inventoryPage = new InventoryPage();
        CartPage cartPage = new CartPage();
        bool itemPrice, itemName;
        bool itemAfterCart, itemNameAfterCart;
        [Given(@"I click add to cart button")]
        public void GivenIClickAddToCartButton()
        {
            inventoryPage.ClickCartButton();
            itemPrice = inventoryPage.GetPriceBeforeAddToCart();
            itemName = inventoryPage.GetNameBeforeAddToCart();
           
        }
        [When(@"I click cart icon")]
        public void WhenIClickCartIcon()
        {
            inventoryPage.ClickCartIcon();
        }
        [Then(@"cart page should displayed")]
        public void ThenCartPageShouldDisplayed()
        {
            Assert.That("YOUR CART", Is.EqualTo(cartPage.GetText()));

        }
        [Then(@"I verify the item price")]
        public void ThenIVerifyTheItemPrice()
        {
            itemAfterCart=cartPage.GetPriceAfterAddToCart();
            Assert.That(itemPrice, Is.EqualTo(itemAfterCart));
        }
        [Then(@"verify the item name in the cart")]
        public void ThenVerifyTheItemNameInTheCart()
        {
            itemNameAfterCart=cartPage.GetNameAfterAddToCart();
            Assert.That(itemName, Is.EqualTo(itemNameAfterCart));
        }
        [Then(@"I click checkout button")]
        public void ThenIClickCheckoutButton()
        {
            cartPage.CheckoutButton();
        }
    }
}
