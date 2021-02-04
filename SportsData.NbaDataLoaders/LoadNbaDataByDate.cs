using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Services;

namespace SportsData.NbaDataLoaders
{
    public class LoadNbaDataByDate
    {
        INbaApiService _service;

        public LoadNbaDataByDate(INbaApiService service)
        {
            _service = service;
        }

        [FunctionName(nameof(LoadNbaDataByDate))]
        public async void Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] LoadGamesByDateRequestDto dateString
            , [Queue("past-game-stats"), StorageAccount("AzureWebJobsStorage")] ICollector<AddTeamPerformanceRequestDto> newGames
            , ILogger log)
        {
            DateTime date = DateTime.Parse(dateString.Date);
            // Call Nba Api games endpoint to get last night's games
            var playedGames = await _service.GetGamesWithStatsByDateAsync(date);

            if (playedGames.Count > 0)
            {
                log.LogInformation("Games found, loading now");
            }
            else
            {
                log.LogInformation("No games found");
            }

            playedGames.ForEach(game => newGames.Add(game));

            // Call POST game data endpoint on API
            // var tasks = playedGames.Select(g => _service.AddTeamPerformanceDataAsync(g));

            // await Task.WhenAll(tasks);

        }
    }
}
