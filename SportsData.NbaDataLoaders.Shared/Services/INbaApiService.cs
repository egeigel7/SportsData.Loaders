using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Services
{
    public interface INbaApiService
    {
        Task<List<NbaTeamPerformanceDto>> GetGamesByDateAsync(DateTime date);
        Task<List<AddTeamPerformanceRequestDto>> GetGamesWithStatsByDateAsync(DateTime date);
        Task AddTeamPerformanceDataAsync(AddTeamPerformanceRequestDto teamPerformanceStats);
    }
}
