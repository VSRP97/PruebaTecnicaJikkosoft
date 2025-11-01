using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Application.Abstractions.Caching;

namespace LibraryManager.Application.Commands.Users.GetUserByEmail
{
    public record class GetUserByEmailQuery(string Email) : ICachedQuery<UserResponse>
    {
        public string CacheKey => $"user-{Email}";

        public TimeSpan? Expiration => null;
    }
}
