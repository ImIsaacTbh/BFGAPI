using Data.Common;

namespace TestAPI
{
    public class SheetsRequestInfo
    {
    }
}

namespace Overlays.Common
{
    public struct CurrentMatchInfo
    {
        public BasicTeamInfo TopTeam;
        public BasicTeamInfo BottomTeam;
    }

    public struct BasicTeamInfo
    {
        public string name;
        public string imageUrl;
    }
}

namespace Data.Common
{
    public struct Player
    {
        public string name;
        public string pronouns;
        public string handle;
    }

    public struct Talent
    {
        public string name;
        public string pronouns;
        public string handle;
    }
}

namespace Data.League
{
    public struct LeagueMatchInfo
    {
        public List<LeagueTeamInfo> teams;
        public bool sidesSwitched;
    }

    public struct LeagueChampionInfo
    {
        public string name;
        public string imageUrl;
        public string role;
    }

    public struct  LeagueTeamInfo
    {
        public string name;
        public string imageUrl;
        public List<Player> players;
        public List<LeagueChampionInfo> picks;
        public List<LeagueChampionInfo> bans;
    }
}

namespace Data.Valorant
{

}

namespace Data.RocketLeague
{

}
