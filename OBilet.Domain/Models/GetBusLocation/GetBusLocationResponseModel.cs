using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OBilet.Domain.Models.GetBusLocation
{
    public class GetBusLocationResponseModel
    {
		public string Status { get; set; }
		[JsonProperty("data")]
		[JsonPropertyName("data")]
		public List<BusLocationResponseData> BusLocationResponseData { get; set; }
		public string Message { get; set; }

		[JsonProperty("user-message")]
		[JsonPropertyName("user-message")]
		public string UserMessage { get; set; }
		//[JsonProperty("api-request-id")]
		//[JsonPropertyName("api-request-ide")]
		//public string ApiRequestId { get; set; }
		//public string Controller { get; set; }
		//[JsonProperty("client-request-id")]
		//[JsonPropertyName("client-request-id")]
		//public string ClientRequestId { get; set; }

		//[JsonProperty("web-correlation-id")]
		//[JsonPropertyName("web-correlation-id")]
		//public string WebCorrelationId { get; set; }
		//[JsonProperty("correlation-id")]
		//[JsonPropertyName("correlation-id")]
		//public string CorrelationId { get; set; }
		//public string Parameters { get; set; }

	}
    public class BusLocationResponseData
    {
		public int Id { get; set; }
		//[JsonProperty("parent-id")]
		//[JsonPropertyName("parent-id")]
		//public int ParentId { get; set; }
		//public string Type { get; set; }
		public string Name { get; set; }
		//[JsonProperty("geo-location")]
		//[JsonPropertyName("geo-location")]
		//public GeoLocation GeoLocation { get; set; }
		//public int Zoom { get; set; }
		//[JsonProperty("tz-code")]
		//[JsonPropertyName("tz-code")]
		//public string TzCode { get; set; }
		//[JsonProperty("weather-code")]
		//[JsonPropertyName("weather-code")]
		//public string WeatherCode { get; set; }
		//public int Rank { get; set; }
		//[JsonProperty("reference-code")]
		//[JsonPropertyName("reference-code")]
		//public string ReferenceCode { get; set; }
		//[JsonProperty("city-id")]
		//[JsonPropertyName("city-id")]
		//public int? CityId { get; set; }
		//[JsonProperty("reference-country")]
		//[JsonPropertyName("reference-country")]
		//public string ReferenceCountry { get; set; }
		//[JsonProperty("country-id")]
		//[JsonPropertyName("country-id")]
		//public int CountryId { get; set; }
		//public string Keywords { get; set; }
		//[JsonProperty("city-name")]
		//[JsonPropertyName("city-name")]
		//public string CityName { get; set; }
		//public string Languages { get; set; }
		//[JsonProperty("country-name")]
		//[JsonPropertyName("country-name")]
		//public string CountryName { get; set; }
		//public string Code { get; set; }
		//[JsonProperty("show-country")]
		//[JsonPropertyName("show-country")]
		//public bool ShowCountry { get; set; }
		//[JsonProperty("area-code")]
		//[JsonPropertyName("area-code")]
		//public string AreaCode { get; set; }
		//[JsonProperty("long-name")]
		//[JsonPropertyName("long-name")]
		//public string LongName { get; set; }
		//[JsonProperty("is-city-center")]
		//[JsonPropertyName("is-city-center")]
		//public bool IsCityCenter { get; set; }
	}

    public class GeoLocation
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int zoom { get; set; }
    }

}
