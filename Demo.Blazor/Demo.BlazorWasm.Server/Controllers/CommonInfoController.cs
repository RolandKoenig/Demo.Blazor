using Demo.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonInfoController : ControllerBase
    {
        private readonly ILogger<CommonInfoController> logger;

        public CommonInfoController(ILogger<CommonInfoController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<CommonInfo> Get()
        {
            var result = new CommonInfo();

            result.MachineName = Environment.MachineName;
            result.Framework = RuntimeInformation.FrameworkDescription;
            result.StartupTimeStamp = DateTime.UtcNow - TimeSpan.FromDays(3.0);
            result.Guid = Guid.Parse("{AEDE4DB4-D57D-4E2C-816E-19B0A9B52870}");
            result.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            result.Alerts.Add(new CommonInfo.AlertShortInfo()
            {
                AlertID = "LOST_CONNECTION",
                AlertCount = 3,
                AlertMessage = "Connection to partner lost"
            });
            result.Alerts.Add(new CommonInfo.AlertShortInfo()
            {
                AlertID = "NET_EXCEPTION",
                AlertCount = 1,
                AlertMessage = "Unhandled exception of type NullReferenceException"
            });

            return result;
        }

    }
}
