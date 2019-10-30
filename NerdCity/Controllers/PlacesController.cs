// using Microsoft.AspNetCore.Mvc;
// using NerdCity.Models;

// namespace NerdCity.Controllers
// {
//     [Route("search")]
//     [ApiController]
//     public class PlacesController : Controller
//     {
//         [HttpGet]
//         public IActionResult Index(string searchTerm)
//         {
//             var features = Feature.GetFeatures(searchTerm);
//             return RedirectToAction("Index", "Home", new {showStores = features});
//         }
//     }
// }