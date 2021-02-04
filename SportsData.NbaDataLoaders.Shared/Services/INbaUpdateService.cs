using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Services
{
    public interface INbaUpdateService
    {
        Task<CompletedGameDbDto> UpdateTeamStatsAsync(AddTeamPerformanceRequestDto dto);
        NbaTeamGameDbDto CreateTeamGameFromPerformance(AddTeamPerformanceRequestDto dto);
        CompletedGameDbDto CreateCompletedGameFromPerformance(AddTeamPerformanceRequestDto dto);
    }
}
