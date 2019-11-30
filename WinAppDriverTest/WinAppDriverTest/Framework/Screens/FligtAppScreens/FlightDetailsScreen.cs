using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;


namespace WinAppDriverTest.Framework.Screens.FligtAppScreens
{
    public class FlightDetailsScreen : IFlightDetailsScreen
    {
        private WindowsElement _screenElement;
        public FlightDetailsScreen(WindowsElement screenElement)
        {
            this._screenElement = screenElement;
        }


        public WindowsElement PassengerName => (WindowsElement)this._screenElement.FindElementByAccessibilityId("passengerName");

        public WindowsElement CloseButton => (WindowsElement)this._screenElement.FindElementByName("Close");

        public WindowsElement FlightNumber => (WindowsElement)this._screenElement.FindElementByAccessibilityId("flightNumber");

        public WindowsElement PricePerTicket => (WindowsElement)this._screenElement.FindElementByAccessibilityId("pricePerTicket");

        public WindowsElement TotalPrice => (WindowsElement)this._screenElement.FindElementByAccessibilityId("totalPrice");

        public WindowsElement OrderButton => (WindowsElement)this._screenElement.FindElementByAccessibilityId("orderBtn");

        public WindowsElement NewSearchButton => (WindowsElement)this._screenElement.FindElementByAccessibilityId("newSearchBtn");

        public WindowsElement OrderCompletedStatus => (WindowsElement)this._screenElement.FindElementByAccessibilityId("orderCompleted");

        public void AssertFlightNumber(string FlightNo)
        {
            Assert.IsNotNull(this.FlightNumber.FindElementByClassName("TextBlock").FindElementByName(FlightNo),(FlightNo + " doesn't exist"));
        }

        public void AssertPricePerTicket(string PricePerTicket)
        {
            Assert.IsNotNull(this.PricePerTicket.FindElementByClassName("TextBlock").FindElementByName(PricePerTicket), (PricePerTicket + " doesn't exist"));
        }

        public void AssertTotalPrice(string TotalPrice)
        {
            Assert.IsNotNull(this.TotalPrice.FindElementByClassName("TextBlock").FindElementByName(TotalPrice), (TotalPrice + " doesn't exist"));
        }

        public void EnterPassengerName(string passengerName)
        {
            this.PassengerName.SendKeys(passengerName);
        }

       
    }
}
