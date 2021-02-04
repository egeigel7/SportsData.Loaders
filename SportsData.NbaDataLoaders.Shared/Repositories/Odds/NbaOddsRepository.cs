using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Repositories.Odds
{
    public class NbaOddsRepository : INbaOddsRepository
    {
        private readonly HttpClient _client;
        private readonly string NbaOddsUrl = $"https://{Environment.GetEnvironmentVariable("OddsApiUri")}";
        private readonly string NbaOddsHostName = Environment.GetEnvironmentVariable("OddsApiUri");
        private readonly string NbaOddsKey = Environment.GetEnvironmentVariable("OddsApiKey");
        private readonly ILogger _logger;
        public NbaOddsRepository(IHttpClientFactory factory, ILogger log)
        {
            _client = factory.CreateClient();
            _logger = log;
        }
        public async Task<List<NbaSpreadsDto>> GetSpreads()
        {
            var nbaApiUrl = $"{NbaOddsUrl}/odds/?sport=basketball_nba&region=us&mkt=spreads&dateFormat=iso&oddsFormat=american&apiKey=92d37fb7f086103f7aef144b1ec9b017";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(nbaApiUrl),
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var spreadsResponse = JObject.Parse(body).ToObject<GetNbaSpreadsResponseDto>();
                List<NbaSpreadsDto> spreads = MapToNbaSpreads(spreadsResponse);
                return spreads;
            }
        }

        private List<NbaSpreadsDto> MapToNbaSpreads(GetNbaSpreadsResponseDto spreadsResponse)
        {
            List<NbaSpreadsDto> spreadsList = new List<NbaSpreadsDto>();
            foreach (var game in spreadsResponse.Data)
            {
                for(int i=0;i < game.Teams.Count;i++)
                {
                    var opponentsName = i == 0 ? game.Teams[1] : game.Teams[0];
                    NbaSpreadsDto teamSpread = new NbaSpreadsDto(game.CommenceTime, game.Teams[i], opponentsName,
                        new Spread(game.Sites[0].Odds.Spreads.Points[i], game.Sites[0].Odds.Spreads.Odds[i]));
                    spreadsList.Add(teamSpread);
                }
            }
            return spreadsList;
        }

        public async Task<List<NbaTotalsDto>> GetTotals()
        {
            var nbaApiUrl = $"{NbaOddsUrl}/odds/?sport=basketball_nba&region=us&mkt=totals&dateFormat=iso&oddsFormat=american&apiKey={NbaOddsKey}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(nbaApiUrl),
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var spreadsResponse = JObject.Parse(body).ToObject<GetNbaTotalsResponseDto>();
                List<NbaTotalsDto> totals = MapToNbaTotals(spreadsResponse);
                return totals;
            }
        }

        private List<NbaTotalsDto> MapToNbaTotals(GetNbaTotalsResponseDto totalsResponse)
        {
            List<NbaTotalsDto> totalsList = new List<NbaTotalsDto>();
            foreach (var game in totalsResponse.Data)
            {
                for(int i=0; i < game.Teams.Count; i++)
                {
                    var opponentsName = i == 0 ? game.Teams[1] : game.Teams[0];
                    NbaTotalsDto teamTotal = new NbaTotalsDto(game.CommenceTime, game.Teams[i], opponentsName,
                        new OverUnder(game.Sites[0].Odds.Totals.Points[0], game.Sites[0].Odds.Totals.Odds[0], game.Sites[0].Odds.Totals.Odds[1]));
                    totalsList.Add(teamTotal);
                }
            }
            return totalsList;
        }
    }
}
