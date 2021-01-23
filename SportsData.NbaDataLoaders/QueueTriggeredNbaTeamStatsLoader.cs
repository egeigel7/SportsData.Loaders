using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders
{
    public class QueueTriggeredNbaTeamStatsLoader
    {
        INbaUpdateService _service;
        public QueueTriggeredNbaTeamStatsLoader(INbaUpdateService service)
        {
            _service = service;
        }
        [FunctionName(nameof(QueueTriggeredNbaTeamStatsLoader))]
        public void Run(
            [QueueTrigger("new-game", Connection = "AzureWebJobsStorage")] AddTeamPerformanceRequestDto data,
            [CosmosDB(
                databaseName: "BasketballDatabase",
                collectionName: "Games",
                ConnectionStringSetting = "CosmosDbConnection")]out NbaTeamGameDbDto document,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            _service.UpdateTeamStatsAsync(data).Wait();

            document = _service.CreateTeamGameFromPerformance(data);

            log.LogInformation($"Loader processed {data.FullName}'s game on {data.GameStartTime} .");

            // return new OkObjectResult(data);
        }
    }
}
