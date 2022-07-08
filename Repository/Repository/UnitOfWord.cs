using System;
using Models.Entities;
using Repository.IRepository;
using Models.Configuration;

namespace Repository.Repository
{
    public class UnitOfWord : IUnitOfWord
    {
        private readonly RepositoryContext _context;

        public UnitOfWord(RepositoryContext context)
        {
            _context = context;
        }

        private IGenericRepository<Business> _business;
        private IGenericRepository<CtgAccount> _ctgAccount;
        private IGenericRepository<SeatDetail> _seatDetail;
        private IGenericRepository<SeatHeader> _seatHeader;
        private IGenericRepository<TypeBook> _typeBook;
        private IGenericRepository<TypeDocument> _typeDocument;
        private IGenericRepository<TypeFuente> _typeFuente;

        //

        public IGenericRepository<CtgAccount> CtgAccount
          => _ctgAccount ??= new GenericRepository<CtgAccount>(_context);

        public IGenericRepository<SeatDetail> SeatDetail
        => _seatDetail ??= new GenericRepository<SeatDetail>(_context);

        public IGenericRepository<SeatHeader> SeatHeader
        => _seatHeader ??= new GenericRepository<SeatHeader>(_context);

        public IGenericRepository<TypeBook> TypeBook
        => _typeBook ??= new GenericRepository<TypeBook>(_context);

        public IGenericRepository<TypeDocument> TypeDocument
        => _typeDocument ??= new GenericRepository<TypeDocument>(_context);

        public IGenericRepository<TypeFuente> TypeFuente
        => _typeFuente ??= new GenericRepository<TypeFuente>(_context);

        public IGenericRepository<Business> Businnes
        => _business ??= new GenericRepository<Business>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
