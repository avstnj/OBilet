using OBilet.Domain;
using OBilet.Domain.Models.GetBusJourney;

namespace OBilet.Service.Abstract
{
    public interface IBusJourneyService
    {
        Task<ResultMessage<GetBusJourneyResponseModel>> GetBusJourneys(GetBusJourneyRequestModel request);
    }
}
