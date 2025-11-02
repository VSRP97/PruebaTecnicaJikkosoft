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

        public Task<Book?> GetByIsbnAsync(string isbn, CancellationToken cancellationToken = default)
        {
            var book = DbContext
                .Set<Book>()
                .FirstOrDefaultAsync(book => book.ISBN == isbn, cancellationToken);

            return book;
        }
    }
}
