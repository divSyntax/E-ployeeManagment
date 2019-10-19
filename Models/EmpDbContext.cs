using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public class EmpDbContext : DbContext
    {

        private DbSet<Employee> employees;

        public DbSet<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee 
            { 
                Id = 1,
                Name = "Timmy Turner",
                Dep = Dept.IT,
                Email = "turner@company.com"
            });
        }
    }
}
