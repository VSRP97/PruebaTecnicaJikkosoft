using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Abstractions
{
    public interface IRepository<T>
    {
        public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        public void Add(T entity);

        public void Delete(T entity);
    }
}
