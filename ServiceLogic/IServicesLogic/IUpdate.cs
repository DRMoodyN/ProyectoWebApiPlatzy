using System;

namespace ServiceLogic.IServicesLogic
{
    public interface IUpdate<T>
    {
        Task<bool> UpdateAsync(Guid id, T entity);
    }
}
