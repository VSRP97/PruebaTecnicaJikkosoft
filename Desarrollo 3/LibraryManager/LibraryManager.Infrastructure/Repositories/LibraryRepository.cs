using LibraryManager.Domain.Entities.Libraries;
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
    }
}
