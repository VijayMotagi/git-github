using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using System.Windows.Forms;
namespace KeywordsDriver
{
    public static class Calculator_Keywords
    {
       public static  System.Drawing.Point mousePoint = new System.Drawing.Point();
        public static AutomationElement _calculatorAutomationElement = null;
        public static void DeskTopParentWindow()
        {
            AutomationElement rootElement = AutomationElement.RootElement;
            AutomationElementCollection appElementCollection = rootElement.FindAll(TreeScope.Children, new System.Windows.Automation.PropertyCondition(AutomationElement.ControlTypeProperty, System.Windows.Automation.ControlType.Window));


            foreach (AutomationElement ae in appElementCollection)
            {
                if (ae.Current.Name.Contains("Calculator"))
                {

                    _calculatorAutomationElement = ae;
                    return;
                }
            }

            throw new Exception("Failed to Find Desktop Application for automation test suite execution");
        }
        public static void OpenCalculator(List<string> parameters)
        {
            System .Diagnostics .Process .Start("Calc.exe");
        }
        public static void Sleep(List<string> parameters)
        {
            System .Threading .Thread .Sleep (Convert .ToInt32 (parameters [0].Trim ()) * 1000);
        }
        public static void Calc_Digit_ButtonClick(List<string> parameters)
        {

            DeskTopParentWindow();
            string stringRep = parameters[0].Trim().ToString();

            for (int index = 0; index < stringRep.Length; index++)
            {
                int leftDigit = int.Parse(stringRep[index].ToString());

                //GetInvokePattern(GetDigitButton(leftDigit)).Invoke();
                InvokePattern invokePattern = null;
                invokePattern = GetDigitButton(leftDigit).GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                if (invokePattern != null)
                {
                    invokePattern.Invoke();
                } 
            }
            
        }
        public static AutomationElement GetDigitButton(int number)
        {
            DeskTopParentWindow();
            if ((number < 0) || (number > 9))
            {
                throw new InvalidOperationException("mumber must be a digit 0-9");
            }

            AutomationElement buttonElement = _calculatorAutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, number.ToString()));

            if (buttonElement == null)
            {
                throw new InvalidOperationException("Could not find button corresponding to digit" + number);
            }

            return buttonElement;
        }
        public static InvokePattern GetInvokePattern(AutomationElement element)
        {
            return element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
        }
        public static void Calc_OpenMenu(List<string> parameters)
        {
            DeskTopParentWindow();
            AutomationElement menuElement = _calculatorAutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, parameters[0].Trim()));
            ExpandCollapsePattern expPattern = menuElement.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            //ExpandCollapsePattern expPattern = FindMenu(parameters[0].Trim());
            expPattern.Expand();
        }
        public static void Calc_CloseMenu(List<string> parameters)
        {
            DeskTopParentWindow();
            AutomationElement menuElement = _calculatorAutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, parameters[0].Trim()));
            ExpandCollapsePattern expPattern = menuElement.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            expPattern.Collapse();
        }
        public static void Calc_ExecuteMenuByName(List<string> parameters)
        {
            DeskTopParentWindow();
            AutomationElement menuElement = _calculatorAutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, parameters[0].Trim()));
            if (menuElement == null)
            {
                return;
            }

            InvokePattern invokePattern = menuElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            if (invokePattern != null)
            {
                invokePattern.Invoke();
            }
        }

        public static void Calc_ResultBox_ResultVerify(List<string> parameters)
        {
            ConsolePrintMessage.PrintActionMsg("Finding Calclator");
            DeskTopParentWindow();
            ConsolePrintMessage.PrintActionMsg("Found Calclator");
            List<string> parameters_data = new List<string>();
            parameters_data.Add("Edit");
            ConsolePrintMessage.PrintActionMsg("Opening Menu Edit in Calclator");
            Calc_OpenMenu(parameters_data);
            ConsolePrintMessage.PrintActionMsg("Opended Menu Edit in Calclator");
            parameters_data.Clear();

            parameters_data.Add("Copy");
            ConsolePrintMessage.PrintActionMsg("Opening Menu Copy in Calclator");
            Calc_ExecuteMenuByName(parameters_data);
            ConsolePrintMessage.PrintActionMsg("Opended Menu Copy in Calclator");
            parameters_data.Clear();

            ConsolePrintMessage.PrintActionMsg("Data Bind objet for Clipboard");
            IDataObject iData = Clipboard.GetDataObject();
            ConsolePrintMessage.PrintActionMsg("Data Binded objet for Clipboard");
            // Is Data Text? 
            MessageBox.Show(iData.ToString());
            if (iData.GetDataPresent(DataFormats.Text))
            {
                ConsolePrintMessage.PrintActionMsg("Getting Text");
                if ((String)iData.GetData(DataFormats.Text) == parameters[0].Trim())
                {
                    ConsolePrintMessage.PrintValidationPassedMsg("Actual result '" + parameters[0].Trim() + "' matched with expected result '" + parameters[0].Trim() + "'");
                }
                else
                {
                    ConsolePrintMessage.PrintValidationFailureMsg("Actual result '" + (String)iData.GetData(DataFormats.Text) + "' FAILED to match with expected result '" + parameters[0].Trim() + "'");

                }
            }
        }

        public static void Calc_Button_Click(List<string> parameters)
        {
            DeskTopParentWindow();
            AutomationElement buttonElement = _calculatorAutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, parameters[0].Trim().ToString()));

            if (buttonElement == null)
            {
                throw new InvalidOperationException("Could not find button corresponding to " + parameters[0].Trim().ToString());
            }
            GetInvokePattern(buttonElement).Invoke();
            InvokePattern invokePattern = null;
            invokePattern = buttonElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            if (invokePattern != null)
            {
                invokePattern.Invoke();
            }
            
           
            
        }
    }
}
