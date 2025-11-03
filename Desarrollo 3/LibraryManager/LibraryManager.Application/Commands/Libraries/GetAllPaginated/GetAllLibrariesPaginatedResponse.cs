using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Libraries.GetAllPaginated
{
    internal class GetAllLibrariesPaginatedResponse
    {
        public IReadOnlyList<GetLibraryResponse> Libraries { get; set; }
        public int TotalCount { get; set; }
    }

    internal class GetLibraryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
