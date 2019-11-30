using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriverTest.Framework.Screens.FligtAppScreens
{
    public class BookFlightScreen : IBookFlightScreen
    {
        private WindowsElement _screenElement;
        public BookFlightScreen(WindowsElement screenElement)
        {
            this._screenElement = screenElement;
        }
        
        public WindowsElement FromCityComboBox => (WindowsElement)this._screenElement.FindElementByAccessibilityId("fromCity");

        public WindowsElement ToCityComboBox => (WindowsElement)this._screenElement.FindElementByAccessibilityId("toCity");


        public WindowsElement DateOfJourneryEditBox => (WindowsElement)this._screenElement.FindElementByAccessibilityId("datePicker").FindElementByAccessibilityId("PART_TextBox");


        public WindowsElement ClassComboBox => (WindowsElement)this._screenElement.FindElementByAccessibilityId("Class");
        public WindowsElement NoOfTicketsComboBox => (WindowsElement)this._screenElement.FindElementByAccessibilityId("numOfTickets");

        public WindowsElement FindFlightsButton => (WindowsElement)this._screenElement.FindElementByName("FIND FLIGHTS");

        public WindowsElement BackButton => (WindowsElement)this._screenElement.FindElementByName("BACK");

        public WindowsElement CloseButton => (WindowsElement)this._screenElement.FindElementByName("Close");

       
        public void ComboBoxItemSelection(WindowsElement comboBox, string itemName)
        {
            comboBox.Click();
            //string xpath = "//Window[@ClassName=\"Popup\"]/ListItem[@ClassName=\"ListBoxItem\"][@Name=\"" + itemName + "\"]";

            WindowsElement popup = (WindowsElement)this._screenElement.FindElementByClassName("Popup");
            WindowsElement listItem = (WindowsElement)popup.FindElementByName(itemName);
            listItem.Click();


        }

        public void EnterDateOfJourney(string dateOfJourney)
        {
            this.DateOfJourneryEditBox.Clear();
            this.DateOfJourneryEditBox.SendKeys(dateOfJourney);
        }
    }
}
