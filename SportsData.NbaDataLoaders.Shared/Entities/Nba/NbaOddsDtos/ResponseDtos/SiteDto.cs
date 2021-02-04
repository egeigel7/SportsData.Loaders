using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos.ResponseDtos
{
    public class SiteDto
    {
        [JsonProperty("site_key")]
        public string SiteKey { get; set; }

        [JsonProperty("site_nice")]
        public string SiteNice { get; set; }

        [JsonProperty("last_update")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("odds")]
        public OddsDto Odds { get; set; }
    }
}
