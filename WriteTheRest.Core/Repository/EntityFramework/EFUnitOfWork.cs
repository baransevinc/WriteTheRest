using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriteTheRest.Core.Repository.Abstract;
using WriteTheRest.Core.Repository.DbContexts;

namespace WriteTheRest.Core.Repository.EntityFramework
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContextBase _context;
        private readonly Dictionary<Type, object> _repositories;
        private IDbContextTransaction _transaction;

        public EFUnitOfWork(DbContextBase context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<T> Repository<T>() where T : class, new()
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                _repositories[typeof(T)] = new EFGenericRepository<T>(_context);
            }
            return (IGenericRepository<T>)_repositories[typeof(T)];
        }


        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
