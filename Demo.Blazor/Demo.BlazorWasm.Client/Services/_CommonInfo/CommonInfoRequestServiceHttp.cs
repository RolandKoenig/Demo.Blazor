using Demo.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Client.Services
{
    public class CommonInfoRequestServiceHttp : ICommonInfoRequestService
    {
        private HttpClient _httpClient;

        public CommonInfoRequestServiceHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CommonInfo> GetCommonInfoAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<CommonInfo>("CommonInfo");
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
