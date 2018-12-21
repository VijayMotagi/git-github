using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium.Test.Automation.Framework;
using AventStack.ExtentReports;

namespace globalSQA.PageObjects
{
    public class globalSQAHomePage
    {
        private IWebDriver driver;
        private DriverActions driverActions;
        private Synchronization sync;
        private UIActions uiActions;
        private ExtentTest test;
        public globalSQAHomePage(IWebDriver driver, ExtentTest t)
        {
            this.driver = driver;
            driverActions = new DriverActions(this.driver);
            sync = new Synchronization(this.driver,t);
            uiActions = new UIActions(this.driver,t);
            PageFactory.InitElements(this.driver, this);
            this.test = t;
        }
        public By By_TestersHub_SamplePageTest_Menu = By.XPath("//a/span[text()='Sample Page Test']");

        [FindsBy(How = How.XPath, Using = "//a[text()='Tester’s Hub']")]
        public IWebElement TestersHubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//a/span[text()='Sample Page Test']")] 
        public IWebElement TestersHub_SamplePageTest_Menu { get; set; }

        [FindsBy(How = How.Id, Using = "g2599-experienceinyears")]
        public IWebElement experienceinyearsComboBox{ get; set; }
        


        public void MouseMoverHoverOnTestersHubMenu()
        {
            this.driverActions.MouseHoverOnElement(this.TestersHubMenu);
            this.test.Log(Status.Pass, "Successful mover hover on Tester's Hub Main Menu");
        }
        public void ClickOnTestersHub_SamplePageTest_Menu()
        {
            sync.WaitForElement(this.By_TestersHub_SamplePageTest_Menu, 10);
            TestersHub_SamplePageTest_Menu.Click();
            this.test.Log(Status.Pass, "Successful click on Sample Page Test Menu");
        }
        
    }

}