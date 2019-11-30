using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Reflection;
using System.Diagnostics;
using System.Linq;

namespace WinAppDriverTest
{
     public abstract class DriverContext
     {
        private WindowsDriver<WindowsElement> _driver;
        private string appNameToTest = string.Empty;
        private WindowsElement _desktop;
        public DriverContext()
        {
            this.CheckWinAppDriverIsRunning();

            this.GetApplicationName();

            var options = new AppiumOptions();
           
            GetAppiumOption(ref options);
           
             options.AddAdditionalCapability("deviceName", "WindowsPC");
            _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            SetDesktopElement();
        }
        private void GetAppiumOption(ref AppiumOptions options)
        {
            if (appNameToTest == "Notepad")
            {

                options.AddAdditionalCapability("app", @"C:\Windows\System32\notepad.exe");
            }
            else if (appNameToTest == "Calculator")
            {
                options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

            }
            else if (appNameToTest == "Sticky Notes")
            {
                options.AddAdditionalCapability("app", @"Microsoft.MicrosoftStickyNotes_8wekyb3d8bbwe!App");
            }
            else if (appNameToTest == "Flight")
            {
                options.AddAdditionalCapability("app", @"D:\Technical\UFT\InstallUFT\samples\Flights Application\FlightsGUI.exe");

            }
        }
       
        private void SetDesktopElement()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Root");
            _desktop = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options).FindElementByName("Desktop 1");
            options = null;
        }

        public WindowsDriver<WindowsElement> DriverInstance { get { return _driver; } set { _driver=value; } }


        public WindowsElement Desktop { get { return _desktop; } set { _desktop = value; } }

        public void DriverQuit()
        {
            try
            {
                this._driver.Quit();
                this._driver = null;
            }
            catch (Exception)
            {

               
            }
        }
        
        ~DriverContext()
        {
            if (this._driver != null)
            {

                DriverQuit();
            }
            //var winAppDriverProcesses = Process.GetProcesses().
            //                     Where(pr => pr.ProcessName == "WinAppDriver");

            //foreach (var process in winAppDriverProcesses)
            //{
            //    process.Kill();
            //    break;
            //}
        }

        private void CheckWinAppDriverIsRunning()
        {
            
            Process[] processlist = Process.GetProcesses();
            bool processexist = false;
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName == "WinAppDriver") 
                {
                    processexist = true;
                    
                    break;
                }
            }
            if(processexist==false) Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
        }

        private void  GetApplicationName()
        {
            Type t = this.GetType();
            Console.WriteLine("Type is: {0}", t.Name);
            PropertyInfo[] props = t.GetProperties();

            foreach (var prop in props)
            {

                if (prop.Name.ToString() == "AppName")
                {
                    if (props[0].PropertyType == typeof(string))
                    {
                        object app = props[0].GetValue(this, null);
                        this.appNameToTest = app.ToString();
                        break;
                    }
                }
            }

        }
       
    }
}
