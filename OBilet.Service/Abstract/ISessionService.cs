using OBilet.Domain;
using OBilet.Domain.Models.GetSession;

namespace OBilet.Service.Abstract
{
    public interface ISessionService
    {
        Task<ResultMessage<GetSessionResponseModel>> GetSession(GetSessionRequestModel request);
    }
}
