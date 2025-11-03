using LibraryManager.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Books
{
    public static class BookErrors
    {
        public static readonly Error NotFound = new(
            "Book.NotFound",
            "The book with the specified identifier was not found.");
    }
}
