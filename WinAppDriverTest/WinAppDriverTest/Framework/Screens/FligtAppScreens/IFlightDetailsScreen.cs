

using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriverTest.Framework.Screens.FligtAppScreens
{
   public interface IFlightDetailsScreen
    {
        WindowsElement PassengerName { get; }
        WindowsElement CloseButton { get; }

        WindowsElement FlightNumber { get; }
        WindowsElement PricePerTicket { get; }
        WindowsElement TotalPrice { get; }
        WindowsElement OrderButton { get; }
        WindowsElement NewSearchButton { get; }

        WindowsElement OrderCompletedStatus { get; }

        void EnterPassengerName(string passengerName);
        void AssertFlightNumber(string FlightNo);
        void AssertPricePerTicket(string PricePerTicket);
        void AssertTotalPrice(string TotalPrice);

        
    }
}
