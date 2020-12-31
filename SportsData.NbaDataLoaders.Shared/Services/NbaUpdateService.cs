using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
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
        public NbaUpdateService(INbaDbRepository repository)
        {
            _repository = repository;
        }

        public NbaTeamGameDbDto CreateTeamGameFromPerformance(AddTeamPerformanceRequestDto dto)
        {
            // string convertedDate = DateTime.Parse(dto.GameStartTime).ToString("yyyyMMdd");
            var partitionKey = String.Join("-", LEAGUE_NAME, dto.FullName);
            var teamId = String.Join("-", dto.SeasonYear, dto.FullName);
            return new NbaTeamGameDbDto(
                dto.GameStartTime,
                teamId,
                partitionKey,
                dto.FullName,
                dto.Nickname,
                dto.Stats
            );
        }

        public Task<NbaTeamPerformanceDbDto> UpdateTeamStatsAsync(AddTeamPerformanceRequestDto dto)
        {
            NbaTeamPerformanceDbDto dbDto = new NbaTeamPerformanceDbDto(
                dto.SeasonYear,
                dto.ShortName,
                dto.FullName,
                dto.Nickname,
                dto.LogoUrl,
                1,
                dto.Stats
            );
            return _repository.UpdateTeamStatsAsync(dbDto);
        }
    }
}
