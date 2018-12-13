namespace EPN_Parser.EpnApi.Entity
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class TopProductsResponse
    {
        [JsonProperty("results")]
        public Results Results { get; set; }

        [JsonProperty("identified_as")]
        public string IdentifiedAs { get; set; }

        public static TopProductsResponse FromJson(string json) => JsonConvert.DeserializeObject<TopProductsResponse>(json, Converter.Settings);
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
    }
}
