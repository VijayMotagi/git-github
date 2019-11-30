using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriverTest
{
    public class CalculatorNumberButton : INumberButtons
    {
        private WindowsDriver<WindowsElement> driver;

        public CalculatorNumberButton(WindowsDriver<WindowsElement> _driver)
        {
            this.driver = _driver;
        }
        public WindowsElement One => driver.FindElementByName("One");

        public WindowsElement Two => driver.FindElementByName("Two");

        public WindowsElement Three => driver.FindElementByName("Three");

        public WindowsElement Four => driver.FindElementByName("Four");
    }
}
