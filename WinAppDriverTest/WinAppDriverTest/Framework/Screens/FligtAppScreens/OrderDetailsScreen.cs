using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace WinAppDriverTest.Framework.Screens.FligtAppScreens
{
    public class OrderDetailsScreen : IOrderDetailsScreen
    {
        private WindowsElement _screenElement;
        public OrderDetailsScreen(WindowsElement screenElement)
        {
            this._screenElement = screenElement;
        }

        public WindowsElement OrderCompletedStatus => (WindowsElement)this._screenElement.FindElementByAccessibilityId("orderCompleted");

        public WindowsElement OrderDeletedStatus
        {
            get {
                    try
                    {
                        return (WindowsElement)this._screenElement.FindElementByAccessibilityId("orderDeleted");
                    }
                    catch (Exception)
                    {

                        return null;
                    }
                    
                }
        }
        

        public WindowsElement OrderUpdateButton => (WindowsElement)this._screenElement.FindElementByAccessibilityId("updateBtn");

        public WindowsElement OrderDeleteButton => (WindowsElement)this._screenElement.FindElementByXPath("//Button[@ClassName=\"Button\"]");

        public WindowsElement NotificationWindow => (WindowsElement)this._screenElement.FindElementByName("Notification");

        public WindowsElement AreyousureyouwanttodeletethisorderText => (WindowsElement)this.NotificationWindow.FindElementByName("Are you sure you want to delete this order?");

        public WindowsElement AreyousureyouwanttodeletethisorderNotificationYesButton => (WindowsElement)this.NotificationWindow.FindElementByName("Yes");

        public WindowsElement AreyousureyouwanttodeletethisorderNotificationNoButton => (WindowsElement)this.NotificationWindow.FindElementByName("No");

        public WindowsElement PassengerName => (WindowsElement)this._screenElement.FindElementByAccessibilityId("passengerName");

        public void AssertOrderDeletePopupAppeared()
        {
            Assert.IsNotNull(this.AreyousureyouwanttodeletethisorderText);
        }

        public void AssertOrderGotCreated()
        {
            Assert.IsNotNull(this.OrderCompletedStatus);
        }

        public void AssertOrderGotDeleted()
        {
            Assert.IsNotNull(this.OrderDeletedStatus);
        }

        public void AssertOrderIsNottDeleted()
        {
            Assert.Null(this.OrderDeletedStatus);
        }

        public void EnterPassengerName(string passengerName)
        {
            this.PassengerName.SendKeys(passengerName);
        }

        public void WaitTillOrderStatusCompleted(int timeout = 5)
        {
            for (int i = 0; i < timeout; i++)
            {
                try
                {
                    var ctrl = this.OrderCompletedStatus;
                    if (ctrl != null) break;

                }
                catch (Exception)
                {

                    System.Threading.Thread.Sleep(1000);
                }
            }

        }

        public void WaitTillOrderStatusDeleted(int timeout = 5)
        {
            for (int i = 0; i < timeout; i++)
            {
                try
                {
                    var ctrl = this.OrderDeletedStatus;
                    if (ctrl != null) break;

                }
                catch (Exception)
                {

                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        public void WaitTillOrderStatusUpdated(int timeout = 5)
        {
            for (int i = 0; i < timeout; i++)
            {
                try
                {
                    var ctrl = this.OrderUpdateButton;
                    if (ctrl != null) break;

                }
                catch (Exception)
                {

                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
