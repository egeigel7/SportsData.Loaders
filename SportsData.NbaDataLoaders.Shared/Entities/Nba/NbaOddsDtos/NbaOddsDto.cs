using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos
{
    public class NbaOddsDto
    {
        public NbaOddsDto(DateTime startTimeUTC, string teamName, Spread spread, OverUnder overUnder)
        {
            StartTimeUTC = startTimeUTC;
            TeamName = teamName;
            Spread = spread;
            OverUnder = overUnder;
        }
        public DateTime StartTimeUTC { get; set; }
        public string TeamName { get; set; }
        public Spread Spread { get; set; }
        public OverUnder OverUnder { get; set; }
    }
}
