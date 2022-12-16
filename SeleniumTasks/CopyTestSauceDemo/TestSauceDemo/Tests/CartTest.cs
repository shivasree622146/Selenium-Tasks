using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using POMSauceDemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestSauceDemo.Base;
using TestSauceDemo.Utilities;

namespace TestSauceDemo.Tests
{
    public class CartTest: BaseTest
    {
       
        [Test,Order(3)]
        public void CartPageTest()
        {
            LoginPage loginPage;
            InventoryPage inventoryPage;
            CartPage cartPage;
            CheckoutPage checkoutPage;

            extentReports.test =extentReports.report.CreateTest("Cart Page Test").Info("Test Started");

            loginPage = new LoginPage();

            loginPage.UserName(pageUtility.userName);
            loginPage.Password(pageUtility.passWord);
            inventoryPage = loginPage.LoginButton();

            inventoryPage.ClickCartButton();

            bool itemPrice = inventoryPage.GetPriceBeforeAddToCart();
            bool itemName = inventoryPage.GetPriceBeforeAddToCart();


            cartPage = inventoryPage.ClickCartIcon();
            bool itemAfterCart = cartPage.GetPriceAfterAddToCart();
            Assert.That(itemPrice, Is.EqualTo(itemAfterCart));
            extentReports.test.Log(Status.Info, "Verified price of product before and after adding to cart");

            bool itemNameAfterCart = cartPage.GetNameAfterAddToCart();
            Assert.That(itemName, Is.EqualTo(itemNameAfterCart));
            extentReports.test.Log(Status.Info, "Verified name of product before and after adding to cart");

            Assert.That("YOUR CART", Is.EqualTo(cartPage.GetText()));
            extentReports.test.Log(Status.Info, "Navigated to Cart Page");

            Thread.Sleep(2000);
            extentReports.test.Log(Status.Info, "Clicked Cart icon");

            checkoutPage =cartPage.CheckoutButton();
            Thread.Sleep(2000);
            extentReports.test.Log(Status.Info, "Clicked Checkout button");
            extentReports.test.Log(Status.Pass, "Cart Test Passed");
        }
     
    }
}
