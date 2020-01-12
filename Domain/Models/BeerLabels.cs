using Newtonsoft.Json;

namespace Domain.Models
{
    public class BeerLabels
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("contentAwareIcon")]
        public string ContentAwareIcon { get; set; }

        [JsonProperty("contentAwareMedium")]
        public string ContentAwareMedium { get; set; }

        [JsonProperty("contentAwareLarge")]
        public string ContentAwareLarge { get; set; }
    }
}
