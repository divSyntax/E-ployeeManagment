using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public interface IEmployeeRepo
    {
        Employee getEmployee(int Id);
        IEnumerable<Employee> getAllEmployees();
        Employee Add(Employee employee);
        Employee Update(Employee updateEmp);
        Employee DeleteEmp(int id);
    }
}
