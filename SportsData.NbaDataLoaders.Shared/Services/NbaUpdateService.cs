using Microsoft.Extensions.Logging;
using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Exceptions;
using SportsData.NbaDataLoaders.Shared.Repositories.Db;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Services
{
    public class NbaUpdateService: INbaUpdateService
    {
        private const string LEAGUE_NAME = "NBA";
        INbaDbRepository _repository;
        ILogger _logger;
        public NbaUpdateService(INbaDbRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public CompletedGameStatsOnlyDbDto CreateCompletedGameStatsOnlyFromPerformance(AddTeamPerformanceRequestDto dto)
        {
            // string convertedDate = DateTime.Parse(dto.GameStartTime).ToString("yyyyMMdd");
            var partitionKey = string.Join("-", LEAGUE_NAME, dto.FullName.Trim().ToUpperInvariant());
            var teamId = string.Join("-", dto.SeasonYear, dto.FullName.Trim().ToUpperInvariant());
            return new CompletedGameStatsOnlyDbDto(
                dto.GameStartTime,
                teamId,
                partitionKey,
                dto.FullName,
                dto.Nickname,
                dto.OpponentName,
                "COMPLETED",
                dto.Stats
            );
        }

        public CompletedGameDbDto CreateCompletedGameFromPerformance(AddTeamPerformanceRequestDto dto, UpcomingGameDbDto upcomingGameDto)
        {
            // string convertedDate = DateTime.Parse(dto.GameStartTime).ToString("yyyyMMdd");
            var partitionKey = string.Join("-", LEAGUE_NAME, dto.FullName.Trim().ToUpperInvariant());
            var teamId = string.Join("-", dto.SeasonYear, partitionKey);
            return new CompletedGameDbDto(
                dto.GameStartTime,
                teamId,
                partitionKey,
                dto.FullName,
                dto.Nickname,
                dto.OpponentName,
                "COMPLETED",
                upcomingGameDto.OverUnder,
                upcomingGameDto.Spread,
                dto.Stats
            );
        }

        public async Task<CompletedGameDbDto> UpdateTeamStatsAsync(AddTeamPerformanceRequestDto dto)
        {
            Records recordsToAdd = new Records();
            try
            {
                var game = await _repository.GetUpcomingGameAsync(dto);
                if (game.Status != "UPCOMING")
                    throw new IncorrectGameStatusException("The game was not in upcoming status when trying to process");
                var gameSpread = (dto.Stats.PointsFor - dto.Stats.PointsAgainst);
                var oddsSpread = 0 - double.Parse(game.Spread.Value);
                var gameTotal = (dto.Stats.PointsFor + dto.Stats.PointsAgainst);
                var oddsTotal = double.Parse(game.OverUnder.Total);
                //Process Spread
                if (gameSpread > oddsSpread)
                    recordsToAdd.ATSWins++;
                else if (gameSpread < oddsSpread)
                    recordsToAdd.ATSLosses++;
                else recordsToAdd.ATSPushes++;
                //Process Over Under
                if (gameTotal > oddsTotal)
                    recordsToAdd.OverCount++;
                else if (gameTotal < oddsTotal)
                    recordsToAdd.UnderCount++;
                else recordsToAdd.OverUnderPushes++;
                //Process Result
                if (dto.Stats.PointsFor > dto.Stats.PointsAgainst)
                    recordsToAdd.SeasonWins++;
                else recordsToAdd.SeasonLosses++;

                NbaTeamPerformanceDbDto dbDto = new NbaTeamPerformanceDbDto(
                dto.SeasonYear,
                dto.ShortName,
                dto.FullName,
                dto.Nickname,
                dto.LogoUrl,
                1,
                recordsToAdd,
                dto.Stats
                );
                await _repository.UpdateTeamStatsAsync(dbDto);
                return CreateCompletedGameFromPerformance(dto, game);
            }
            catch (GameDoesNotExistException ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
            catch (IncorrectGameStatusException ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<CompletedGameStatsOnlyDbDto> UpdatePastTeamStatsOnlyAsync(AddTeamPerformanceRequestDto dto)
        {
            if(await _repository.DoesGameWithStatsExist(dto))
                throw new GameAlreadyExistsException($"Game has already been uploaded for {dto.FullName} on {dto.GameStartTime}");
            try
            {
                NbaTeamPerformanceStatsOnlyDbDto dbDto = new NbaTeamPerformanceStatsOnlyDbDto(
                dto.SeasonYear,
                dto.ShortName,
                dto.FullName,
                dto.Nickname,
                dto.LogoUrl,
                1,
                dto.Stats
                );
                await _repository.UpdateTeamStatsOnlyAsync(dbDto);
                return CreateCompletedGameStatsOnlyFromPerformance(dto);
            }
            catch (GameDoesNotExistException ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
            catch (IncorrectGameStatusException ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
