using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaApiDtos
{
    public class GameStatisticsDto
    {
        public string GameId { get; set; }
        public string TeamId { get; set; }
        public string FastBreakPoints { get; set; }
        public string PointsInPaint { get; set; }
        public string BiggestLead { get; set; }
        public string SecondChancePoints { get; set; }
        public string PointsOffTurnovers { get; set; }
        public string LongestRun { get; set; }
        public string Points { get; set; }
        public string FGM { get; set; }
        public string FGA { get; set; }
        public string FGP { get; set; }
        public string FTM { get; set; }
        public string FTA { get; set; }
        public string FTP { get; set; }
        public string TPM { get; set; }
        public string TPA { get; set; }
        public string TPP { get; set; }
        public string OffReb { get; set; }
        public string DefReb { get; set; }
        public string TotReb { get; set; }
        public string Assists { get; set; }
        public string PFouls { get; set; }
        public string Steals { get; set; }
        public string Turnovers { get; set; }
        public string Blocks { get; set; }
        public string PlusMinus { get; set; }
        public string Min { get; set; }
    }
}
