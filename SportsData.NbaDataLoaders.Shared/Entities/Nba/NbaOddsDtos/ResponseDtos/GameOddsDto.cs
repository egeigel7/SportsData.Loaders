using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos.ResponseDtos
{
    public class GameOddsDto
    {
        [JsonProperty("sport_key")]
        public string SportKey { get; set; }

        [JsonProperty("sport_nice")]
        public string SportNice { get; set; }

        [JsonProperty("teams")]
        public List<string> Teams { get; set; }

        [JsonProperty("home_team")]
        public string HomeTeam { get; set; }

        [JsonProperty("commence_time")]
        public DateTime CommenceTime { get; set; }

        [JsonProperty("sites")]
        public List<SiteDto> Sites { get; set; }

        [JsonProperty("sites_count")]
        public int SitesCount { get; set; }
    }
}
