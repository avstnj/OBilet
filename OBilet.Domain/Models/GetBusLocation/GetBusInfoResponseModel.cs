namespace OBilet.Domain.Models.GetBusLocation
{
    public class GetBusInfoResponseModel
    {
        public List<BusInfoResponseData> BusInfoResponseData { get; set; }
    }
    public class BusInfoResponseData
    {
        public int? id { get; set; }
        public string? name { get; set; }
    }
}
