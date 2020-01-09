using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Models
{
    public class Beer
    {
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("numberOfPages")]
        public int NumberOfPages { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("data")]
        public ICollection<BeerData> BeerData { get; set; }
    }
}
