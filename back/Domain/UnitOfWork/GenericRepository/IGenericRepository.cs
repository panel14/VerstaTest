using System.Linq.Expressions;

namespace OrderTest.Domain.UnitOfWork.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties);

        public TEntity? GetByID(object id);

        public void Insert(TEntity entity);

        public void Delete(object id);

        public void Delete(TEntity entity);

        public void Update(TEntity entity);
    }
}
