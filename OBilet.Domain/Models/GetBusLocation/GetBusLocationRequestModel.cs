using Newtonsoft.Json;

namespace OBilet.Domain.Models.GetBusLocation
{
    public class GetBusLocationRequestModel : BusTrackingBaseModel
    {
        public string? data { get; set; }
        public DateTime date { get; set; }
    }
}
