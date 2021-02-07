using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests
{
    public class ProcessGameOddsRequestDto
    {
        public ProcessGameOddsRequestDto(DateTime startTimeUTC, string teamName, string logoUrl, string opponentsTeamName, Spread spread, OverUnder overUnder)
        {
            StartTimeUTC = startTimeUTC;
            TeamName = teamName;
            LogoUrl = logoUrl;
            OpponentsTeamName = opponentsTeamName;
            Spread = spread;
            OverUnder = overUnder;
        }
        public DateTime StartTimeUTC { get;  }
        public string TeamName { get; }
        public string LogoUrl { get; set; }
        public string OpponentsTeamName { get; }
        public Spread Spread { get; }
        public OverUnder OverUnder { get; }
    }
}
