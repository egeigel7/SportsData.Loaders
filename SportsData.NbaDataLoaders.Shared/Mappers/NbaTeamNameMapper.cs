using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Mappers
{
    public static class NbaTeamNameMapper
    {
        static Dictionary<string, string> NbaTeamNameDictionary = new Dictionary<string, string>()
        {
            { "Los Angeles Clippers", "LA Clippers" },
            { "LA Clippers", "LA Clippers"},
            { "Golden State Warriors", "Golden State Warriors" },
            { "Los Angeles Lakers", "Los Angeles Lakers" },
            { "LA Lakers", "Los Angeles Lakers" },
            { "Brooklyn Nets", "Brooklyn Nets" },
            { "Orlando Magic", "Orlando Magic" },
            { "Memphis Grizzlies", "Memphis Grizzlies" },
            { "New Orleans Pelicans", "New Orleans Pelicans" },
            { "Phoenix Suns", "Phoenix Suns" },
            { "Philadelphia 76ers", "Philadelphia 76ers" },
            { "Charlotte Hornets", "Charlotte Hornets" },
            { "Utah Jazz", "Utah Jazz" },
            { "San Antonio Spurs", "San Antonio Spurs" },
            { "Milwaukee Bucks", "Milwaukee Bucks" },
            { "Indiana Pacers", "Indiana Pacers" },
            { "Washington Wizards", "Washington Wizards" },
            { "Dallas Mavericks", "Dallas Mavericks" },
            { "Sacramento Kings", "Sacramento Kings" },
            { "Denver Nuggets", "Denver Nuggets" },
            { "Atlanta Hawks", "Atlanta Hawks" },
            { "Portland Trail Blazers", "Portland Trail Blazers" },
            { "Boston Celtics", "Boston Celtics" },
            { "Chicago Bulls", "Chicago Bulls"},
            { "Minnesota Timberwolves", "Minnesota Timberwolves" },
            { "Detroit Pistons", "Detroit Pistons" },
            { "New York Knicks", "New York Knicks" },
            { "Toronto Raptors", "Toronto Raptors" },
            { "Miami Heat", "Miami Heat" },
            { "Cleveland Cavaliers", "Cleveland Cavaliers" },
            { "Houston Rockets", "Houston Rockets" },
            { "Oklahoma City Thunder", "Oklahoma City Thunder" }
        };
        public static string MapTeamName(string teamName)
        {
            if (NbaTeamNameDictionary.TryGetValue(teamName, out string mappedName))
                return mappedName;
            else
                return null;
        }
    }
}
