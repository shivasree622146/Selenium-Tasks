using AventStack.ExtentReports;
using CommonLibrary.Extensions;
using OpenQA.Selenium;
using POMSauceDemo.BasePage;

namespace POMSauceDemo.PageObjects
{
    public class CartPage:BasePageClass
    {
        #region Locators
        By pageTitle = By.XPath("//span[@class='title']");
        By priceAfterAddToCart = By.XPath("//div[@class='inventory_item_price']");
        By nameAfterAddToCart = By.XPath("//div[@class='inventory_item_name']");
        By checkoutButton = By.Id("checkout");
        #endregion
        public string GetText()
        {
            extentReports.test = extentReports.report.CreateTest("Cart Test").Info("Test started");
            extentReports.test.Log(Status.Info, "Navigated to cart page");
            return driver.FindElement(pageTitle).Text;
 
        }
        public bool GetPriceAfterAddToCart()
        {
            extentReports.test.Log(Status.Info, "Verified the price before and after add to cart");
            return driver.FindElement(priceAfterAddToCart).IsDisplayed();
          
        }
        public bool GetNameAfterAddToCart()
        {

            extentReports.test.Log(Status.Info, "Verified the name before and after add to cart");
            return driver.FindElement(nameAfterAddToCart).IsDisplayed();
        }
        public CheckoutPage CheckoutButton()
        {
            driver.FindElement(checkoutButton).ClickOnIt();
            extentReports.test.Log(Status.Info, "Clicked checkout button");
            extentReports.test.Log(Status.Pass, " Cart Page Test Passed");
            return new CheckoutPage();
    
        }
    }
}
