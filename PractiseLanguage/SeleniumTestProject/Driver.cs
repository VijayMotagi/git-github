using OpenQA.Selenium;
using SeleniumTestProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    public class Driver  : DriverContext
    {
        
        public  Driver(IWebDriver driver,string browsername):base(driver, browsername)
        {
           
        }

        public IWebDriver DriverInstance()
        {
            return base.driver;
        }
        public void NavigateToURL(string url)
        {

            base.driver.Navigate().GoToUrl(url);
        }

        public void MaximixeBrowserWindow()
        {
            base.driver.Manage().Window.Maximize();
        }

        public void QuitDriver()
        {
            try
            {
                base.driver.Quit();
                base.driver.Dispose();

            }
            catch (Exception)
            {


            }

        }

        public MercuryLoginPage MercuryLoginPage { get { return new MercuryLoginPage(base.driver); } }

    }
}
