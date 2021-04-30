using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApiProject.Controllers
{
    public class HomeController : Controller
    {
        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
