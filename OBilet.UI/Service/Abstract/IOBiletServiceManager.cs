using OBilet.Domain;
using OBilet.Domain.Models.GetBusJourney;
using OBilet.Domain.Models.GetBusLocation;

namespace OBilet.UI.Service.Abstract
{
    public interface IOBiletServiceManager
    {
        Task<ResultMessage<GetBusLocationResponseModel>> GetBusLocations(string? data);
        Task<ResultMessage<GetBusJourneyResponseModel>> GetBusJourneys(DateTime departureDate, int destinationId, int originId);
    }
}
