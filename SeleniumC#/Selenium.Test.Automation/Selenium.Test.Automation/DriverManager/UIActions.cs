using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;

namespace Selenium.Test.Automation.Framework
{
    public class UIActions
    {
        private ExtentTest test;
        public UIActions(IWebDriver d,ExtentTest t)
        {
            this.test = t;
        }
        public void SelectComboBoxByValue(IWebElement e, String value)
        {
            SelectElement select = new SelectElement(e);
            select.SelectByValue(value);
            test.Log(Status.Pass, "Selected Value " + value);
        }
        public void SelectComboBoxByVisibleText(IWebElement e, String visibleText)
        {
            SelectElement select = new SelectElement(e);
            select.SelectByText(visibleText);
            test.Log(Status.Pass, "Selected Text " + visibleText);
        }
        public void SelectComboBoxByIndex(IWebElement e, int index)
        {
            SelectElement select = new SelectElement(e);
            select.SelectByIndex(index);
            test.Log(Status.Pass, "Selected Index " + index.ToString());
        }


    }
}
