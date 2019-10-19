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
            throw new NotImplementedException();
        }

        public Employee DeleteEmp(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> getAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee getEmployee(int Id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee updateEmp)
        {
            throw new NotImplementedException();
        }
    }
}
