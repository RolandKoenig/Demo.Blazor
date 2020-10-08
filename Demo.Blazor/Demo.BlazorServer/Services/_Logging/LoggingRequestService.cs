using Demo.Shared.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BlazorServer.Services
{
    public class LoggingRequestService : ILoggingRequestService
    {
        public async Task<LoggingResult> GetLoggingAsync(LoggingRequest request)
        {
            var result = new LoggingResult();

            // Simulate some working time
            await Task.Delay(1000);

            // Generate entries
            var messageBuilder = new StringBuilder(128);
            var entriesToGenerate = request.MaxCountEntries < 100 ? request.MaxCountEntries : 100;
            var actTimeStamp = request.MaxTimeStamp;
            for (var loop = 0; loop < entriesToGenerate; loop++)
            {
                if (actTimeStamp < request.MinTimeStamp) { break; }

                messageBuilder.Clear();
                messageBuilder.Append("This is a generated message");
                if (!string.IsNullOrEmpty(request.SearchString))
                {
                    messageBuilder.Append(" (");
                    messageBuilder.Append(request.SearchString);
                    messageBuilder.Append(")");
                }

                result.Lines.Add(new LoggingLine()
                {
                    TimeStamp = actTimeStamp,
                    Category = "Test",
                    Message = messageBuilder.ToString()
                });

                actTimeStamp = actTimeStamp - TimeSpan.FromMinutes(1.0);
            }

            return result;
        }
    }
}
