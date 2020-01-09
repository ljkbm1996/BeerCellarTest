namespace Domain.Models
{
    using Newtonsoft.Json;

    public class BeerCategory
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
