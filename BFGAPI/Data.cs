using bfgshit;
using Google.Apis.Sheets.v4.Data;
using Overlays.Common;

namespace BFG_API
{
    public class Data
    {
        public static KeyValuePair<DateTime, CurrentMatchInfo> _CurrentMatchInfo = new(DateTime.Now.AddMinutes(-5), new());
        public static KeyValuePair<DateTime, OverlayText> _CurrentOverlayInfo = new(DateTime.Now.AddMinutes(-5), new());

        public static CurrentMatchInfo GetCurrentMatchInfo()
        {
            if (_CurrentMatchInfo.Key.AddSeconds(3) < DateTime.Now)
            {
                var req = api.service.Spreadsheets.Values.Get("1GcXlpKxmSDN0DMDKpxXFI4UmshLNoxuo0X8Tu7KywJk", "API!B2:D3").Execute();
                _CurrentMatchInfo = new KeyValuePair<DateTime, CurrentMatchInfo>(DateTime.Now, new CurrentMatchInfo
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
                return _CurrentMatchInfo.Value;
            }
            else
            {
                return _CurrentMatchInfo.Value;
            }
        }

        public static OverlayText GetCurrentOverlayInfo()
        {
            if(_CurrentOverlayInfo.Key.AddSeconds(3) < DateTime.Now)
            {
                var req = api.service.Spreadsheets.Values.Get("1GcXlpKxmSDN0DMDKpxXFI4UmshLNoxuo0X8Tu7KywJk", "API!B6:B7").Execute();
                _CurrentOverlayInfo = new KeyValuePair<DateTime, OverlayText>(DateTime.Now, new OverlayText
                {
                    header = req.Values.ElementAt(0).ElementAt(0).ToString(),
                    content = req.Values.ElementAt(1).ElementAt(0).ToString()
                });
                return _CurrentOverlayInfo.Value;
            }
            else
            {
                return _CurrentOverlayInfo.Value;
            }
        }
    }
}
