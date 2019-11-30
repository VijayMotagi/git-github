using System;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;

namespace WinAppDriverTest
{
    [TestFixture]
    public class TestSuite6 : BaseTestSuite
    {

        [Test]
        public void Test1()
        {

            try
            {
                base.DriverInstance.FindElement(By.Id("ContentElement")).Click();
                //base.DriverInstance.FindElement(By.Id("NoteMenuButton")).Click();
                //base.DriverInstance.FindElement(By.Name("All notes")).Click();

            }
            catch (Exception)
            {


            }



        }

        ~TestSuite6()
        {

            base.DriverQuit();
        }
        [SetUp]
        public override void TestInit()
        {


        }
        public string AppName { get { return "Sticky Notes"; } }

    }
}
