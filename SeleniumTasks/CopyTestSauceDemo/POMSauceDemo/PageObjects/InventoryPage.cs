using AventStack.ExtentReports;
using CommonLibrary.Extensions;
using OpenQA.Selenium;
using POMSauceDemo.BasePage;
using System.Collections.Generic;

namespace POMSauceDemo.PageObjects
{
    public class InventoryPage:BasePageClass
    {
        #region Locators
        By homePageBanner = By.XPath("//span[text()='Products']");
        By listOfProducts = By.XPath("//div[@class='inventory_item']");
        By priceBeforeAddToCart = By.XPath("//div[@class='inventory_item']//div[@class='inventory_item_price']");
        By cartBadge = By.XPath("//span[@class='shopping_cart_badge']");
        By nameBeforeAddToCart = By.XPath("//div[@class='inventory_item']//div[@class='inventory_item_name']");
        By CartButton = By.XPath("//button[text()='Add to cart']");
        By CartIcon = By.XPath("//a[@class='shopping_cart_link']");
        #endregion

        public bool CartBadge()
        {
            extentReports.test.Log(Status.Info, "Cart Badge is displayed");
            return driver.FindElement(cartBadge).Displayed;
       
        }

        public IList<IWebElement> ListOfProducts()
        {
            extentReports.test = extentReports.report.CreateTest("Inventory Test").Info("Test started");
            extentReports.test.Log(Status.Info, "List of products displayed in inventory page");
            return driver.FindElements(listOfProducts);
          
        }

        public string GetText()
        {
            extentReports.test.Log(Status.Info, "Inventory page title is displayed"); 
            return driver.FindElement(homePageBanner).Text;
        }

        public bool GetPriceBeforeAddToCart()
        {
            extentReports.test.Log(Status.Info, "Checking price of product before add to cart");
            return driver.FindElement(priceBeforeAddToCart).IsDisplayed();
    

        }

        public bool GetNameBeforeAddToCart()
        {
            extentReports.test.Log(Status.Info, "Checking name of product before add to cart");
            return driver.FindElement(nameBeforeAddToCart).IsDisplayed();

        }

        public void ClickCartButton()
        {
            extentReports.test.Log(Status.Info, "Clicked Add to cart button");
            driver.FindElement(CartButton).Click();
        }

        public CartPage ClickCartIcon()
        {
            driver.FindElement(CartIcon).ClickOnIt();
            extentReports.test.Log(Status.Info, "Clicked Cart icon");
            extentReports.test.Log(Status.Pass,"Inventory Test Passed");

            return new CartPage();
        
        }
    }
}
