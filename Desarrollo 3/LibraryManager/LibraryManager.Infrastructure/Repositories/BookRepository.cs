using LibraryManager.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    internal sealed class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Book?> GetByIsbnAsync(string isbn, CancellationToken cancellationToken = default)
        {
            var book = await DbContext
                .Set<Book>()
                .FirstOrDefaultAsync(book => book.ISBN == isbn, cancellationToken);

            return book;
        }

        public async Task<(IReadOnlyList<Book>, int)> GetAllBooksPaginated(
            int skip,
            int limit,
            string? search)
        {
            var query = DbContext.Set<Book>().AsQueryable();

            var totalRecords = query.Count();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(b => b.ISBN.Contains(search)
                                         || b.Author.Contains(search)
                                         || b.Title.Contains(search)
                                         || b.PublicationYear.ToString().Contains(search));

            query = query.Skip(skip).Take(limit);

            var books = await query
                .OrderByDescending(b => b.PublicationYear)
                .ToListAsync();

            return (books, totalRecords);
        }
    }
}
