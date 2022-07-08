using System;

namespace ServiceLogic.IServicesLogic
{
    public interface ICrud<T>
    {
        Task<T> AddAsync(T entity);
        Task<T> GetIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<bool> DeleteAsync(Guid id);
    }
}
