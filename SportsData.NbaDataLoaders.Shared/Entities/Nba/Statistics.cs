using Newtonsoft.Json;
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
        [JsonProperty("pointsFor")]
        public int PointsFor { get; set; }
        [JsonProperty("pointsAgainst")]
        public int PointsAgainst { get; set; }
        [JsonProperty("fastBreakPoints")]
        public int FastBreakPoints { get; set; }
        [JsonProperty("pointsInPaint")]
        public int PointsInPaint { get; set; }
        [JsonProperty("biggestLead")]
        public int BiggestLead { get; set; }
        [JsonProperty("secondChancePoints")]
        public int SecondChancePoints { get; set; }
        [JsonProperty("pointsOffTurnovers")]
        public int PointsOffTurnovers { get; set; }
        [JsonProperty("longestRun")]
        public int LongestRun { get; set; }
        [JsonProperty("fgm")]
        public int FGM { get; set; }
        [JsonProperty("fga")]
        public int FGA { get; set; }
        [JsonProperty("fgp")]
        public double FGP { get; set; }
        [JsonProperty("ftm")]
        public int FTM { get; set; }
        [JsonProperty("fta")]
        public int FTA { get; set; }
        [JsonProperty("ftp")]
        public double FTP { get; set; }
        [JsonProperty("tpm")]
        public int TPM { get; set; }
        [JsonProperty("tpa")]
        public int TPA { get; set; }
        [JsonProperty("tpp")]
        public double TPP { get; set; }
        [JsonProperty("offReb")]
        public int OffReb { get; set; }
        [JsonProperty("defReb")]
        public int DefReb { get; set; }
        [JsonProperty("totReb")]
        public int TotReb { get; set; }
        [JsonProperty("assists")]
        public int Assists { get; set; }
        [JsonProperty("pFouls")]
        public int PFouls { get; set; }
        [JsonProperty("steals")]
        public int Steals { get; set; }
        [JsonProperty("turnovers")]
        public int Turnovers { get; set; }
        [JsonProperty("blocks")]
        public int Blocks { get; set; }
        [JsonProperty("plusMinus")]
        public int PlusMinus { get; set; }
        [JsonProperty("min")]
        public string Min { get; set; }
    }
}
