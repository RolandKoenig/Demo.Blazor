using Demo.Shared.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Demo.Shared.Dto
{
    public class LoggingRequest
    {
        [IsDateAfterOrBefore(nameof(MaxTimeStamp), DateCompareMode.Before)]
        public DateTimeOffset MinTimeStamp
        {
            get;
            set;
        } = DateTime.Now - TimeSpan.FromHours(3.0);

        [IsDateAfterOrBefore(nameof(MinTimeStamp), DateCompareMode.After)]
        public DateTimeOffset MaxTimeStamp
        {
            get;
            set;
        } = DateTime.Now;

        [Range(0, 1000)]
        public int MaxCountEntries
        {
            get;
            set;
        } = 100;

        [MaxLength(50)]
        public string SearchString
        {
            get;
            set;
        }
    }
}
