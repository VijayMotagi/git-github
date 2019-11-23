using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    [TestClass]
    public class TestBase
    {
        private static Driver _driver;
        static TestBase()
        {
            IWebDriver driver = null;
            _driver = new Driver(driver, "Chrome");
            
            s_log = new StringBuilder();
            Log.AppendLine("--------------------------------------");
            Log.AppendLine("TestBase.TestBase() <-- acts as ClassInitialize in base");
            Log.AppendLine("Here you can setup the code which will be used to all module which inherits Test Base");
            Log.AppendLine("--------------------------------------");
        }

        [TestInitialize]
        public void BaseTestInit()
        {
            Driver.MaximixeBrowserWindow();
            Log.AppendLine("--------------------------------------");
            Log.AppendLine("TestBase.BaseTestInit()");
            Log.AppendLine("Here you can setup the test setup for the test case");
            Log.AppendLine("--------------------------------------");
        }

        [TestCleanup]
        public void BaseTestCleanup()
        {
            Log.AppendLine("--------------------------------------");
            Log.AppendLine("TestBase.BaseTestCleanup()");
            Log.AppendLine("Here you can setup the cleanup for the test case");
            Log.AppendLine("--------------------------------------");
            Console.WriteLine(Log.ToString());
            Log.Clear();
        }

        public static StringBuilder Log
        {
            get { return s_log; }
        }

        static StringBuilder s_log;

        public static Driver Driver
        {
            get { return _driver; }
        }
        ~TestBase()
        {
            Driver.QuitDriver();
        }
    }
}
