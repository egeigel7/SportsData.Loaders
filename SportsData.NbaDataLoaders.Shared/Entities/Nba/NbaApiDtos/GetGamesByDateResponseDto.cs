using System.Collections.Generic;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaApiDtos
{
    public class GetGamesByDateResponseDto 
    {
        public int Status { get; }
        public string Message { get; }
        public int Results { get; }
        public List<string> Filters { get; }
        public List<NbaApiGameDto> Games { get; }
        public GetGamesByDateResponseDto(int status, string message, int results, List<string> filters, List<NbaApiGameDto> games)
        {
            Status = status;
            Message = message;
            Results = results;
            Filters = filters;
            Games = games;
        }
    }
}
