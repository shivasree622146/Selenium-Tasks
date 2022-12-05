using SeleniumTestProject.BaseClass;
using SeleniumTestProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.TestScripts
{
    [TestFixture]
    public class Module1 : BaseTest
    {
        [Test]
        public void TestMethod()
        {
            var searchpage = new SearchPage(driver);
            searchpage.NavigateToResultPage();
            searchpage.SearchResultName();
            var resultPage=searchpage.FindButton();
            resultPage.ResultCount();
            resultPage.ResultsInDescription();
            Thread.Sleep(2000);
        }
    }
}
