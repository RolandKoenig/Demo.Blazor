using Demo.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Client.Services
{
    public class ChatMessageEventArgs : EventArgs
    {
        public ChatMessage Message { get; }

        public ChatMessageEventArgs(ChatMessage message)
        {
            this.Message = message;
        }
    }
}
