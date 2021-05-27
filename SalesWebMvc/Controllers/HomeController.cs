using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class HomeController : Controller
    {
        //Leanr: IActionResult são endpoints!
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Reception"] = "Hello, welcome to our store! We hope you're having an amazing day and find out all products you need here.";
            ViewData["Nome"] = "Mariana Antunes";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
