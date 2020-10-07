using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Demo.Shared.Dto;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Demo.BlazorWasm.Client.Services;

namespace Demo.BlazorWasm.Client.Pages
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
