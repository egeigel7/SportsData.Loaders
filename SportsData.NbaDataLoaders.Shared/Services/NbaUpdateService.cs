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
        ILogger<NbaUpdateService> _logger;
        public NbaUpdateService(INbaDbRepository repository, ILogger<NbaUpdateService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public CompletedGameDbDto CreateCompletedGameFromPerformance(AddTeamPerformanceRequestDto dto)
        {
            // string convertedDate = DateTime.Parse(dto.GameStartTime).ToString("yyyyMMdd");
            var partitionKey = string.Join("-", LEAGUE_NAME, dto.FullName.Trim().ToUpperInvariant());
            var teamId = string.Join("-", dto.SeasonYear, dto.FullName.Trim().ToUpperInvariant());
            var logoUrl = string.IsNullOrWhiteSpace(dto.LogoUrl) ? "" : dto.LogoUrl;
            return new CompletedGameDbDto(
                dto.GameStartTime,
                teamId,
                partitionKey,
                dto.FullName,
                dto.Nickname,
                dto.OpponentName,
                logoUrl,
                "COMPLETED",
                dto.Stats
            );
        }

        public CompletedGameDbDto CreateCompletedGameFromPerformance(AddTeamPerformanceRequestDto dto, UpcomingGameDbDto upcomingGameDto)
        {
            // string convertedDate = DateTime.Parse(dto.GameStartTime).ToString("yyyyMMdd");
            var partitionKey = string.Join("-", LEAGUE_NAME, dto.FullName.Trim().ToUpperInvariant());
            var teamId = string.Join("-", dto.SeasonYear, partitionKey);
            var logoUrl = string.IsNullOrWhiteSpace(dto.LogoUrl) ? upcomingGameDto.LogoUrl : dto.LogoUrl;
            return new CompletedGameDbDto(
                dto.GameStartTime,
                teamId,
                partitionKey,
                dto.FullName,
                dto.Nickname,
                dto.OpponentName,
                logoUrl,
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
                    throw new IncorrectGameStatusException($"The {game.FullName} game was not in upcoming status when trying to process on {game.Date}");
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

        public async Task<CompletedGameDbDto> UpdatePastTeamsStatsAsync(LoadPastGameRequestDto dto)
        {
            if (!dto.StatsOnly)
            {
                return await UpdateTeamStatsAsync(dto.Game);
            }
            
            if(await _repository.DoesGameWithStatsExist(dto.Game))
                throw new GameAlreadyExistsException($"Game has already been uploaded for {dto.Game.FullName} on {dto.Game.GameStartTime}");
            try
            {
                NbaTeamPerformanceStatsOnlyDbDto dbDto = new NbaTeamPerformanceStatsOnlyDbDto(
                dto.Game.SeasonYear,
                dto.Game.ShortName,
                dto.Game.FullName,
                dto.Game.Nickname,
                dto.Game.LogoUrl,
                1,
                dto.Game.Stats
                );
                await _repository.UpdateTeamStatsOnlyAsync(dbDto);
                return CreateCompletedGameFromPerformance(dto.Game);
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
