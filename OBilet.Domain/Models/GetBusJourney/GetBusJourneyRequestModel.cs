using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OBilet.Domain.Models.GetBusJourney
{
    public class GetBusJourneyRequestModel : BusTrackingBaseModel
    {
        public DateTime date { get; set; }
        [JsonProperty("data")]
        [JsonPropertyName("data")]
        public BusJourneyData BusJourneyData { get; set; }
    }
    public class BusJourneyData
    {
        [JsonProperty("origin-id")]
        [JsonPropertyName("origin-id")]
        public int originid { get; set; }

        [JsonProperty("destination-id")]
        [JsonPropertyName("destination-id")]
        public int destinationid { get; set; }

        [JsonProperty("departure-date")]
        [JsonPropertyName("departure-date")]
        public DateTime departuredate { get; set; }
    }
}
