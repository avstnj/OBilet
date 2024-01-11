using Microsoft.Extensions.Options;
using OBilet.Common.ApiHelpers;
using OBilet.Domain;
using OBilet.Domain.Models.Configuration;
using OBilet.Domain.Models.GetBusJourney;
using OBilet.Service.Abstract;

namespace OBilet.Service.Concreate
{
    public class BusJourneyService : IBusJourneyService
    {
        private readonly OBiletServiceModel _oBiletApiModel;

        public BusJourneyService(IOptions<OBiletServiceModel> oBiletApiModel)
        {
            _oBiletApiModel = oBiletApiModel.Value;
        }

        public async Task<ResultMessage<GetBusJourneyResponseModel>> GetBusJourneys(GetBusJourneyRequestModel request)
        {
            try
            {
                var getSessionUrl = $"{_oBiletApiModel.OBiletApiBaseUrl}{_oBiletApiModel.GetBusJourneysEndPoint}";
                var datalist = await ApiProcess.PostMetod<GetBusJourneyRequestModel, GetBusJourneyResponseModel>(getSessionUrl, request, _oBiletApiModel.Token);

                return new ResultMessage<GetBusJourneyResponseModel> { Data = datalist, IsSuccess = true, Message = "Başarılı" };
            }
            catch (Exception ex)
            {
                return new ResultMessage<GetBusJourneyResponseModel> { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}
