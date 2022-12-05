using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
namespace SeleniumTask1
{

    public class Base
    {
        public void Open(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
            IWebElement searchElement = driver.FindElement(By.Name("q"));
            searchElement.SendKeys("Epam Systems");
            driver.FindElement(By.XPath("//div[@class='FPdoLc lJ9FBc']//input[@class='gNO89b']")).Click();

        }
    }
}
