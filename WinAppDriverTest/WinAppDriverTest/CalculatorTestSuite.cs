using System;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace WinAppDriverTest
{
    [TestFixture]
    public class CalculatorTests:BaseTestSuite
    {
        
        ~CalculatorTests()
        {

            base.DriverQuit();
        }
       
       
        [Test]
        public void Addition()
        {
           
             base.DriverInstance.FindElementByName("Five").Click();
             base.DriverInstance.FindElementByName("Plus").Click();
             base.DriverInstance.FindElementByName("Seven").Click();
             base.DriverInstance.FindElementByName("Equals").Click();

            var calculatorResult = GetCalculatorResultText();
            Assert.AreEqual("12", calculatorResult);
        }
        [Test]
        public void Division()
        {
             base.DriverInstance.FindElementByAccessibilityId("num8Button").Click();
             base.DriverInstance.FindElementByAccessibilityId("num8Button").Click();
             base.DriverInstance.FindElementByAccessibilityId("divideButton").Click();
             base.DriverInstance.FindElementByAccessibilityId("num1Button").Click();
             base.DriverInstance.FindElementByAccessibilityId("num1Button").Click();
             base.DriverInstance.FindElementByAccessibilityId("equalButton").Click();
            Assert.AreEqual("8", GetCalculatorResultText());
        }
        [Test]
        public void Multiplication()
        {
             base.DriverInstance.FindElementByXPath("//Button[@Name='Nine']").Click();
             base.DriverInstance.FindElementByXPath("//Button[@Name='Multiply by']").Click();
             base.DriverInstance.FindElementByXPath("//Button[@Name='Nine']").Click();
             base.DriverInstance.FindElementByXPath("//Button[@Name='Equals']").Click();
            Assert.AreEqual("81", GetCalculatorResultText());
        }
        [Test]
        public void Subtraction()
        {
             base.DriverInstance.FindElementByXPath("//Button[@AutomationId='num9Button']").Click();
             base.DriverInstance.FindElementByXPath("//Button[@AutomationId='minusButton']").Click();
             base.DriverInstance.FindElementByXPath("//Button[@AutomationId='num1Button']").Click();
             base.DriverInstance.FindElementByXPath("//Button[@AutomationId='equalButton']").Click();
            Assert.AreEqual("8", GetCalculatorResultText());
        }
        [Test]
        [TestCase("One", "Plus", "Seven", "8")]
        [TestCase("Nine", "Minus", "One", "8")]
        [TestCase("Eight", "Divide by", "Eight", "1")]
        public void Templatized(string input1, string operation, string input2, string expectedResult)
        {
             base.DriverInstance.FindElementByName(input1).Click();
             base.DriverInstance.FindElementByName(operation).Click();
             base.DriverInstance.FindElementByName(input2).Click();
             base.DriverInstance.FindElementByName("Equals").Click();
            Assert.AreEqual(expectedResult, GetCalculatorResultText());
        }
        private string GetCalculatorResultText()
        {
            return  base.DriverInstance.FindElementByAccessibilityId("CalculatorResults").Text.Replace("Display is", string.Empty).Trim();
        }
        public string AppName { get { return "Calculator"; } }
    }
}
