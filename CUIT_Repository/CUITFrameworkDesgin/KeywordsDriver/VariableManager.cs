using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeywordsDriver
{
   public static class VariableManager
    {
       /// <summary>
       /// Stores Global Variables name & value used in Configuration sheet in framework test execution sheet
       /// </summary>
       public static Dictionary<string, string> GlobalVariables = new Dictionary<string, string>();
       /// <summary>
       /// Stores Local Variables name & value used in Child Scenario sheet in framework test execution sheet
       /// </summary>
       public static Dictionary<string, string> LocalVariables = new Dictionary<string, string>();

       /// <summary>
       /// Functions stores the variable name and values in global or local dictionary
       /// </summary>
       /// <param name="variableName">Varibale Name</param>
       /// <param name="variableValue">Varibale Value</param>
       /// <param name="global">Optional True for Global storage and false for Local storage</param>
       public static void AddVaraibles(string variableName,string variableValue,bool global=false)
       {
           if (global)
           {
               try
               {
                   GlobalVariables.Add(variableName, variableValue);
                   
               }
               catch
               {
                   GlobalVariables.Remove(variableName);
                   GlobalVariables.Add(variableName, variableValue);
               }
               finally
               {
               }
               ConsolePrintMessage.PrintActionMsg("Added Global Variable '" + variableName + "'");
               
           }
           else
           {
               try
               {
                   LocalVariables.Add(variableName, variableValue);
               }
               catch
               {
                   LocalVariables.Remove(variableName);
               }
               finally
               {
                   LocalVariables.Add(variableName, variableValue);
               }
               ConsolePrintMessage.PrintActionMsg("Added Local Variable '" + variableName + "'");
           }
       }
    }
}
