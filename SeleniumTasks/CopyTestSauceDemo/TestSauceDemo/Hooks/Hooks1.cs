using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Gherkin.Ast;
using OpenQA.Selenium.Chrome;
using POMSauceDemo.BasePage;
using TechTalk.SpecFlow;
using TestSauceDemo.Base;
using TestSauceDemo.Screenshots;

namespace TestSauceDemo.Hooks
{
    [Binding]
    public sealed class Hooks1 :BaseTest
    {

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            SetUp();

        }
     


        [AfterScenario("@tag1")]
        public void AfterScenario()
        {
            Close();
        }
    }
}