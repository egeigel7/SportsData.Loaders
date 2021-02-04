using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos
{
    [DataContract]
    public class OverUnder
    {
        public OverUnder(string total, int overOdds, int underOdds)
        {
            Total = total;
            OverOdds = overOdds;
            UnderOdds = underOdds;
        }
        [JsonProperty("total")]
        public string Total { get; set; }
        [JsonProperty("overOdds")]
        public int OverOdds { get; set; }
        [JsonProperty("underOdds")]
        public int UnderOdds { get; set; }

    }
}
