using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PractiseLanguage.AbstractClass;

namespace PractiseLanguage
{
    [TestClass]
    public class DerivedTest : BaseTest
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("DerivedTest.TestMethod1");
            PrintMessage();
            LoginFlows loginflows = new LoginFlows();
            loginflows.LoginSubmit();
            loginflows.ForgetPassword();
        }

        public override void PrintMessage()
        {
            Console.WriteLine("This is log message");
        }

        [TestMethod]
        public void AbstractClassTest()
        {
            FullTimeEmployee fte = new FullTimeEmployee()
            {
                ID=101,
                FirstName="Vijay",
                LastName="Motagi",
                AnnualSalary=60000,
                EmployeeType="Full Time"
            };

           
            ContractEmployee cte = new ContractEmployee()
            {
                ID = 101,
                FirstName = "Shriya",
                LastName = "Motagi",
                HourlyPay = 200,
                TotalHours=40,
                EmployeeType = "Contract"
            };

           

            Employees e = new Employees();
            e.List.Add(fte);
            e.List.Add(cte);

            e.DisplayInformation();


        }
    }
}
