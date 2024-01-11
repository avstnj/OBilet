using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using OBilet.Common.ApiHelpers;
using OBilet.Domain;
using OBilet.Domain.Models;
using OBilet.Domain.Models.Configuration;
using OBilet.Domain.Models.GetBusJourney;
using OBilet.Domain.Models.GetBusLocation;
using OBilet.Domain.Models.GetSession;
using OBilet.UI.Helpers;
using OBilet.UI.Service.Abstract;

namespace OBilet.UI.Service.Concreate
{
	public class OBiletServiceManager : IOBiletServiceManager
	{
		private readonly OBiletUIConfigurationModel _oBiletUIConfigurationModel;
		private readonly IMemoryCache _cache;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public OBiletServiceManager(IOptions<OBiletUIConfigurationModel> oBiletUIConfigurationModel, IMemoryCache cache, IHttpContextAccessor httpContextAccessor)
		{
			_oBiletUIConfigurationModel = oBiletUIConfigurationModel.Value;
			_cache = cache;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<ResultMessage<SessionResponseData>> GetSession()
		{
			try
			{
				string cacheKey = $"Session";
				if (!_cache.TryGetValue(cacheKey, out var cachedData))
				{
					string? userAgent = _httpContextAccessor.HttpContext?.Request?.Headers["User-Agent"].ToString();
					(string browserName, string browserVersion) = BrowserServiceInfo.GetBrowserInfoFromUserAgent(userAgent);

					string externalIP = "";
					using (HttpClient client = new HttpClient())
					{
						HttpResponseMessage response = await client.GetAsync("http://api.ipify.org");
						response.EnsureSuccessStatusCode();
						externalIP = await response.Content.ReadAsStringAsync();
					}
					//externalIP = "165.114.41.21";

					GetSessionRequestModel getSessionRequestModel = new GetSessionRequestModel
					{
						type = 1,
						browser = new Browser
						{
							name = browserName,
							version = browserVersion
						},
						connection = new Connection
						{
							ipaddress = externalIP,
							port = "5117"
						}
					};

					var getSessionUrl = $"{_oBiletUIConfigurationModel.OBiletApiUrl}{_oBiletUIConfigurationModel.GetSession}";
					var datalist = await ApiProcess.PostMetod<GetSessionRequestModel, ResultMessage<GetSessionResponseModel>>(getSessionUrl, getSessionRequestModel);

					if (datalist.IsSuccess && datalist.Data != null)
					{
						cachedData = new SessionResponseData { deviceid = datalist.Data.data.deviceid, sessionid = datalist.Data.data.sessionid };
						_cache.Set(cacheKey, cachedData, TimeSpan.FromMinutes(120));

						return new ResultMessage<SessionResponseData> { Data = datalist?.Data?.data, IsSuccess = true, Message = "Başarılı" };
					}

					return new ResultMessage<SessionResponseData> { IsSuccess = false, Message = datalist.Message };
				}
				else
				{
					return new ResultMessage<SessionResponseData>() { Data = cachedData as SessionResponseData, IsSuccess = true };
				}
			}
			catch (Exception ex)
			{
				return new ResultMessage<SessionResponseData> { IsSuccess = false, Message = ex.Message };
			}
		}
		public async Task<ResultMessage<GetBusLocationResponseModel>> GetBusLocations(string? data)
		{
			try
			{
				var session = await GetSession();
				if (session.IsSuccess && session.Data != null)
				{
					string deviceid = session.Data.deviceid;
					string sessionid = session.Data.sessionid;
					var languages = _httpContextAccessor?.HttpContext?.Request.Headers["Accept-Language"].ToString().Split(',').FirstOrDefault();
					//string selectedLanguages = "tr-TR";
					string selectedLanguages = languages != null ? languages : "tr-TR";

					GetBusLocationRequestModel getBusLocationResponseModel = new GetBusLocationRequestModel
					{
						date = DateTime.Now,
						devicesession = new DeviceSession
						{
							deviceid = deviceid,
							sessionid = sessionid
						},
						language = selectedLanguages,
						data = data
					};
					var getSessionUrl = $"{_oBiletUIConfigurationModel.OBiletApiUrl}{_oBiletUIConfigurationModel.GetBusLocations}";
					var datalist = await ApiProcess.PostMetod<GetBusLocationRequestModel, ResultMessage<GetBusLocationResponseModel>>(getSessionUrl, getBusLocationResponseModel);

					return new ResultMessage<GetBusLocationResponseModel> { Data = datalist.Data, IsSuccess = true, Message = "Başarılı" };
				}

				return new ResultMessage<GetBusLocationResponseModel> { IsSuccess = false, Message = session.Message };
			}
			catch (Exception ex)
			{
				return new ResultMessage<GetBusLocationResponseModel> { IsSuccess = false, Message = ex.Message };
			}
		}
		public async Task<ResultMessage<GetBusJourneyResponseModel>> GetBusJourneys(DateTime departureDate, int destinationId, int originId)
		{
			try
			{
				var session = await GetSession();
				if (session.IsSuccess && session.Data != null)
				{
					string deviceid = session.Data.deviceid;
					string sessionid = session.Data.sessionid;

					var languages = _httpContextAccessor?.HttpContext?.Request.Headers["Accept-Language"].ToString().Split(',').FirstOrDefault();
					//string selectedLanguages = "tr-TR";
					string selectedLanguages = languages != null ? languages : "tr-TR";

					GetBusJourneyRequestModel getBusJourneyRequestModel = new GetBusJourneyRequestModel
					{
						date = DateTime.Now,
						devicesession = new DeviceSession
						{
							deviceid = deviceid,
							sessionid = sessionid,
						},
						BusJourneyData = new BusJourneyData
						{
							departuredate = departureDate,
							destinationid = destinationId,
							originid = originId
						},
						language = selectedLanguages
					};

					var getSessionUrl = $"{_oBiletUIConfigurationModel.OBiletApiUrl}{_oBiletUIConfigurationModel.GetBusJourneys}";
					var datalist = await ApiProcess.PostMetod<GetBusJourneyRequestModel, ResultMessage<GetBusJourneyResponseModel>>(getSessionUrl, getBusJourneyRequestModel);

					return new ResultMessage<GetBusJourneyResponseModel> { Data = datalist?.Data, IsSuccess = true, Message = "Başarılı" };
				}

				return new ResultMessage<GetBusJourneyResponseModel> { IsSuccess = false, Message = session.Message };
			}
			catch (Exception ex)
			{
				return new ResultMessage<GetBusJourneyResponseModel> { IsSuccess = false, Message = ex.Message };
			}
		}
	}
}
