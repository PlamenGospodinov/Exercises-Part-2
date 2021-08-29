using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    class Employee
    {
        private int empId;
        private string empName;
        public double salary { get; set; }
        public int grade { get; set; }
        private string company = "IBM";

        IEmail email;

        public Employee(int empId,string empName,IEmail email)
        {
            this.empId = empId;
            this.empName = empName;
            this.email = email;
        }

        public void NotifyEmployee()
        {
            email.SendEmail();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IEmail email = new OutlookEmail();
            Employee emp1 = new Employee(100, "Alex",email);
            emp1.salary = 100000;
            emp1.NotifyEmployee();

            email = new WebserviceEmail();
            Employee emp2 = new Employee(100, "Emily",email);
            emp2.salary = 20000;
        }
    }
}
