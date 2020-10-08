using Demo.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorServer.Services
{
    public class ChatService : IChatService
    {
        public event EventHandler<ChatMessageEventArgs> MessageReceived;

        public void SendMessage(ChatMessage message)
        {
            this.MessageReceived?.Invoke(this, new ChatMessageEventArgs(message));
        }
    }
}
