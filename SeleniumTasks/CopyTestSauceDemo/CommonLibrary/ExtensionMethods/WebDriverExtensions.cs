using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonLibrary.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebDriver driver;

        static WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(3));

        public static void SetValue(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }
        public static void ClickOnIt(this IWebElement element)
        {
            element.Click();
        }
        public static void ElementIsExists(By element)
        {
            if (element == null)
            {
                wait.Until(ExpectedConditions.ElementExists(element));
            }
        }
        public static void ElementVisible(By element) => wait.Until(ExpectedConditions.ElementIsVisible(element));
        public static void TitleContains(string element) => wait.Until(ExpectedConditions.TitleContains(element));
        public static bool IsDisplayed(this IWebElement element)
        {
            bool result;
            try
            {
                result = element.Displayed;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public static void javaScriptScrollTillElementFound(string element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public static void click(WebDriver driver, By by)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                driver.FindElement(by).Click();
            }

            catch (StaleElementReferenceException sere)
            {
                driver.FindElement(by).Click();
            }
        }
        public static void Sleep(this IWebDriver driver, int sleeptime)
        {
            Thread.Sleep(sleeptime * 1000);
        }
        public static bool IsChecked(this IWebDriver driver, By by)
        {
            return driver.FindElement(by).Selected;
        }


    }
}
