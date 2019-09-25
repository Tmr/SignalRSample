using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using SignalRSample.Hub.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRSample.Hub
{
    public class LKHub : Hub<LKAPI>
    {
        HubConfig Config;
        public LKHub(HubConfig config)
        {
            Config = config;
        }

        public async IAsyncEnumerable<IEnumerable<UnsignedDocumentNotification>> UnsignedDocumentsNotifications(
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // Check the cancellation token regularly so that the server will stop
                // producing notifications if the client disconnects.
                cancellationToken.ThrowIfCancellationRequested();

                // Get unsigned document list
                IEnumerable<UnsignedDocumentNotification> docs = 
                    new UnsignedDocumentNotification[] { 
                        new UnsignedDocumentNotification($"Document 1 {DateTime.Now}"),
                        new UnsignedDocumentNotification($"Document 2 {DateTime.Now}")
                    };

                // Return documents 
                yield return docs;

                // Use the cancellationToken in other APIs that accept cancellation
                // tokens so the cancellation can flow down to them.
                await Task.Delay(Config.UnsignedDocumentsNotificationDelayMs, cancellationToken);
            }
        }
    }
}
