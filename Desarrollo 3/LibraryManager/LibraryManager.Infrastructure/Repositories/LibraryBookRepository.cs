using LibraryManager.Domain.Entities.LibraryBooks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    internal sealed class LibraryBookRepository : Repository<LibraryBook>, ILibraryBookRepository
    {
        public LibraryBookRepository(LibraryManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(IReadOnlyList<LibraryBook>, int)> GetAllLibraryBooksPaginated(
            int skip,
            int limit,
            string? search)
        {
            var query = DbContext.Set<LibraryBook>().AsQueryable();

            var totalRecords = query.Count();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(b => b.Book.Title.Contains(search)
                || b.Book.ISBN.Contains(search));

            query = query.Skip(skip).Take(limit);

            var libraryBooks = await query
                .Include(b => b.Book)
                .OrderByDescending(lb => lb.AvailableCopies)
                .ToListAsync();

            return (libraryBooks, totalRecords);
        }
    }
}
