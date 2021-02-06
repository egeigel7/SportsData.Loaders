using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Services;

namespace SportsData.NbaDataLoaders
{
    public class TimedNbaOddsLoader
    {
        INbaOddsService _oddsService;
        ILogger<TimedNbaOddsLoader> _logger;
        public TimedNbaOddsLoader(INbaOddsService oddsService, ILogger<TimedNbaOddsLoader> logger)
        {
            _oddsService = oddsService;
            _logger = logger;
        }
        [FunctionName(nameof(TimedNbaOddsLoader))]
        public async Task Run([TimerTrigger("0 0 11 * * *")]TimerInfo myTimer,
            [Queue("odds"), StorageAccount("AzureWebJobsStorage")] ICollector<ProcessGameOddsRequestDto> oddsToProcess)
        {
            try
            {
                var odds = await _oddsService.GetUpcomingOdds();
                if (odds.Count > 0)
                {
                    _logger.LogInformation("Odds found, loading now");
                    odds.ForEach(odd => oddsToProcess.Add(odd));
                }
                else
                {
                    _logger.LogInformation("No odds found");
                    return;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unhandled exception occured while getting odds: {ex.Message}");
            }
        }
    }
}
