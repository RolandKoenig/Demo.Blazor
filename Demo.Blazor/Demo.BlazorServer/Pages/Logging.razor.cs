using Demo.BlazorServer.Services;
using Demo.Shared.Dto;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo.BlazorServer.Pages
{
    public partial class Logging
    {
        public LoggingRequest Request
        {
            get;
            set;
        } = new LoggingRequest();

        public LoggingResult Result
        {
            get;
            set;
        } = new LoggingResult();

        public bool IsLoading { get; private set; } = false;

        [Inject]
        public ILoggingRequestService LoggingService { get; set; }

        public async Task HandleValidSubmitAsync()
        {
            if (this.IsLoading) { return; }
            this.IsLoading = true;
            try
            {
                this.Result = await this.LoggingService.GetLoggingAsync(this.Request);
            }
            finally
            {
                this.IsLoading = false;
            }
        }
    }
}
