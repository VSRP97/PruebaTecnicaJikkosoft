using LibraryManager.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Libraries
{
    public interface ILibraryRepository : IRepository<Library>
    {
        public Task<Library?> GetById(Guid id, CancellationToken cancellationToken);

        public Task<(IReadOnlyList<Library>, int)> GetAllLibrariesPaginated(
            int skip,
            int limit,
            string? search,
            CancellationToken cancellationToken = default);
    }
}
