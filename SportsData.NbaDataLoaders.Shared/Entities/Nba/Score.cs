using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba
{
    public class Score
    {
        public Score(string points)
        {
            Points = points;
        }

        public string Points { get; }
    }
}
