using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace LibraryManager.Infrastructure.Caching
{
    public static class CacheOptions
    {
        public static MemoryCacheEntryOptions DefaultExpiration => new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
        };

        public static MemoryCacheEntryOptions Create(TimeSpan? expiration) =>
            expiration is not null ?
                new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration } :
                DefaultExpiration;
    }
}
