using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace Selenium.Test.Automation.Framework
{
    public class DriverManager
    {
        private IWebDriver driver;
        
        public IWebDriver setupBrowser(string browser)
        {
            switch (browser.ToUpper())
            {
                case "CHROME":
                    this.driver = new ChromeDriver();
                    break;
                case "FIREFOX":
                    this.driver = new FirefoxDriver();
                    break;
                case "INTERNETEXPLORER":
                    var options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    options.EnsureCleanSession = true;
                    options.IgnoreZoomLevel = true;
                    this.driver = new InternetExplorerDriver(options);
                    break;
                case "EDGE":
                    this.driver = new EdgeDriver();
                    break;
            }
            this.driver.Manage().Window.Maximize();
            return this.driver;
        }
        

    }
}
