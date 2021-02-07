using Newtonsoft.Json;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos
{
    public class UpcomingGameDbDto
    {
        public UpcomingGameDbDto(DateTime date, string teamKey, string fullName, string logoUrl, string opponentId, string status, OverUnder overUnder, Spread spread)
        {
            Date = date;
            TeamKey = teamKey ?? throw new ArgumentNullException(nameof(teamKey));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            OpponentId = opponentId ?? throw new ArgumentNullException(nameof(opponentId));
            LogoUrl = logoUrl; // ?? throw new ArgumentNullException(nameof(logoUrl));
            Status = status ?? throw new ArgumentNullException(nameof(status));
            OverUnder = overUnder ?? throw new ArgumentNullException(nameof(overUnder));
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
        [JsonProperty("logoUrl")]
        public string LogoUrl { get; }
        [JsonProperty("opponentId")]
        public string OpponentId { get; }
        [JsonProperty("status")]
        public string Status { get; }
        [JsonProperty("overUnder")]
        public OverUnder OverUnder { get; }
        [JsonProperty("spread")]
        public Spread Spread { get; }
    }
}
