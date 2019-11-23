using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestProject
{
    [TestClass]
    public class TestSuite1 : BaseTestSuite
    {
        
       private static Driver Driver;
       

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Console.WriteLine("TestSuite1.ClassInitialize");
            IWebDriver driver = null;
            Driver = new Driver( driver, "Chrome");

            Driver.DriverInstance();
            Driver.MaximixeBrowserWindow();
            
            
        }
        


        [TestMethod]
        public void TestCase1()
        {
            Console.WriteLine("TestSuite1.TestCase1");
            Driver.NavigateToURL("http://www.newtours.demoaut.com/");
        }
        [TestMethod]
        public void TestCase2()
        {
            Console.WriteLine("TestSuite1.TestCase2");
            Driver.NavigateToURL("http://www.google.com/");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("TestSuite1.ClassCleanup");
            Driver.QuitDriver();
        }
    }
}
