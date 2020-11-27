using System;
using DataAccess.Repositories.UserRepository;

namespace DataAccess.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        // Repositories
        IUserRepository UserRepository();

        // Operations
        void Commit();
        void RollBack();
        void Begin();
        void Open();
        void Close();
    }
}
