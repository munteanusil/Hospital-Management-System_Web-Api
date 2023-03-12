using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts
{
    public interface IBaseRepository<TEntity>
    {
        //oferă metode specifice pentru a efectua operații de tip CRUD pe entități de un tip specific
        IQueryable<TEntity> Get(
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<TEntity> SingleOrDefaultAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<TEntity> InsertAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Dispose();
    }
}
