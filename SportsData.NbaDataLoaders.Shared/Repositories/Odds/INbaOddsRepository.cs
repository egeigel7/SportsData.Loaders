using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Repositories.Odds
{
    public interface INbaOddsRepository
    {
        Task<List<NbaSpreadsDto>> GetSpreads();
        Task<List<NbaTotalsDto>> GetTotals();
    }
}
