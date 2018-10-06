using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
namespace KeywordsDriver
{
    public static class ExcelManager
    {
       public static  Excel.Application xlApp=new Excel.Application();
       public static Excel.Workbook xlWorkBook;
       public static Excel.Worksheet xlWorkSheet;
       public static Excel.Range range;
        public static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch 
            {
                obj = null;
             }
            finally
            {
                GC.Collect();
            }
        }
        public static void ConfigurationSheetDataInitialise(string filepath)
        {
            ConsolePrintMessage.PrintActionMsg("Loading Configaration Sheet Data as Global Variables");

            string str;
            int rCnt = 0;
            int cCnt = 0;

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            
            range = xlWorkSheet.UsedRange;

            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                string variableName = string.Empty;
                string variableValue = string.Empty;
                str = (string)(range.Cells[rCnt, 1] as Excel.Range).Value ;
                variableName = str;
                str = (string)(range.Cells[rCnt, 2] as Excel.Range).Value;       
                variableValue = str;
                VariableManager.AddVaraibles(variableName, variableValue, true);
                   
            }
            ConsolePrintMessage.PrintActionMsg("--------Global Variables(Names & Values)------------");
            
            
            foreach (KeyValuePair<string, string> pair in VariableManager.GlobalVariables)
            {
                ConsolePrintMessage.PrintActionMsg( pair.Key.ToString() + " = " + pair.Value.ToString());
                
            }
        }
        public static void ReleaseExcelObjects()
        {
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

        }
        public static void SampleCode(string filepath)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;

            //for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            //{
            //    for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
            //    {
            //        str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
            //        //MessageBox.Show(str);
            //    }
            //}
            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                string variableName = string.Empty;
                string variableValue = string.Empty;
                str = (string)(range.Cells[rCnt, 1] as Excel.Range).Value;
                variableName = str;
                str = (string)(range.Cells[rCnt, 2] as Excel.Range).Value;
                variableValue = str;
                VariableManager.AddVaraibles(variableName, variableValue, true);

            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }
        public static void ChildSheetExecution(Boolean parentOrChildSheetFlow=false,int childSheetActiveIndex=1)
        {
            
            ExcelManager.xlWorkSheet = (Excel.Worksheet)ExcelManager.xlWorkBook.Worksheets.get_Item(FrameworkSettings.ExecutionSheetActiveWorksheetIndex);
            ExcelManager.range = ExcelManager.xlWorkSheet.UsedRange;
            if (parentOrChildSheetFlow)
            {
                FrameworkSettings.ExecutionSheetActiveWorksheetIndex = childSheetActiveIndex;
            }

            string str = string.Empty; 
            int rCnt = 0;
            int cCnt = 0;

            ConsolePrintMessage.PrintHeaderMsg("Child Scenario Sheet '" + ExcelManager.xlWorkSheet.Name + " ' Execution started");
            List<string> rowValues = new List<string>();
            for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                ConsolePrintMessage.PrintHeaderMsg("Executing Row '" + rCnt.ToString () + "'");
                rowValues = new List<string>();
                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    
                    object oData = (range.Cells[rCnt, cCnt] as Excel.Range).Value2;

                    if (oData != null)
                    {
                        if (oData is string)
                        {
                            str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;

                        }

                        else
                        {
                            str = Convert.ToString(oData);
                        }
                        //ConsolePrintMessage.PrintActionMsg(str);
                    }
                    else
                    {
                        str = string.Empty ;
                    }
                    rowValues.Add(str);
                }
                string comment = rowValues[0];
                string testObject = rowValues[1];
                string actionkeyword = rowValues[2];
                List<string> parameters = new List<string>(rowValues[3].Split(';'));
                if (parameters[0] == string.Empty)
                {
                    parameters = new List<string>();
                }
                parameters = parameterResolver(parameters, actionkeyword);
                string parent1 = rowValues[4];
                string parent2 = rowValues[5];
                string parent3 = rowValues[6];
                string parent4 = rowValues[7];
                if (comment == "#")
                {
                    ConsolePrintMessage.PrintWarningMsg("Row '" + rCnt.ToString() + "'" + " is commented in scenario sheet");
                }
                else
                {
                    Keywords.Execute(actionkeyword, parameters);
                }
                
            }
            ConsolePrintMessage.PrintHeaderMsg("Child Scenario Sheet '" + ExcelManager.xlWorkSheet.Name + " ' Execution completed");
            VariableManager.LocalVariables.Clear();
        }

        public static List<string> parameterResolver(List<string > parameter,string keywordName)
        {
            List<string> resolvedParameter = new List<string>();
            foreach (string items in parameter)
            {
                if (items.StartsWith("{") & items.EndsWith("}"))
                {
                    bool variableFound = false;
                    string tempVariableName = items.Replace("{","");
                    tempVariableName = tempVariableName.Replace("}", "").Trim();
                    try
                    {
                        resolvedParameter.Add(VariableManager.LocalVariables[tempVariableName]);
                        variableFound = true;
                    }
                    catch
                    {
                        
                    }
                    if (variableFound==false)
                    {
                        try
                        {
                            resolvedParameter.Add(VariableManager.GlobalVariables[tempVariableName]);
                            variableFound = true;
                        }
                        catch
                        {
                            
                            resolvedParameter.Add(items);
                        }
                    }
                    if (variableFound == false)
                    {
                        ConsolePrintMessage.PrintFailureMessage("Parameter '" + items + "'" + "is not present either in local or global" + " used for keyword '" + keywordName + "', so using parameter value as it is i.e " + items );
                    }
                    
                }
                else
                {
                    resolvedParameter.Add(items);
                }
            }

            return resolvedParameter;
        }
    }


}
