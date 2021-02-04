using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos
{
    public class CompletedGameDbDto
    {
        public CompletedGameDbDto(string date, string teamId, string teamKey, string fullName, string nickname, string opponentId, string status, Statistics stats)
        {
            Date = DateTime.Parse(date);
            TeamId = teamId ?? throw new ArgumentNullException(nameof(teamId));
            TeamKey = teamKey ?? throw new ArgumentNullException(nameof(teamKey));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            Nickname = nickname ?? throw new ArgumentNullException(nameof(nickname));
            OpponentId = opponentId ?? throw new ArgumentNullException(nameof(opponentId));
            Status = status;
            Stats = stats ?? throw new ArgumentNullException(nameof(stats));
        }
        [JsonProperty("date")]
        public DateTime Date { get; }
        [JsonProperty("id")]
        public string Id { get { return Date.ToString("yyyyMMdd"); } }
        [JsonProperty("teamId")]
        public string TeamId { get; }
        [JsonProperty("teamKey")]
        public string TeamKey { get; }
        [JsonProperty("fullName")]
        public string FullName { get; }
        [JsonProperty("nickName")]
        public string Nickname { get; }
        [JsonProperty("opponentId")]
        public string OpponentId { get; }
        [JsonProperty("status")]
        public string Status { get; }
        [JsonProperty("stats")]
        public Statistics Stats { get; }
    }
}
