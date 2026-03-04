using bfgshit;
using Overlays.Common;

namespace BFG_API
{
    public class Data
    {
        public static KeyValuePair<DateTime, CurrentMatchInfo> CurrentMatchInfo = new(DateTime.Now.AddMinutes(-5), new());

        public static CurrentMatchInfo GetCurrentMatchInfo()
        {
            if (CurrentMatchInfo.Key.AddSeconds(3) < DateTime.UtcNow)
            {
                var req = api.service.Spreadsheets.Values.Get("1GcXlpKxmSDN0DMDKpxXFI4UmshLNoxuo0X8Tu7KywJk", "API!B2:D3").Execute();
                CurrentMatchInfo = new KeyValuePair<DateTime, CurrentMatchInfo>(DateTime.UtcNow, new CurrentMatchInfo
                {
                    TopTeam = new BasicTeamInfo
                    {
                        name = req.Values.ElementAt(0).ElementAt(0).ToString(),
                        imageUrl = req.Values.ElementAt(0).ElementAt(1).ToString()
                    },
                    BottomTeam = new BasicTeamInfo
                    {
                        name = req.Values.ElementAt(1).ElementAt(0).ToString(),
                        imageUrl = req.Values.ElementAt(1).ElementAt(1).ToString()
                    }
                });
                return CurrentMatchInfo.Value;
            }
            else
            {
                return CurrentMatchInfo.Value;
            }
        }
    }
}
