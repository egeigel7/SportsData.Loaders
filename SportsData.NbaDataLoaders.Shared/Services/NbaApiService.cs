using SportsData.Infrastructure.Repositories.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaApiDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Mappers.Nba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Services
{
    public class NbaApiService : INbaApiService
    {
        private readonly INbaApiRepository _repository;
        private readonly IGetGamesByDateResponseMapper _mapper;
        private readonly IAddTeamGameFromPerformanceMapper _addGameMapper;
        public NbaApiService(INbaApiRepository repository, IGetGamesByDateResponseMapper mapper, IAddTeamGameFromPerformanceMapper addGameMapper)
        {
            _repository = repository;
            _mapper = mapper;
            _addGameMapper = addGameMapper;
        }

        public async Task<List<Game>> GetGamesByDateAsync(DateTime date)
        {
            var response = await _repository.GetGamesByDateAsync(date);
            var mappedGames = _mapper.Convert(response);
            return mappedGames;

        }

        public async Task<List<AddTeamPerformanceRequestDto>> GetGamesWithStatsByDateAsync(DateTime date)
        {
            var playedGames = await _repository.GetGamesByDateAsync(date);
            var mappedGames = new List<AddTeamPerformanceRequestDto>();
            foreach (var game in playedGames.Games)
            {
                var gameStats = await _repository.GetStatsByGameIdAsync(game.GameId);
                // Enhanced home team stats
                var enhancedHomeStats = gameStats.Statistics.Where(s => s.TeamId == game.HTeam.TeamId).First();
                AddTeamPerformanceRequestDto homeEnhancedStats = EnhanceStats(game.StartTimeUTC, game.HTeam, enhancedHomeStats, Convert.ToInt32(game.VTeam.Score.Points), game.SeasonYear);
                mappedGames.Add(homeEnhancedStats);
                // Enhanced visiting team stats
                var enhancedVisitingTeamStats = gameStats.Statistics.Where(s => s.TeamId == game.VTeam.TeamId).First();
                AddTeamPerformanceRequestDto visitingEnhancedStats = EnhanceStats(game.StartTimeUTC, game.VTeam, enhancedHomeStats, Convert.ToInt32(game.HTeam.Score.Points), game.SeasonYear);
                mappedGames.Add(visitingEnhancedStats);
            }
            return mappedGames;
        }

        public async Task AddTeamPerformanceDataAsync(AddTeamPerformanceRequestDto teamPerformanceStats)
        {
            _repository.AddTeamPerformanceAsync(teamPerformanceStats);
        }

        private AddTeamPerformanceRequestDto EnhanceStats(DateTime startTime, NbaApiGameContestantDto team, GameStatisticsDto stats, int opponentsPointsScored, string seasonYear)
        {
            Statistics enhancedStats = new Statistics(
                Convert.ToInt32(stats.Points),
                opponentsPointsScored,
                Convert.ToInt32(stats.FastBreakPoints),
                Convert.ToInt32(stats.PointsInPaint),
                Convert.ToInt32(stats.BiggestLead),
                Convert.ToInt32(stats.SecondChancePoints),
                Convert.ToInt32(stats.PointsOffTurnovers),
                Convert.ToInt32(stats.LongestRun),
                Convert.ToInt32(stats.FGM),
                Convert.ToInt32(stats.FGA),
                Convert.ToDouble(stats.FGP),
                Convert.ToInt32(stats.FTM),
                Convert.ToInt32(stats.FTA),
                Convert.ToDouble(stats.FTP),
                Convert.ToInt32(stats.TPM),
                Convert.ToInt32(stats.TPA),
                Convert.ToDouble(stats.TPP),
                Convert.ToInt32(stats.OffReb),
                Convert.ToInt32(stats.DefReb),
                Convert.ToInt32(stats.TotReb),
                Convert.ToInt32(stats.Assists),
                Convert.ToInt32(stats.PFouls),
                Convert.ToInt32(stats.Steals),
                Convert.ToInt32(stats.Turnovers),
                Convert.ToInt32(stats.Blocks),
                Convert.ToInt32(stats.PlusMinus),
                stats.Min
            );
            return new AddTeamPerformanceRequestDto(
                startTime.ToString(),
                seasonYear,
                team.ShortName,
                team.FullName,
                team.NickName,
                team.Logo,
                enhancedStats
            );
        }

        Task<List<NbaTeamPerformanceDto>> INbaApiService.GetGamesByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
