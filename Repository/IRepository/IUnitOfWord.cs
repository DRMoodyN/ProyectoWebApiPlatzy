using System;
using Models.Entities;

namespace Repository.IRepository
{
    public interface IUnitOfWord : IDisposable
    {
        IGenericRepository<Business> Businnes { get; }

        IGenericRepository<CtgAccount> CtgAccount { get; }

        IGenericRepository<SeatDetail> SeatDetail { get; }

        IGenericRepository<SeatHeader> SeatHeader { get; }

        IGenericRepository<TypeBook> TypeBook { get; }

        IGenericRepository<TypeDocument> TypeDocument { get; }

        IGenericRepository<TypeFuente> TypeFuente { get; }

        Task SaveAsync();
    }
}
