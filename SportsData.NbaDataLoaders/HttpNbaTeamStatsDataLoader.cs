using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using SportsData.NbaDataLoaders.Shared.Services;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Exceptions;

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
                ConnectionStringSetting = "CosmosDbConnection")]out CompletedGameDbDto document,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
 
            document = _service.UpdateTeamStatsAsync(data).Result;

            // document = _service.CreateTeamGameFromPerformance(data);

            log.LogInformation($"Loader processed {data.FullName}'s game on {data.GameStartTime} .");

            return new OkObjectResult(data);
        }
    }
}
