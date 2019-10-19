using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public static class ModelBuilderExtention
    {
        public static void Add(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Name = "Timmy Turner",
                Dep = Dept.IT,
                Email = "turner@company.com"
            }, new Employee
            {
                Id = 2,
                Name = "Jimmy Nutron",
                Dep = Dept.IT,
                Email = "nutron@company.com"
            }
           );
        }
    }
}
