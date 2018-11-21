using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using KeywordsDriver;
using System.Data.OleDb;
using System.Data;
namespace CUITFramework
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {


        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            string temp = System.IO.Directory.GetCurrentDirectory();
            
            List<string> para = new List<string>();

            para.Add("30");
            KeywordsDriver.Calculator_Keywords.Calc_ResultBox_ResultVerify (para);
            para.Clear();

            para.Add("Multiply");
            KeywordsDriver.Calculator_Keywords.Calc_Button_Click(para);
            para.Clear();

            para.Add("6");
            KeywordsDriver.Calculator_Keywords.Calc_Digit_ButtonClick(para);
            para.Clear();

            para.Add("Equals");
            KeywordsDriver.Calculator_Keywords.Calc_Button_Click(para);
            para.Clear();

            string names = "Vijay;m";
            //List<string> result = names.Split(',').ToList();
            
            //List<string> result = names.Split(new char[] { ',' }).ToList(); 
            //KeywordsDriver.FrameworkSettings.ScreenShotsCapture("C:\\songs\\Vijay");
            int a = 0;
            int b = 2;
            ConsolePrintMessage.PrintValidationMessage("Verifying A is greater than B", "A should be greater than B");
            if (a>b)
            {
                ConsolePrintMessage.PrintValidationPassedMsg(" A is greater than B");
            }
            else 
            {
                ConsolePrintMessage.PrintValidationFailureMsg (" A is less than B");
            }
            ConsolePrintMessage.PrintValidationMessage("Verifying A is equal to B", "A should be equal to B");
            if (a < b)
            {
                ConsolePrintMessage.PrintValidationPassedMsg(" A is lesser than B");
            }
            else
            {
                ConsolePrintMessage.PrintValidationFailureMsg(" A is greater than B");
            }
            Validations.Validations_TotalCount = Validations.Validations_PassedCount + Validations.Validations_FailedCount;
            ConsolePrintMessage.PrintActionMsg("Total Validations:" + Validations.Validations_TotalCount.ToString());

            ConsolePrintMessage.PrintHeaderMsg ("Coded UI Test Method start");
            Keywords.LoadKeywords();
            List<string> Parameters = new List<string>();
            Keywords.Execute("ClickButton", Parameters);
            Keywords.Execute("ClickButtonWithIndex", Parameters);
            ConsolePrintMessage.PrintActionMsg (DateTime.Now + "\t" + " End");
            try
            {
                foreach (KeyValuePair<string, string> pair in VariableManager.GlobalVariables)
                {
                    //Console.WriteLine("{0}, {1}",
                    //pair.Key,
                    //pair.Value);
                    ConsolePrintMessage.PrintActionMsg("Key Name:" + pair.Key.ToString() + " " + "Value=" + pair.Value.ToString());
                }
            }
            catch
            {
                ConsolePrintMessage.PrintActionMsg("FAILED Dictionary");
            }

            ConsolePrintMessage.PrintActionMsg("Cliking on button Five");
            Mouse.Click(CUIT_ObjectRepository.TestObject["repoTO_BtnFive"]);

            ConsolePrintMessage.PrintActionMsg("Testing Completed");
            ConsolePrintMessage.PrintHeaderMsg("Coded UI Test Method end");
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        }

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
