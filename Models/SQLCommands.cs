using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public class SQLCommands : IEmployeeRepo
    {
        private readonly EmpDbContext empDbContext;

        public SQLCommands(EmpDbContext empDbContext)
        {
            this.empDbContext = empDbContext;
        }

        public Employee Add(Employee employee)
        {
            empDbContext.Add(employee);
            empDbContext.SaveChanges();

            return employee;
        }

        public Employee DeleteEmp(int id)
        {
            Employee deleteEmp = empDbContext.Employees.Find(id);

            if(deleteEmp != null)
            {
                empDbContext.Employees.Remove(deleteEmp);
                empDbContext.SaveChanges();
            }

            return deleteEmp;
        }

        public IEnumerable<Employee> getAllEmployees()
        {
           return empDbContext.Employees;
        }

        public Employee getEmployee(int Id)
        {
            return empDbContext.Employees.Find(Id);
        }

        public Employee Update(Employee updateEmp)
        {
            var emp = empDbContext.Employees.Attach(updateEmp);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            empDbContext.SaveChanges();
            return updateEmp;
        }
    }
}
