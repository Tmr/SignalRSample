using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRSample
{
    public class HubConfig
    {
        public int UnsignedDocumentsNotificationDelayMs { get; }

        public HubConfig(int unsignedDocumentsNotificationDelayMs)
        {
            UnsignedDocumentsNotificationDelayMs = unsignedDocumentsNotificationDelayMs;
        }
    }
}
