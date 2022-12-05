using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTask1
{
    public class Chrome : Base
    {
        IWebDriver driver;

        public void CreateChromeDriver()
        {
            driver=new ChromeDriver();
        }
        public void OpenChrome()
        {
            Open(driver);
        }
        public void CloseChrome()
        {
            driver.Close();
        }
    }
}
