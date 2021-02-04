using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba
{
    public class Records
    {
        public Records()
        {
            SeasonWins = 0;
            SeasonLosses = 0;
            ATSWins = 0;
            ATSLosses = 0;
            ATSPushes = 0;
            OverCount = 0;
            UnderCount = 0;
            OverUnderPushes = 0;
        }

        public Records(int seasonWins, int seasonLosses, int atsWins, int atsLosses, int overCount, int underCount)
        {
            SeasonWins = seasonWins;
            SeasonLosses = seasonLosses;
            ATSWins = atsWins;
            ATSLosses = atsLosses;
            OverCount = overCount;
            UnderCount = underCount;
        }
        [JsonProperty("seasonWins")]
        public int SeasonWins { get; set; }
        [JsonProperty("seasonLosses")]
        public int SeasonLosses { get; set; }
        [JsonProperty("atsWins")]
        public int ATSWins { get; set; }
        [JsonProperty("atsLosses")]
        public int ATSLosses { get; set; }
        [JsonProperty("atsPushes")]
        public int ATSPushes { get; set; }
        [JsonProperty("overCount")]
        public int OverCount { get; set; }
        [JsonProperty("underCount")]
        public int UnderCount { get; set; }
        [JsonProperty("overUnderPushes")]
        public int OverUnderPushes { get; set; }
    }
}
