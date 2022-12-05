using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTestProject.BaseClass;
using System.Collections;
using System.Linq;

namespace SeleniumTestProject
{
    [TestFixture]
    public class Tests : BaseTest
    {

        [Test]
        public void searchButton()
        {
            string searchElement="";
            try
            {
                //IWebElement searchButton = driver.FindElement(By.XPath("//button[@class='header-se']"));
                IWebElement searchButton = driver.FindElement(By.XPath("//button[@class='header-search__button header__icon']"));
                searchButton.Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("frequent-searches__title")));
                IWebElement ele = driver.FindElement(By.XPath("//div[@class='frequent-searches-ui']/ul"));
                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> webElements = ele.FindElements(By.TagName("li"));
                IList<IWebElement> elements = (IList<IWebElement>)webElements;
                for(int i =1; i < elements.Count; i++)
                {
                    if(i==2)
                    {
                        elements[i].Click();
                        Console.WriteLine(elements[i].Text);
                        searchElement = elements[i].GetAttribute("innerHTML");
                    }

                }
                //foreach (IWebElement li in elements)
                //{
                //    if (li.Text.Equals("DevOps"))
                //    {
                //        li.Click();
                //    }
                //}
                IWebElement findButton = driver.FindElement(By.ClassName("header-search__submit"));
                findButton.Click();
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Search']")));
              
                Thread.Sleep(3000);

                IWebElement results = driver.FindElement(By.XPath("//h2[@class='search-results__counter']"));
                Console.WriteLine(results.Text);
                string[] resultCount = results.Text.Split(' ');
                if (Int32.Parse(resultCount[0]) >= 10)
                {
                    Console.WriteLine("More than 10 results were found");
                }
                
                Thread.Sleep(2000);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,200)", "");
                //IList<IWebElement> resultLinks = driver.FindElements(By.TagName("article"));

                IList<IWebElement> resultsInDescription = driver.FindElements(By.XPath("//p[@class='search-results__description']"));
                for (int i = 0; i < resultsInDescription.Count; i++)
                {
                    var eleme = resultsInDescription[i].GetAttribute("innerHTML");
                    bool element = eleme.Contains(searchElement);
                    if (i<=11)
                    {
                       
                        //Console.WriteLine(resultLinks[i].Text);
                        Assert.True(element);
                       
                    }
                  

                }
                Console.WriteLine("search Element there in the description : " +searchElement);






            }
            catch (Exception e)
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile("C:\\Users\\Shivasree_Ambavaram\\source\\repos\\SeleniumTestProject\\SeleniumTestProject\\Screenshots\\s1.png", ScreenshotImageFormat.Png);
                Console.WriteLine(e.StackTrace);
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

