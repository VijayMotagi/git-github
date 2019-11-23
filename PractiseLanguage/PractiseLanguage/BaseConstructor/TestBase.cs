using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseLanguage.BaseConstructor
{
    [TestClass]
    public class TestBase
    {
        static TestBase()
        {
            s_log = new StringBuilder();
            Log.AppendLine("TestBase.TestBase() <-- acts as ClassInitialize in base");
        }

        [TestInitialize]
        public void BaseTestInit()
        {
            Log.AppendLine("TestBase.BaseTestInit()");
        }

        [TestCleanup]
        public void BaseTestCleanup()
        {
            Console.WriteLine(Log.ToString());
        }

        public static StringBuilder Log
        {
            get { return s_log; }
        }

        static StringBuilder s_log;
    }
}
