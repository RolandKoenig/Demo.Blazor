using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Client.Pages
{
    public partial class JavaScriptInterop
    {
        [Inject]
        public IJSRuntime JSRuntime
        {
            get;
            set;
        }

        public async Task CallJavaScript_AlertAsync()
        {
            await this.JSRuntime.InvokeVoidAsync("alert", "This is a test message");
        }
    }
}
