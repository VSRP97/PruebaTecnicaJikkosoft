using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.LibraryBooks.GetAllPaginated
{
    internal class GetAllLibraryBooksPaginatedResponse
    {
        public IReadOnlyList<GetLibraryBookResponse> LibraryBooks { get; set; }
        public int TotalCount { get; set; }
    }

    internal class GetLibraryBookResponse
    {
        public Guid Id { get; set; }
        public Guid LibraryId { get; set; }
        public Guid BookId { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
    }
}
