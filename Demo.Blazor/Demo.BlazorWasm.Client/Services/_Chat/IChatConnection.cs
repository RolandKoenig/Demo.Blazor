using Demo.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Client.Services
{
    public interface IChatConnection : IDisposable
    {
        bool IsConnected { get; }

        event EventHandler<ChatMessageEventArgs> MessageReceived;

        Task SendMessageAsync(ChatMessage message);
    }
}
