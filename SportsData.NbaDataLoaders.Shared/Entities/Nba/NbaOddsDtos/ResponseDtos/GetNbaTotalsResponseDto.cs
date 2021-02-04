using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos.ResponseDtos
{
    public class GetNbaTotalsResponseDto
    {

            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("data")]
            public List<GameTotalsDto> Data { get; set; }
    }

    public class Totals
    {
        [JsonProperty("points")]
        public List<string> Points { get; set; }

        [JsonProperty("odds")]
        public List<int> Odds { get; set; }

        [JsonProperty("position")]
        public List<string> Position { get; set; }
    }

    public class Odds
    {
        [JsonProperty("totals")]
        public Totals Totals { get; set; }
    }

    public class Site
    {
        [JsonProperty("site_key")]
        public string SiteKey { get; set; }

        [JsonProperty("site_nice")]
        public string SiteNice { get; set; }

        [JsonProperty("last_update")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("odds")]
        public Odds Odds { get; set; }
    }

    public class GameTotalsDto
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
        public List<Site> Sites { get; set; }

        [JsonProperty("sites_count")]
        public int SitesCount { get; set; }
    }
}
