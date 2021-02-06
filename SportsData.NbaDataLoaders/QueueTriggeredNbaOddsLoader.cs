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
        ILogger<QueueTriggeredNbaOddsLoader> _logger;
        public QueueTriggeredNbaOddsLoader(IOddsRequestToDbDtoMapper mapper, ILogger<QueueTriggeredNbaOddsLoader> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
        [FunctionName("QueueTriggeredNbaOddsLoader")]
        public void Run([QueueTrigger("odds", Connection = "AzureWebJobsStorage")] ProcessGameOddsRequestDto data,
            [CosmosDB(
                databaseName: "BasketballDatabase",
                collectionName: "Games",
                ConnectionStringSetting = "CosmosDbConnection")]out UpcomingGameDbDto document)
        {
            document = _mapper.Map(data);
            _logger.LogInformation($"QueueTriggeredNbaOddsLoader mapped data and it is uploading odds for: {data.TeamName} on {data.StartTimeUTC}");
        }
    }
}
