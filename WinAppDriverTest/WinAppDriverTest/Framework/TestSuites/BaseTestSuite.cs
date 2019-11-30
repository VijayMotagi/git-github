using System;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace WinAppDriverTest
{
    [TestFixture]
    public abstract class BaseTestSuite : DriverContext
    {
        
        [SetUp]
        public virtual void TestInit()
        {
            base.DriverInstance.FindElementByName("Clear").Click();

        }
        [TearDown]
        public virtual void TestCleanup()
        {

        }



        



    }
}
