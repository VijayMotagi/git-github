﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 10.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace CUITFramework.CalculatorUIMapClasses
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public partial class CalculatorUIMap
    {
        
        #region Properties
        public CalculatorWindow CalculatorWindow
        {
            get
            {
                if ((this.mCalculatorWindow == null))
                {
                    this.mCalculatorWindow = new CalculatorWindow();
                }
                return this.mCalculatorWindow;
            }
        }
        #endregion
        
        #region Fields
        private CalculatorWindow mCalculatorWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class CalculatorWindow : WinWindow
    {
        
        public CalculatorWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Calculator";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "CalcFrame";
            this.WindowTitles.Add("Calculator");
            #endregion
        }
        
        #region Properties
        public Button5UIItemWindow Button5UIItemWindow
        {
            get
            {
                if ((this.mButton5UIItemWindow == null))
                {
                    this.mButton5UIItemWindow = new Button5UIItemWindow(this);
                }
                return this.mButton5UIItemWindow;
            }
        }
        #endregion
        
        #region Fields
        private Button5UIItemWindow mButton5UIItemWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class Button5UIItemWindow : WinWindow
    {
        
        public Button5UIItemWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlId] = "135";
            this.WindowTitles.Add("Calculator");
            #endregion
        }
        
        #region Properties
        public WinButton Button5
        {
            get
            {
                if ((this.mButton5 == null))
                {
                    this.mButton5 = new WinButton(this);
                    #region Search Criteria
                    this.mButton5.SearchProperties[WinButton.PropertyNames.Name] = "5";
                    this.mButton5.WindowTitles.Add("Calculator");
                    #endregion
                }
                return this.mButton5;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mButton5;
        #endregion
    }
}
