using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using globalSQA.PageObjects;
using System.Data;
// Extend Reports Namesapces
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace Selenium.Test.Automation.Framework
{

    [TestClass]
    public class globalSQA_HomePageTest
    {
        #region Driver Related Variables
        private static IWebDriver driver;
        private static DriverManager driverManager = new DriverManager();
        private static UIActions uIActions;
        private static Synchronization sync;
        #endregion
        
        #region Extent Report Variables
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        private static ExtentTest test;
        private static string testResultFile;
        #endregion
        
        #region page variables
        private static globalSQAHomePage homePage;
        #endregion

        #region Class Intialize / Class Cleanup
        [ClassInitialize]
        public static void classInit(TestContext testcontext)
        {

            driver = driverManager.setupBrowser(ConfigurationManager.AppSettings["Browser"]);//new ChromeDriver();
            driver.Url = ConfigurationManager.AppSettings["URL"];
           

        }
        [ClassCleanup]
        public static void cleanup()
        {

            driver.Close();
            driver.Quit();
            driver.Dispose();


        }
        #endregion

        #region Tests
        [TestMethod]
        [DeploymentItem("Data\\DDT.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\DDT.csv", "DDT#csv", DataAccessMethod.Random)]
        public void TestCase1()
        {
            try
            {
                string yrsOfExp = TestContext.DataRow["YrsOfExp"].ToString();
                test.Log(Status.Info, "Running test to select Years Of Exp " + yrsOfExp);
                test.Log(Status.Info, "Mouse Hovering On Tester's Hub Menu");
                homePage.MouseMoverHoverOnTestersHubMenu();
                test.Log(Status.Info, "Clicking on Menu Sample Page Test");
                homePage.ClickOnTestersHub_SamplePageTest_Menu();
                test.Log(Status.Info, "Waiting for Sample Page Test to appear");
                sync.WaitForBrowserTitleChange("Sample Page Testing", 90);
                test.Log(Status.Info, "Selecting Years Of Exp " + yrsOfExp);
                uIActions.SelectComboBoxByValue(homePage.experienceinyearsComboBox, yrsOfExp);
            }
            catch (Exception ex)
            {

                test.Fail(ex.Message);
            }




        }
        [TestMethod]

        [DeploymentItem("Data\\DDT.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\DDT.csv", "DDT#csv", DataAccessMethod.Random)]
        public void TestCase2()
        {
            try
            {
                string yrsOfExp = TestContext.DataRow["YrsOfExp"].ToString();
                test.Log(Status.Info, "Running test to select Years Of Exp " + yrsOfExp);
                test.Log(Status.Info, "Mouse Hovering On Tester's Hub Menu");
                homePage.MouseMoverHoverOnTestersHubMenu();
                test.Log(Status.Info, "Clicking on Menu Sample Page Test");
                homePage.ClickOnTestersHub_SamplePageTest_Menu();
                test.Log(Status.Info, "Waiting for Sample Page Test to appear");
                sync.WaitForBrowserTitleChange("Sample Page Testing", 90);
                test.Log(Status.Info, "Selecting Years Of Exp " + yrsOfExp);
                uIActions.SelectComboBoxByValue(homePage.experienceinyearsComboBox, yrsOfExp);
            }
            catch (Exception ex)
            {

                test.Fail(ex.Message);
            }

        }
        [TestMethod]
        public void TestCase3()
        {

            try
            {
                
                string yrsOfExp = "10+";
                test.Log(Status.Info, "Running test to select Years Of Exp " + yrsOfExp);
                test.Log(Status.Info, "Mouse Hovering On Tester's Hub Menu");
                homePage.MouseMoverHoverOnTestersHubMenu();
                test.Log(Status.Info, "Clicking on Menu Sample Page Test");
                homePage.ClickOnTestersHub_SamplePageTest_Menu();
                test.Log(Status.Info, "Waiting for Sample Page Test to appear");
                sync.WaitForBrowserTitleChange("Sample Page Testing", 90);
                test.Log(Status.Info, "Selecting Years Of Exp " + yrsOfExp);
                uIActions.SelectComboBoxByValue(homePage.experienceinyearsComboBox, yrsOfExp);
            }
            catch (Exception ex)
            {

                test.Fail(ex.Message);
            }


        }
        #endregion

        #region Test Variables
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private static TestContext testContextInstance;
        [TestCleanup]
        public void testcleanup()
        {
            extent.Flush();
            testContextInstance.AddResultFile(testResultFile);
            TakeScreenshot();

        }
        [TestInitialize]
        public void testInit()
        {
            SetupExtentReporting(testContextInstance.TestName + "_" + "TestLog" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            homePage = new globalSQAHomePage(driver, test);
            sync = new Synchronization(driver, test);
            uIActions = new UIActions(driver, test);

        }
        #endregion

        #region Extent Report Component
        private static void SetupExtentReporting(string reportName)
        {
            //To obtain the current solution path/project path
            string assemblyPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) + @"\Reports\";
            string reportPath = assemblyPath + reportName + ".html";


            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            if (pth.Contains("TestResults"))
            {
                string actualPath = pth.Substring(0, pth.LastIndexOf("TestResults"));
                actualPath = Path.Combine(actualPath + @"Selenium.Test.Automation");
                //actualPath = Path.Combine(actualPath + @"Reports");
                string projectPath = new Uri(actualPath).LocalPath;
                reportPath = projectPath + "\\Reports\\" + reportName + ".html";

            }
            //Append the html report file to current project path

            Console.WriteLine(reportPath);
            testResultFile = reportPath;
            htmlReporter = new ExtentHtmlReporter(reportPath);

            htmlReporter.Configuration().Theme = Theme.Dark;

            htmlReporter.Configuration().DocumentTitle = "Test Automation";

            htmlReporter.Configuration().ReportName = "Test Automation Report";

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
            test = extent.CreateTest(testContextInstance.TestName);
        }
        #endregion

        #region Screenshot Component
        private static void TakeScreenshot()
        {
            string screenshotName = testContextInstance.TestName + "_" + "Img" + DateTime.Now.ToString("yyyyMMddHHmmss");
            //To obtain the current solution path/project path
            string assemblyPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) + @"\Reports\";
            string screenshotPath = assemblyPath + screenshotName + ".png";


            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            if (pth.Contains("TestResults"))
            {
                string actualPath = pth.Substring(0, pth.LastIndexOf("TestResults"));
                actualPath = Path.Combine(actualPath + @"Selenium.Test.Automation");
                //actualPath = Path.Combine(actualPath + @"Reports");
                string projectPath = new Uri(actualPath).LocalPath;
                screenshotPath = projectPath + "\\Reports\\" + screenshotName + ".png";

            }
            try
            {
                var ssdriver = driver as ITakesScreenshot;
                var screenshot = ssdriver.GetScreenshot();
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                testContextInstance.AddResultFile(screenshotPath);

            }
            catch (Exception ex)
            {
                test.Warning("Failed to capture screenshot and exception occured " + ex.Message);
            }
            finally
            {

            }

        }
        #endregion
    }
}


