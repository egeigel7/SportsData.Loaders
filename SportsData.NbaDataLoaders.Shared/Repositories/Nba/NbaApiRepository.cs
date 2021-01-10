using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
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
        private readonly string NbaApiUrl = $"https://{Environment.GetEnvironmentVariable("NbaApiUri")}";
        private readonly string NbaApiHostName = Environment.GetEnvironmentVariable("NbaApiUri");
        private readonly string NbaApiKey = Environment.GetEnvironmentVariable("NbaApiKey");
        private readonly ILogger _logger;
        public NbaApiRepository(IHttpClientFactory factory, ILogger log)
        {
            _client = factory.CreateClient();
            _logger = log;
        }

        public async Task AddTeamPerformanceAsync(AddTeamPerformanceRequestDto teamPerformanceStats)
        {
            var updateTeamDataUrl = Environment.GetEnvironmentVariable("UpdateTeamDataUri");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(updateTeamDataUrl),
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
                    { "x-rapidapi-key", NbaApiKey },
                    { "x-rapidapi-host", NbaApiHostName },
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
            var nbaApiUrl = $"{NbaApiUrl}/statistics/games/gameId/{gameId}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(nbaApiUrl),
                Headers =
                {
                    { "x-rapidapi-key",  NbaApiKey },
                    { "x-rapidapi-host", NbaApiHostName },
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
