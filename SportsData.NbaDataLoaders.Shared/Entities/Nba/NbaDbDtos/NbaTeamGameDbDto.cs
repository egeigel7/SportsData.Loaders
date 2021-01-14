using Newtonsoft.Json;
using System;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos
{
    public class NbaTeamGameDbDto
    {
        public NbaTeamGameDbDto(string date, string teamId, string teamKey, string fullName, string nickname, Statistics stats)
        {
            Date = DateTime.Parse(date); 
            TeamId = teamId ?? throw new ArgumentNullException(nameof(teamId));
            TeamKey = teamKey ?? throw new ArgumentNullException(nameof(teamKey));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            Nickname = nickname ?? throw new ArgumentNullException(nameof(nickname));
            Stats = stats ?? throw new ArgumentNullException(nameof(stats));
        }
        public DateTime Date { get; }
        [JsonProperty("id")]
        public string Id { get { return Date.ToString("yyyyMMdd"); } }
        public string TeamId { get; }
        [JsonProperty("teamKey")]
        public string TeamKey { get; }
        public string FullName { get; }
        public string Nickname { get; }
        public Statistics Stats { get; }
        }
}
