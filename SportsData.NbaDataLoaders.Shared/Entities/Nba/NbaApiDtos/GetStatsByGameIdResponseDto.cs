using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaApiDtos
{
    public class GetStatsByGameIdResponseDto
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public int Results { get; set; }
        public List<string> Filters { get; set; }
        public List<GameStatisticsDto> Statistics { get; set; }
    }
}
