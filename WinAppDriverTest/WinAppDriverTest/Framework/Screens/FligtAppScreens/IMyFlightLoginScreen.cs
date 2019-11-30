using OpenQA.Selenium.Appium.Windows;
namespace WinAppDriverTest
{
    public interface IMyFlightLoginScreen
    {
        WindowsElement UserNameEdittBox { get; }

        WindowsElement PasswordEdittBox { get; }

        WindowsElement OkButton { get; }

        WindowsElement CancelButton { get; }

        WindowsElement FINDFLIGHTSButton { get; }

        WindowsElement CloseButton { get; }
    }
}
