using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PractiseLanguage.BaseConstructor
{
    [TestClass]
    public class TestClass1 : TestBase
    {
        

        static TestClass1() //Replaces ClassInitialize method
        {
            Log.AppendLine("TestClass1.TestClass1() <-- acts as ClassInitialize in derived");

        }

        [TestInitialize]
        public void TestInit()
        {
            Log.AppendLine("TestClass1.TestInit()");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Log.AppendLine("TestClass1.TestMethod1()");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Log.AppendLine("TestClass1.TestMethod2()");
        }
    }
}
