using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorWasm.Client.Shared
{
    public partial class NavMenu
    {
        private bool _isNavMenuCollapsed = true;

        public string NavMenuCssClass => _isNavMenuCollapsed ? "collapse" : string.Empty;

        private void ToggleNavMenu()
        {
            _isNavMenuCollapsed = !_isNavMenuCollapsed;
        }
    }
}
