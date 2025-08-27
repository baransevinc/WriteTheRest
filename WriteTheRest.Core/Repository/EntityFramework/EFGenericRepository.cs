using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WriteTheRest.Core.Repository.Abstract;
using WriteTheRest.Core.Repository.DbContexts;

namespace WriteTheRest.Core.Repository.EntityFramework
{
    public class EFGenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected readonly DbContextBase _context;
        private readonly DbSet<T> _dbSet;

        public EFGenericRepository(DbContextBase context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(short id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while accessing the database.");
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while accessing the database.");
            }

        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while adding the entity to the database.");
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while updating the entity in the database.");
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while deleting the entity from the database.");
            }
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while finding entities in the database.");
            }
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _dbSet.Where(predicate).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while finding the entity in the database.");
            }
        }
    }
}
