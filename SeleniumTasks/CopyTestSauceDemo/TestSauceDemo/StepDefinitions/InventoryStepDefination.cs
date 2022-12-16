using OpenQA.Selenium;
using POMSauceDemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestSauceDemo.Base;

namespace TestSauceDemo.StepDefinitions
{
    [Binding]
    public class InventoryStepDefination: BaseTest
    {
        
            LoginPage loginPage = new LoginPage();
            InventoryPage inventoryPage = new InventoryPage();
            CartPage cartPage = new CartPage();

            [Given(@"I am in inventory page")]
            public void GivenIAmInInventoryPage()
            {
            LoginSteps loginSteps = new LoginSteps();
            loginSteps.Login();

            }

            [Then(@"I verify the list of products in the page")]
            public void ThenIVerifyTheListOfProductsInThePage()
            {
                IList<IWebElement> webElements = inventoryPage.ListOfProducts();
                Console.WriteLine(webElements.Count);
                Assert.True(webElements.Count != 0);

            }
            [When(@"I click add to cart button")]
            public void WhenIClickAddToCartButton()
            {
            inventoryPage.ClickCartButton();
                
            }
            [Then(@"products added to cart")]
            public void ThenProductsAddedToCart()
            {
                Assert.True(inventoryPage.CartBadge());
            }
            [When(@"I click Cart Icon")]
            public void WhenIClickCartIcon()
            {
                inventoryPage.ClickCartIcon();
            }
            [Then(@"Cart page is displayed")]
            public void ThenCartPageIsDisplayed()
            {
                Assert.That("YOUR CART", Is.EqualTo(cartPage.GetText()));
            }

    }
}
