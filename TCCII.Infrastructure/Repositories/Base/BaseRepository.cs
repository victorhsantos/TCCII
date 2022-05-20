using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TCCII.Deputados.Core.Entities.Base;
using TCCII.Deputados.Core.Interfaces.Repositories.Base;
using TCCII.Deputados.Infrastructure.Data;

namespace TCCII.Deputados.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
    {
        public DeputadosDbContext Context { get; }
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(DeputadosDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedAt = DateTime.UtcNow;
                baseEntity.UpdatedAt = DateTime.UtcNow;
                baseEntity.ExcludedAt = DateTime.Parse("9999-12-31");
            }

            await DbSet.AddAsync(entity);
            return entity;
        }

        public TEntity Remove(TEntity entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.ExcludedAt = DateTime.UtcNow;
                DbSet.Update(entity);
            }
            else
            {
                DbSet.Remove(entity);
            }

            return entity;
        }

        public TEntity FindById(params object[] ids)
        {
            return DbSet.Find(ids);
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.UpdatedAt = DateTime.UtcNow;
            }

            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;

            return entity;
        }

        public virtual IEnumerable<TEntity> QueryableFor(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            Context.Dispose();
        }


        #endregion IDisposable
    }
}
