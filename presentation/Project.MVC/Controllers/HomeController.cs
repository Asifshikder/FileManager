using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.MVC.Models;
using Project.Services.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPageService _pageService;

        public HomeController(ILogger<HomeController> logger, IPageService pageService)
        {
            _logger = logger;
            _pageService = pageService;
        }

        public IActionResult Index(int pageid = 0)
        {
            if (pageid == 0)
                pageid = 1;
            var model = _pageService.GetPageData(pageid);
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
