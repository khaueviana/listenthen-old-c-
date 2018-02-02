using ListenThen.Domain.Interfaces;
using ListenThen.Domain.Interfaces.UoW;
using ListenThen.Infra.Data.Context;

namespace ListenThen.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ListenThenContext _context;

        public UnitOfWork(ListenThenContext context)
        {
            this._context = context;
        }

        public bool Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return rowsAffected > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}