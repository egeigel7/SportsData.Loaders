using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos.ResponseDtos
{
    public class OddsDto
    {
        [JsonProperty("spreads")]
        public SpreadsDto Spreads { get; set; }
    }
}
