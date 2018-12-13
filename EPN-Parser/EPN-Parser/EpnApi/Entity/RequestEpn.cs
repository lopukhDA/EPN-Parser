namespace EPN_Parser.EpnApi.Entity
{
    using System.Configuration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RequestEpn
    {
        [JsonProperty("user_api_key")]
        public string UserApiKey { get; set; } = ConfigurationManager.AppSettings.Get("user_api_key");

        [JsonProperty("user_hash")]
        public string UserHash { get; set; } = ConfigurationManager.AppSettings.Get("user_hash");

        [JsonProperty("api_version")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ApiVersion { get; set; } = 2;

        [JsonProperty("requests")]
        public Requests Requests { get; set; }


        public static RequestEpn FromJson(string json) => JsonConvert.DeserializeObject<RequestEpn>(json, Converter.Settings);
    }

    public partial class Requests
    {
        [JsonProperty("request")]
        public Request Request { get; set; }
    }

    public partial class Request
    {
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionRequest ActionRequest { get; set; }

        [JsonProperty("lang")]
        public Lang Lang { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }
}