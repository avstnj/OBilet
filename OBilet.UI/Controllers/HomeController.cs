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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetBusLocations()
        {
            var result = await _iOBiletServiceManager.GetBusLocations(null);
            if (result.IsSuccess && result.Data != null)
                return Json(result?.Data?.BusLocationResponseData?.Select(x => new BusInfoResponseData { id = x.Id, name = x.Name }).Take(500).ToList());
            else
                return Json(null);
        }

        [HttpPost]
        public async Task<JsonResult> GetBusJourneys(string departureDate, int destinationId, int originId)
        {
            DateTime departureDateTime = String.IsNullOrEmpty(departureDate) ? DateTime.Now.Date : 
                new DateTime(Convert.ToInt32(departureDate.Split('/')[2]), Convert.ToInt32(departureDate.Split('/')[0]), Convert.ToInt32(departureDate.Split('/')[1])).Date;

            var result = await _iOBiletServiceManager.GetBusJourneys(departureDateTime, destinationId, originId);

			if (result.IsSuccess && result.Data != null)
				return Json(result?.Data?.BusJourneyResponseData?.ToList());
			else
				return Json(null);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}