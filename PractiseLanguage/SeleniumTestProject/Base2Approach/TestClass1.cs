using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SeleniumTestProject
{
    [TestClass]
    public class TestClass1 : TestBase
    {


        static TestClass1() //Replaces ClassInitialize method
        {
            Log.AppendLine("--------------------------------------");
            Log.AppendLine("TestClass1.TestClass1() <-- acts as ClassInitialize in derived");
            Log.AppendLine("--------------------------------------");

        }


        [TestMethod]
        public void TestMethod1()
        {
            Log.AppendLine("--------------------------------------");
            Log.AppendLine("TestClass1.TestMethod1()");
            Log.AppendLine("Test Cases steps comes here");
            Driver.NavigateToURL("http://www.newtours.demoaut.com/");
            Log.AppendLine("--------------------------------------");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Log.AppendLine("--------------------------------------");
            Log.AppendLine("TestClass1.TestMethod2()");
            Log.AppendLine("Test Cases steps comes here");
            Driver.NavigateToURL("http://www.google.com/");
            Log.AppendLine("--------------------------------------");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Log.AppendLine("--------------------------------------");
            Log.AppendLine("TestClass1.TestMethod3()");
            Log.AppendLine("Test Cases steps comes here");
            Driver.NavigateToURL("http://www.newtours.demoaut.com/");
            Driver.MercuryLoginPage.txtUserName.SendKeys("mercury");
            Driver.MercuryLoginPage.txtPassword.SendKeys("mercury");
            Log.AppendLine("--------------------------------------");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Log.AppendLine("--------------------------------------");
            Log.AppendLine("TestClass1.TestMethod4()");
            Log.AppendLine("Test Cases steps comes here");
            Driver.NavigateToURL("http://www.google.com/");
            Log.AppendLine("--------------------------------------");
        }
    }
}
