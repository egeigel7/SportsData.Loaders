using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Exceptions;
using SportsData.NbaDataLoaders.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders
{
    public class QueueTriggeredNbaTeamStatsLoader
    {
        INbaUpdateService _service;
        ILogger<QueueTriggeredNbaTeamStatsLoader> _logger;
        public QueueTriggeredNbaTeamStatsLoader(INbaUpdateService service, ILogger<QueueTriggeredNbaTeamStatsLoader> logger)
        {
            _service = service;
            _logger = logger;
        }
        [FunctionName(nameof(QueueTriggeredNbaTeamStatsLoader))]
        public void Run(
            [QueueTrigger("new-game", Connection = "AzureWebJobsStorage")] AddTeamPerformanceRequestDto data,
            [CosmosDB(
                databaseName: "BasketballDatabase",
                collectionName: "Games",
                ConnectionStringSetting = "CosmosDbConnection")]out CompletedGameDbDto document)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            try
            {
                document = _service.UpdateTeamStatsAsync(data).Result;
            }
            catch (AggregateException ex)
            {
                if (ex.Message.Contains("game was not in upcoming status when trying to process"))
                {
                    document = null;
                    return;
                }
                _logger.LogError($"An unhandled exception occured {ex.Message}");
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unhandled exception occured {ex.Message}");
                throw ex;
            }
            // document = _service.CreateCompletedGameFromPerformance(data);

            _logger.LogInformation($"Loader processed {data.FullName}'s game on {data.GameStartTime} .");

            // return new OkObjectResult(data);
        }
    }
}
