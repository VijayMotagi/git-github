using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PractiseLanguage.AbstractClass
{
   public class Employees
    {
        public List<Object> List = new List<object>();

        public void DisplayInformation()
        {
            foreach (var item in List)
            {
                Console.WriteLine("#######################################");
                Console.WriteLine("Displaying Employee details");
                PropertyInfo[] properties = item.GetType().GetProperties();
                Console.WriteLine("Full Name:" + item.GetType().GetMethod("GetFullName").Invoke(item, null));
                Console.WriteLine("Monthly Salary: {0}",item.GetType().GetMethod("GetMonthlySalary").Invoke(item, null));
                foreach (PropertyInfo property in properties)
                {
                    object propertyValue = property.GetValue(item, null);

                    Console.WriteLine("{0}:{1}", property.Name, propertyValue);
                }
               
                Console.WriteLine("#######################################");
            }

        }
    }
}
