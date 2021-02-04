using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos
{
    [DataContract]
    public class Spread
    {
        public Spread(string value, int odds)
        {
            Value = value;
            Odds = odds;
        }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("odds")]
        public int Odds { get; set; }
    }
}
