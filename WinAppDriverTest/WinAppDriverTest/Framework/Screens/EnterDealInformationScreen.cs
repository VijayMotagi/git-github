using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using WinAppDriverTest;

namespace WinAppDriverTest.Framework.Screens
{
    public interface IEnterDealInformationScreen
    {
        WindowsElement DealName { get; }

        WindowsElement DealAliasName { get; }

        WindowsElement Add { get; }

        WindowsElement AddDotDot { get; }

    }
    
    public class EnterDealInformationScreen : IEnterDealInformationScreen
    {
        private WindowsDriver<WindowsElement> driver;

        public EnterDealInformationScreen(WindowsDriver<WindowsElement> _driver)
        {
            this.driver = _driver;
        }
        public WindowsElement DealName => driver.FindElementByName("DealName");

        public WindowsElement DealAliasName => driver.FindElementByName("DealAliasName");

        public WindowsElement Add => driver.FindElementByName("Add");

        public WindowsElement AddDotDot => driver.FindElementByName("Add..");

       

        public void EnterDealInformation(string dealName, string dealAliasName)
        {
            DealName.SendKeys(dealName);

            DealAliasName.SendKeys(dealAliasName);

        }

    }
}
