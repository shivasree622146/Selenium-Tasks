
using AventStack.ExtentReports;
using CommonLibrary.TestReport;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace POMSauceDemo.BasePage
{
    public class BasePageClass 
    {
        public static IWebDriver driver;
        public static ExtentReportBaseClass extentReports = new ExtentReportBaseClass(); 
        protected PageUtilityClass pageUtility = new PageUtilityClass();
        public void StartInvokeBrowser()
        {
            
            extentReports.ExtentStart();
            InitialBrowser(pageUtility.browserName);
        }

        public void InitialBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    driver.Navigate().GoToUrl(pageUtility.sauceUrl);
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    driver.Navigate().GoToUrl(pageUtility.sauceUrl);
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    driver.Navigate().GoToUrl(pageUtility.sauceUrl);
                    break;
            }
        }
        public void CloseBrowser()
        {
            extentReports.ExtentClose();
            driver.Close();
        }



    }
}
