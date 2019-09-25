using System.Collections.Generic;
using System.Threading;

namespace SignalRSample
{
    public interface LKAPI
    {
        public IAsyncEnumerable<int> UnsignedDocumentsNotifications(CancellationToken cancellationToken);
    }
}