using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaApiDtos
{
    public class NbaApiContestantScoreDto
    {
        public NbaApiContestantScoreDto(string points)
        {
            Points = points;
        }

        public string Points { get; }
    }
}
