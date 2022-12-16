using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMSauceDemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestSauceDemo.Base;
using TestSauceDemo.Screenshots;
using TestSauceDemo.Utilities;

namespace TestSauceDemo.Tests
{
    public class InventoryTest:BaseTest
    {
        [Test,Order(2)]
        public void InventoryPageTest()
        {
            LoginPage loginPage;
            InventoryPage inventoryPage;
            CartPage cartPage;

            extentReports.test = extentReports.report.CreateTest("Inventory Page Test").Info("Test Started");

            loginPage = new LoginPage();
        

            loginPage.UserName(pageUtility.userName);
            loginPage.Password(pageUtility.passWord);
            inventoryPage=loginPage.LoginButton();

            inventoryPage.ClickCartButton();
            extentReports.test.Log(Status.Info, "Clicked AddToCart button");
         
            Assert.That(inventoryPage.GetText(), Is.EqualTo("PRODUCTS"));
            extentReports.test.Log(Status.Info, "Inventory Page is displayed");


            extentReports.test.Log(Status.Pass, "Inventory Test Passed");

        }
    }
}
