using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TagHelperEx.Models;
using TagHelperEx.TagHelpers;


namespace TagHelperEx.Controllers
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
            List<ComboItem> comboItems = new List<ComboItem>()
            {
                new ComboItem() { Key="1", Value = "Mot", Tag = new string[] { "1", "2" } },
                new ComboItem() { Key="2", Value = "Hai", Tag = new string[] { "4", "5" }  }
            };

            return View(comboItems);
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
