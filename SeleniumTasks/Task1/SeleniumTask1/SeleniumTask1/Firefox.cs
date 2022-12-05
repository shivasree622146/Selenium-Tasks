using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace SeleniumTask1
{
    public class Firefox :Base
    {
        IWebDriver driver;

        public void CreateFirefoxDriver()
        {
            driver = new FirefoxDriver();
        }
        public void OpenFirefox()
        {
            Open(driver);
        }
        public void CloseFirefox()
        {
            driver.Close();
        }

    }
}
