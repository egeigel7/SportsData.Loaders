using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaApiDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.Infrastructure.Repositories.Nba
{
    public class NbaApiRepository : INbaApiRepository
    {
        private readonly HttpClient _client;

        public NbaApiRepository(IHttpClientFactory factory)
        {
            _client = factory.CreateClient();
        }

        public async Task AddTeamPerformanceAsync(AddTeamPerformanceRequestDto teamPerformanceStats)
        {
            var updateTeamDataUrl = $"http://localhost:7071/api/HttpNbaTeamStatsDataLoader";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(updateTeamDataUrl),
                //Headers =
                //{
                //    { "x-rapidapi-key", "ea61dbc290msh26d23555f5b2f27p15cf70jsn8fce5f15677a" },
                //    { "x-rapidapi-host", "api-nba-v1.p.rapidapi.com" },
                //},
                Content = new StringContent(JsonConvert.SerializeObject(teamPerformanceStats), Encoding.UTF8, "application/json")
        };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task<GetGamesByDateResponseDto> GetGamesByDateAsync(DateTime date)
        {
            var formattedDate = date.ToString("yyyy-MM-dd");
            var nbaApiUrl = $"https://api-nba-v1.p.rapidapi.com/games/date/{formattedDate}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(nbaApiUrl),
                Headers =
                {
                    { "x-rapidapi-key", "ea61dbc290msh26d23555f5b2f27p15cf70jsn8fce5f15677a" },
                    { "x-rapidapi-host", "api-nba-v1.p.rapidapi.com" },
                },
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var games = JObject.Parse(body).SelectToken("api").ToObject<GetGamesByDateResponseDto>();
                return games;
            }
        }

        public async Task<GetStatsByGameIdResponseDto> GetStatsByGameIdAsync(string gameId)
        {
            var nbaApiUrl = $"https://api-nba-v1.p.rapidapi.com/statistics/games/gameId/{gameId}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(nbaApiUrl),
                Headers =
                {
                    { "x-rapidapi-key", "ea61dbc290msh26d23555f5b2f27p15cf70jsn8fce5f15677a" },
                    { "x-rapidapi-host", "api-nba-v1.p.rapidapi.com" },
                },
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var stats = JObject.Parse(body).SelectToken("api").ToObject<GetStatsByGameIdResponseDto>();
                return stats;
            }
        }
    }
}
