using LibraryManager.Application.Abstractions.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Libraries.GetById
{
    public sealed record GetLibraryByIdQuery(Guid Id) : ICachedQuery<LibraryResponse>
    {
        public string CacheKey => $"library-{Id}";

        public TimeSpan? Expiration => null;
    }
}
