using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Entities.Nba
{
    public class Statistics
    {
        public Statistics(int pointsFor, int pointsAgainst, int fastBreakPoints, int pointsInPaint, int biggestLead, int secondChancePoints, int pointsOffTurnovers, int longestRun, int fGM, int fGA, double fGP, int fTM, int fTA, double fTP, int tPM, int tPA, double tPP, int offReb, int defReb, int totReb, int assists
            , int pFouls, int steals, int turnovers, int blocks, int plusMinus, string min)
        {
            PointsFor = pointsFor;
            PointsAgainst = pointsAgainst;
            FastBreakPoints = fastBreakPoints;
            PointsInPaint = pointsInPaint;
            BiggestLead = biggestLead;
            SecondChancePoints = secondChancePoints;
            PointsOffTurnovers = pointsOffTurnovers;
            LongestRun = longestRun;
            FGM = fGM;
            FGA = fGA;
            FGP = fGP;
            FTM = fTM;
            FTA = fTA;
            FTP = fTP;
            TPM = tPM;
            TPA = tPA;
            TPP = tPP;
            OffReb = offReb;
            DefReb = defReb;
            TotReb = totReb;
            Assists = assists;
            PFouls = pFouls;
            Steals = steals;
            Turnovers = turnovers;
            Blocks = blocks;
            PlusMinus = plusMinus;
            Min = min ?? throw new ArgumentNullException(nameof(min));
        }

        public int PointsFor { get; set; }
        public int PointsAgainst { get; set; }
        public int FastBreakPoints { get; set; }
        public int PointsInPaint { get; set; }
        public int BiggestLead { get; set; }
        public int SecondChancePoints { get; set; }
        public int PointsOffTurnovers { get; set; }
        public int LongestRun { get; set; }
        public int FGM { get; set; }
        public int FGA { get; set; }
        public double FGP { get; set; }
        public int FTM { get; set; }
        public int FTA { get; set; }
        public double FTP { get; set; }
        public int TPM { get; set; }
        public int TPA { get; set; }
        public double TPP { get; set; }
        public int OffReb { get; set; }
        public int DefReb { get; set; }
        public int TotReb { get; set; }
        public int Assists { get; set; }
        public int PFouls { get; set; }
        public int Steals { get; set; }
        public int Turnovers { get; set; }
        public int Blocks { get; set; }
        public int PlusMinus { get; set; }
        public string Min { get; set; }
    }
}
