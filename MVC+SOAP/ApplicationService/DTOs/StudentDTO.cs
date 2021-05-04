using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FacultyNumber { get; set; }
        public int YearsInUniversity { get; set; }

    }
}
