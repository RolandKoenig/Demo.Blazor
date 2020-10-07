using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Shared.Components
{
    public partial class LoadingScreenSwitch
    {
        [Parameter]
        public bool IsLoading
        {
            get;
            set;
        }

        [Parameter]
        public RenderFragment ChildContent
        {
            get;
            set;
        }
    }
}
