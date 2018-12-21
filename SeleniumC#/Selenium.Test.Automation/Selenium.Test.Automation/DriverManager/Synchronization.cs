using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Test.Automation.Framework
{
    public class Synchronization
    {
        private IWebDriver driver;
        private ExtentTest test;
        public Synchronization(IWebDriver d, ExtentTest t)
        {
            this.driver = d;
            this.test = t;
        }
        public void WaitForElement(By by, double timeoutInSeconds)
        {
            test.Log(Status.Pass, "");
            WebDriverWait wait = new WebDriverWait(this.driver, System.TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            test.Log(Status.Pass, "WaitForElement successful");
        }

        public void WaitForBrowserTitleChange(string pageTitle, double timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, System.TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(pageTitle));
            test.Log(Status.Pass, "WaitForBrowserTitleChange successful");
        }
        public void WaitForBrowserUrlContains(string urlContains, double timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, System.TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(urlContains));
            test.Log(Status.Pass, "WaitForBrowserUrlContains successful");
        }

    }
}
