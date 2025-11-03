using LibraryManager.Domain.Entities.Members;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    internal sealed class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(LibraryManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(IReadOnlyList<Member>, int)> GetAllMembersPaginated(
            int skip,
            int limit,
            string? search)
        {
            var query = DbContext.Set<Member>().AsQueryable();

            var totalRecords = query.Count();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(m => m.Name.Contains(search)
                                         || m.Email.Contains(search));

            query = query.Skip(skip).Take(limit);

            var members = await query
                .OrderBy(m => m.Name)
                .Include(m => m.Loans)
                .ToListAsync();

            return (members, totalRecords);
        }
    }
}
