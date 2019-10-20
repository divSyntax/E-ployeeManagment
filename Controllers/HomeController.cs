using EmployeeManagment.Models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepo employee_Repo;
        private readonly IHostingEnvironment hosting_Environment;
        public HomeController(IEmployeeRepo employeeRepo, IHostingEnvironment hostingEnvironment)
        {
            employee_Repo = employeeRepo;
            hosting_Environment = hostingEnvironment;
        }

        public ViewResult Index()
        {
            var model = employee_Repo.getAllEmployees();
            return View(model);
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel
            {
                employee = employee_Repo.getEmployee(id??1),
                PageTitle = "Emp Details"
            };
            return View(viewModel);
        }

        public ViewResult Strings()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateView employee)
        {
            if(ModelState.IsValid)
            {

                string filepath = null;
                if(employee.Photo != null)
                {
                    string uploads = Path.Combine(hosting_Environment.WebRootPath, "images");
                    filepath = Guid.NewGuid().ToString() + "_" + employee.Photo.FileName;
                    string path = Path.Combine(uploads, filepath);
                    employee.Photo.CopyTo(new FileStream(path, FileMode.Create));

                }

                Employee newEmployee = new Employee
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    Dep = employee.Dep,
                    EmpPhoto = filepath

                };

                employee_Repo.Add(newEmployee);

                return RedirectToAction("details", new { id = newEmployee.Id });
            }

            return View();
        }
    }
}
