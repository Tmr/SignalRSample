using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRSample.Hub.DTO
{
    public class UnsignedDocumentNotification
    {
        public UnsignedDocumentNotification(string documentName)
        {
            DocumentName = documentName;
        }

        public string DocumentName { get; }

    }
}
