using CRUD.Models;
using CRUD.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CRUDAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteController : Controller
    {

        private readonly EmployeeViewModel employeeViewModel;

        public SiteController(EmployeeViewModel employeeViewModel)
        {
            this.employeeViewModel = employeeViewModel;
        } 



        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult Index()
        {
            List<Employee> employee= employeeViewModel.GetAllEmployees();
            return Ok(employee);
        }



        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult EmployeeInfo(Employee employee)
        {
            employeeViewModel.AddEmployee(employee);
                
            return Ok();
        }



        [HttpGet]
        [Route("EditEmployee")]
        public IActionResult EditEmployee(int id)
        {
           var employee = employeeViewModel.GetEmployeeById(id);

            return Ok(employee);
        }



        [HttpPut]
        [Route("EditEmployee")]
        public IActionResult EditEmployee(Employee employee)
        {
            employeeViewModel.UpdatesEmployee(employee);

            return Ok();
        }



        [HttpDelete]
        [Route("DeleteEmp/{id}")]
        public IActionResult DeleteEmp(int id)
        {
            employeeViewModel.DeleteEmployee(id);

            return Ok();
        }
    }
}
