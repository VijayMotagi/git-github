using System;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using WinAppDriverTest.Framework.Screens.FligtAppScreens;
using WinAppDriverTest.Framework.TestSuites;

namespace WinAppDriverTest
{
    [TestFixture]
    public class FlightReservationTestSuite : BaseTestSuite, IFlightAppScreens
    {

        [Test]
        [TestCase("Denver", "Paris", "3", "Economy")]
        [TestCase("Denver", "Paris", "2", "Economy")]
        [TestCase("Denver", "Paris", "1", "Economy")]
        [TestCase("Paris", "Denver", "3", "Business")]
        [TestCase("Paris", "Denver", "2", "Business")]
        [TestCase("Paris", "Denver", "1", "Business")]
        [TestCase("Denver", "Paris", "1", "First")]
        [TestCase("Denver", "Paris", "2", "First")]
        [TestCase("Denver", "Paris", "3", "First")]
        [TestCase("Denver", "Paris", "10", "First")]
        public void Test1(string from,string to,string tickets,string classType)
        {
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.FromCityComboBox, from);
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.ToCityComboBox, to);
            BookFlightScreen.DateOfJourneryEditBox.Click();
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.NoOfTicketsComboBox, tickets);
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.ClassComboBox, classType);
           
            BookFlightScreen.FindFlightsButton.Click();

            BookFlightScreen.BackButton.Click();
           
        }
        [Test]
        [TestCase("Denver", "Paris", "1", "First")]
        public void Test2(string from, string to, string tickets, string classType)
        {

            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.FromCityComboBox, from);
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.ToCityComboBox, to);
            BookFlightScreen.DateOfJourneryEditBox.Click();
            BookFlightScreen.EnterDateOfJourney("02-12-2020");
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.NoOfTicketsComboBox, tickets);
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.ClassComboBox, classType);
            BookFlightScreen.FindFlightsButton.Click();

            SelectFlightScreen.FlightSelect("15807 AF");
            SelectFlightScreen.SELECTFLIGHTButton.Click();

            FlightDetailsScreen.EnterPassengerName("Test");
            FlightDetailsScreen.AssertFlightNumber("15807 AF");
            FlightDetailsScreen.AssertPricePerTicket("$490.80");
            FlightDetailsScreen.AssertTotalPrice("$490.80");
            FlightDetailsScreen.OrderButton.Click();

            OrderDetailsScreen.WaitTillOrderStatusCompleted(30);
            OrderDetailsScreen.AssertOrderGotCreated();
            OrderDetailsScreen.OrderDeleteButton.Click();
            OrderDetailsScreen.AssertOrderDeletePopupAppeared();
            OrderDetailsScreen.AreyousureyouwanttodeletethisorderNotificationYesButton.Click();
            OrderDetailsScreen.WaitTillOrderStatusDeleted(30);
            OrderDetailsScreen.AssertOrderGotDeleted();



        }
        [Test]
        [TestCase("Denver", "Paris", "1", "First")]
        public void Test3(string from, string to, string tickets, string classType)
        {

            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.FromCityComboBox, from);
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.ToCityComboBox, to);
            BookFlightScreen.DateOfJourneryEditBox.Click();
            BookFlightScreen.EnterDateOfJourney("02-12-2020");
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.NoOfTicketsComboBox, tickets);
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.ClassComboBox, classType);
            BookFlightScreen.FindFlightsButton.Click();

            SelectFlightScreen.FlightSelect("15807 AF");
            SelectFlightScreen.SELECTFLIGHTButton.Click();

            FlightDetailsScreen.EnterPassengerName("Test");
            FlightDetailsScreen.AssertFlightNumber("15807 AF");
            FlightDetailsScreen.AssertPricePerTicket("$490.80");
            FlightDetailsScreen.AssertTotalPrice("$490.80");
            FlightDetailsScreen.OrderButton.Click();

            OrderDetailsScreen.WaitTillOrderStatusCompleted(30);
            OrderDetailsScreen.AssertOrderGotCreated();
            OrderDetailsScreen.EnterPassengerName("Test 1");
            OrderDetailsScreen.OrderUpdateButton.Click();
            OrderDetailsScreen.WaitTillOrderStatusUpdated(30);
            OrderDetailsScreen.OrderDeleteButton.Click();
            OrderDetailsScreen.AreyousureyouwanttodeletethisorderNotificationYesButton.Click();
            OrderDetailsScreen.WaitTillOrderStatusDeleted(30);
            OrderDetailsScreen.AssertOrderGotDeleted();



        }
        [Test]
        [TestCase("Denver", "Paris", "1", "First")]
        public void Test4(string from, string to, string tickets, string classType)
        {

            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.FromCityComboBox, from);
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.ToCityComboBox, to);
            BookFlightScreen.DateOfJourneryEditBox.Click();
            BookFlightScreen.EnterDateOfJourney("02-12-2020");
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.NoOfTicketsComboBox, tickets);
            BookFlightScreen.ComboBoxItemSelection(BookFlightScreen.ClassComboBox, classType);
            BookFlightScreen.FindFlightsButton.Click();

            SelectFlightScreen.FlightSelect("15807 AF");
            SelectFlightScreen.SELECTFLIGHTButton.Click();

            FlightDetailsScreen.EnterPassengerName("Test");
            FlightDetailsScreen.AssertFlightNumber("15807 AF");
            FlightDetailsScreen.AssertPricePerTicket("$490.80");
            FlightDetailsScreen.AssertTotalPrice("$490.80");
            FlightDetailsScreen.OrderButton.Click();

            OrderDetailsScreen.WaitTillOrderStatusCompleted(30);
            OrderDetailsScreen.AssertOrderGotCreated();
            OrderDetailsScreen.OrderDeleteButton.Click();
            OrderDetailsScreen.AssertOrderDeletePopupAppeared();
            OrderDetailsScreen.AreyousureyouwanttodeletethisorderNotificationNoButton.Click();
            OrderDetailsScreen.WaitTillOrderStatusDeleted();
            OrderDetailsScreen.AssertOrderIsNottDeleted();



        }
        ~FlightReservationTestSuite()
        {
            MyFlightLoginScreen.CloseButton.Click();
            base.DriverQuit();
            
        }
        [SetUp]
        public override void TestInit()
        {

            try
            {
                MyFlightLoginScreen.UserNameEdittBox.SendKeys("john");
                MyFlightLoginScreen.PasswordEdittBox.SendKeys("HP");
                MyFlightLoginScreen.OkButton.Click();
            }
            catch (Exception)
            {


            }
        }
        [TearDown]
        public override void TestCleanup()
        {
            
        }
        public string AppName { get { return "Flight"; } }

        public MyFlightLoginScreen MyFlightLoginScreen { get { return new MyFlightLoginScreen((WindowsElement)Desktop.FindElementByName("Micro Focus MyFlight Sample Application")); } }

        public BookFlightScreen BookFlightScreen { get { return new BookFlightScreen((WindowsElement)Desktop.FindElementByName("Micro Focus MyFlight Sample Application")); } }

        public SelectFlightScreen SelectFlightScreen { get { return new SelectFlightScreen((WindowsElement)Desktop.FindElementByName("Micro Focus MyFlight Sample Application")); } }

        public FlightDetailsScreen FlightDetailsScreen { get { return new FlightDetailsScreen((WindowsElement)Desktop.FindElementByName("Micro Focus MyFlight Sample Application")); } }
        public OrderDetailsScreen OrderDetailsScreen { get { return new OrderDetailsScreen((WindowsElement)Desktop.FindElementByName("Micro Focus MyFlight Sample Application")); } }

    }
}
