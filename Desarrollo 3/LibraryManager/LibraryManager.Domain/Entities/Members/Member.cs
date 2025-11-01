using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Members
{
    /// <summary>
    /// Represents a member of a library
    /// </summary>
    public sealed class Member : Entity
    {
        private Member(Guid id, FullName fullName, string email) : base(id)
        {
            FullName = fullName;
            Email = email;
        }

        private Member()
        {
            
        }

        /// <summary>
        /// Full name of the member
        /// </summary>
        public FullName FullName { get; private set; }

        /// <summary>
        /// Email address of the member
        /// </summary>
        public string Email { get; private set; }


        #region Navigation
        /// <summary>
        /// Colection of books borrowed by the member
        /// </summary>
        public ICollection<Book> BorrowedBooks { get; private set; }
        #endregion

        /// <summary>
        /// Creates a new instance of the <see cref="Member"/> class with a unique identifier.
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="email"></param>
        /// <returns>A new <see cref="Member"/> object initialized with the specified full name and email address.</returns>
        public static Member Create(
            FullName fullname,
            string email)
        {
            var member = new Member(
                Guid.NewGuid(),
                fullname,
                email);

            return member;
        }

        /// <summary>
        /// Updates the member's information.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="email"></param>
        /// <returns>A <see cref="Result"></returns>
        public Result Update(
            FullName fullName,
            string email)
        {
            FullName = fullName;
            Email = email;

            return Result.Success();
        }
    }
}
