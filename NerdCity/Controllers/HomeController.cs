using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BAMCIS.GeoJSON;
using NerdCity.Models;
using NerdCity.ViewModels;

namespace NerdCity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var features = NerdCity.Models.Feature.GetFeatures("");
            ViewBag.Collect = features;
            return View(new IndexViewModel(){GeoJsonData = features} );
        }

        // [HttpGet, ActionName("Index")]
        // public IActionResult IndexAndPoints(FeatureCollection showStores)
        // {
        //     return View(showStores);
        // }

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
