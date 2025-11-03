using LibraryManager.Domain.Entities.Libraries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    internal sealed class LibraryRepository : Repository<Library>, ILibraryRepository
    {
        public LibraryRepository(LibraryManagerDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task<(IReadOnlyList<Library>, int)> GetAllLibrariesPaginated(
            int skip,
            int limit,
            string? search)
        {
            var query = DbContext.Set<Library>().AsQueryable();

            var totalRecords = query.Count();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(b => b.Name.Contains(search));

            query = query.Skip(skip).Take(limit);

            var libraries = await query
                .OrderByDescending(b => b.Name)
                .ToListAsync();

            return (libraries, totalRecords);
        }
    }
}
