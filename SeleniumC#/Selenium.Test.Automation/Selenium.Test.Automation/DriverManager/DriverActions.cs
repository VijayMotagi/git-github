using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
namespace Selenium.Test.Automation.Framework
{
    public class DriverActions
    {
        private IWebDriver driver;
        private OpenQA.Selenium.Interactions.Actions action;
        public DriverActions(IWebDriver d)
        {
            this.driver = d;
        }
        public void MouseHoverOnElement(IWebElement e)
        {
            action = new OpenQA.Selenium.Interactions.Actions(this.driver);
            action.MoveToElement(e).Build().Perform();
            action = null;
        }

       
    }
}
