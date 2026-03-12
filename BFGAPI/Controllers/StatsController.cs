using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using bfgshit;
using Newtonsoft.Json;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("common/[controller]")]
    public class TeamInfoController : ControllerBase
    {
        [HttpGet(Name = "GetTeamInfo")]
        public string Get()
        {
            var data = BFG_API.Data.GetCurrentMatchInfo();
            return JsonConvert.SerializeObject(data);
        }
    }

    [Route("common/[controller]")]
    public class TeamRosterController : ControllerBase
    {
        [HttpGet(Name = "GetTeamRoster")]
        public string Get()
        {
            return "Not implemented yet";
        }
    }

    [Route("common/[controller]")]
    public class PopupOverlay : ControllerBase
    {
        [HttpGet(Name = "GetPopupOverlay")]
        public string Get()
        {
            var data = BFG_API.Data.GetCurrentOverlayInfo();
            return JsonConvert.SerializeObject(data);
            //return JsonConvert.SerializeObject(new
            //{
            //    title = "BFG 26 is live!",
            //    subtitle = "this is a subtitle"
            //});
        }
    }
}