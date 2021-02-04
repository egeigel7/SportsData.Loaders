using Newtonsoft.Json;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos
{
    public class NbaGameOddsDbDto
    {
        public NbaGameOddsDbDto(DateTime date, string teamKey, string fullName, string opponentId, string gameStatus, OverUnder overUnder, Spread spread)
        {
            Date = date;
            TeamKey = teamKey ?? throw new ArgumentNullException(nameof(teamKey));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            OpponentId = opponentId ?? throw new ArgumentNullException(nameof(opponentId));
            OverUnder = overUnder ?? throw new ArgumentNullException(nameof(overUnder));
            GameStatus = gameStatus ?? throw new ArgumentNullException(nameof(gameStatus));
            Spread = spread ?? throw new ArgumentNullException(nameof(spread));
        }
        [JsonProperty("date")]
        public DateTime Date { get; }
        [JsonProperty("id")]
        public string Id { get { return Date.ToString("yyyyMMdd"); } }
        [JsonProperty("teamKey")]
        public string TeamKey { get; }
        [JsonProperty("fullName")]
        public string FullName { get; }
        [JsonProperty("opponentId")]
        public string OpponentId { get; }
        [JsonProperty("status")]
        public string GameStatus { get; }
        [JsonProperty("overUnder")]
        public OverUnder OverUnder { get; }
        [JsonProperty("spread")]
        public Spread Spread { get; }
    }
}
