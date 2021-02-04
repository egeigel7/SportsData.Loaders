using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos.ResponseDtos
{
    public class SpreadsDto
    {
        [JsonProperty("odds")]
        public List<int> Odds { get; set; }

        [JsonProperty("points")]
        public List<string> Points { get; set; }
    }
}
