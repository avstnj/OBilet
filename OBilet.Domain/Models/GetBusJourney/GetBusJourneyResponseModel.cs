using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OBilet.Domain.Models.GetBusJourney
{
    public class GetBusJourneyResponseModel
    {
        public string status { get; set; }
        [JsonProperty("data")]
        [JsonPropertyName("data")]
        public List<BusJourneyResponseData> BusJourneyResponseData { get; set; }
        public string message { get; set; }

        [JsonProperty("user-message")]
        [JsonPropertyName("user-message")]
        public string usermessage { get; set; }

        [JsonProperty("api-request-id")]
        [JsonPropertyName("api-request-id")]
        public string apirequestid { get; set; }
        public string controller { get; set; }
    }
    public class BusJourneyResponseData
    {
        public int id { get; set; }

        [JsonProperty("partner-id")]
        [JsonPropertyName("partner-id")]
        public int partnerid { get; set; }

        [JsonProperty("partner-name")]
        [JsonPropertyName("partner-name")]
        public string partnername { get; set; }

        [JsonProperty("route-id")]
        [JsonPropertyName("route-id")]
        public int routeid { get; set; }

        [JsonProperty("bus-type")]
        [JsonPropertyName("bus-type")]
        public string bustype { get; set; }

        [JsonProperty("total-seats")]
        [JsonPropertyName("total-seats")]
        public int totalseats { get; set; }

        [JsonProperty("available-seats")]
        [JsonPropertyName("available-seats")]
        public int availableseats { get; set; }
        public Journey journey { get; set; }
        public List<Feature> features { get; set; }

        [JsonProperty("origin-location")]
        [JsonPropertyName("origin-location")]
        public string originlocation { get; set; }

        [JsonProperty("destination-location")]
        [JsonPropertyName("destination-location")]
        public string destinationlocation { get; set; }

        [JsonProperty("is-active")]
        [JsonPropertyName("is-active")]
        public bool isactive { get; set; }

        [JsonProperty("origin-location-id")]
        [JsonPropertyName("origin-location-id")]
        public int originlocationid { get; set; }

        [JsonProperty("destination-location-id")]
        [JsonPropertyName("destination-location-id")]
        public int destinationlocationid { get; set; }

        [JsonProperty("is-promoted")]
        [JsonPropertyName("is-promoted")]
        public bool ispromoted { get; set; }

        [JsonProperty("cancellation-offset")]
        [JsonPropertyName("cancellation-offset")]
        public int cancellationoffset { get; set; }

        [JsonProperty("has-bus-shuttle")]
        [JsonPropertyName("has-bus-shuttle")]
        public bool hasbusshuttle { get; set; }

        [JsonProperty("disable-sales-without-gov-id")]
        [JsonPropertyName("disable-sales-without-gov-id")]
        public bool disablesaleswithoutgovid { get; set; }

        [JsonProperty("display-offset")]
        [JsonPropertyName("display-offset")]
        public string displayoffset { get; set; }

        [JsonProperty("partner-rating")]
        [JsonPropertyName("partner-rating")]
        public double partnerrating { get; set; }
    }

    public class Feature
    {
        public int id { get; set; }
        public int priority { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        [JsonProperty("is-promoted")]
        [JsonPropertyName("is-promoted")]
        public bool ispromoted { get; set; }

        [JsonProperty("back-color")]
        [JsonPropertyName("back-color")]
        public string backcolor { get; set; }

        [JsonProperty("fore-color")]
        [JsonPropertyName("fore-color")]
        public string forecolor { get; set; }
    }

    public class Journey
    {
        public string kind { get; set; }
        public string code { get; set; }
        public List<Stop> stops { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
        public string currency { get; set; }
        public string duration { get; set; }

        [JsonProperty("original-price")]
        [JsonPropertyName("original-price")]
        public int originalprice { get; set; }

        [JsonProperty("internet-price")]
        [JsonPropertyName("internet-price")]
        public int internetprice { get; set; }
        public string booking { get; set; }

        [JsonProperty("bus-name")]
        [JsonPropertyName("bus-name")]
        public string busname { get; set; }
        public Policy policy { get; set; }
        public List<string> features { get; set; }
        public string description { get; set; }
        public string available { get; set; }
    }

    public class Policy
    {
        [JsonProperty("max-seats")]
        [JsonPropertyName("max-seats")]
        public string maxseats { get; set; }

        [JsonProperty("max-single")]
        [JsonPropertyName("max-single")]
        public string maxsingle { get; set; }

        [JsonProperty("max-single-males")]
        [JsonPropertyName("max-single-males")]
        public string maxsinglemales { get; set; }

        [JsonProperty("max-single-females")]
        [JsonPropertyName("max-single-females")]
        public string maxsinglefemales { get; set; }

        [JsonProperty("mixed-genders")]
        [JsonPropertyName("mixed-genders")]
        public bool mixedgenders { get; set; }

        [JsonProperty("gov-id")]
        [JsonPropertyName("gov-id")]
        public bool govid { get; set; }
        public bool lht { get; set; }
    }

    public class Stop
    {
        public string name { get; set; }
        public string station { get; set; }
        public DateTime time { get; set; }

        [JsonProperty("is-origin")]
        [JsonPropertyName("is-origin")]
        public bool isorigin { get; set; }

        [JsonProperty("is-destination")]
        [JsonPropertyName("is-destination")]
        public bool isdestination { get; set; }
    }
}
