using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Books;
using LibraryManager.Domain.Entities.Libraries;
using LibraryManager.Domain.Entities.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.LibraryBooks
{
    public sealed class LibraryBook : Entity
    {
        public LibraryBook(
            Guid id,
            Guid libraryId,
            Guid bookId,
            int totalCopies,
            int availableCopies)
        {
            Id = id;
            LibraryId = libraryId;
            BookId = bookId;
            TotalCopies = totalCopies;
            AvailableCopies = availableCopies;
        }

        public LibraryBook()
        {

        }

        public Guid Id { get; set; }

        public Guid LibraryId { get; private set; }

        public Guid BookId { get; private set; }

        public int TotalCopies { get; private set; }

        public int AvailableCopies { get; set; }

        #region Navigation
        public Library Library { get; private set; }
        public Book Book { get; private set; }
        public ICollection<Loan> Loans { get; private set; } = [];
        #endregion

        public static LibraryBook Create(
            Guid libraryId,
            Guid bookId,
            int totalCopies,
            int availableCopies)
        {
            var libraryBook = new LibraryBook(
                Guid.NewGuid(),
                libraryId,
                bookId,
                totalCopies,
                availableCopies);

            return libraryBook;
        }

        public Result UpdateTotalCopies(int amountToUpdate)
        {
            var newTotalCopies = TotalCopies + amountToUpdate;
            var newAvailableCopies = AvailableCopies + amountToUpdate;
            if (newTotalCopies < 1)
                return Result.Failure(LibraryBookErrors.TotalCopiesBelowOne);
            if (newAvailableCopies < 0)
                return Result.Failure(LibraryBookErrors.AvailableCopiesBelowZero);

            TotalCopies = newTotalCopies;
            AvailableCopies = newAvailableCopies;
            return Result.Success();
        }

        /// <summary>
        /// Reduces the number of available copies when lending books.
        /// </summary>
        /// <param name="amountToLend"></param>
        /// <returns></returns>
        public Result LendCopies(int amountToLend = 1)
        {
            if (AvailableCopies <= 0)
                return Result.Failure(LibraryBookErrors.OutOfStock);

            if (amountToLend > AvailableCopies)
                return Result.Failure(LibraryBookErrors.InsufficientStock);

            AvailableCopies -= amountToLend;

            return Result.Success();
        }

        /// <summary>
        /// Increments the number of available copies when returning books.
        /// </summary>
        /// <param name="amountToReturn"></param>
        /// <returns></returns>
        public Result ReturnCopies(int amountToReturn = 1)
        {
            if (AvailableCopies + amountToReturn > TotalCopies)
                return Result.Failure(LibraryBookErrors.ExceedingTotalCopies);

            AvailableCopies += amountToReturn;
            return Result.Success();
        }
    }
}
