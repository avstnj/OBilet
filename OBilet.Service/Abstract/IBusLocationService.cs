using OBilet.Domain;
using OBilet.Domain.Models.GetBusLocation;

namespace OBilet.Service.Abstract
{
    public interface IBusLocationService
    {
        Task<ResultMessage<GetBusLocationResponseModel>> GetBusLocations(GetBusLocationRequestModel request);
        Task<ResultMessage<GetBusInfoResponseModel>> GetBusInfo(GetBusLocationRequestModel request);
    }
}
