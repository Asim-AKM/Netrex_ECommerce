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
            return obj;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            _dbSet.Remove(entity);
            return true;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task<T> Update(T obj)
        {
            _dbSet.Update(obj);
            return obj;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll(int? pageNumber = null, int? pageSize = null)
        {
            IQueryable<T> query = _dbSet;

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                int page = pageNumber.Value < 1 ? 1 : pageNumber.Value;
                int size = pageSize.Value < 1 ? 10 : pageSize.Value;

                query = query
                    .Skip((page - 1) * size)
                    .Take(size);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
    }
}


