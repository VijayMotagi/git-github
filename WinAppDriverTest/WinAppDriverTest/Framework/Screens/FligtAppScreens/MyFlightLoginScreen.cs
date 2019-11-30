using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriverTest
{
    public class MyFlightLoginScreen : IMyFlightLoginScreen
    {
        
        private WindowsElement _screenElement;
        public MyFlightLoginScreen(WindowsElement screenElement)
        {
            this._screenElement = screenElement;
        }
        public WindowsElement UserNameEdittBox => (WindowsElement)this._screenElement.FindElementByAccessibilityId("agentName");

        public WindowsElement PasswordEdittBox => (WindowsElement)this._screenElement.FindElementByAccessibilityId("password");

        public WindowsElement OkButton => (WindowsElement)this._screenElement.FindElementByAccessibilityId("okButton");

        public WindowsElement CancelButton => (WindowsElement)this._screenElement.FindElementByName("Cancel");

        public WindowsElement FINDFLIGHTSButton => (WindowsElement)this._screenElement.FindElementByName("FIND FLIGHTS");

        public WindowsElement CloseButton => (WindowsElement)this._screenElement.FindElementByName("Close");
    }
}
