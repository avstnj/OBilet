namespace OBilet.Domain.Models.Configuration
{
    public class OBiletServiceModel
    {
        public string? OBiletApiBaseUrl { get; set; }
        public string? GetSessionEndPoint { get; set; }
        public string? GetBusLocationsEndPoint { get; set; }
        public string? GetBusJourneysEndPoint { get; set; }
        public string? Token { get; set; }
    }
}
