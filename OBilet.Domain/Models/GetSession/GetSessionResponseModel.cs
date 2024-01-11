using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OBilet.Domain.Models.GetSession
{
    public class GetSessionResponseModel
    {
        public string status { get; set; }
        public SessionResponseData data { get; set; }
        public string message { get; set; }

        [JsonProperty("user-message")]
        [JsonPropertyName("user-message")]
        public string usermessage { get; set; }

        [JsonProperty("api-request-id")]
        [JsonPropertyName("api-request-id")]
        public string apirequestid { get; set; }
        public string controller { get; set; }
    }
    public class SessionResponseData
    {
        [JsonProperty("session-id")]
        [JsonPropertyName("session-id")]
        public string sessionid { get; set; }

        [JsonProperty("device-id")]
        [JsonPropertyName("device-id")]
        public string deviceid { get; set; }
    }
}
