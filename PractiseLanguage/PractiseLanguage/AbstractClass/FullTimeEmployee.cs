using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseLanguage.AbstractClass
{
    public class FullTimeEmployee:BaseEmployee
    {
        

        public int AnnualSalary { get; set; }
       
        public override int GetMonthlySalary()
        {
            return this.AnnualSalary / 12;
        }
    }
}
