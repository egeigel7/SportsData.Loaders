using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Repositories.Db
{
    public interface INbaDbRepository
    {
        Task<NbaTeamPerformanceDbDto> UpdateTeamStatsAsync(NbaTeamPerformanceDbDto dto);
        Task<NbaTeamPerformanceStatsOnlyDbDto> UpdateTeamStatsOnlyAsync(NbaTeamPerformanceStatsOnlyDbDto dto);
        Task<bool> DoesGameWithStatsExist(AddTeamPerformanceRequestDto dto);
        Task<UpcomingGameDbDto> GetUpcomingGameAsync(AddTeamPerformanceRequestDto dto);
    }
}
