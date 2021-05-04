using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class Student1SystemDBContext : DbContext
    {
        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
