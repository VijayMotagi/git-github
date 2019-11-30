using System;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace WinAppDriverTest
{
    [TestFixture]
    public class TestSuite2 : BaseTestSuite
    {
       
         [Test]
        public void Test1()
        {

            // Verify that Notepad is started with untitled new file
            Assert.AreEqual(true, base.DriverInstance.Title.Contains("Untitled - Notepad"));

            // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
            base.DriverInstance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);

            
        }
        [Test]
        public void Test2()
        {
            // Keep track of the edit box to be used throughout the  base.DriverInstance
            WindowsElement editBox = base.DriverInstance.FindElementByClassName("Edit");
            Assert.IsNotNull(editBox);
        }
        [Test]
        public void MenuItemEdit()
        {
            WindowsElement editBox = base.DriverInstance.FindElementByClassName("Edit");
            // Select Edit -> Time/Date to get Time/Date from Notepad
            Assert.AreEqual(string.Empty, editBox.Text);
             base.DriverInstance.FindElementByName("Edit").Click();
             base.DriverInstance.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Time/Date\")]").Click();
            string timeDateString = editBox.Text;
            Assert.AreNotEqual(string.Empty, timeDateString);

            // Select all text, copy, and paste it twice using MenuItem Edit -> Select All, Copy, and Paste
             base.DriverInstance.FindElementByName("Edit").Click();
             base.DriverInstance.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Select All\")]").Click();
             base.DriverInstance.FindElementByName("Edit").Click();
             base.DriverInstance.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Copy\")]").Click();
             base.DriverInstance.FindElementByName("Edit").Click();
             base.DriverInstance.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Paste\")]").Click();
             base.DriverInstance.FindElementByName("Edit").Click();
             base.DriverInstance.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Paste\")]").Click();

            // Verify that the Time/Date string is duplicated
            Assert.AreEqual(timeDateString + timeDateString, editBox.Text);
            base.DriverInstance.FindElementByName("Edit").Click();
            base.DriverInstance.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Select All\")]").Click();
            base.DriverInstance.FindElementByName("Edit").Click();
            base.DriverInstance.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Delete\")]").Click();
           

        }
        ~TestSuite2()
        {

            base.DriverQuit();
        }
        [SetUp]
        public override void TestInit()
        {

        }
        public string AppName { get { return "Notepad"; }  }

    }
}
