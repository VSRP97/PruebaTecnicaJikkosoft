using LibraryManager.Application.Abstractions.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LibraryBooks.GetById
{
    public sealed record GetLibraryBookByIdQuery(Guid Id) : ICachedQuery<GetLibraryBookByIdResponse>
    {
        public string CacheKey => $"libraryBookId-{Id}";
        public TimeSpan? Expiration => null;
    }
}
