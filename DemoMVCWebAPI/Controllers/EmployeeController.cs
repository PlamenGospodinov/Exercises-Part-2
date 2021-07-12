using ModelLayer2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace DemoMVCWebAPIApp.Controllers
{
    public class EmployeeController : ApiController
    {
        List<Employee> employees;

        public EmployeeController()
        {
            employees = new List<Employee>();
            employees.Add(new Employee { ID = 1, Name = "Plamen", ContactNumber = 999555888, Address = "bul. Bulgaria 365" });
            employees.Add(new Employee { ID = 2, Name = "Ivan", ContactNumber = 999555777, Address = "bul. Bulgaria 236" });
        }

        //api/employee
        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        //api/employee/1
        public Employee Get(int id)
        {
            return employees.FirstOrDefault(x => x.ID.Equals(id));
        }
    }
}