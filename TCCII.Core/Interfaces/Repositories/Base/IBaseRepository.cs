using System.Linq.Expressions;

namespace TCCII.Core.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        TEntity FindById(params object[] keyValues);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
        Task Save();
        IEnumerable<TEntity> QueryableFor(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
    }
}
