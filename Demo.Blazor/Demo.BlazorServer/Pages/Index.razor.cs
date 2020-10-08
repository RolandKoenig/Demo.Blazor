using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Demo.BlazorServer.Services;
using Demo.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace Demo.BlazorServer.Pages
{
    public partial class Index
    {
        public CommonInfo Data { get; private set; } = null;

        [Inject]
        public ICommonInfoRequestService CommonInfoService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            this.Data = await this.CommonInfoService.GetCommonInfoAsync();
        }
    }
}
