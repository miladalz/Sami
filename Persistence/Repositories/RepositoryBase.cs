using Application.Interfaces.Repositories;
using Domain.Common;
using Domain.Dtos;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly SamiDbContext _context;
        private readonly DbSet<T> _entities;

        public RepositoryBase(SamiDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            var result = _entities.Add(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IList<T>> FindAll(PaginationRequest pr, Expression<Func<T, bool>>? filter = null)
        {
            var query = _entities.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.Take(pr.Take).Skip(pr.GetPage()).ToListAsync();
        }

        public async Task<T?> FindById(long id)
        {
            return await _entities.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Remove(T entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            var result = _entities.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
