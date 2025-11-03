using LibraryManager.Application.Abstractions.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Books.GetByIsbn
{
    public sealed record GetBookByIsbnQuery(
        string Isbn) : ICachedQuery<GetBookByIsbnResponse>
    {
        public string CacheKey => $"bookIsbn-{Isbn}";
        public TimeSpan? Expiration => null;
    }
}
