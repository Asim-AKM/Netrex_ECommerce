using Domain_Service.Entities.Roles;
using Domain_Service.Entities.UserCredentials;
using Domain_Service.Entities.Users;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Service.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public IRepository<User> Users =>  new Repository<User>(_context);

        public IRepository<UserCreadential> UserCreads => new Repository<UserCreadential>(_context);

        public IRepository<UserRole> UserRoles => new Repository<UserRole>(_context);

        public async Task<int> SaveChangesAsync()
        {
           return  await _context.SaveChangesAsync();
        }
    }
}
