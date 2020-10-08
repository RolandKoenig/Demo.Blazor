﻿using Demo.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BlazorServer.Services
{
    public interface ILoggingRequestService
    {
        public Task<LoggingResult> GetLoggingAsync(LoggingRequest request);
    }
}
