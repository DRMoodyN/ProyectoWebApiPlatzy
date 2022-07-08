using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Models.Configuration;
using Repository.IRepository;

namespace Repository.Repository
{
    public class GenericRepository<T>
    : IGenericRepository<T> where T : class
    {
        private readonly RepositoryContext _context;
        private readonly DbSet<T> _set;

        public GenericRepository(RepositoryContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task AddAsync(T entity) => await _set.AddAsync(entity);

        public async Task<List<T>> GetAllAsync<O>(Expression<Func<T, bool>> where,
        Expression<Func<T, O>> orderBy)
        {
            return await _set.AsNoTracking()
            .Where(where)
            .OrderBy(orderBy)
            .ToListAsync();
        }

        public async Task<T> GetIdAsync(Expression<Func<T, bool>> expression)
        {
            return await _set.AsNoTracking()
            .FirstOrDefaultAsync(expression);
        }

        public void Update(T entity) => _set.Update(entity);
    }
}
