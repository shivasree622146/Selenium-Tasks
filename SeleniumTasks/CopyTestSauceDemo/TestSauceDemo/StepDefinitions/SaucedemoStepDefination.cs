using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestSauceDemo.Base;
using POMSauceDemo.BasePage;
using CommonLibrary.Extensions;
using POMSauceDemo.PageObjects;

namespace TestSauceDemo.StepDefinitions
{
    [Binding]
    public class SaucedemoStepDefination: BaseTest
    {
        
        LoginPage loginPage = new LoginPage();
        
        [Given(@"I launch the Saucedemo application")]
        public void GivenILaunchTheSaucedemoApplication()
        {
            loginPage.NavigateTo();
        }

        [Then(@"login page is displayed")]
        public void ThenLoginPageIsDisplayed()
        {
            Assert.True(loginPage.PageUrl().Contains("https://www.saucedemo.com/"));

        }

        [When(@"I enter the (.*)")]
        public void WhenIEnterTheStandard_User(string username)
        {
            loginPage.UserName(username);
        }
        [When(@"I also enter the (.*)")]
        public void WhenIAlsoEnterTheSecret_Sauce(string password)
        {
            loginPage.Password(password);
        }

        [When(@"Click the login button")]
        public void WhenClickTheLoginButton()
        {
            loginPage.LoginButton();
        }

        [Then(@"list of products page is displayed")]
        public void ThenListOfProductsPageIsDisplayed()
        {
            bool homePageDisplay = driver.Url.Contains("inventory.html");
            Assert.True(homePageDisplay);
            Console.WriteLine(homePageDisplay);
        }

        
        [Then(@"error messages should display")]
        public void ThenErrorMessagesShouldDisplay()
        {
            Assert.True(loginPage.ErrorMessage());
        }

}
}
