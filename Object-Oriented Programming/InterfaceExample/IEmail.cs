using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    interface IEmail
    {
        void SendEmail();
    }

    class OutlookEmail : IEmail
    {
        public void SendEmail()
        {
            Console.WriteLine("send outlook email");
        }
    }

    class WebserviceEmail : IEmail
    {
        public void SendEmail()
        {
            Console.WriteLine("send webservice email");
        }
    }
}
