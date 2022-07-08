using System.Linq.Expressions;

namespace Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetIdAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> GetAllAsync<O>(Expression<Func<T, bool>> where,
        Expression<Func<T, O>> orderBy);

        Task AddAsync(T entity);

        void Update(T entity);
    }
}
