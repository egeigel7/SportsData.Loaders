using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Services;

namespace SportsData.NbaDataLoaders
{
    public class TimedNbaOddsLoader
    {
        INbaOddsService _oddsService;
        public TimedNbaOddsLoader(INbaOddsService oddsService)
        {
            _oddsService = oddsService;
        }
        [FunctionName("TimedNbaOddsLoader")]
        public async void Run([TimerTrigger("0 0 11 * * *")]TimerInfo myTimer,
            [Queue("odds"), StorageAccount("AzureWebJobsStorage")] ICollector<ProcessGameOddsRequestDto> oddsToProcess,
            ILogger log)
        {
            var odds = await _oddsService.GetUpcomingOdds();
            odds.ForEach(odd => oddsToProcess.Add(odd));
        }
    }
}
