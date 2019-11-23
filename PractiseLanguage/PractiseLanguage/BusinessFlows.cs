using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseLanguage
{
   public interface ILoginFlows
    {
         void LoginSubmit();

        void ForgetPassword();

    }

    public class LoginFlows : ILoginFlows
    {
        public void ForgetPassword()
        {
            Console.WriteLine("ForgetPassword");
        }

        public void LoginSubmit()
        {
            Console.WriteLine("LoginSubmit");
        }
    }
}
