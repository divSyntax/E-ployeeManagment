using EmployeeManagment.Models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepo employee_Repo;
        public HomeController(IEmployeeRepo employeeRepo)
        {
            employee_Repo = employeeRepo;
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
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                Employee newEmployee = employee_Repo.Add(employee);
                return RedirectToAction("details", new { id = newEmployee });
            }

            return View();
        }
    }
}
