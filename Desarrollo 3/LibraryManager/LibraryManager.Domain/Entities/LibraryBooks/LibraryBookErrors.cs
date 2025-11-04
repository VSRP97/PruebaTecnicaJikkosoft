using LibraryManager.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.LibraryBooks
{
    public static class LibraryBookErrors
    {
        public static readonly Error NotFound = new(
            "LibraryBook.NotFound",
            "The library book with the specified identifier was not found.");

        public static readonly Error OutOfStock = new(
            "Book.OutOfStock",
            "This book edition is currently out of stock.");

        public static readonly Error InsufficientStock = new(
            "Book.InsufficientStock",
            "There are not enough copies of this book edition available to fulfill the request.");

        public static readonly Error ExceedingTotalCopies = new(
            "Book.ExceedingTotalCopies",
            "Returning these copies would exceed the total number of copies owned by the library.");

        public static readonly Error TotalCopiesBelowOne = new(
            "Book.InvalidTotalCopies",
            "The total number of copies must be at least one.");

        public static readonly Error AvailableCopiesBelowZero = new(
            "Book.AvailableCopiesBelowZero",
            "The number of available copies cannot be less than zero.");

        public static readonly Error Exists = new(
            "LibraryBook.Exists",
            "The library already has this book edition in its collection.");
    }
}
