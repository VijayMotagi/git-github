using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using KeywordsDriver;
namespace CUITFramework
{
   public static class CUIT_ObjectRepository
    {
       public static Dictionary<string, UITestControl> TestObject = new Dictionary<string, UITestControl>();
       public static void TestObjectLoader()
       {
           ConsolePrintMessage.PrintActionMsg("Loading test objects stored in Object Repository - Start");
           CalculatorUIMapClasses.CalculatorUIMap UIMap = new CalculatorUIMapClasses.CalculatorUIMap();
           TestObject.Add("repoTO_BtnFive", UIMap.CalculatorWindow.Button5UIItemWindow.Button5);
           UIMap = null;
           ConsolePrintMessage.PrintActionMsg("Loading test objects stored in Object Repository - End");
       }

    }
}
