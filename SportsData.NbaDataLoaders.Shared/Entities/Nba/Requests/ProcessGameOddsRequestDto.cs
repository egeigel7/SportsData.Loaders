using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests
{
    public class ProcessGameOddsRequestDto
    {
        public ProcessGameOddsRequestDto(DateTime startTimeUTC, string teamName, string opponentsTeamName, Spread spread, OverUnder overUnder)
        {
            StartTimeUTC = startTimeUTC;
            TeamName = teamName;
            OpponentsTeamName = opponentsTeamName;
            Spread = spread;
            OverUnder = overUnder;
        }
        public DateTime StartTimeUTC { get;  }
        public string TeamName { get; }
        public string OpponentsTeamName { get; }
        public Spread Spread { get; }
        public OverUnder OverUnder { get; }
    }
}
