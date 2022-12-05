using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    public class ExtentReportDemo
    {
        ExtentReports extentReports = null;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extentReports = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Shivasree_Ambavaram\source\repos\SeleniumTestProject\SeleniumTestProject\ExtentReports\ExtentReportDemo.html");
            extentReports.AttachReporter(htmlReporter);
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extentReports.Flush();
        }
        [Test]
        public void searchButton1()
        {
            IWebDriver driver = null;
            ExtentTest test = null; ;
            try
            {
                test = extentReports.CreateTest("searchButton1").Info("Test Started");
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.epam.com/");
                driver.Manage().Window.Maximize();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                wait.Until(driver => driver.FindElement(By.XPath("//span[text()='Engineering the Future']")));
                test.Log(Status.Info, "Chrome Browser Launched");

                IWebElement searchButton = driver.FindElement(By.XPath("//button[@class='header-search__button header__icon']"));
                searchButton.Click();
                test.Log(Status.Info, "Clicked search button");
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                //wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("frequent-searches__title")));

                //IWebElement ele = driver.FindElements(By.ClassName("frequent-searches__item")).FirstOrDefault(x => x.Text == "DevOps");
                //ele.Click();
                Thread.Sleep(3000);
                IWebElement ele = driver.FindElement(By.XPath("//div[@class='frequent-searches-ui']/ul"));
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> webElements = ele.FindElements(By.TagName("li"));
                IList<IWebElement> elements = (IList<IWebElement>)webElements;
                foreach (IWebElement li in elements)
                {
                    if (li.Text.Equals("DevOps"))
                    {
                        li.Click();
                    }
                }
                test.Log(Status.Info, "Selected Third Option");

                IWebElement findButton = driver.FindElement(By.ClassName("header-search__submit"));
                findButton.Click();
                test.Log(Status.Info, "Clicked Find Button");
                driver.Close();

                test.Log(Status.Pass, "searchButton1 Password");
                //wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Search']")));
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }
        [Test]
        public void searchButton2()
        {
            IWebDriver driver = null;
            ExtentTest test = null; ;
            try
            {
                test = extentReports.CreateTest("searchButton2").Info("Test Started");
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.epam.com/");
                driver.Manage().Window.Maximize();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                wait.Until(driver => driver.FindElement(By.XPath("//span[text()='Engineering the Future']")));
                test.Log(Status.Info, "Chrome Browser Launched");

                IWebElement searchButton = driver.FindElement(By.XPath("//button[@class='h__button header__icon']"));
                searchButton.Click();
                test.Log(Status.Info, "Clicked search button");
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                //wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("frequent-searches__title")));

                //IWebElement ele = driver.FindElements(By.ClassName("frequent-searches__item")).FirstOrDefault(x => x.Text == "DevOps");
                //ele.Click();
                Thread.Sleep(3000);
                IWebElement ele = driver.FindElement(By.XPath("//div[@class='frequent-searches-ui']/ul"));
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> webElements = ele.FindElements(By.TagName("li"));
                IList<IWebElement> elements = (IList<IWebElement>)webElements;
                foreach (IWebElement li in elements)
                {
                    if (li.Text.Equals("DevOps"))
                    {
                        li.Click();
                    }
                }
                test.Log(Status.Info, "Selected Third Option");

                IWebElement findButton = driver.FindElement(By.ClassName("header-search__submit"));
                findButton.Click();
                test.Log(Status.Info, "Clicked Find Button");
                driver.Close();

                test.Log(Status.Pass, "searchButton2 Password");
                //wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Search']")));
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }
    }
}
