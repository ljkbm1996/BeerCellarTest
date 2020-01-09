namespace Domain.Models
{
    using System;
    using Newtonsoft.Json;

    public class BeerData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameDisplay")]
        public string NameDisplay { get; set; }

        [JsonProperty("abv")]
        public string Abv { get; set; }

        [JsonProperty("style")]
        public BeerStyle Style { get; set; }

        [JsonProperty("labels")]
        public BeerLabels Labels { get; set; }

        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("updateDate")]
        public DateTime UpdateDate { get; set; }

        [JsonProperty("isOrganic")]
        public char IsOrganic { get; set; }

        [JsonProperty("isRetired")]
        public char IsRetired { get; set; }
    }
}
