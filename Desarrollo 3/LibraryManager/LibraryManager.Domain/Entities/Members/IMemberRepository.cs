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
        public Task<Member> GetById(Guid id, CancellationToken cancellationToken = default);

        public Task<Member> GetByEmail(string email, CancellationToken cancellationToken = default);

        public Task<(IReadOnlyList<Member>, int)> GetAllMembersPaginated(
            int skip,
            int limit,
            string? search,
            CancellationToken cancellationToken = default);
    }
}
