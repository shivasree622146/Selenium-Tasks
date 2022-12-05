using Gherkin.Ast;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableRow = TechTalk.SpecFlow.TableRow;

namespace FlipkartTask5.StepDefinitions
{

    [Binding]
    public sealed class HomeStepDefinations
    {
        IWebDriver driver = new ChromeDriver();
        string beforeClick="";
        [Given(@"I launch https://www\.flipkart\.com")]
        public void GivenILaunchHttpsWww_Flipkart_Com()
        {
            driver.Navigate().GoToUrl("https://www.flipkart.com");
            driver.Manage().Window.Maximize();
        }
        [Then(@"Login popup window is displayed")]
        public void ThenLoginPopupWindowIsDisplayed()
        {
            bool loginPopUpWindow = driver.FindElement(By.XPath("//div[@class='_3oBhRa col col-2-5 _4H6HH5']//span[text()='Login']")).Displayed;
            Assert.True(loginPopUpWindow);
            Console.WriteLine("Login PopUp Window is displayed");

        }
        [Given(@"I handle login popup winodw to not login to Application")]
        public void GivenIHandleLoginPopupWinodwToNotLoginToApplication()
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Escape).Build().Perform();
            Console.WriteLine("Closed the Login PopUp Window successfully");
        }
        [Then(@"home page is displayed")]
        public void ThenHomePageIsDisplayed()
        {
            string homePageTitle = driver.Title;
            Assert.That(driver.Title.Contains("Online Shopping"), homePageTitle);
            Console.WriteLine("Home page is displayed");
        }
        [When(@"I verify tabname available in home page")]
        public void WhenIVerifyTabnameAvailableInHomePage(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                foreach(string value in row.Values)
                {
                    
                    if (value == "Grocery")
                    {
                        IWebElement groceryTab = driver.FindElement(By.XPath("//div[text()='Grocery']"));
                        groceryTab.Click();
                        Thread.Sleep(2000);
                        string groceryPageTitle = driver.Title;
                        Console.WriteLine("After Clicking grocery tab :" + groceryPageTitle);

                        Assert.IsTrue(driver.Title == "Flipkart Grocery Store - Buy Groceries Online & Get Rs.1 Deals at Flipkart.com", groceryPageTitle);
                        Console.WriteLine("Grocery tab is avaiable in home page");
                        driver.Navigate().Back();

                        Thread.Sleep(2000);
                    }
                    else if (value == "Mobiles")
                    {
                        IWebElement mobilesTab = driver.FindElement(By.XPath("//div[text()='Mobiles']"));
                        mobilesTab.Click();
                        Thread.Sleep(2000);
                        string mobilesPageTitle = driver.Title;
                        Console.WriteLine("After clicking mobile tab :" + mobilesPageTitle);
                        Assert.That(driver.Title.Contains("Mobile Phones Online"), mobilesPageTitle);
                        Console.WriteLine("Mobiles tab is available in home page");
                        driver.Navigate().Back();
                        Thread.Sleep(2000);
                    }
                    else if (value == "Fashion")
                    {
                        bool fashionDisplayed = driver.FindElement(By.XPath("//div[text()='Fashion']")).Displayed;
                        Assert.IsTrue(fashionDisplayed, "Fashion tab is displayed");
                        Console.WriteLine("Fashion tab is available in home page");
                    }
                    else if (value == "Electronics")
                    {
                        bool electronicsDisplayed = driver.FindElement(By.XPath("//div[text()='Electronics']")).Displayed;
                        Assert.IsTrue(electronicsDisplayed, "Electronics tab is displayed");
                        Console.WriteLine("Electronics tab is available in home page");
                    }
                    else if (value == "Home")
                    {
                        bool homeDisplayed = driver.FindElement(By.XPath("//div[text()='Home']")).Displayed;
                        Assert.IsTrue(homeDisplayed, "Home tab is displayed");
                        Console.WriteLine("Home tab is available in home page");
                    }
                    else if (value == "Appliances")
                    {
                        bool appliancesDisplayed = driver.FindElement(By.XPath("//div[text()='Appliances']")).Displayed;
                        Assert.IsTrue(appliancesDisplayed, "Appliances tab is displayed");
                        Console.WriteLine("Appliances tab is available in home page");
                    }
                    else if (value == "Travel")
                    {
                        bool travelDisplayed = driver.FindElement(By.XPath("//div[text()='Travel']")).Displayed;
                        Assert.IsTrue(travelDisplayed, "travel tab is displayed");
                        Console.WriteLine("Travel tab is available in home page");
                    }
                    else if (value == "Top Offers")
                    {
                        bool topOffersDisplayed = driver.FindElement(By.XPath("//div[text()='Top Offers']")).Displayed;
                        Assert.IsTrue(topOffersDisplayed, "TopOffers tab is displayed");
                        Console.WriteLine("Top Offers tab is available in home page");
                    }
                    else if (value == "Beauty Toys & More")
                    {
                        bool beautyToysMoreDisplayed = driver.FindElement(By.XPath("//div[text()='Beauty, Toys & More']")).Displayed;
                        Assert.IsTrue(beautyToysMoreDisplayed, "Beauty, Toys & More tab is displayed");
                        Console.WriteLine("Beauty Toys & More tab is available in home page");
                    }
                    else if (value == "2-Wheelers")
                    {
                        bool twoWheelersDisplayed = driver.FindElement(By.XPath("//div[text()='2-Wheelers']")).Displayed;
                        Assert.IsTrue(twoWheelersDisplayed, "2-Wheelers tab is displayed");
                        Console.WriteLine("2-Wheelers tab is available in home page");

                        Thread.Sleep(2000);
                    }
                }
            }
        }
        [When(@"I click on Electronics tab")]
        public void WhenIClickOnElectronicsTab()
        {
            IWebElement element = driver.FindElement(By.XPath("//div[text()='Electronics']"));
            Actions electronicsTabMouseHover = new Actions(driver);

            electronicsTabMouseHover.MoveToElement(element).Build().Perform();

            
        }
        [When(@"select the electronics gst store")]
        public void WhenSelectTheElectronicsGstStore()
        {
            driver.FindElement(By.XPath("//div[@class='_3XS_gI _7qr1OC']//a[text()='Electronics GST Store']")).Click();

            Thread.Sleep(2000);
        }
        [Then(@"I navigated to the electronics GST Store page")]
        public void ThenINavigatedToTheElectronicsPage()
        {
            string electronicsGstStoreTitle = driver.Title;
            Assert.True(driver.Title.Contains("Electronics GST Store"),electronicsGstStoreTitle);
        }
        [When(@"I go to tv and appliances")]
        public void WhenIGoToTvAndAppliances()
        {
            IWebElement tvAndAppliances = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/div[2]/div/div/span[2]"));
            Actions tvAndAppliancesMouseHover = new Actions(driver);

            tvAndAppliancesMouseHover.MoveToElement(tvAndAppliances).Build().Perform();
          
        }
        [When(@"click on Split ACs")]
        public void WhenClickOnSplitACs()
        {
            driver.FindElement(By.XPath("//a[@title='Split ACs']")).Click();

            Thread.Sleep(2000);
        }
        [Then(@"verify the Split ACs result page")]
        public void ThenVerifyTheSplitACsResultPage()
        {
            string splitAcsDisplayed = driver.Title;
            Assert.True(driver.Title.Contains("Split AC"),splitAcsDisplayed);
            Console.WriteLine("Navigated to the result page");
            IWebElement newestFirst = driver.FindElement(By.XPath("//div[text()='Newest First']"));
            newestFirst.Click();
            //IWebElement scrollDownPage = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/div[3]/div[1]/div[2]/div[25]/div/div/div/a/div[2]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,150)", "");
            //js.ExecuteScript("arguments[0].scrollIntoView()", scrollDownPage);

            Thread.Sleep(3000);
            //IWebElement backToTop = driver.FindElement(By.XPath("//span[text()='Back to top']"));
            //backToTop.Click();
            
            Thread.Sleep(3000);
        }
        [When(@"I click on the result item")]
        public void WhenIClickOnTheResultItem()
        {
            
            IWebElement resultItem = driver.FindElement(By.XPath("//div[@data-id='ACNGGX9SRUTPUXZB']//div[@class='_2kHMtA']"));
            resultItem.Click();
            IWebElement bc = driver.FindElement(By.XPath("//div[@data-id='ACNGGX9SRUTPUXZB']//div[@class='_30jeq3 _1_WHN1']"));
            beforeClick = bc.GetAttribute("innerHTML");
            Console.WriteLine(beforeClick);

            Thread.Sleep(3000);
        }
        [Then(@"I navigated to the item details page")]
        public void ThenINavigatedToTheItemDetailsPage()
        {
            string resultPageTitle = driver.Title;
            Console.WriteLine(resultPageTitle);
        }
        [Then(@"comparing the price before and after clicking on the result item")]
        public void ThenComparingThePriceBeforeAndAfterClickingOnTheResultItem()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            //Assert.That(price, Is.SameAs(driver.FindElement(By.XPath("//div[contains(text(),'₹37,499')]"))));
            IWebElement ac = driver.FindElement(By.XPath("//div[@class='_30jeq3 _16Jk6d']"));
            string afterClick = ac.GetAttribute("innerHTML");
            Console.WriteLine(afterClick);
            Assert.AreEqual(beforeClick, afterClick);

            Console.WriteLine("Both the item prices are same");
            Thread.Sleep(3000);
            driver.Close();

            Thread.Sleep(3000);
            driver.Quit();

        }

    }
}







    

