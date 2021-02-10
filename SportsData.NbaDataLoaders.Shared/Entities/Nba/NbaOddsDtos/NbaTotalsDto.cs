using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos
{
    public class NbaTotalsDto
    {
        public NbaTotalsDto(DateTime startTimeUTC, bool isHome, string teamName, string opponentsName, OverUnder overUnder)
        {
            StartTimeUTC = startTimeUTC;
            IsHome = isHome;
            TeamName = teamName;
            OpponentsName = opponentsName;
            OverUnder = overUnder;
        }

        public DateTime StartTimeUTC { get; set; }
        public bool IsHome { get; set; }
        public string TeamName { get; set; }
        public string OpponentsName { get; set; }
        public OverUnder OverUnder { get; set; }
    }
}
