using AventStack.ExtentReports;
using CommonLibrary.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POMSauceDemo.BasePage;
using System;

namespace POMSauceDemo.PageObjects
{
    public class LoginPage : BasePageClass
    {
        #region Locators
        By username = By.Id("user-name");
        By password = By.Id("password");
        By login = By.Name("login-button");
        By homePageDisplay = By.XPath("//div[@id='inventory_container']");
        By errorMessages = By.XPath("//div[@class='error-message-container error']");
       
        #endregion

        public string PageUrl()
        {
            string pageUrl = driver.Url;
            Console.WriteLine(pageUrl);
            return pageUrl;
        }
        public void NavigateTo()
        {
            driver.Navigate().GoToUrl(PageUrl());
            extentReports.test = extentReports.report.CreateTest("Login Test Report").Info("Test started");
            extentReports.test.Log(Status.Info, "Navigated to Url");
        }

        public void UserName(string userName)
        {
            driver.FindElement(username).SetValue(userName);
            extentReports.test.Log(Status.Info, "Username entered into Usename text field");
        }

        public void Password(string passWord)
        {
            driver.FindElement(password).SetValue(passWord);
            extentReports.test.Log(Status.Info, "Password entered into Usename text field");
        }
    
        public bool ErrorMessage()
        {
            extentReports.test.Log(Status.Info, "Error Message is displayed");
            extentReports.test.Log(Status.Pass, "Login Test Passed");
            return driver.FindElement(errorMessages).Displayed;
      
        }

        public InventoryPage LoginButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
            wait.Until(driver => driver.FindElement(login));
            //WebDriverExtensions.ElementVisible(login);
            driver.FindElement(login).ClickOnIt();
            extentReports.test.Log(Status.Info, "Clicked Login Button");
            extentReports.test.Log(Status.Pass, "Login Test Passed");
            return new InventoryPage();
        }
     
    }
}
