using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppDriverTest.Framework.Screens.FligtAppScreens
{
    public interface IBookFlightScreen
    {
        WindowsElement FromCityComboBox { get; }

        WindowsElement ToCityComboBox { get; }

        WindowsElement DateOfJourneryEditBox { get; }

        WindowsElement ClassComboBox { get; }

        WindowsElement NoOfTicketsComboBox { get; }

        WindowsElement FindFlightsButton { get; }

        WindowsElement CloseButton { get; }

        WindowsElement BackButton { get; }

        void ComboBoxItemSelection(WindowsElement comboBox, string itemName);
        void EnterDateOfJourney(string dateOfJourney);

    }
}
