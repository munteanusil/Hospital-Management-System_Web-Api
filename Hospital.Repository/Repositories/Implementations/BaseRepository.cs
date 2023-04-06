using Hospital_Management_System_Web_Api.EntitiesModels;
using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Hospital_Management_System_Web_Api.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System_Web_Api.Abstractions;

namespace Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Implementations
{
    //Clasa BaseRepository<TEntity> este o clasă abstractă care servește ca o clasă de bază pentru toate repository-urile definite în
    //cadrul aplicației. Aceasta conține funcționalitate comună pe care o vor utiliza toate repository-urile, precum și definiția metodelor
    //pe care acestea trebuie să le implementeze.

    public abstract class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class, IBaseEntity, new()
    {

        
        protected readonly HospitalDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(HospitalDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }


         public IQueryable<TEntity> Get(
         Func<IQueryable<TEntity>, IIncludableQueryable <TEntity, object>> include = null,
         Expression<Func<TEntity, bool>> filter = null,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
         {
              IQueryable<TEntity> query = _dbSet;

              if (include != null) 
                query = include(query);

               if (filter != null) 
                 query = query.Where(filter);

                if (orderBy != null) 
                  query = orderBy(query);

              return query;
          }

        public async Task<TEntity> SingleOrDefaultAsync(
            Expression<Func<TEntity,bool>> filter =null,
            Func<IQueryable<TEntity>, 
            IIncludableQueryable<TEntity,object>> include = null)
        { IQueryable<TEntity> query = _dbSet;

            if (include != null) query = include(query);

               if(filter != null) query = query.Where(filter);

                return await query.SingleOrDefaultAsync();
        }
        
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity); 
            return result.Entity;
        }
        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }


    }
}
