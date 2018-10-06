using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace KeywordsDriver
{
   public static class UIAutomationLibrary
    {
       public static AutomationElement  rootAppElementForTest=null;
       public static void DeskTopParentWindow()
       {
           AutomationElement rootElement = AutomationElement.RootElement;
           AutomationElementCollection  appElementCollection = rootElement.FindAll (TreeScope.Children, new System.Windows.Automation.PropertyCondition(AutomationElement.ControlTypeProperty , System .Windows .Automation .ControlType .Window ));
           

           foreach (AutomationElement ae in appElementCollection)
           {
               if (ae.Current.Name.Contains("Calculator"))
               {
                   
                   rootAppElementForTest = ae;
                   return;
               }
           }

           throw new Exception("Failed to Find Desktop Application for automation test suite execution");
       }

       public static void msaa_ClickButton(List <string > parameters)
       {
           DeskTopParentWindow();
           

           System.Windows.Automation.PropertyCondition condition1=new System.Windows.Automation.PropertyCondition(AutomationElement.ControlTypeProperty, System.Windows.Automation.ControlType.Button );
           System.Windows.Automation.PropertyCondition condition2 = new System.Windows.Automation.PropertyCondition(AutomationElement.NameProperty , parameters [0].Trim());

           System.Windows.Automation.AndCondition condition = new System.Windows.Automation.AndCondition(condition1, condition2);

           AutomationElement btn = rootAppElementForTest.FindFirst(TreeScope.Descendants, condition);

           InvokePattern invokePattern = btn.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
           if (invokePattern != null)
           {
               invokePattern.Invoke();
           } 

       }
       public static void msaa_TextCtrl_TextVerify(List<string> parameters)
       {
           DeskTopParentWindow();


           System.Windows.Automation.PropertyCondition condition1 = new System.Windows.Automation.PropertyCondition(AutomationElement.ControlTypeProperty, System.Windows.Automation.ControlType.Text );
           System.Windows.Automation.PropertyCondition condition2 = new System.Windows.Automation.PropertyCondition(AutomationElement.NameProperty, parameters[0].Trim());

           System.Windows.Automation.AndCondition condition = new System.Windows.Automation.AndCondition(condition1, condition2);

           AutomationElement btn = rootAppElementForTest.FindFirst(TreeScope.Subtree , condition2);
           //var targetTextPattern = btn.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
           ValuePattern valuePatternA =
              btn.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
           ConsolePrintMessage.ConsoleWriteMsg(valuePatternA.Current.Value);
          
       }
       //private  ExpandCollapsePattern FindMenu(string menu)
       //{
       //    AutomationElement menuElement = rootAppElementForTest.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, menu.ToString()));
       //    ExpandCollapsePattern expPattern = menuElement.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
       //    return expPattern;
       //}
       public static void OpenMenu(List<string> parameters)
       {
           AutomationElement menuElement = rootAppElementForTest.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, parameters[0].Trim()));
           ExpandCollapsePattern expPattern = menuElement.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
           //ExpandCollapsePattern expPattern = FindMenu(parameters[0].Trim());
           expPattern.Expand();
       }
       public static void CloseMenu(List<string> parameters)
       {
           AutomationElement menuElement = rootAppElementForTest.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, parameters[0].Trim()));
           ExpandCollapsePattern expPattern = menuElement.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
           expPattern.Collapse();
       }
       public static void ExecuteMenuByName(List<string> parameters)
       {
           AutomationElement menuElement = rootAppElementForTest.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, parameters[0].Trim()));
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
    }
}
