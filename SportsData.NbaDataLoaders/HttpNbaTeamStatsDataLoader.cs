using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Services;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;

namespace SportsData.NbaDataLoaders
{
    public class HttpNbaTeamStatsDataLoader
    {
        INbaUpdateService _service;
        public HttpNbaTeamStatsDataLoader(INbaUpdateService service)
        {
            _service = service;
        }
        [FunctionName(nameof(HttpNbaTeamStatsDataLoader))]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] AddTeamPerformanceRequestDto data,
            [CosmosDB(
                databaseName: "BasketballDatabase",
                collectionName: "Games",
                ConnectionStringSetting = "CosmosDBConnection")]out NbaTeamGameDbDto document,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            _service.UpdateTeamStatsAsync(data).Wait();

            document = _service.CreateTeamGameFromPerformance(data);

            log.LogInformation($"Loader processed {data.FullName}'s game on {data.GameStartTime} .");

            return new OkObjectResult(data);
        }
    }
}
