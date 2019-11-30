using System;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace WinAppDriverTest
{
    [TestFixture]
    public  class TestSuite1 : BaseTestSuite
    {
       

        [Test]
        public void Test1()
        {
            
            CalculatorNumberButton.One.Click();
            CalculatorNumberButton.Four.Click();
           

            
        }
        [Test]
        public void Test2()
        {
            CalculatorNumberButton.Two.Click();
            CalculatorNumberButton.Three.Click();
        }

        ~TestSuite1()
        {

            base.DriverQuit();
        }
        public string AppName { get { return "Calculator"; } }
        public CalculatorNumberButton CalculatorNumberButton { get { return new CalculatorNumberButton(base.DriverInstance); } }
    }
}
