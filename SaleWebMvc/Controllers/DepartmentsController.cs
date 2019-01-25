using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaleWebMvc.Models;

namespace SaleWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();

            list.Add(new Department { Id = 1, Name = "Eletrônicos" });
            list.Add(new Department { Id = 1, Name = "Moda" });

            return View(list);
        }
    }
}