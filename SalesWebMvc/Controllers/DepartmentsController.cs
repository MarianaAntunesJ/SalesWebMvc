using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            var departmentsList = new List<Department>();

            departmentsList.Add(new Department { Id = 1, Name = "Eletronics" });
            departmentsList.Add(new Department { Id = 2, Name = "Dolls" });
            departmentsList.Add(new Department { Id = 3, Name = "Cars" });

            return View(departmentsList);
        }
    }
}
