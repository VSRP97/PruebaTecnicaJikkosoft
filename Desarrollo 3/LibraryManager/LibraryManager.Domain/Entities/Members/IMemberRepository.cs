using LibraryManager.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Members
{
    public interface IMemberRepository : IRepository<Member>
    {
        public Task<(IReadOnlyList<Member>, int)> GetAllMembersPaginated(
            int skip,
            int limit,
            string? search);
    }
}
