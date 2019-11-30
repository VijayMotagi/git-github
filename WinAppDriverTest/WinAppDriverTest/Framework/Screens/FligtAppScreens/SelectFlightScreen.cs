using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriverTest.Framework.Screens.FligtAppScreens
{
    public class SelectFlightScreen : ISelectFlightScreen
    {
        private WindowsElement _screenElement;
        public SelectFlightScreen(WindowsElement screenElement)
        {
            this._screenElement = screenElement;
        }

       
        public WindowsElement FlightDataGrid => (WindowsElement)this._screenElement.FindElementByAccessibilityId("flightsDataGrid");

        public WindowsElement CloseButton => (WindowsElement)this._screenElement.FindElementByName("Close");

        public WindowsElement SELECTFLIGHTButton => (WindowsElement)this._screenElement.FindElementByAccessibilityId("selectFlightBtn");

        public void FlightSelect(string flightName)
        {
            bool flightSelected = false;

            var dataRows = this.FlightDataGrid.FindElementsByClassName("DataGridRow");
            WindowsElement rowToSelect = null;
            foreach (var row in dataRows)
            {
                var datacells = row.FindElementsByClassName("DataGridCell");
                foreach (var cell in datacells)
                {
                   
                    try
                    {
                        var textBlock=cell.FindElementByName(flightName);
                        if (textBlock != null)
                        {
                            rowToSelect = (WindowsElement)row;
                            flightSelected = true;
                            break;
                        }
                    }
                    catch (Exception)
                    {

                    }
                   
                    

                }
                if (flightSelected == true) break;
            }
            if (flightSelected == false) throw new Exception("Failed to select the flight " + flightName);
            rowToSelect.Click();
        }
    }
}
