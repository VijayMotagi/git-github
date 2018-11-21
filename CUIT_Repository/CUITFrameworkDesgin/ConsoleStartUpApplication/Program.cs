using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UITesting;
using KeywordsDriver;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
namespace ConsoleStartUpApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White     ;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Framework Application Version 1.0.0.0");
            Console.WriteLine("Author 'Vijaykumar Motagi'");
            Console.WriteLine("--------------------------------------------");
            ConsolePrintMessage.PrintHeaderMsg("--- Framework Execution started ---");
             
            if (args.Length > 0)
            {
                ConsolePrintMessage.PrintActionMsg("Test Sheet: '" + args[0] + "'" + " used for test execution");
            }

            FrameworkSettings.TestExecutionSheetFilePath = args[0];
            
            
            ExcelManager.xlWorkBook = ExcelManager.xlApp.Workbooks.Open(args[0], 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            if (args[3] == "true")
            {
                FrameworkSettings.RunParentScenarionSheet = true;
                FrameworkSettings.ExecutionSheetActiveWorksheetIndex = Convert.ToInt32(args[5]);
                ExcelManager.xlWorkSheet = (Excel.Worksheet)ExcelManager.xlWorkBook.Worksheets.get_Item(FrameworkSettings.ExecutionSheetActiveWorksheetIndex);
                ExcelManager.range = ExcelManager.xlWorkSheet.UsedRange;

                ConsolePrintMessage.PrintActionMsg("Executing Parent Scenario Sheet Validations");
            }
            else
            {
                FrameworkSettings.RunParentScenarionSheet = false;
                FrameworkSettings.ExecutionSheetActiveWorksheetIndex = Convert.ToInt32(args[3]);
                ExcelManager.xlWorkSheet = (Excel.Worksheet)ExcelManager.xlWorkBook.Worksheets.get_Item(FrameworkSettings.ExecutionSheetActiveWorksheetIndex);
                ExcelManager.range = ExcelManager.xlWorkSheet.UsedRange;
                ConsolePrintMessage.PrintActionMsg("Executing Child Scenario Scenario Sheet:'" + ExcelManager.xlWorkSheet.Name + "'" + " Validations" );
                
            }

            TestSettings.executable_parent_folder_path = args[4];
            ConsolePrintMessage.PrintActionMsg("Test Sheet Executable Parent Path: '" + TestSettings.executable_parent_folder_path + "'" + " used for test execution");

            string testResultDirectory = TestSettings.executable_parent_folder_path + "TestResult";
            if (!System.IO.Directory.Exists(testResultDirectory))
            {
                System.IO.Directory.CreateDirectory(testResultDirectory);
            }
            FrameworkSettings.TestResultFolderPath = testResultDirectory;
            ConsolePrintMessage.PrintActionMsg("Test Result Folder Path: '" + testResultDirectory + "'");

            ExcelManager.ConfigurationSheetDataInitialise(FrameworkSettings.TestExecutionSheetFilePath);
            //ConsolePrintMessage.PrintActionMsg(VariableManager.GlobalVariables.Count.ToString());
            //ConsolePrintMessage.PrintActionMsg(VariableManager.GlobalVariables["Item2"]);
            if (VariableManager.GlobalVariables["ToolUsed"] == "CUIT")
            {
                ConsolePrintMessage.PrintHeaderMsg("--- Tool Used 'Coded UI Test' Playback Initialise started ---");
                Playback.Initialize();
                CUITFramework.CUIT_ObjectRepository.TestObjectLoader();
                Keywords.LoadKeywords();
                //CUITFramework.CodedUITest1 test = new CUITFramework.CodedUITest1();
                //test.CodedUITestMethod1();
                ExcelManager.ChildSheetExecution();
            }       
            
            if (VariableManager.GlobalVariables["ToolUsed"] == "CUIT")
            {
                Playback.Cleanup();
                ConsolePrintMessage.PrintHeaderMsg("--- Coded UI Test Playback Cleanup Done ---");
                Console.ReadKey();
            }
            ExcelManager.ReleaseExcelObjects();
        }
    }
}
