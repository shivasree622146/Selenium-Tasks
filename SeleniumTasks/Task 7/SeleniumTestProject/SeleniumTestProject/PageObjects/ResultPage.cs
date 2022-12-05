using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.PageObjects
{
    public class ResultPage
    {
        IWebDriver driver;
        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.XPath,Using = "//h2[@class='search-results__counter']")]
        public IWebElement results { get; set; }
        public void ResultCount()
        {
            string[] resultCount = results.Text.Split(' ');
            if (Int32.Parse(resultCount[0]) >= 10)
            {
                Console.WriteLine("More than 10 results were found");
            }

            Thread.Sleep(2000);
        }

        [FindsBy(How=How.XPath,Using = "//p[@class='search-results__description']")]
        public IList<IWebElement> resultsInDescription { get; set; }
        public void ResultsInDescription()
        {
            
            for (int i = 0; i < resultsInDescription.Count; i++)
            {
                var eleme = resultsInDescription[i].GetAttribute("innerHTML");
                bool element = eleme.Contains("DevOps");
                if (i <= 11)
                {
                    Assert.True(element);

                }


            }
            Console.WriteLine("search Element there in the description");
        }
    }
}
