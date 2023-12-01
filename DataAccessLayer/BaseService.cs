using IDataAccessLayer;
using Playlistify.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        private readonly PlaylistifyContext _db;

        public BaseService(PlaylistifyContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(T entity, bool saved = true)
        {
            _db.Set<T>().Add(entity);

            if (saved) await _db.SaveChangesAsync();

        }

        public async Task DeleteAsync(T entity, bool saved = true)
        {
            await DeleteAsync(entity.Id, saved);

        }
        /// <summary>
        /// 未被实现
        /// </summary>
        /// <param name="id"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id, bool saved = true)
        {
            //_db.Configuration.ValidateOnSaveEnabled = false;
            //var t = new T() { Id = id };
            //_db.Entry(t).State = EntityState.Unchanged;
            //t.IsRemoved = true;

            //if (saved)
            //{
            //    await _db.SaveChangesAsync();
            //    _db.Configuration.ValidateOnSaveEnabled = true;
            //}

            // need to revise
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task EditAsync(T entity, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Entry(entity).State = EntityState.Modified;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }
        /// <summary>
        /// 未被实现
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 未被实现
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetById(Guid id)
        {
            // need to revise
            //return await _db.Set<T>().Where(m => !m.IsRemoved).AsNoTracking().FirstAsync(m => m.Id == id);
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
            _db.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
