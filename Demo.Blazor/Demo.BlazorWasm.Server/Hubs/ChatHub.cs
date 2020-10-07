using Demo.Shared.Dto;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
