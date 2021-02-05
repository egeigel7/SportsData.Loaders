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
        public QueueTriggeredUpdatePastNbaTeamStats(INbaUpdateService service)
        {
            _service = service;
        }
        [FunctionName("QueueTriggeredUpdatePastNbaTeamStats")]
        public void Run([QueueTrigger("past-game-stats", Connection = "")] AddTeamPerformanceRequestDto data,
            [CosmosDB(
                databaseName: "BasketballDatabase",
                collectionName: "Games",
                ConnectionStringSetting = "CosmosDbConnection")]out CompletedGameStatsOnlyDbDto document,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {data}");

            document = _service.UpdatePastTeamStatsOnlyAsync(data).Result;

            // document = _service.CreateCompletedGameFromPerformance(data);

            log.LogInformation($"Loader processed {data.FullName}'s game on {data.GameStartTime} .");
        }
    }
}
