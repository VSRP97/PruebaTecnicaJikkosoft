using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Books.GetAllPaginated
{
    internal class GetAllBooksPaginatedResponse
    {
        public IReadOnlyList<GetBookResponse> Books { get; set; }
        public int TotalCount { get; set; }
    }

    internal class GetBookResponse
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
