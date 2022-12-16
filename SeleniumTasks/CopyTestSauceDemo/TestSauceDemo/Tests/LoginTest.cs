using AventStack.ExtentReports;
using OpenQA.Selenium;
using POMSauceDemo.PageObjects;
using System.Text.Json;
using System.Threading.Tasks;
using TestSauceDemo.Base;
using TestSauceDemo.Utilities;
using OpenQA.Selenium.Chrome;
using TestSauceDemo.Screenshots;
using System.Configuration;

namespace TestSauceDemo.Tests
{
    public class LoginTest : BaseTest
    {
        [Test,Order(1)]
        public void LoginPageTest()
        {
            
                LoginPage loginPage;
                InventoryPage inventoryPage;

            extentReports.test = extentReports.report.CreateTest("Login Page Test").Info("Test Started");


            extentReports.test.Log(Status.Info, "SauceDemo.com launched");

                string pageTitle = driver.Title;
                Assert.That(driver.Title.Contains("Swag Labs"), pageTitle);

                loginPage = new LoginPage();
                loginPage.UserName(pageUtility.userName);
            extentReports.test.Log(Status.Info, "Entered Username");

                loginPage.Password(pageUtility.passWord);
            extentReports.test.Log(Status.Info, "Entered Password");

                inventoryPage = loginPage.LoginButton();
            extentReports.test.Log(Status.Info, "Clicked login button successfully");

            extentReports.test.Log(Status.Pass, "Login Test Passed");
            
   
        }
    }
}
     
                
   



