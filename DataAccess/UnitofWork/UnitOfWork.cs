﻿using DataAccess.Repositories.UserRepository;
using DataAccess.Database;

namespace DataAccess.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        // Properties
        private readonly DapperDbContext _dbContext;

        // Repositories
        private IUserRepository userRepository;

        // Repositories props
        public IUserRepository UserRepository() => userRepository ??= new UserRepository(_dbContext);

        public UnitOfWork(DapperDbContext dbContext) => _dbContext = dbContext;

        public void Open() => _dbContext.DbConnection.Open();

        public void Close() => _dbContext.DbConnection.Close();

        public void Begin() => _dbContext.DbTransaction = _dbContext.DbConnection.BeginTransaction();

        public void Commit() => _dbContext.DbTransaction.Commit();

        public void RollBack() => _dbContext.DbTransaction.Rollback();

        private void ResetRepositories()
        {
            userRepository = null;
        }

        #region Disposable Members
        public void Dispose()
        {
            _dbContext.Dispose();
            ResetRepositories();
        }

        
        #endregion
    }
}
