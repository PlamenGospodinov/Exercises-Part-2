using FirstWeekDistributed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FirstWeekDistributed.Controllers
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
            return View();
        }

        public ActionResult BgToll(string car_id)
        {
            var url = "https://check.bgtoll.bg/check/vignette/plate/BG/";
            var client = new WebClient();
            if(car_id != null && car_id != "")
            {
                var body = client.DownloadString(url + car_id);
                JObject data = JObject.Parse(body);
                if((bool)data["ok"] == true)
                {
                    ViewData["validation"] = car_id;
                    ViewData["vignetteNumber"] = data["vignette"]["vignetteNumber"];
                    ViewData["validityDateFrom"] = data["vignette"]["validityDateFromFormated"];
                    ViewData["validityDateTo"] = data["vignette"]["validityDateToFormated"];
                    ViewData["price"] = data["vignette"]["price"];
                }
                else
                {
                    ViewData["validation"] = "Няма активна винетка .";
                }
                ViewData["body"] = body;
            }
            else
            {
                ViewData["validation"] = "Моля въведете номер на автомобил.";
            }
            
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
