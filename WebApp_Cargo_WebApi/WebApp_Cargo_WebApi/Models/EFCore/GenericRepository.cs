using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Cargo_WebApi.Models.EFCore
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly Cargo_AutomationContext _dbContext;
        public GenericRepository(Cargo_AutomationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(int id, T item)
        {
            _dbContext.Set<T>().Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
