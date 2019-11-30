using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppDriverTest.Framework.Screens.FligtAppScreens;

namespace WinAppDriverTest.Framework.TestSuites
{
    interface IFlightAppScreens
    {
        MyFlightLoginScreen MyFlightLoginScreen { get; }
        BookFlightScreen BookFlightScreen { get; }
        SelectFlightScreen SelectFlightScreen { get; }
        FlightDetailsScreen FlightDetailsScreen { get; }
        OrderDetailsScreen OrderDetailsScreen { get; }
    }
}
