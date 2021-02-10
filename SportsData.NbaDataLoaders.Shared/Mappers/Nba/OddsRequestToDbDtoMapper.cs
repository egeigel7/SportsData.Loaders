using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Mappers.Nba
{
    public class OddsRequestToDbDtoMapper : IOddsRequestToDbDtoMapper
    {
        private const string LEAGUE_NAME = "NBA";
        public UpcomingGameDbDto Map(ProcessGameOddsRequestDto dto)
        {
            var partitionKey = string.Join("-", LEAGUE_NAME, dto.TeamName.Trim().ToUpperInvariant());
            return new UpcomingGameDbDto(
                dto.StartTimeUTC,
                dto.IsHome,
                partitionKey,
                dto.TeamName,
                dto.LogoUrl,
                dto.OpponentsTeamName,
                "UPCOMING",
                dto.OverUnder,
                dto.Spread
            );
        }
    }
}
