using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTask1
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            Chrome chrome = new Chrome();
            Firefox firefox = new Firefox();
            Edge edge = new Edge();
            //Testing with chrome
            chrome.CreateChromeDriver();
            chrome.OpenChrome();
            chrome.CloseChrome();
            //Testing with firefox
            firefox.CreateFirefoxDriver();
            firefox.OpenFirefox();
            firefox.CloseFirefox();
            //Testing with edge
            edge.CreateEdgeDriver();
            edge.OpenEdge();
            edge.CloseEdge();

        }
    }
    
}
