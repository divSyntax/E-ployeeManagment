using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public class EmployeeImplementation : IEmployeeRepo
    {
        private List<Employee> employeesList;

        public EmployeeImplementation()
        {
            employeesList = new List<Employee>()
            {
                new Employee(){Id=1, Name="Mike",Email="mike@company.com",Dep=Dept.IT },
                new Employee(){Id=2, Name="Jerry",Email="jerry@company.com",Dep=Dept.IT },
                new Employee(){Id=3, Name="Gary",Email="gary@company.com",Dep=Dept.IT }
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = employeesList.Max(e => e.Id) + 1;
            employeesList.Add(employee);

            return employee;
        }

        public IEnumerable<Employee> getAllEmployees()
        {
            return employeesList;
        }

        public Employee getEmployee(int Id)
        {
            return employeesList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
