using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaApiDtos;
using System.Collections.Generic;

namespace SportsData.NbaDataLoaders.Shared.Mappers.Nba
{
    public interface IGetGamesByDateResponseMapper
    {
        List<Game> Convert(GetGamesByDateResponseDto response);
    }
}
