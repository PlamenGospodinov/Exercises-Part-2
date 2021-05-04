using ApplicationService.DTOs;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace ApplicationService.Implementations
{
    public class StudentManagementService
    {
        private Student1SystemDBContext ctx = new Student1SystemDBContext();

        public List<StudentDTO> Get()
        {
            List<StudentDTO> studentsDto = new List<StudentDTO>();

            foreach (var item in ctx.Students.ToList())
            {
                studentsDto.Add(new StudentDTO
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age,
                    FacultyNumber = item.FacultyNumber,
                    YearsInUniversity = item.YearsInUniversity
                });
            }

            return studentsDto;
        }

        public bool Save(StudentDTO studentDTO)
        {
            Student Student = new Student
            {
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                Age = studentDTO.Age,
                FacultyNumber = studentDTO.FacultyNumber,
                YearsInUniversity = studentDTO.YearsInUniversity
            };

            try
            {
                ctx.Students.Add(Student);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Student student = ctx.Students.Find(id);
                ctx.Students.Remove(student);
                ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
