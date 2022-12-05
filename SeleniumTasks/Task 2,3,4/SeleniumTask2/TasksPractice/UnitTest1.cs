using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using NUnit.Framework;
using System.Xml.Linq;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.DevTools.V106.IndexedDB;

namespace TasksPractice
{
    public class Tests
    {
        IWebDriver driver;
        //WebDriverWait wait;
        
        [SetUp]
        public void Setup()
        {
        
            //driver = new EdgeDriver();
            driver = new ChromeDriver();
            //wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            //driver = new FirefoxDriver();
        }
        [Test]
        public void TestPassword()
        {
            driver.Navigate().GoToUrl("https://www.amazon.in");
            driver.Manage().Window.Maximize();

            Actions actions = new Actions(driver);
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]"));
            actions.MoveToElement(element).Build().Perform();

            IWebElement signin = driver.FindElement(By.XPath("//*[@id=\"nav-flyout-ya-signin\"]/a/span"));
            signin.Click();
            driver.FindElement(By.Name("email")).SendKeys("shivasree05042000@gmail.com");
            driver.FindElement(By.Id("continue")).Click();
            IWebElement passwordtext = driver.FindElement(By.Name("password"));
            string str = "heloo1254";
            passwordtext.SendKeys(str);
            Assert.That(str.Length > 8 && str.Length < 13);
            driver.Close();



        }

        [Test]
        public void Test1()
        {
            //IWebElement searchbox = driver.FindElement(By.Name("q"));
            //searchbox.SendKeys("Epam systems");
            //IWebElement searchbutton= driver.FindElement(By.XPath("//div[@class='FPdoLc lJ9FBc']//input[@class='gNO89b']"));
            //searchbutton.Click();


            ////task - 1
            //driver.Navigate().GoToUrl("https://www.google.com");
            //driver.Manage().Window.Maximize();
            //IWebElement searchbox = driver.FindElement(By.Name("q"));
            //searchbox.SendKeys("India");
            //driver.FindElement(By.XPath("//div[@class='FPdoLc lJ9FBc']//input[@class='gNO89b']")).Click();
            //driver.Close();

            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();
            //Thread.Sleep(5000);
            
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Close();

            //Thread.Sleep(1000);
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.scrollBy(0,350)", "");
            //IWebElement Elements = driver.FindElement(By.XPath("//h5[text()='Elements']"));
            ////object value = wait.Until(drv => drv.FindElement(By.XPath("//h5[text()='Elements']")));
            //Elements.Click();
            //Thread.Sleep(1000);

            //driver.FindElement(By.XPath("//span[text()='Text Box']")).Click();
            //IWebElement fullname = driver.FindElement(By.Id("userName"));
            //fullname.SendKeys("Shivasree Ambavaram");
            //IWebElement mail = driver.FindElement(By.XPath("//input[@type='email']"));
            //mail.Click();

            //mail.SendKeys("shiva@gmail.com");

            //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            //fluentWait.Timeout = TimeSpan.FromSeconds(5);
            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            //IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            //js1.ExecuteScript("window.scrollBy(0,350)", "");
            //driver.FindElement(By.XPath("//button[@id='submit']")).Click();



        }
        [Test]
        public void Alerts()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            driver.Manage().Window.Maximize();
            //driver.FindElement(By.Id("alertButton")).Click();
            //IAlert alert = driver.SwitchTo().Alert();
            //Thread.Sleep(2000);
            //alert.Accept();

