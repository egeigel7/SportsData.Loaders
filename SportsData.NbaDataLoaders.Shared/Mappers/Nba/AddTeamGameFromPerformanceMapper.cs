using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Mappers.Nba
{
    public class AddTeamGameFromPerformanceMapper : IAddTeamGameFromPerformanceMapper
    {
        public AddTeamPerformanceRequestDto Convert(DateTime date, NbaTeamPerformanceDto dto)
        {
            return new AddTeamPerformanceRequestDto(
                date.ToString(),
                dto.SeasonYear,
                dto.ShortName,
                dto.FullName,
                dto.Nickname,
                dto.LogoUrl,
                dto.Stats
            );
        }
    }
}
