using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Services
{
    public interface INbaOddsService
    {
        Task<List<ProcessGameOddsRequestDto>> GetUpcomingOdds();
        Task<List<NbaSpreadsDto>> GetUpcomingSpreads();
        Task<List<NbaTotalsDto>> GetUpcomingOverUnders();
    }
}
