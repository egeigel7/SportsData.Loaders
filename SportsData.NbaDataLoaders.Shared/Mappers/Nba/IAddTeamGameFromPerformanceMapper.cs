using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Mappers.Nba
{
    public interface IAddTeamGameFromPerformanceMapper
    {
        AddTeamPerformanceRequestDto Convert(DateTime date, NbaTeamPerformanceDto dto);
    }
}
