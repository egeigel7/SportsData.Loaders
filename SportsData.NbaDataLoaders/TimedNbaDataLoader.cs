using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Services;

namespace SportsData.NbaDataLoaders
{
    public class TimedNbaDataLoader
    {
        INbaApiService _service;
        ILogger<TimedNbaDataLoader> _logger;

        public TimedNbaDataLoader(INbaApiService service, ILogger<TimedNbaDataLoader> logger)
        {
            _service = service;
            _logger = logger;
        }

        [FunctionName(nameof(TimedNbaDataLoader))]
        [StorageAccount("AzureWebJobsStorage")]
        public async Task Run([TimerTrigger("0 0 9 * * *")]TimerInfo myTimer
            , [Queue("new-game"), StorageAccount("AzureWebJobsStorage")] ICollector<AddTeamPerformanceRequestDto> newGames)
        {
            var date = DateTime.UtcNow;
            // Call Nba Api games endpoint to get last night's games
            var playedGames = await _service.GetGamesWithStatsByDateAsync(date);

            if (playedGames.Count > 0)
            {
                _logger.LogInformation("Games found, loading now");
            }
            else
            {
                _logger.LogInformation("No games found");
            }

            playedGames.ForEach(game => newGames.Add(game));
        }
    }
}
