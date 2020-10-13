using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Demo.Shared.Dto
{
    public class CommonInfo
    {
        public string MachineName
        {
            get;
            set;
        } = string.Empty;

        public Guid Guid
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }

        public DateTimeOffset StartupTimeStamp
        {
            get;
            set;
        } = DateTimeOffset.UtcNow;

        public string Framework
        {
            get;
            set;
        } = String.Empty;

        public List<AlertShortInfo> Alerts
        {
            get;
        } = new List<AlertShortInfo>();

        //*******************************************************************************
        //*******************************************************************************
        //*******************************************************************************
        public class AlertShortInfo
        {
            public string AlertID { get; set; }

            public int AlertCount { get; set; }

            public string AlertMessage { get; set; }
        }
    }
}
