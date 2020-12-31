using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Repositories.Db
{
    public interface INbaDbRepository
    {
        Task<NbaTeamPerformanceDbDto> UpdateTeamStatsAsync(NbaTeamPerformanceDbDto dto);

    }
}
