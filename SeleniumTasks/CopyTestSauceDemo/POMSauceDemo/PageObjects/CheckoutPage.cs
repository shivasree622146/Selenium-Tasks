using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POMSauceDemo.BasePage;
using CommonLibrary.Extensions;
using AventStack.ExtentReports;

namespace POMSauceDemo.PageObjects
{
    public class CheckoutPage:BasePageClass
    {
       
        #region Locators
        By pageDisplayed = By.XPath("//span[text()='Checkout: Your Information']");
        By firstName = By.Id("first-name");
        By lastName = By.Name("lastName");
        By zipCode = By.Id("postal-code");
        By continueButton = By.Id("continue");
        By checkoutOverview = By.XPath("//span[text()='Checkout: Overview']");
        By finishButton = By.Id("finish");
        By totalCost = By.XPath("//div[@class='summary_total_label']");
        By checkoutCompleteTitle = By.XPath("//span[text()='Checkout: Complete!']");
        By errorMessage = By.XPath("//div[@class='error-message-container error']");
        #endregion
        public string GetCheckOutPageText()
        {
            extentReports.test = extentReports.report.CreateTest("Checkout Test").Info("Test started");
            extentReports.test.Log(Status.Info, "Checkout details page displayed");
            return driver.FindElement(pageDisplayed).Text;
          
        }
        public void FirstName(string firstname)
        {
            driver.FindElement(firstName).SetValue(firstname);
            extentReports.test.Log(Status.Info, "Entered Firstname");
        }
        public void LastName(string lastname)
        {
            driver.FindElement(lastName).SetValue(lastname);
            extentReports.test.Log(Status.Info, "Entered Lastname");
        }
        public void ZipCode(string zipcode)
        {
            driver.FindElement(zipCode).SetValue(zipcode);
            extentReports.test.Log(Status.Info, "Entered PostalCode");
        }
        public void ClickContinue()
        {
            driver.FindElement(continueButton).ClickOnIt();
            extentReports.test.Log(Status.Info, "Clicked Continue Button");
        }
        public string CheckoutPageOverview()
        {
            extentReports.test.Log(Status.Info, "Navigated to checkout Overview page");
            return driver.FindElement(checkoutOverview).Text;
        
        }
        public string CheckTotalCost()
        {
            string cost= driver.FindElement(totalCost).Text;
            string[] splitText = cost.Split(' ');
            string parts = splitText[1];
            Console.WriteLine(parts);
            extentReports.test.Log(Status.Info, "Checked total cose of product");
            return parts;
          
        }
        public void ClickFinish()
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.PageDown);
            driver.FindElement(finishButton).ClickOnIt();
            extentReports.test.Log(Status.Info, "Clicked Finish button");
        }
        public string CheckoutCompletePageTitle()
        {
            extentReports.test.Log(Status.Info, "Navigated to checkout complete page");
            extentReports.test.Log(Status.Pass, " Checkout Test Passed");
            return driver.FindElement(checkoutCompleteTitle).Text;
      
        }
        public bool CheckErrorMessageDisplayed()
        {
            extentReports.test.Log(Status.Info, "Error Message displayed");
            extentReports.test.Log(Status.Pass, " Invalid Checkout details Test Passed");
            extentReports.test.Log(Status.Pass, " Checkout Test Passed");
            return driver.FindElement(errorMessage).Displayed;

        } 
    }
}
