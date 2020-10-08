using Demo.BlazorServer.Services;
using Demo.Shared.Dto;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorServer.Pages
{
    public partial class Chat : IDisposable
    {
        public ChatMessage NewMessage
        {
            get;
            set;
        } = new ChatMessage();

        public List<ChatMessage> ChatHistory
        {
            get;
        } = new List<ChatMessage>();

        [Inject]
        public IChatService ChatService
        {
            get;
            set;
        }

        protected override void OnInitialized()
        {
            this.ChatService.MessageReceived += this.OnChatService_MessageReceived;
        }

        private void OnChatService_MessageReceived(object sender, ChatMessageEventArgs eArgs)
        {
            _ = this.InvokeAsync(() =>
            {
                this.ChatHistory.Insert(0, eArgs.Message);
                this.StateHasChanged();
            });
        }

        public void SendMessage()
        {
            this.ChatService.SendMessage(this.NewMessage.Clone());
        }

        public void Dispose()
        {
            this.ChatService.MessageReceived -= this.OnChatService_MessageReceived;
        }
    }
}
