using LibraryManager.Application.Abstractions.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Members.GetById
{
    public sealed record GetMemberByIdQuery(Guid Id) : ICachedQuery<GetMemberByIdResponse>
    {
        public string CacheKey => $"memberId-{Id}";
        public TimeSpan? Expiration => null;
    }
}
