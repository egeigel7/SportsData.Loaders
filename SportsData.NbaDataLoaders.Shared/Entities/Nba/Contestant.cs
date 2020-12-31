using SportsData.NbaDataLoaders.Shared.Entities.Nba;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Core.Entities.Nba
{
    public class Contestant
    {
        public Contestant(string teamId, string shortName, string fullName, string nickName, string logo, Score score)
        {
            TeamId = teamId;
            ShortName = shortName;
            FullName = fullName;
            NickName = nickName;
            Logo = logo;
            Score = score;
        }

        public string TeamId { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Logo { get; set; }
        public Score Score { get; set; }
    }
}
