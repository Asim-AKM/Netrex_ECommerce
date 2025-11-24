using Infrastructure_Service.Data;
using Domain_Service.RepoInterfaces.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.GenericRepository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public async Task<T> Create(T obj)
        {
            await _dbSet.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> Delete(T obj)
        {
            _dbSet.Remove(obj);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);

        }

        public async Task<T> Update(T obj)
        {
            _dbSet.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
