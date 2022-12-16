using OpenQA.Selenium;
using POMSauceDemo.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSauceDemo.Screenshots;

namespace TestSauceDemo.Screenshots
{
    public class ScreenSnap:BasePageClass
    {
        public void TakeScreenshot()
        {
            string current = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(current).Parent.Parent.FullName;
            string screenShotPath = projectDirectory + @"\Screenshots\Snaps.png";
            Console.WriteLine(screenShotPath);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenShotPath, ScreenshotImageFormat.Png);
            driver.Quit();
        }
    }
}
