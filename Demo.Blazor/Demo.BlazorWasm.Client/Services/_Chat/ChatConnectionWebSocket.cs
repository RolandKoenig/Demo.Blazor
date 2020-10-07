using Demo.Shared.Dto;
using Flurl;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Client.Services
{
    public class ChatConnectionWebSocket : IChatConnection
    {
        private HubConnection _hubConnection;


        public bool IsConnected => _hubConnection.State == HubConnectionState.Connected;

        public event EventHandler<ChatMessageEventArgs> MessageReceived;

        public ChatConnectionWebSocket(Url baseUrl)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(baseUrl.AppendPathSegment("/chathub"))
                .Build();

            _hubConnection.On<ChatMessage>("ReceiveMessage", (message) =>
            {
                this.MessageReceived?.Invoke(this, new ChatMessageEventArgs(message));
            });
        }

        public Task ConnectAsync()
        {
            return _hubConnection.StartAsync();
        }

        public void Dispose()
        {
            _ = _hubConnection.DisposeAsync();
        }

        public Task SendMessageAsync(ChatMessage message)
        {
            return _hubConnection.SendAsync("SendMessage", message);
        }
    }
}
