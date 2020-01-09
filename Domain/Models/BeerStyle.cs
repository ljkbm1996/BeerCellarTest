namespace Domain.Models
{
    using Newtonsoft.Json;

    public class BeerStyle
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("category")]
        public BeerCategory Category { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
