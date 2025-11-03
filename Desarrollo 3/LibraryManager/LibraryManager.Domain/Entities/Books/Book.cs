using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Libraries;
using LibraryManager.Domain.Entities.LibraryBooks;
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
            int publicationYear,
            DateTime createdAt)
        {
            Id = id;
            ISBN = iSBN;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            CreatedAt = createdAt;
        }

        private Book()
        {
        }

        public Guid  Id { get; private set; }

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
        /// Date the book was registered.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        #region Navigation

        public ICollection<LibraryBook> LibraryBooks { get; set; } = [];
        #endregion

        /// <summary>
        /// Creates a new instance of the <see cref="Book"/> class with a unique identifier.
        /// </summary>
        /// <param name="iSBN"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="publicationYear"></param>
        /// <returns></returns>
        public static Book Create(
            string iSBN,
            string title,
            string author,
            int publicationYear,
            DateTime utcNow)
        {
            var book = new Book(
                Guid.NewGuid(),
                iSBN,
                title,
                author,
                publicationYear,
                utcNow);

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
    }
}
