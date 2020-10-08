using Demo.BlazorWasm.Client.Services;
using Demo.Shared.Dto;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Client.Pages
{
    public partial class Chat : IDisposable
    {
        private IChatConnection _chatConnection;

        public ChatMessage NewMessage
        {
            get;
            set;
        } = new ChatMessage();

        public List<ChatMessage> ChatHistory
        {
            get;
        } = new List<ChatMessage>();

        public bool IsConnected => _chatConnection.IsConnected;

        [Inject]
        public NavigationManager NavigationManager
        {
            get;
            set;
        }

        [Inject]
        public IChatService ChatService
        {
            get;
            set;
        }

        protected override async Task OnInitializedAsync()
        {
            _chatConnection = await this.ChatService.ConnectToChatAsync(this.NavigationManager.BaseUri);
            _chatConnection.MessageReceived += (sender, eArgs) =>
            {
                this.ChatHistory.Insert(0, eArgs.Message);
                this.StateHasChanged();
            };
        }

        public Task SendMessageAsync()
        {
            return _chatConnection.SendMessageAsync(this.NewMessage);
        }

        public void Dispose()
        {
            _chatConnection.Dispose();
        }
    }
}
