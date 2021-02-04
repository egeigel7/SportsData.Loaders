using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos
{
    public class NbaTotalsDto
    {
        public NbaTotalsDto(DateTime startTimeUTC, string teamName, string opponentsName, OverUnder overUnder)
        {
            StartTimeUTC = startTimeUTC;
            TeamName = teamName;
            OpponentsName = opponentsName;
            OverUnder = overUnder;
        }

        public DateTime StartTimeUTC { get; set; }
        public string TeamName { get; set; }
        public string OpponentsName { get; set; }
        public OverUnder OverUnder { get; set; }
    }
}
