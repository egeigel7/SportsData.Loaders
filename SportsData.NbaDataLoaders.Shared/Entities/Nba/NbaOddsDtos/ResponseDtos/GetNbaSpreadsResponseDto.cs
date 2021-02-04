using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos.ResponseDtos
{
    public class GetNbaSpreadsResponseDto
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public List<GameOddsDto> Data { get; set; }
    }
}
