using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Selenium.Test.Automation.Framework
{
    [TestFixture]
    public class ExtentReportsWithNUnit
    {
        private static IWebDriver driver;
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        private static ExtentTest test;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            //To obtain the current solution path/project path

            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            string projectPath = new Uri(actualPath).LocalPath;



            //Append the html report file to current project path

            string reportPath = projectPath + "Reports\\TestRunReport.html";


            htmlReporter = new ExtentHtmlReporter(reportPath);

            htmlReporter.Configuration().Theme = Theme.Dark;

            htmlReporter.Configuration().DocumentTitle = "Test Automation";

            htmlReporter.Configuration().ReportName = "Test Automation Report";

            /*htmlReporter.Configuration().JS = "$('.brand-logo').text('test image').prepend('<img src=@"file:///D:\Users\jloyzaga\Documents\FrameworkForJoe\FrameworkForJoe\Capgemini_logo_high_res-smaller-2.jpg"> ')";*/
            htmlReporter.Configuration().JS = "$('.brand-logo').text('').append('<img src=D:\\Users\\jloyzaga\\Documents\\FrameworkForJoe\\FrameworkForJoe\\Capgemini_logo_high_res-smaller-2.jpg>')";
            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void InitBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void PassingTest()
        {
            test = extent.CreateTest("Passing test","This test cases is to test pass one");
            test.Log(Status.Info, "Step 1");
            driver.Navigate().GoToUrl("http://www.google.com");

            try
            {
                test.Log(Status.Info, "Step 2");
                Assert.IsTrue(true);
                test.Pass("Assertion passed");
            }
            catch (AssertionException)
            {
                test.Fail("Assertion failed");
                throw;
            }
        }

        [Test]
        public void FailingTest()
        {
            test = extent.CreateTest("Failing test", "This test cases is to test fail one");
            test.Log(Status.Info, "Step 1");
            driver.Navigate().GoToUrl("http://www.yahoo.com");

            try
            {
                test.Log(Status.Info, "Step 2");
                Assert.IsTrue(false);
                test.Pass("Assertion passed");
            }
            catch (AssertionException)
            {
                test.Fail("Assertion failed");
                throw;
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [OneTimeTearDown]
        public void GenerateReport()
        {
            extent.Flush();
        }
    }
}