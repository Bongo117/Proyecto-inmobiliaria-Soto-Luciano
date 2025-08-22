using Inmobiliaria.MVC.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inmobiliaria.MVC.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly InmobiliariaContext _ctx;
        private readonly DbSet<T> _set;

        public EfRepository(InmobiliariaContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }

        public async Task<List<T>> GetAllAsync() => await _set.ToListAsync();
        public async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);
        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _set.Where(predicate).ToListAsync();
        public async Task AddAsync(T entity) { await _set.AddAsync(entity); await _ctx.SaveChangesAsync(); }
        public async Task UpdateAsync(T entity) { _set.Update(entity); await _ctx.SaveChangesAsync(); }
        public async Task DeleteAsync(int id)
        {
            var e = await GetByIdAsync(id);
            if (e is null) return;
            _set.Remove(e);
            await _ctx.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) => await _set.AnyAsync(predicate);
    }
}
