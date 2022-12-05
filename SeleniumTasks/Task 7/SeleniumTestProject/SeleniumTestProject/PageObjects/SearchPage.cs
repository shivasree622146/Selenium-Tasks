using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SeleniumTestProject.PageObjects
{
    public class SearchPage
    {
        IWebDriver driver;
        string searchElement = "";
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@class='header-search__button header__icon']")]
        public IWebElement searchButton { get; set; }


        public void NavigateToResultPage()
        {
            searchButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("frequent-searches__title")));
        }
        [FindsBy(How=How.XPath,Using = "//div[@class='frequent-searches-ui']/ul")]
        public IWebElement searchResult { get; set; }
        public void SearchResultName()
        {
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> webElements = searchResult.FindElements(By.TagName("li"));
            IList<IWebElement> elements = (IList<IWebElement>)webElements;
            for (int i = 0; i < elements.Count; i++)
            {
                if(i == 2)
                {
                    elements[i].Click();
                    searchElement = elements[i].GetAttribute("innerHTML");
                    Thread.Sleep(2000);
                }
            }
        }
        [FindsBy(How=How.XPath,Using = "//button[@class='header-search__submit']")]
        public IWebElement findButton { get; set; }
        public ResultPage FindButton()
        {
            findButton.Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,200)", "");
            return new ResultPage(driver);
        }
    }
}
