using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AnimalCrossingTeam.Core.Contexts.Interfaces;
using AnimalCrossingTeam.Core.Models;
using AnimalCrossingTeam.Core.Services;
using AnimalCrossingTeam.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AnimalCrossingTeam.Web.Models;

namespace AnimalCrossingTeam.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBeteService _beteService;

        public HomeController(IBeteService beteService)
        {
            _beteService = beteService;
        }

        public IActionResult Index() => View(_beteService.GetLastBetes());


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
