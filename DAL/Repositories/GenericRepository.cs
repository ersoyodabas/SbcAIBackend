using Sbc.DAL.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sbc.DAL.Repositories
{
    /// <summary>
    /// Generic Repository for all entities
    /// Provides CRUD operations and OData support
    /// </summary>
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly _DbContext _context;

        public GenericRepository()
        {
            _context = new _DbContext();
            _dbSet = _context.Set<TEntity>();
        }

        public GenericRepository(_DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        /// <summary>
        /// Returns IQueryable for OData support
        /// </summary>
        public IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Get entity by ID
        /// </summary>
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Add new entity
        /// </summary>
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update entity
        /// </summary>
        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete entity by ID
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Check if entity exists
        /// </summary>
        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.FindAsync(id) != null;
        }

        /// <summary>
        /// Get count of all entities
        /// </summary>
        public async Task<int> GetCountAsync()
        {
            return await _dbSet.CountAsync();
        }
    }
}
