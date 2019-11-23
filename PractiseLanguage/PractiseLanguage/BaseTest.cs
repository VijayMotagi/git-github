using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PractiseLanguage
{
    [TestClass]
    public abstract class BaseTest
    {

        
        [TestInitialize]
        public  void TestInitialize()
        {
            Console.WriteLine("BaseTest.TestInitialize");
        }

        [TestCleanup]
        public  void TestCleanup()
        {
            Console.WriteLine("BaseTest.TestCleanup");
        }

        public abstract void PrintMessage();

       
    }

}
