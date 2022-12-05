using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTestProject.BaseClass;
using SeleniumTestProject.Utilities;

namespace SeleniumTestProject
{
    [TestFixture]
    public class ParallelTesting : BaseTest
    {
        IWebDriver driver;

        [Test]
        public void searchButton()
        {
            var Driver=new BrowserUtility().Init(driver);
            IWebElement searchButton = Driver.FindElement(By.XPath("//button[@class='header-search__button header__icon']"));
            searchButton.Click();
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("frequent-searches__title")));

            //IWebElement ele = driver.FindElements(By.ClassName("frequent-searches__item")).FirstOrDefault(x => x.Text == "DevOps");
            //ele.Click();
            Thread.Sleep(3000);
            IWebElement ele = Driver.FindElement(By.XPath("//div[@class='frequent-searches-ui']/ul"));
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> webElements = ele.FindElements(By.TagName("li"));
            IList<IWebElement> elements = (IList<IWebElement>)webElements;
            foreach (IWebElement li in elements)
            {
                if (li.Text.Equals("DevOps"))
                {
                    li.Click();
                }
            }
            IWebElement findButton = Driver.FindElement(By.ClassName("header-search__submit"));
            findButton.Click();
            //wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Search']")));




        }


    }
}