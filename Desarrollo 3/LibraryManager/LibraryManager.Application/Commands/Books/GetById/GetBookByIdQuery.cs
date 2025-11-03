using LibraryManager.Application.Abstractions.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Books.GetById
{
    public sealed record GetBookByIdQuery(Guid Id) : ICachedQuery<GetBookByIdResponse>
    {
        public string CacheKey => $"bookId-{Id}";

        public TimeSpan? Expiration => null;
    }
}
