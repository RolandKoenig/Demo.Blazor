using Demo.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Demo.BlazorServer.Services
{
    public class CommonInfoRequestService : ICommonInfoRequestService
    {
        public Task<CommonInfo> GetCommonInfoAsync()
        {
            return Task.FromResult(new CommonInfo()
            {
                Guid = Guid.NewGuid(),
                MachineName = Environment.MachineName,
                StartupTimeStamp = DateTimeOffset.UtcNow.AddDays(-3.5),
                Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(3)
            });
        }
    }
}
