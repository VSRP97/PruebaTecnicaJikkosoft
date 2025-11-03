using LibraryManager.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Libraries
{
    public static class LibraryErrors
    {
        public static readonly Error NotFound = new(
            "Library.NotFound",
            "The library with the specified identifier was not found.");
    }
}
