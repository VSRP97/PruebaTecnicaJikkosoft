using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Libraries;
using LibraryManager.Domain.Entities.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Books
{
    public sealed class Book : Entity
    {
        private Book(
            Guid id,
            string iSBN,
            string title,
            string author,
            int publicationYear) : base(id)
        {
            ISBN = iSBN;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }

        private Book()
        {
        }

        /// <summary>
        /// Identifier of the library that owns the book.
        /// </summary>
        public Guid LibraryId { get; set; }

        /// <summary>
        /// International Standard Book Number (ISBN) of the book.
        /// </summary>
        public string ISBN { get; private set; }

        /// <summary>
        /// Title of the book.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Author of the book.
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// Year of publication of the book.
        /// </summary>
        public int PublicationYear { get; private set; }

        /// <summary>
        /// Total number of copies of the book.
        /// </summary>
        public int TotalCopies { get; private set; }

        /// <summary>
        /// Total number of available copies of the book.
        /// </summary>
        public int AvailableCopies { get; private set; }

        #region Navigation
        public Library Library { get; private set; }
        public ICollection<Loan> Loans { get; set; } = [];
        #endregion

        /// <summary>
        /// Creates a new instance of the <see cref="Book"/> class with a unique identifier.
        /// </summary>
        /// <param name="iSBN"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="publicationYear"></param>
        /// <param name="isAvailable"></param>
        /// <returns></returns>
        public static Book Create(
            string iSBN,
            string title,
            string author,
            int publicationYear,
            bool isAvailable = true)
        {
            var book = new Book(
                Guid.NewGuid(),
                iSBN,
                title,
                author,
                publicationYear);

            return book;
        }

        /// <summary>
        /// Updates the book's metadata.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="publicationYear"></param>
        /// <returns></returns>
        public Result UpdateMetaData(
            string title,
            string author,
            int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
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
                return Result.Failure(BookErrors.OutOfStock);

            if (amountToLend > AvailableCopies)
                return Result.Failure(BookErrors.InsufficientStock);

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
            AvailableCopies += amountToReturn;
            return Result.Success();
        }
    }
}
