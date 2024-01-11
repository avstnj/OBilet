using Microsoft.Extensions.Options;
using OBilet.Common.ApiHelpers;
using OBilet.Domain;
using OBilet.Domain.Models.Configuration;
using OBilet.Domain.Models.GetBusLocation;
using OBilet.Service.Abstract;

namespace OBilet.Service.Concreate
{
    public class BusLocationService : IBusLocationService
    {
        private readonly OBiletServiceModel _oBiletApiModel;

        public BusLocationService(IOptions<OBiletServiceModel> oBiletApiModel)
        {
            _oBiletApiModel = oBiletApiModel.Value;
        }

        public async Task<ResultMessage<GetBusLocationResponseModel>> GetBusLocations(GetBusLocationRequestModel request)
        {
            try
            {
                var getSessionUrl = $"{_oBiletApiModel.OBiletApiBaseUrl}{_oBiletApiModel.GetBusLocationsEndPoint}";
                var datalist = await ApiProcess.PostMetod<GetBusLocationRequestModel, GetBusLocationResponseModel>(getSessionUrl, request, _oBiletApiModel.Token);

                return new ResultMessage<GetBusLocationResponseModel> { Data = datalist, IsSuccess = true, Message = "Başarılı" };
            }
            catch (Exception ex)
            {
                return new ResultMessage<GetBusLocationResponseModel> { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}
