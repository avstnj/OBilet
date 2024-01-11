using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OBilet.Domain.Models
{
    public class BusTrackingBaseModel
    {
        [JsonProperty("device-session")]
        [JsonPropertyName("device-session")]
        public DeviceSession devicesession { get; set; }
        public string language { get; set; }
    }
    public class DeviceSession
    {
        [JsonProperty("session-id")]
        [JsonPropertyName("session-id")]
        public string sessionid { get; set; }

        [JsonProperty("device-id")]
        [JsonPropertyName("device-id")]
        public string deviceid { get; set; }
    }
}
