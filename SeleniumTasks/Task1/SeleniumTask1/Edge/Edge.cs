using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace EdgeNunit
{
    public class EdgeTests
    {
        IWebDriver dv;
        [SetUp]
        public void Setup()
        {
            dv = new EdgeDriver();
        }

        [Test]
        public void EdgeTest()
        {
            dv.Navigate().GoToUrl("https://www.google.com");
            dv.Manage().Window.Maximize();
            IWebElement searchElement = dv.FindElement(By.Name("q"));
            searchElement.SendKeys("India");
            dv.FindElement(By.XPath("//div[@class='FPdoLc lJ9FBc']//input[@class='gNO89b']")).Click();

        }
        [TearDown]
        public void CloseEdge()
        {
            dv.Close();
        }
    }
}