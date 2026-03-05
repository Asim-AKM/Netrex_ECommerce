using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Service.Persistance.Repositories.UserManagmentRepo_s
{
    public class CustomerRepo : Repository<Customer>, ICustomerRepo
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerbyFK(Guid userId)
        {
            return await _context.Customers.Where(x=>x.UserId==userId).FirstOrDefaultAsync()??new Customer();   
        }
    }
}
