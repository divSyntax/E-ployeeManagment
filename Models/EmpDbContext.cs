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
    }
}
