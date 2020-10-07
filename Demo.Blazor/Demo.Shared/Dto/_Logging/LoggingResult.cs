using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Shared.Dto
{
    public class LoggingResult
    {
        public List<LoggingLine> Lines
        {
            get;
            set;
        } = new List<LoggingLine>();
    }
}
