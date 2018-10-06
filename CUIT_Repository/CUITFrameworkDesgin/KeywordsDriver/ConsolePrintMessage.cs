using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeywordsDriver
{
    public static  class ConsolePrintMessage
    {
        public static void SetDefaultConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void PrintWarningMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + "\t" + msg);
            ConsoleWriteMsg(msg);
            SetDefaultConsoleColor();
            //TestResultFile(msg, string.Empty, string.Empty);
        }
        public static void PrintFailureMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + "\t" + msg);
            ConsoleWriteMsg(msg);
            SetDefaultConsoleColor();
            //TestResultFile(msg, string.Empty, string.Empty);
        }

        public static void PrintActionMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + "\t" + msg);
            ConsoleWriteMsg(msg);
            SetDefaultConsoleColor();
            //TestResultFile(msg, string.Empty, string.Empty);
        }

        public static void PrintHeaderMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow ;
            Console.BackgroundColor = ConsoleColor.DarkCyan  ;
            ConsoleWriteMsg(msg);
            //Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + "\t" + msg);
            SetDefaultConsoleColor();
            //TestResultFile(msg, string.Empty, string.Empty);
        }
        public static void ConsoleWriteMsg(string msg)
        {
            List<string> mesList = msgStringList(msg);
            foreach (string item in mesList)
            {
                if (mesList.Count == 1)
                {
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + "\t" + item);
                    break;
                }
                if (mesList.Count > 1)
                {
                    Console.Write(DateTime.Now.ToString("hh:mm:ss") + "\t" + item);
                }
                //else
                //{
                //    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + "\t" + item);
                //}
                
            }
            if (mesList.Count > 1)
            {
                Console.WriteLine("");
            }
        }
        public static void ConsoleWriteMsg_new(string msg)
        {
            List<string> mesList = msgStringList(msg);

            ConsoleColor bgc = Console.BackgroundColor;
            ConsoleColor fgc = Console.ForegroundColor ;

            foreach (string item in mesList)
            {
                if (mesList.Count == 1)
                {
                    SetDefaultConsoleColor();
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + "\t");
                    Console.BackgroundColor = bgc;
                    Console.ForegroundColor = fgc;
                    Console.Write(item);
                    Console.WriteLine("");
                    break;
                }
                if (mesList.Count > 1)
                {
                    Console.Write(DateTime.Now.ToString("hh:mm:ss") + "\t" + item);
                }
                //else
                //{
                //    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss") + "\t" + item);
                //}

            }
            if (mesList.Count > 1)
            {
                Console.WriteLine("");
            }
        }
        private static List <string> msgStringList(string msg)
        {
            string temp = msg; 
            List<string> tempList = new List<string>();
            int times = 1;
            string str = temp;
            int offset = 0;
            int length = 64;
            int Orlength = temp.Length;
            do
            {

                if (str.Length > 64)
                {
                    str = temp.Substring(offset, 64);
                    length = Orlength - (64 * times) - 1;
                    tempList.Add(str);
                    offset = (64 * times) + 1;
                    str = temp.Substring(offset, length);
                }

                times = times + 1;

            } while (str.Length > 64);
            if (str.Length > 0)
            {
                tempList.Add(str);
            }

            
            return tempList;
        }

        public static void PrintValidationPassedMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green ;
            ConsoleWriteMsg("Actual Result" + msg);
            Validations.Validations_PassedCount = Validations.Validations_PassedCount + 1;
            SetDefaultConsoleColor();
            TestResultFile(ActionMsg, ExpectedMsg, msg);
        }
        public static void PrintValidationFailureMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleWriteMsg("Actual Result" + msg);
            Validations.Validations_FailedCount = Validations.Validations_FailedCount + 1;
            SetDefaultConsoleColor();
            TestResultFile(ActionMsg, ExpectedMsg, msg);
            FrameworkSettings.ScreenShotsCapture("FAILED_VALIDATION_" + Validations.Validations_FailedCount + ".JPEG");
        }

        public static void PrintValidationMessage(string actionMsg, string expectedMsg)
        {
            Console.ForegroundColor = ConsoleColor.White ;
            Validations.ValidationCount = Validations.ValidationCount + 1;

            ConsoleWriteMsg("-----Validation " + Validations.ValidationCount.ToString() + "-----");
            SetDefaultConsoleColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            ConsoleWriteMsg(actionMsg);
            SetDefaultConsoleColor();
            Console.ForegroundColor = ConsoleColor.Green  ;
            ConsoleWriteMsg("Expected Result:" + expectedMsg);
            SetDefaultConsoleColor();
            ActionMsg = actionMsg;
            ExpectedMsg = expectedMsg;
        }

        public static void TestResultFile(string actionMsg, string expectedMsg, string actualResult)
        {
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleWriteMsg("Action Message:-" + actionMsg + " " + "Expected Message:-" + expectedMsg + " " + "Actual Result:-" + actualResult );
            SetDefaultConsoleColor();
        }

        public static string ActionMsg = string.Empty;
        public static string ExpectedMsg = string.Empty;
    }
}
