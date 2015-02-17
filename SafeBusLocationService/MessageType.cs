using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeBusLocationService
{
        public enum LoginStatus
        {
            Success,
            Failed
        }

        public enum  BusStatus
        {
            Running,
            Stopped
        }

        public enum Message
        {
            DataFetchSuccess,
            DataFetchFailed,
            LoginSuccess,
            LoginFailed
        }
}