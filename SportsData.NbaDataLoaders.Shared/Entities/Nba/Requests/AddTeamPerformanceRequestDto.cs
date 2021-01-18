using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests
{
    public class AddTeamPerformanceRequestDto
    {
        public AddTeamPerformanceRequestDto(string gameStartTime, string seasonYear, string shortName, string fullName, string nickname, string logoUrl, string opponentName, Statistics stats)
        {
            GameStartTime = gameStartTime ?? throw new ArgumentNullException(nameof(gameStartTime));
            SeasonYear = seasonYear ?? throw new ArgumentNullException(nameof(seasonYear));
            ShortName = shortName ?? throw new ArgumentNullException(nameof(shortName));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            Nickname = nickname ?? throw new ArgumentNullException(nameof(nickname));
            LogoUrl = logoUrl ?? throw new ArgumentNullException(nameof(logoUrl));
            OpponentName = opponentName ?? throw new ArgumentNullException(nameof(opponentName));
            Stats = stats ?? throw new ArgumentNullException(nameof(stats));
        }

        public string GameStartTime { get; }
        public string SeasonYear { get;}
        public string ShortName { get; }
        public string FullName { get; }
        public string Nickname { get; }
        public string LogoUrl { get; }
        public string OpponentName { get; }
        public Statistics Stats { get; }
    }
}
