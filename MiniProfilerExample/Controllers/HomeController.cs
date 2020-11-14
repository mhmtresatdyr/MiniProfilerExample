using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniProfilerExample.Models;
using StackExchange.Profiling;

namespace MiniProfilerExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (MiniProfiler.Current.Step("İlk ViewData Atama"))
            {
                ViewData["Test1"] = "Test1 ViewDatası set edildi";

                using (MiniProfiler.Current.Step("İkinci ViewData Atama"))
                {
                    ViewData["Test2"] = "Test2 ViewDatası set edildi";
                    return View();
                }
            }
            
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
