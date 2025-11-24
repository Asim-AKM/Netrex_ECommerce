using Domain_Service.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.RepoInterfaces.GenericRepo
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<bool> Delete(T obj);
        Task<T> GetById(Guid id);

    }
}
