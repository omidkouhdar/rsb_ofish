using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RSB_Ofish_System.Models;
using RSB_Ofish_System.Repository.Ofish.Interfaces;

namespace RSB_Ofish_System.Controllers
{
    [Authorize(Roles ="Guard")]
    public class Home : Controller
    {
        private readonly ILogger<Home> _logger;
        private readonly IOfishService _ofishService;
        public Home(ILogger<Home> logger , IOfishService ofishService)
        {
            _logger = logger;
            _ofishService = ofishService;
        }
        public  IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> getTodayData(int pageId = 1)
        {
            ViewData["currenPage"] = pageId;
            var model = await _ofishService.GetTodayOfishLists(pageId);
            return PartialView("_ofishDataView", model);
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
