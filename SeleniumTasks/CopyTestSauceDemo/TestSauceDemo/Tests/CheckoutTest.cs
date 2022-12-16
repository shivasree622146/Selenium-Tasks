using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using POMSauceDemo.CustomExceptions;
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
    public class CheckoutTest:BaseTest
    {
        [Test,Order(4)]
        public void CheckoutPageTest()
        {
            try
            {
                LoginPage loginPage;
                InventoryPage inventoryPage;
                CartPage cartPage;
                CheckoutPage checkoutPage;

                extentReports.test = extentReports.report.CreateTest("Checkout Page Test").Info("Test Started");

                loginPage = new LoginPage();

                loginPage.UserName(pageUtility.userName);
                loginPage.Password(pageUtility.passWord);
                inventoryPage = loginPage.LoginButton();

                inventoryPage.ClickCartButton();

                cartPage = inventoryPage.ClickCartIcon();

                bool itemPriceAfterCart = cartPage.GetPriceAfterAddToCart();
                checkoutPage = cartPage.CheckoutButton();


                Assert.That(checkoutPage.GetCheckOutPageText(), Is.EqualTo("CHECKOUT: YOUR INFORMATION"));
                extentReports.test.Log(Status.Info, "Navigated to Checkout Page");

                checkoutPage.FirstName(pageUtility.firstName);
                checkoutPage.LastName(pageUtility.lastName);
                checkoutPage.ZipCode(pageUtility.pinCode);
                extentReports.test.Log(Status.Info, "Entered Checkout details");

                checkoutPage.ClickContinue();
                Assert.That(checkoutPage.CheckoutPageOverview(), Is.EqualTo("CHECKOUT: OVERVIEW"));
                extentReports.test.Log(Status.Info, "Navigated to Checkout Overview Page");

                string totalCost=checkoutPage.CheckTotalCost();
                Assert.False(totalCost.Equals(itemPriceAfterCart));
                extentReports.test.Log(Status.Info, "Verified total cost of item");

                checkoutPage.ClickFinish();
                Thread.Sleep(3000);
                extentReports.test.Log(Status.Pass, "CheckOut Test Passed");
            }catch(CheckFilePathException e)
            {
                throw new CheckFilePathException("File Path is incorrect");
            }
        }
    
    }
}
