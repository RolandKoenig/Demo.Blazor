using Demo.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorServer.Services
{
    public interface IChatService
    {
        event EventHandler<ChatMessageEventArgs> MessageReceived;

        void SendMessage(ChatMessage message);
    }
}
