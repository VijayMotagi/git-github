using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
   public abstract class DriverContext
    {
        protected IWebDriver driver;
        public DriverContext(IWebDriver _driver,string browsername)
        {
            this.driver = driver = new ChromeDriver();

            
        }

       
    }
}
