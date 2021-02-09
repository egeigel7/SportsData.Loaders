using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests
{
    public class LoadPastGameRequestDto
    {
        public LoadPastGameRequestDto(bool statsOnly, AddTeamPerformanceRequestDto game)
        {
            StatsOnly = statsOnly;
            Game = game;
        }
        public bool StatsOnly { get; }
        public AddTeamPerformanceRequestDto Game { get; }
    }
}
