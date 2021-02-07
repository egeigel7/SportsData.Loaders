using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.NbaDataLoaders.Shared.Mappers.Nba
{
    public class NbaTeamImageMapper
    {
        static Dictionary<string, string> NbaTeamNameDictionary = new Dictionary<string, string>()
        {
            { "LA Clippers", "https://upload.wikimedia.org/wikipedia/fr/d/d6/Los_Angeles_Clippers_logo_2010.png"},
            { "Golden State Warriors", "https://upload.wikimedia.org/wikipedia/fr/thumb/d/de/Warriors_de_Golden_State_logo.svg/1200px-Warriors_de_Golden_State_logo.svg.png" },
            { "Los Angeles Lakers", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3c/Los_Angeles_Lakers_logo.svg/220px-Los_Angeles_Lakers_logo.svg.png" },
            { "Brooklyn Nets", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Brooklyn_Nets_newlogo.svg/130px-Brooklyn_Nets_newlogo.svg.png" },
            { "Orlando Magic", "https://upload.wikimedia.org/wikipedia/fr/b/bd/Orlando_Magic_logo_2010.png" },
            { "Memphis Grizzlies", "https://upload.wikimedia.org/wikipedia/en/thumb/f/f1/Memphis_Grizzlies.svg/1200px-Memphis_Grizzlies.svg.png" },
            { "New Orleans Pelicans", "https://upload.wikimedia.org/wikipedia/fr/thumb/2/21/New_Orleans_Pelicans.png/200px-New_Orleans_Pelicans.png" },
            { "Phoenix Suns", "https://upload.wikimedia.org/wikipedia/fr/5/56/Phoenix_Suns_2013.png" },
            { "Philadelphia 76ers", "https://upload.wikimedia.org/wikipedia/fr/4/48/76ers_2016.png" },
            { "Charlotte Hornets", "https://upload.wikimedia.org/wikipedia/fr/thumb/f/f3/Hornets_de_Charlotte_logo.svg/1200px-Hornets_de_Charlotte_logo.svg.png" },
            { "Utah Jazz", "https://upload.wikimedia.org/wikipedia/fr/3/3b/Jazz_de_l%27Utah_logo.png" },
            { "San Antonio Spurs", "https://upload.wikimedia.org/wikipedia/fr/0/0e/San_Antonio_Spurs_2018.png" },
            { "Milwaukee Bucks", "https://upload.wikimedia.org/wikipedia/fr/3/34/Bucks2015.png" },
            { "Indiana Pacers", "https://upload.wikimedia.org/wikipedia/fr/thumb/c/cf/Pacers_de_l%27Indiana_logo.svg/1180px-Pacers_de_l%27Indiana_logo.svg.png" },
            { "Washington Wizards", "https://upload.wikimedia.org/wikipedia/fr/archive/d/d6/20161212034849%21Wizards2015.png" },
            { "Dallas Mavericks", "https://upload.wikimedia.org/wikipedia/fr/thumb/b/b8/Mavericks_de_Dallas_logo.svg/150px-Mavericks_de_Dallas_logo.svg.png" },
            { "Sacramento Kings", "https://upload.wikimedia.org/wikipedia/fr/thumb/9/95/Kings_de_Sacramento_logo.svg/1200px-Kings_de_Sacramento_logo.svg.png" },
            { "Denver Nuggets", "https://upload.wikimedia.org/wikipedia/fr/thumb/3/35/Nuggets_de_Denver_2018.png/180px-Nuggets_de_Denver_2018.png" },
            { "Atlanta Hawks", "https://upload.wikimedia.org/wikipedia/fr/e/ee/Hawks_2016.png" },
            { "Portland Trail Blazers", "https://upload.wikimedia.org/wikipedia/en/thumb/2/21/Portland_Trail_Blazers_logo.svg/1200px-Portland_Trail_Blazers_logo.svg.png" },
            { "Boston Celtics", "https://upload.wikimedia.org/wikipedia/fr/thumb/6/65/Celtics_de_Boston_logo.svg/1024px-Celtics_de_Boston_logo.svg.png" },
            { "Chicago Bulls", "https://upload.wikimedia.org/wikipedia/fr/thumb/d/d1/Bulls_de_Chicago_logo.svg/1200px-Bulls_de_Chicago_logo.svg.png"},
            { "Minnesota Timberwolves", "https://upload.wikimedia.org/wikipedia/fr/thumb/d/d9/Timberwolves_du_Minnesota_logo_2017.png/200px-Timberwolves_du_Minnesota_logo_2017.png" },
            { "Detroit Pistons", "https://upload.wikimedia.org/wikipedia/en/thumb/1/1e/Detroit_Pistons_logo.svg/1200px-Detroit_Pistons_logo.svg.png" },
            { "New York Knicks", "https://upload.wikimedia.org/wikipedia/fr/d/dc/NY_Knicks_Logo_2011.png" },
            { "Toronto Raptors", "https://upload.wikimedia.org/wikipedia/fr/8/89/Raptors2015.png" },
            { "Miami Heat", "https://upload.wikimedia.org/wikipedia/fr/thumb/1/1c/Miami_Heat_-_Logo.svg/1200px-Miami_Heat_-_Logo.svg.png" },
            { "Cleveland Cavaliers", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/04/Cleveland_Cavaliers_secondary_logo.svg/1186px-Cleveland_Cavaliers_secondary_logo.svg.png" },
            { "Houston Rockets", "https://upload.wikimedia.org/wikipedia/fr/thumb/d/de/Houston_Rockets_logo_2003.png/330px-Houston_Rockets_logo_2003.png" },
            { "Oklahoma City Thunder", "https://upload.wikimedia.org/wikipedia/fr/thumb/4/4f/Thunder_d%27Oklahoma_City_logo.svg/1200px-Thunder_d%27Oklahoma_City_logo.svg.png" }
        };
        public static string GetTeamImageLink(string teamName)
        {
            if (NbaTeamNameDictionary.TryGetValue(teamName, out string image))
                return image;
            else
                return null;
        }
    }
}
