using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories
{
    internal abstract class Repository<T>
        where T : Entity
    {
        protected readonly LibraryManagerDbContext DbContext;

        protected Repository(LibraryManagerDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual void Add(T entity) => DbContext.Add(entity);

        public void Delete(T entity) => DbContext.Remove(entity);
    }
}
