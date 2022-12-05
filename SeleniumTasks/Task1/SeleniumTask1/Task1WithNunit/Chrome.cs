using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChromeNunit
{
    public class ChromeTests
    {
        IWebDriver dv;
        [SetUp]
        public void Setup()
        {
            dv=new ChromeDriver();
        }

        [Test]
        public void ChromeTest()
        {
            dv.Navigate().GoToUrl("https://www.google.com");
            dv.Manage().Window.Maximize();
            IWebElement searchElement = dv.FindElement(By.Name("q"));
            searchElement.SendKeys("India");
            dv.FindElement(By.XPath("//div[@class='FPdoLc lJ9FBc']//input[@class='gNO89b']")).Click();

        }
        [TearDown]
        public void CloseChrome()
        {
            dv.Close();
        }
    }
}