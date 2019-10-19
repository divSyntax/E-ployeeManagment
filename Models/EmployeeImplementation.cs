using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public class EmployeeImplementation : IEmployeeRepo
    {
        private List<Employee> employeesList;

        //hard coded values of employees. Remove when DB is connected. 
        public EmployeeImplementation()
        {
            employeesList = new List<Employee>()
            {
                new Employee(){Id=1, Name="Mike",Email="mike@company.com",Dep=Dept.IT },
                new Employee(){Id=2, Name="Jerry",Email="jerry@company.com",Dep=Dept.IT },
                new Employee(){Id=3, Name="Gary",Email="gary@company.com",Dep=Dept.IT }
            };
        }

        //add employee
        public Employee Add(Employee employee)
        {
            employee.Id = employeesList.Max(e => e.Id) + 1;
            employeesList.Add(employee);

            return employee;
        }

        //delete employee by id
        public Employee DeleteEmp(int id)
        {
            Employee employee = employeesList.FirstOrDefault(e => e.Id == id);

            if(employee != null)
            {
                employeesList.Remove(employee);
            }

            return employee;
        }

        //return all employees
        public IEnumerable<Employee> getAllEmployees()
        {
            return employeesList;
        }

        //get one employee by id
        public Employee getEmployee(int Id)
        {
            return employeesList.FirstOrDefault(e => e.Id == Id);
        }

        //Update employee
        public Employee Update(Employee updateEmp)
        {
            Employee employee = employeesList.FirstOrDefault(e => e.Id == updateEmp.Id);

            if (employee != null)
            {
                employee.Name = updateEmp.Name;
                employee.Email = updateEmp.Email;
                employee.Dep = updateEmp.Dep;
            }

            return employee;
        }
    }
}
