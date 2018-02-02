using System;

namespace ListenThen.Domain.Interfaces.UoW
{
    public interface  IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}