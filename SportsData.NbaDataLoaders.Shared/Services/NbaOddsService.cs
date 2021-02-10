using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaOddsDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using SportsData.NbaDataLoaders.Shared.Exceptions;
using SportsData.NbaDataLoaders.Shared.Mappers;
using SportsData.NbaDataLoaders.Shared.Mappers.Nba;
using SportsData.NbaDataLoaders.Shared.Repositories.Odds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Services
{
    public class NbaOddsService : INbaOddsService
    {
        INbaOddsRepository _repository;
        public NbaOddsService(INbaOddsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProcessGameOddsRequestDto>> GetUpcomingOdds()
        {
            List<ProcessGameOddsRequestDto> oddsToReturn = new List<ProcessGameOddsRequestDto>();
            //Get Spreads
            var spreads = await GetUpcomingSpreads();
            //Get Totals
            var totals = await GetUpcomingOverUnders();
            //Combine into NbaOddsDto
            if (spreads.Count != totals.Count) throw new SpreadsAndTotalsNotMatchedException("The spread count and totals count do not match");
            for (int i = 0; i < spreads.Count; i++)
            {
                if (!spreads[i].TeamName.Equals(totals[i].TeamName)) throw new SpreadsAndTotalsNotMatchedException("Team Name for spreads and totals do not match");
                var teamName = NbaTeamNameMapper.MapTeamName(spreads[i].TeamName);
                var teamImage = NbaTeamImageMapper.GetTeamImageLink(teamName);
                var opponentName = NbaTeamNameMapper.MapTeamName(spreads[i].OpponentsName);
                oddsToReturn.Add(new ProcessGameOddsRequestDto(spreads[i].StartTimeUTC, spreads[i].IsHome, teamName, teamImage, opponentName, spreads[i].Spread, totals[i].OverUnder));
            }
            return oddsToReturn;
        }

        public async Task<List<NbaTotalsDto>> GetUpcomingOverUnders()
        {
            return await _repository.GetTotals();
        }

        public async Task<List<NbaSpreadsDto>> GetUpcomingSpreads()
        {
            return await _repository.GetSpreads();
        }
    }
}
