using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Shared.Components
{
    public partial class LoadingScreen
    {
        [Parameter]
        public string Title
        {
            get;
            set;
        }
    }
}
