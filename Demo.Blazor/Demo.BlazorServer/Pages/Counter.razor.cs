using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorServer.Pages
{
    public partial class Counter
    {
        public int CurrentCount { get; private set; } = 0;

        public void IncrementCount()
        {
            this.CurrentCount++;
        }
    }
}
