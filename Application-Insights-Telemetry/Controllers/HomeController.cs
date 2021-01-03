using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using appinsights_custom_event.Models;
using Microsoft.ApplicationInsights;

namespace appinsights_custom_event.Controllers
{
    public class HomeController : Controller
    {
        private TelemetryClient telemetryClient;

        public HomeController(TelemetryClient telemetryClient)
        {
            this.telemetryClient = telemetryClient;
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

        [HttpPost]
        public ActionResult Hello(string button)
        {
            this.telemetryClient.TrackEvent("HelloWorld");
            ViewBag.Message = "Hello World!";
            return View("Index");
        }
    }
}
