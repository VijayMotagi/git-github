using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriverTest.Framework.Screens.FligtAppScreens
{
   public interface IOrderDetailsScreen
    {
        WindowsElement OrderCompletedStatus { get; }
        WindowsElement OrderDeletedStatus { get; }

        WindowsElement OrderUpdateButton { get; }
        WindowsElement OrderDeleteButton { get; }

        WindowsElement NotificationWindow { get; }
        WindowsElement AreyousureyouwanttodeletethisorderText { get; }
        WindowsElement AreyousureyouwanttodeletethisorderNotificationYesButton { get; }
        WindowsElement AreyousureyouwanttodeletethisorderNotificationNoButton { get; }
        WindowsElement PassengerName { get; }

        void EnterPassengerName(string passengerName);
        void AssertOrderDeletePopupAppeared();
        void WaitTillOrderStatusCompleted(int timeout = 5);
        void WaitTillOrderStatusDeleted(int timeout=5);
        void WaitTillOrderStatusUpdated(int timeout = 5);
        void AssertOrderGotCreated();
        void AssertOrderGotDeleted();
        void AssertOrderIsNottDeleted();
    }
}
