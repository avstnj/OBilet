using Microsoft.Extensions.Options;
using OBilet.Common.ApiHelpers;
using OBilet.Domain;
using OBilet.Domain.Models.Configuration;
using OBilet.Domain.Models.GetSession;
using OBilet.Service.Abstract;

namespace OBilet.Service.Concreate
{
    public class SessionService : ISessionService
    {
        private readonly OBiletServiceModel _oBiletApiModel;

        public SessionService(IOptions<OBiletServiceModel> oBiletApiModel)
        {
            _oBiletApiModel = oBiletApiModel.Value;
        }

        public async Task<ResultMessage<GetSessionResponseModel>> GetSession(GetSessionRequestModel request)
        {
            try
            {
                var getSessionUrl = $"{_oBiletApiModel.OBiletApiBaseUrl}{_oBiletApiModel.GetSessionEndPoint}";
                var datalist = await ApiProcess.PostMetod<GetSessionRequestModel, GetSessionResponseModel>(getSessionUrl, request, _oBiletApiModel.Token);

                return new ResultMessage<GetSessionResponseModel> { Data = datalist, IsSuccess = true, Message = "Başarılı" };
            }
            catch (Exception ex)
            {
                return new ResultMessage<GetSessionResponseModel> { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}
