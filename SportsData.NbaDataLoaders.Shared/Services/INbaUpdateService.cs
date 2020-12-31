using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Services
{
    public interface INbaUpdateService
    {
        Task<NbaTeamPerformanceDbDto> UpdateTeamStatsAsync(AddTeamPerformanceRequestDto dto);
        NbaTeamGameDbDto CreateTeamGameFromPerformance(AddTeamPerformanceRequestDto dto);
    }
}
