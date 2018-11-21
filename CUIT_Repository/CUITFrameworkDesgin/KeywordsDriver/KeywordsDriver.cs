using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeywordsDriver
{
    public class KeywordActionUnit
    {
        public string Name;

        public KeywordAction.KeywordActionMethod Method;

        public int NumParams;

        public KeywordActionUnit(string Name, KeywordAction.KeywordActionMethod Method, int NumParams)
        {
            this.Name = Name;

            this.Method = Method;

            this.NumParams = NumParams;
        }

    }

    public class KeywordAction
    {

        public static List<KeywordActionUnit> KeywordActionUnits = new List<KeywordActionUnit>();

        public string Name;

        public List<string> Tags = new List<string>();

        public string Condition = string.Empty;

        public List<string> Parameters;

        public List<string> OriginalParameters;

        public int QcPoint = -1;

        public delegate void KeywordActionMethod(List<string> parameters);

        //static KeywordActionUnit()
        //{
        //}

    }

    public static class Keywords
    {
        public static void LoadKeywords()
        {
            ConsolePrintMessage.PrintHeaderMsg ("=== Loading Keywords started ======");
            //Generic Keywords list adding to keyword units
            ConsolePrintMessage.PrintActionMsg("=== Loading Generic Keywords ======");
            ConsolePrintMessage.PrintActionMsg("1.   Loaded ClickButton keyword");
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("ClickButton", GenericKeywords.ClickButton, 1));
            ConsolePrintMessage.PrintActionMsg("2.   Loaded Print keyword");
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("Print", GenericKeywords.Print , 1));
            ConsolePrintMessage.PrintActionMsg("3.   Loaded msaa_ClickButton keyword");
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("msaa_ClickButton", KeywordsDriver.UIAutomationLibrary.msaa_ClickButton, 1));
            //AddVariable
            ConsolePrintMessage.PrintActionMsg("4.   Loaded AddVariable keyword");
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("AddVariable", GenericKeywords.AddVariable, 1));
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("msaa_TextCtrl_TextVerify", KeywordsDriver.UIAutomationLibrary.msaa_TextCtrl_TextVerify, 0));

            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("OpenMenu", KeywordsDriver.UIAutomationLibrary.OpenMenu, 1));
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("ExecuteMenuByName", KeywordsDriver.UIAutomationLibrary.ExecuteMenuByName, 1));
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("CloseMenu", KeywordsDriver.UIAutomationLibrary.CloseMenu ,1));
            

            //Application Related Keywords list adding to keyword units
            ConsolePrintMessage.PrintActionMsg("=== Loading Application Related Keywords ======");
            ConsolePrintMessage.PrintActionMsg("1.   Loaded LoginToApp keyword");
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("LoginToApp", AppRelatedKeywords.LoginToApp, 0));


            ConsolePrintMessage.PrintActionMsg("=== Loading Calculator Keywords ======");

            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("Calc_Digit_ButtonClick", KeywordsDriver.Calculator_Keywords.Calc_Digit_ButtonClick, 1));
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("Calc_OpenMenu", KeywordsDriver.Calculator_Keywords.Calc_OpenMenu, 1));
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("Calc_CloseMenu", KeywordsDriver.Calculator_Keywords.Calc_CloseMenu, 1));
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("Calc_ExecuteMenuByName", KeywordsDriver.Calculator_Keywords.Calc_ExecuteMenuByName, 1));
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("Calc_ResultBox_ResultVerify", KeywordsDriver.Calculator_Keywords.Calc_ResultBox_ResultVerify, 1));
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("Calc_Button_Click", KeywordsDriver.Calculator_Keywords.Calc_Button_Click, 1));
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("OpenCalculator", KeywordsDriver.Calculator_Keywords.OpenCalculator, 0));
            KeywordAction.KeywordActionUnits.Add(new KeywordActionUnit("Sleep", KeywordsDriver.Calculator_Keywords.Sleep, 1));

            


            ConsolePrintMessage.PrintHeaderMsg("=== Loading Keywords end ======");

            

        }

        public static void Execute(string keywordName, List<string> Parameters)
        {
            bool keywordExecutionSuccessFullOrFail = false;

            for (int i = 0; i < KeywordsDriver.KeywordAction.KeywordActionUnits.Count; i++)
            {
                if (KeywordsDriver.KeywordAction.KeywordActionUnits[i].Name == keywordName)
                {
                    if (Parameters.Count >= KeywordsDriver.KeywordAction.KeywordActionUnits[i].NumParams)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan   ;
                        ConsolePrintMessage.ConsoleWriteMsg("Executing Keyword: " + keywordName);
                        ConsolePrintMessage.SetDefaultConsoleColor();
                        KeywordsDriver.KeywordAction.KeywordActionUnits[i].Method(Parameters);
                        keywordExecutionSuccessFullOrFail = true;
                    }
                    else
                    {
                        ConsolePrintMessage.PrintFailureMessage("FAILED to execute keyword " + "'" + keywordName + "', because passed parameter is less than expected");
                        return;
                    }
                    
                    break;
                }


            }
            if (keywordExecutionSuccessFullOrFail == false)
            {

                ConsolePrintMessage.PrintFailureMessage("FAILED to execute keyword " + "'" + keywordName + "'");
                
            }
        }
    }

    public static class GenericKeywords
    {
        /// <summary>
        /// Clicks on Button
        /// </summary>
        /// <param name="Parameters"></param>
        public static void ClickButton(List<string> Parameters)
        {

            ConsolePrintMessage.PrintActionMsg("Generic Keyword :" + "'Click Button' Executed");
        }
        /// <summary>
        /// Prints the message
        /// </summary>
        /// <param name="Parameters"></param>
        public static void Print(List<string> Parameters)
        {

            ConsolePrintMessage.PrintActionMsg(Parameters[0].ToString ());
        }
        /// <summary>
        /// Adds the local or global varibales
        /// </summary>
        /// <param name="Parameters1">Variable Name</param>
        /// <param name="Parameters2">Variable Value</param>
        /// <param name="Optional Parameters3">True for Global;False for Local</param>
        public static void AddVariable(List<string> Parameters)
        {
            Boolean  globalORLocal = false;
            string variableValue = string.Empty;
            try
            {
                globalORLocal = Convert.ToBoolean(Parameters[2]);
            }
            catch
            {
            }
            try
            {
                variableValue = Parameters[1];
            }
            catch
            {
            }
            if (globalORLocal)
            {
                VariableManager.GlobalVariables.Add(Parameters[0].Trim(), variableValue);
                ConsolePrintMessage.PrintActionMsg("Added Global Variable '" + Parameters[0].Trim() + "'");
            }
            else
            {
                VariableManager.LocalVariables .Add(Parameters[0].Trim(), variableValue);
                ConsolePrintMessage.PrintActionMsg("Added Local Variable '" + Parameters[0].Trim() + "'");
            }
        }
    }
    public static class AppRelatedKeywords
    {
        public static void LoginToApp(List<string> Parameters)
        {

            ConsolePrintMessage.PrintActionMsg("Application Related Keyword :" + "'LoginToApp' Executed");
        }
    }

    
}
