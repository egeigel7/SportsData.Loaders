using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaApiDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.Infrastructure.Repositories.Nba
{
    public interface INbaApiRepository
    {
        Task<GetGamesByDateResponseDto> GetGamesByDateAsync(DateTime date);
        Task<GetStatsByGameIdResponseDto> GetStatsByGameIdAsync(string gameId);
        Task AddTeamPerformanceAsync(AddTeamPerformanceRequestDto teamPerformanceStats);
    }
}