            //IWebElement element = driver.FindElement(By.Id("promtButton"));
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            //IAlert promptalert = driver.SwitchTo().Alert();
            //String alertText = promptalert.Text;
            //Console.WriteLine("Alert text is " + alertText);
            //promptalert.SendKeys("Shivasree");
            //Thread.Sleep(2000);
            //promptalert.Accept();
            driver.FindElement(By.Id("confirmButton")).Click();
            IAlert alert2=driver.SwitchTo().Alert();
            Thread.Sleep(2000);
            alert2.Dismiss();
            Thread.Sleep(2000);
            driver.Close();

        }
        [Test]
        public void WindowHandling()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.WindowHandles.Count);
            foreach(var windowHandle in driver.WindowHandles)
            {
                Console.WriteLine(windowHandle);
            }
            Console.WriteLine(driver.CurrentWindowHandle);
            driver.FindElement(By.Id("windowButton")).Click();
            Console.WriteLine(driver.WindowHandles.Count);
            foreach (var windowHandle in driver.WindowHandles)
            {
                Console.WriteLine(windowHandle);
            }
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Console.WriteLine(driver.CurrentWindowHandle);
            Thread.Sleep(1000);
            driver.Close();
            //string ParentWindow = driver.CurrentWindowHandle;
            //IWebElement clickElement= driver.FindElement(By.Id("tabButton"));
            //for (var i = 0; i < 1; i++)
            //{
            //    clickElement.Click();

            //}
            //driver.SwitchTo().Window(ParentWindow);

            //IWebElement windowclick= driver.FindElement(By.Id("windowButton"));

            //for (var i = 0; i < 1; i++)
            //{
            //    windowclick.Click();

            //}
        }
        [Test]
        public void iframes()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/frames");
            driver.Manage().Window.Maximize();
            var frame = driver.FindElement(By.Id("frame1"));
            driver.SwitchTo().ParentFrame();
            //driver.SwitchTo().Frame("google_esf");
            Console.WriteLine(driver.Title);
          
            driver.Close();
        }
        [Test]
        public void DropDown()
        {
            driver.Navigate().GoToUrl("https://www.amazon.in");
            driver.Manage().Window.Maximize();
            var option = driver.FindElement(By.Id("searchDropdownBox"));
            var selectElement = new SelectElement(option);
            selectElement.SelectByText("Books");
        }
        [Test]
        public void CheckBox()
        {

            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);

            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,350)", "");
            IWebElement Element = driver.FindElement(By.XPath("//h5[text()='Elements']"));
            Thread.Sleep(1000);
            Element.Click();

            IWebElement checkboxbutton = driver.FindElement(By.XPath("//span[text()='Check Box']"));
            checkboxbutton.Click();

            IWebElement checkbox = driver.FindElement(By.XPath("//span[@class='rct-title']"));
            checkbox.Click();
            //checkbox.Click();
            IWebElement icon = driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/ol[1]/li[1]/span[1]/button[1]/*[1]"));
            icon.Click();
            driver.FindElement(By.XPath("//span[text()='Documents']")).Click();

        }
        //task-3,4

        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://demoqa.com");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string title = driver.Title;

            Console.WriteLine(title);
            Console.WriteLine(title.Length);
            string pageUrl = driver.Url;
            Console.WriteLine(pageUrl);
            Console.WriteLine(pageUrl.Length);
           
            string pageSource = driver.PageSource;
            Console.WriteLine(pageSource);
            Console.WriteLine(pageSource.Length);
            driver.Close(); 
        }
        //Task-5
        [Test]
        public void Flipkart()
        {
            driver.Navigate().GoToUrl("https://www.flipkart.com/");
            driver.Manage().Window.Maximize();
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Escape).Build().Perform();
            


        }
        [Test]
        public void DragandDrop()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/droppable");
            driver.Manage().Window.Maximize();
            Actions action= new Actions(driver);
            action.DragAndDrop(driver.FindElement(By.Id("draggable")),
                driver.FindElement(By.Id("droppable")))
                .Build().Perform();
          
            driver.Close();
        }
        [Test]
        public void FillForm()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            driver.Manage().Window.Maximize();
            Actions actions= new Actions(driver);
            actions.Click(driver.FindElement(By.Id("firstName")))
                .SendKeys("shivasree" + Keys.Tab)
                .SendKeys("Ambavaram" + Keys.Tab)
                .SendKeys("shivasreeambavaram6@gmail.com" + Keys.Tab)
                .SendKeys(Keys.PageDown)
                .Build().Perform();

            
           

        }

    }
}