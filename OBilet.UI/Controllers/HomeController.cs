using Microsoft.AspNetCore.Mvc;
using OBilet.Domain.Models.GetBusLocation;
using OBilet.UI.Models;
using OBilet.UI.Service.Abstract;
using System.Diagnostics;

namespace OBilet.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOBiletServiceManager _iOBiletServiceManager;

        public HomeController(ILogger<HomeController> logger, IOBiletServiceManager iOBiletServiceManager)
        {
            _logger = logger;
            _iOBiletServiceManager = iOBiletServiceManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetBusLocations()
        {
            var result = await _iOBiletServiceManager.GetBusLocations(null);
			if (result.IsSuccess && result.Data != null)
				return Json(result?.Data?.BusLocationResponseData?.Select(x => new BusInfoResponseData { id = x.Id, name = x.Name }).Take(1000).ToList());
			else
				return Json(null);
		}

        [HttpPost]
        public async Task<JsonResult> GetBusJourneys(DateTime departureDate, int destinationId, int originId)
        {
            var result = await _iOBiletServiceManager.GetBusJourneys(departureDate, destinationId, originId);
            //if (result.IsSuccess && result.Data != null)
            //    return Json(result?.Data?.BusLocationResponseData?.Select(x => new BusInfoResponseData { id = x.Id, name = x.Name }).Take(1000).ToList());
            //else
                return Json(null);
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