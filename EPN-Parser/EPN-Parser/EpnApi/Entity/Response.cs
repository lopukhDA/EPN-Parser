namespace EPN_Parser.EpnApi.Entity
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class Response
    {
        [JsonProperty("results")]
        public Results Results { get; set; }

        [JsonProperty("identified_as")]
        public string IdentifiedAs { get; set; }

        public static Response FromJson(string json) => JsonConvert.DeserializeObject<Response>(json, Converter.Settings);
    }

    public partial class Results
    {
        [JsonProperty("request")]
        public Request Request { get; set; }
    }

    public partial class Request
    {
        [JsonProperty("offers")]
        public List<Offer> Offers { get; set; }

        [JsonProperty("offer")]
        public Offer Offer { get; set; }
    }
}
