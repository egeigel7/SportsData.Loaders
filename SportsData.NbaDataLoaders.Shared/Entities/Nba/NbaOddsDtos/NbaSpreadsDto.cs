using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos
{
    public class NbaSpreadsDto
    {
        public NbaSpreadsDto(DateTime startTimeUTC, string teamName, string opponentsName, Spread spread)
        {
            StartTimeUTC = startTimeUTC;
            TeamName = teamName;
            OpponentsName = opponentsName;
            Spread = spread;
        }

        public DateTime StartTimeUTC { get; set; }
        public string TeamName { get; set; }
        public string OpponentsName { get; set; }
        public Spread Spread { get; set; }
    }
}
