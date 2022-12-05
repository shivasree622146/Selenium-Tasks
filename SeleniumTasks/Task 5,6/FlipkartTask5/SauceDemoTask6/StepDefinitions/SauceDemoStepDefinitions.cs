using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SauceDemoTask6.Utils;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace SauceDemoTask6.StepDefinitions
{
    [Binding]
    public sealed class SauceDemoStepDefinitions
    {
        IWebDriver driver=new ChromeDriver();
        string before = "";
        [Given(@"I launch the https://www\.saucedemo\.com/")]
        public void GivenILaunchTheHttpsWww_Saucedemo_Com()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
        }
        [Then(@"login page is displayed")]
        public void ThenLoginPageIsDisplayed()
        {
            bool loginPage = driver.FindElement(By.XPath("//div[@class='login_logo']")).Displayed;
            Assert.True(loginPage);
        }
        [When(@"I enter the (.*)")]
        public void WhenIEnterTheStandard_User(string username)
        {
            var UserName=driver.FindElement(By.Name("user-name"));
            UserName.SendKeys(username);
        }
        [When(@"I also enter the (.*)")]
        public void WhenIAlsoEnterTheSecret_Sauce(string password)
        {
            var password1 = driver.FindElement(By.Name("password"));
            password1.SendKeys(password);
        }
        [When(@"Click the login button")]
        public void WhenClickTheLoginButton()
        {
            IWebElement loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();
        }
        [Then(@"list of products page is displayed")]
        public void ThenListOfProductsPageIsDisplayed()
        {
            bool homePageDisplay = driver.Url.Contains("inventory.html");
            Assert.True(homePageDisplay);
            Console.WriteLine(homePageDisplay);
        }
        [Then(@"select item and verify the price")]
        public void ThenSelectItemAndVerifyThePrice()
        {
            IWebElement beforeAddToCartPrice = driver.FindElement(By.XPath("//div[@class='inventory_item']//div[@class='inventory_item_price']"));
            before=beforeAddToCartPrice.GetAttribute("innerHTML");
            Console.WriteLine("Before add to cart the item price : " +before);
        }
        [When(@"I click the add to cart button")]
        public void WhenIClickTheAddToCartButton()
        {
            IWebElement addToCartButton = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addToCartButton.Click();
            bool addToCartButtonDisabled = driver.FindElement(By.Id("remove-sauce-labs-backpack")).Displayed;
            Assert.True(addToCartButtonDisabled);
        }
        [Then(@"product is added at the cart is displayed")]
        public void ThenProductIsAddedAtTheCartIsDisplayed()
        {
            
            bool addedProductsInCart = driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']")).Displayed;
            Assert.IsTrue(addedProductsInCart);
        }
        [When(@"I click shopping cart icon")]
        public void WhenIClickShoppingCartIcon()
        {
            IWebElement cartButton = driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
            cartButton.Click();
        }
        [Then(@"Cart page is displayed")]
        public void ThenCartPageIsDisplayed()
        {
            bool cartUrlDisplayed = driver.Url.Contains("https://www.saucedemo.com/cart.html");
            Assert.True(cartUrlDisplayed);
            Console.WriteLine("Cart Page is dispalyed");
        }
        [Then(@"verify the price noted as before")]
        public void ThenVerifyThePriceNotedAsBefore()
        {
            IWebElement afterAddToCartPrice = driver.FindElement(By.XPath("//div[@class='inventory_item_price']"));
            string after = afterAddToCartPrice.GetAttribute("innerHTML");
            Console.WriteLine("after add to cart the item price : " + after);
            Assert.AreEqual(before, after);
            Console.WriteLine("Both the prices are same");
        }
        [When(@"I click checkout button")]
        public void WhenIClickCheckoutButton()
        {
            IWebElement checkoutButton = driver.FindElement(By.Id("checkout"));
            checkoutButton.Click();
        }
        [Then(@"checkout page is displayed")]
        public void ThenCheckoutPageIsDisplayed()
        {
            bool checkoutPageDisplay = driver.FindElement(By.XPath("//span[text()='Checkout: Your Information']")).Displayed;
            Assert.True(checkoutPageDisplay);
        }
        [When(@"I enter following details")]
        public void WhenIEnterFollowingDetails(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            var test = dictionary["Firstname"];

            driver.FindElement(By.Id("first-name")).SendKeys(dictionary["Firstname"]);
            driver.FindElement(By.Id("last-name")).SendKeys(dictionary["Lastname"]);
            driver.FindElement(By.Id("postal-code")).SendKeys(dictionary["PostalCode"]);

        }
        [When(@"click continue button")]
        public void WhenClickContinueButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,350)", "");

            IWebElement continueButton = driver.FindElement(By.Id("continue"));
            continueButton.Click();
        }
        [Then(@"checkout overview page is displayed")]
        public void ThenCheckoutOverviewPageIsDisplayed()
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.PageUp).Build().Perform();

            bool checkoutOverviewPage = driver.FindElement(By.XPath("//span[text()='Checkout: Overview']")).Displayed;
            Assert.True(checkoutOverviewPage);
        }
        [Then(@"verify the item and price on checkout page")]
        public void ThenVerifyTheItemAndPriceOnCheckoutPage()
        {
            IWebElement checkoutPrice = driver.FindElement(By.XPath("//div[@class='inventory_item_price']"));
            string checkPrice=checkoutPrice.GetAttribute("innerHTML");
            Assert.AreEqual(before, checkPrice);
            Console.WriteLine("Prices are same");
        }
        [When(@"I click finish button")]
        public void WhenIClickFinishButton()
        {
           IJavaScriptExecutor scrolldown=(IJavaScriptExecutor)driver;
            scrolldown.ExecuteScript("window.scrollBy(0,300)", "");
            IWebElement finishButton = driver.FindElement(By.Id("finish"));
            finishButton.Click();
        }
        [Then(@"checkout complete page will display")]
        public void ThenCheckoutCompletePageWillDisplay()
        {
            bool checkoutComplete = driver.FindElement(By.XPath("//span[text()='Checkout: Complete!']")).Displayed;
            Assert.True(checkoutComplete);
            Console.WriteLine("Checkout Completed");

            driver.Close();
        }





    }

}
