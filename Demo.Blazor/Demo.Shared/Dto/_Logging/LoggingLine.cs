using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Demo.Shared.Dto
{
    public class LoggingLine
    {
        public DateTimeOffset TimeStamp { get; set; }

        public string Category { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}
