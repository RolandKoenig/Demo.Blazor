using Demo.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggingHistoryController : ControllerBase
    {
        private readonly ILogger<LoggingHistoryController> logger;

        public LoggingHistoryController(ILogger<LoggingHistoryController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<LoggingResult>> GetAsync(DateTimeOffset minTimestamp, DateTimeOffset maxTimestamp, int maxEntries, string searchString)
        {
            var result = new LoggingResult();

            // Build logging request
            var request = new LoggingRequest()
            {
                MinTimeStamp = minTimestamp.UtcDateTime,
                MaxTimeStamp = maxTimestamp.UtcDateTime,
                MaxCountEntries = maxEntries,
                SearchString = searchString
            };

            // Validate
            try
            {
                Validator.ValidateObject(request, new ValidationContext(request), true);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
           
            // Simulate some working time
            await Task.Delay(1000);

            // Generate entries
            var messageBuilder = new StringBuilder(128);
            var entriesToGenerate = maxEntries < 100 ? maxEntries : 100;
            var actTimeStamp = request.MaxTimeStamp;
            for(var loop=0; loop< entriesToGenerate; loop++)
            {
                if(actTimeStamp < request.MinTimeStamp) { break; }

                messageBuilder.Clear();
                messageBuilder.Append("This is a generated message");
                if(!string.IsNullOrEmpty(searchString))
                {
                    messageBuilder.Append(" (");
                    messageBuilder.Append(searchString);
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
