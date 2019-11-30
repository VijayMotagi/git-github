using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriverTest.Framework.Screens.FligtAppScreens
{
    public interface ISelectFlightScreen
    {
        WindowsElement FlightDataGrid { get; }

        WindowsElement CloseButton { get; }

        WindowsElement SELECTFLIGHTButton { get; }

        void FlightSelect(string flightName);
    }
}
