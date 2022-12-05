using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;

namespace SeleniumTask1
{
    public class Edge  : Base
    {
        IWebDriver driver;

        public void CreateEdgeDriver()
        {
            driver = new EdgeDriver();
        }
        public void OpenEdge()
        {
            Open(driver);
        }
        public void CloseEdge()
        {
            driver.Close();
        }
    }
}
