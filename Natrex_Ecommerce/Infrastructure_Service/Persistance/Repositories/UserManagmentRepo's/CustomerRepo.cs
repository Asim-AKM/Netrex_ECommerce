using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Service.Persistance.Repositories.UserManagmentRepo_s
{
    public class CustomerRepo(ApplicationDbContext context) : ICustomerRepo
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Customer> GetCustomerbyFK(Guid userId)
        {
            return await _context.Customers.Where(x=>x.UserId==userId).FirstOrDefaultAsync()??new Customer();   
        }
    }
}
