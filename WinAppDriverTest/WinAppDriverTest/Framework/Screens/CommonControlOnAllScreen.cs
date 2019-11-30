using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppDriverTest.Framework.Screens
{
    public interface ICommonControlOnAllScreen
    {
        WindowsElement OkButton { get; }

        WindowsElement ServicingGroupButton { get; }

        WindowsElement ServicingGroupColonButton { get; }

        WindowsElement CancelButton { get; }
    }
    public class CommonControlOnAllScreen : ICommonControlOnAllScreen
    {
        public WindowsElement OkButton => throw new System.NotImplementedException();

        public WindowsElement ServicingGroupButton => throw new System.NotImplementedException();

        public WindowsElement ServicingGroupColonButton => throw new System.NotImplementedException();

        public WindowsElement CancelButton => throw new System.NotImplementedException();
    }

}
