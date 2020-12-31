using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaApiDtos
{
    public class NbaApiGameContestantDto
    {
        public string TeamId { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Logo { get; set; }
        public NbaApiContestantScoreDto Score { get; set; }
    }
}
