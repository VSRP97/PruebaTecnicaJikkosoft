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
        public static readonly Error OutOfStock = new(
            "Book.OutOfStock",
            "This book edition is currently out of stock.");

        public static readonly Error InsufficientStock = new(
            "Book.InsufficientStock",
            "There are not enough copies of this book edition available to fulfill the request.");
    }
}
