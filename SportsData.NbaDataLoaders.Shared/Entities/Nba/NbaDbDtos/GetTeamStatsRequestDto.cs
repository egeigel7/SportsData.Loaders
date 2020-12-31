using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos
{
    public class GetTeamStatsRequestDto
    {
        public string League { get; set; }
        public string TeamName { get; set; }
        public int SeasonYear { get; set; }
    }
}
