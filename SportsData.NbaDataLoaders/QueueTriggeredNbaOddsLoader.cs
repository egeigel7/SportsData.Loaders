using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Mappers.Nba;
using SportsData.NbaDataLoaders.Shared.Services;

namespace SportsData.NbaDataLoaders
{
    public class QueueTriggeredNbaOddsLoader
    {
        IOddsRequestToDbDtoMapper _mapper;
        public QueueTriggeredNbaOddsLoader(IOddsRequestToDbDtoMapper mapper)
        {
            _mapper = mapper;
        }
        [FunctionName("QueueTriggeredNbaOddsLoader")]
        public void Run([QueueTrigger("odds", Connection = "AzureWebJobsStorage")] ProcessGameOddsRequestDto data,
            [CosmosDB(
                databaseName: "BasketballDatabase",
                collectionName: "Games",
                ConnectionStringSetting = "CosmosDbConnection")]out UpcomingGameDbDto document,
            ILogger log)
        {
            document = _mapper.Map(data);
            log.LogInformation($"C# Queue trigger function processed: {data}");
        }
    }
}
