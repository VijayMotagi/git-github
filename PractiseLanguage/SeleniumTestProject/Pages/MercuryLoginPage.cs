using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTestProject.Pages
{
   public class MercuryLoginPage
    {
        
        private IWebDriver _driver;
        public MercuryLoginPage(IWebDriver driver)
        {
            this._driver = driver;       

            PageFactory.InitElements(driver, this);
            
        }

        [FindsBy(How = How.Name, Using = "userName")]
        public IWebElement txtUserName;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement txtPassword;

    }
}
