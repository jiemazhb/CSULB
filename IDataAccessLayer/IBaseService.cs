using Playlistify.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccessLayer
{
    public interface IBaseService<T>: IDisposable where T : BaseEntity
    {
        Task CreateAsync(T entity, bool saved = true);
        Task EditAsync(T entity, bool saved = true);
        Task DeleteAsync(T entity, bool saved = true);
        Task DeleteAsync(Guid id, bool saved = true);
        Task Save();
        Task<T> GetById(Guid id);
        IQueryable<T> GetAll();

    }
}
