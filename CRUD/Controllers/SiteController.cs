using CRUD.Models;
using CRUD.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRUD.Controllers
{
    public class SiteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            List<Employee> employees = employeeViewModel.GetAllEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult EmployeeInfo(int id=0)
        {
                Employee employee = new Employee();

                if (id == 0)
                {
                    employee.Id = 0;
                }
                else
                {
                    EmployeeViewModel emp = new EmployeeViewModel();
                    employee = emp.GetEmployeeById(id);
                }
                return View(employee);   
        }

        [HttpPost]
        public IActionResult EmployeeInfo(Employee employee)
        {
            if(ModelState.IsValid)
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();

                if (employee.Id == 0)
                {
                    employeeViewModel.AddEmployee(employee);
                }
                else
                {
                    employeeViewModel.UpdatesEmployee(employee);
                }
                
                return RedirectToAction("Index", "Site");
            }
            return View();
        }
        
        public IActionResult DeleteEmployee(int id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.DeleteEmployee(id);

            return RedirectToAction("Index", "Site");
        }
    }
}
