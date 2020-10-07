using Demo.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Client.Services
{
    public class LoggingRequestServiceHttp : ILoggingRequestService
    {
        private HttpClient _httpClient;

        public LoggingRequestServiceHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoggingResult> GetLoggingAsync(LoggingRequest request)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<LoggingResult>(
                    $"logginghistory?mintimestamp={request.MinTimeStamp.UtcDateTime.ToString("o")}&" +
                    $"maxtimestamp={request.MaxTimeStamp.UtcDateTime.ToString("o")}&" +
                    $"maxentries={request.MaxCountEntries}&" +
                    $"searchstring={request.SearchString}");
            }
            catch(Exception)
            {
                return new LoggingResult();
            }
        }
    }
}
