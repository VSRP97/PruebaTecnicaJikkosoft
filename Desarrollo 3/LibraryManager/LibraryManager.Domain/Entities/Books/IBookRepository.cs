using LibraryManager.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Books
{
    public interface IBookRepository : IRepository<Book>
    {
        public Task<Book?> GetById(Guid id, CancellationToken cancellationToken = default);

        public Task<Book?> GetByIsbnAsync(string isbn, CancellationToken cancellationToken = default);

        public Task<(IReadOnlyList<Book>, int)> GetAllBooksPaginated(
            int skip,
            int limit,
            string? search,
            CancellationToken cancellationToken = default);
    }
}
