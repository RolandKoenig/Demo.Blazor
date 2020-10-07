using Flurl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Client.Services
{
    public class ChatServiceWebSocket : IChatService
    {
        public async Task<IChatConnection> ConnectToChatAsync(Url baseUrl)
        {
            var result = new ChatConnectionWebSocket(baseUrl);

            await result.ConnectAsync();

            return result;
        }
    }
}
