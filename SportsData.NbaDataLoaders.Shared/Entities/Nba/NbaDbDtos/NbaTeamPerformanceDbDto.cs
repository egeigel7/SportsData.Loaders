using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos
{
    public class NbaTeamPerformanceDbDto
    {
        private const string LEAGUE_NAME = "NBA";
        public NbaTeamPerformanceDbDto(string seasonYear, string shortName, string fullName, string nickname, string logoUrl, int gamesPlayed,Statistics stats)
        {
            SeasonYear = seasonYear ?? throw new ArgumentNullException(nameof(seasonYear));
            ShortName = shortName ?? throw new ArgumentNullException(nameof(shortName));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            Nickname = nickname ?? throw new ArgumentNullException(nameof(nickname));
            LogoUrl = logoUrl ?? throw new ArgumentNullException(nameof(logoUrl));
            GamesPlayed = gamesPlayed;
            Stats = stats ?? throw new ArgumentNullException(nameof(stats));
        }
        [JsonProperty("id")]
        public string Id { get { return String.Join("-", SeasonYear.Trim(), TeamKey); } }
        [JsonProperty("teamKey")]
        public string TeamKey { get { return String.Join("-", LEAGUE_NAME, FullName.Trim().ToUpperInvariant()); }  }
        public string SeasonYear { get; }
        public string ShortName { get; }
        public string FullName { get; }
        public string Nickname { get; }
        public string LogoUrl { get; }
        public int GamesPlayed { get; set; }
        public Statistics Stats { get; }
    }
}
