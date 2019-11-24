using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    public interface IDriverHelper
    {
        void NavigateToURL(string url);
        void MaximixeBrowserWindow();
        void QuitDriver();
        IWebDriver DriverInstance();
    }
}
