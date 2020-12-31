using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba
{
    public class NbaTeamPerformanceDto
    {
        public NbaTeamPerformanceDto(string seasonYear, string shortName, string fullName, string nickname, string logoUrl, Statistics stats)
        {
            SeasonYear = seasonYear ?? throw new ArgumentNullException(nameof(seasonYear));
            ShortName = shortName ?? throw new ArgumentNullException(nameof(shortName));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            Nickname = nickname ?? throw new ArgumentNullException(nameof(nickname));
            LogoUrl = logoUrl ?? throw new ArgumentNullException(nameof(logoUrl));
            Stats = stats ?? throw new ArgumentNullException(nameof(stats));
        }

        public string SeasonYear { get; }
        public string ShortName { get; }
        public string FullName { get; }
        public string Nickname { get; }
        public string LogoUrl { get; }
        public Statistics Stats { get; }
    }
}
