using LibraryManager.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.LibraryBooks
{
    public interface ILibraryBookRepository : IRepository<LibraryBook>
    {
        public Task<LibraryBook> GetById(Guid id, CancellationToken cancellationToken = default);

        public Task<(IReadOnlyList<LibraryBook>, int)> GetAllLibraryBooksPaginated(
            int skip,
            int limit,
            string? search, 
            CancellationToken cancellationToken = default);
    }
}
