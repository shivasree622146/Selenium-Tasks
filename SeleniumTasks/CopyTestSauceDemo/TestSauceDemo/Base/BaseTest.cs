using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using POMSauceDemo.BasePage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestSauceDemo.Utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace TestSauceDemo.Base
{
    public class BaseTest :BasePageClass
    {
      
        [SetUp]
        public void SetUp()
        {
            StartInvokeBrowser();
        }
        [TearDown]
        public void Close()
        {
           
            CloseBrowser();
        }
    }
}
