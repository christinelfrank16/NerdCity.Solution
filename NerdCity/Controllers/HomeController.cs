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
        private string _places_key = System.Environment.GetEnvironmentVariable("mapquest_key");
        public ActionResult Index(string search)
        {
            FeatureCollection collection;
            if(search == null)
            {
                collection = NerdCity.Models.Feature.GetFeatures(_places_key, "");
            }
            else
            {
                collection = NerdCity.Models.Feature.GetFeatures(_places_key, search);
            }
            return View(new IndexViewModel(){GeoJsonData = collection } );
        }

        [HttpPost,ActionName("Index")]
        public ActionResult FormSubmit(string searchValue)
        {
            return RedirectToAction("Index", new { search = searchValue });
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
