using Microsoft.AspNetCore.Mvc;
using OBilet.Domain;
using OBilet.Domain.Models.GetBusJourney;
using OBilet.Domain.Models.GetBusLocation;
using OBilet.Domain.Models.GetSession;
using OBilet.Service.Abstract;

namespace OBilet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OBiletController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly IBusLocationService _busLocationService;
        private readonly IBusJourneyService _busJourneyService;
        public OBiletController(ISessionService sessionService, IBusLocationService busLocationService, IBusJourneyService busJourneyService)
        {
            _sessionService = sessionService;
            _busLocationService = busLocationService;
            _busJourneyService = busJourneyService;
        }

        [HttpPost("GetSession")]
        public async Task<ResultMessage<GetSessionResponseModel>> GetSession([FromBody] GetSessionRequestModel model)
        {
            var result = await _sessionService.GetSession(model);
            return result;
        }

        [HttpPost("GetBusLocations")]
        public async Task<ResultMessage<GetBusLocationResponseModel>> GetBusLocations([FromBody] GetBusLocationRequestModel model)
        {
            var result = await _busLocationService.GetBusLocations(model);
            return result;
        }

        [HttpPost("GetBusInfo")]
        public async Task<ResultMessage<GetBusInfoResponseModel>> GetBusInfo([FromBody] GetBusLocationRequestModel model)
        {
            var result = await _busLocationService.GetBusInfo(model);
            return result;
        }

        [HttpPost("GetBusJourneys")]
        public async Task<ResultMessage<GetBusJourneyResponseModel>> GetBusJourneys([FromBody] GetBusJourneyRequestModel model)
        {
            var result = await _busJourneyService.GetBusJourneys(model);
            return result;
        }
    }
}
