using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Application.Abstractions.Messaging;

namespace LibraryManager.Application.Abstractions.Caching
{
    public interface ICachedQuery<TResponse> : IQuery<TResponse>, ICachedQuery;

    public interface ICachedQuery
    {
        string CacheKey { get; }

        TimeSpan? Expiration { get; }
    }
}
