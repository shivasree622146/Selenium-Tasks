using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.IO;

namespace CommonLibrary.TestReport
{
    public class ExtentReportBaseClass
    {
        public ExtentReports report = null;
        public ExtentTest test =null;
        

        [SetUp]
        public void ExtentStart()
        {   
            string currentDirectory = Environment.CurrentDirectory;
            string project = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            string filePath = project + @"\ReportsForBdd\Bdd.html";
            report = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(filePath);
            report.AttachReporter(htmlReporter);
            
        }
        [TearDown]
        public void ExtentClose()
        {
            report.Flush();
        }

    }

}
