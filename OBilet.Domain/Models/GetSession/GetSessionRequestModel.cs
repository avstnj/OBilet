using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OBilet.Domain.Models.GetSession
{
    public class GetSessionRequestModel
    {
        public int type { get; set; }
        public Connection connection { get; set; }
        public Browser browser { get; set; }
    }
    public class Browser
    {
        public string name { get; set; }
        public string version { get; set; }
    }

    public class Connection
    {
        [JsonProperty("ip-address")]
        [JsonPropertyName("ip-address")]
        public string ipaddress { get; set; }
        public string port { get; set; }
    }

}
