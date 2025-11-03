using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Books;
using LibraryManager.Domain.Entities.LibraryBooks;
using LibraryManager.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Entities.Libraries
{
    public sealed class Library : Entity
    {

        private Library(
            Guid id,
            string name)
        {
            Id = id;
            Name = name;
        }

        private Library()
        {            
        }

        public Guid Id { get; private set; }

        /// <summary>
        /// Name of the library.
        /// </summary>
        public string Name { get; private set; }

        #region Navigation
        public ICollection<LibraryBook> LibraryBooks { get; private set; } = [];
        public ICollection<Member> Members { get; private set; } = [];
        #endregion

        public static Library Create(string name)
        {
            var library = new Library(
                Guid.NewGuid(),
                name);

            return library;
        }

        public Result Update(string name)
        {
            Name = name;

            return Result.Success();
        }
    }
}
