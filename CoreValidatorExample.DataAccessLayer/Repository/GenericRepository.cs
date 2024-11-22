using CoreValidatorExample.DataAccessLayer.Interfaces;
using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {

        private readonly CoreLoanValidatorExampleDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(CoreLoanValidatorExampleDbContext context)
        {
            _context = context;
            // Create the database if it doesn't exist
            _context.Database.EnsureCreated();
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id).ConfigureAwait(false);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync().ConfigureAwait(false);
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity).ConfigureAwait(false);
        //refactor to return base return class
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)

            {
                _dbSet.Remove(entity);

            }
        }
    }    
}
