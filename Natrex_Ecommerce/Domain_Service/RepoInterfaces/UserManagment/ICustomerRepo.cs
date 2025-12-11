using Domain_Service.Entities.UserManagmentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface ICustomerRepo 
    {
        Task GetAll(); 
    }
}
