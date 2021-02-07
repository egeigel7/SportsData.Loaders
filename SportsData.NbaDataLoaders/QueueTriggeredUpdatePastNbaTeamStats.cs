using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Services;

namespace SportsData.NbaDataLoaders
{
    public class QueueTriggeredUpdatePastNbaTeamStats
    {
        INbaUpdateService _service;
        ILogger<QueueTriggeredUpdatePastNbaTeamStats> _logger;
        public QueueTriggeredUpdatePastNbaTeamStats(INbaUpdateService service, ILogger<QueueTriggeredUpdatePastNbaTeamStats> logger)
        {
            _service = service;
            _logger = logger;
        }
        [FunctionName("QueueTriggeredUpdatePastNbaTeamStats")]
        public void Run([QueueTrigger("past-game-stats", Connection = "AzureWebJobsStorage")] AddTeamPerformanceRequestDto data,
            [CosmosDB(
                databaseName: "BasketballDatabase",
                collectionName: "Games",
                ConnectionStringSetting = "CosmosDbConnection")]out CompletedGameStatsOnlyDbDto document)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {data}");

            document = _service.UpdatePastTeamStatsOnlyAsync(data).Result;

            // document = _service.CreateCompletedGameFromPerformance(data);

            _logger.LogInformation($"Loader processed {data.FullName}'s game on {data.GameStartTime} .");
        }
    }
}
