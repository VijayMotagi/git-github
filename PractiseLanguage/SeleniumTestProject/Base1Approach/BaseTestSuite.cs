using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestProject
{
    [TestClass]
    public class BaseTestSuite
    {
       

        [TestInitialize]
        public void TestInitialize()
        {
            Console.WriteLine("BaseTestSuite.TestInitialize");
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Console.WriteLine("BaseTestSuite.TestCleanup");
        }

    }
}
