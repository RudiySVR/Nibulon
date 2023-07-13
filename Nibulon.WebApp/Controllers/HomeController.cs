using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nibulon.WebApp.Models;
using Nibulon.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nibulon.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGrainManipulation  _grainManipulation;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, IGrainManipulation grainManipulation)
        {
            _logger = logger;
            _grainManipulation = grainManipulation;
        }

        public IActionResult Index()
        {
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
