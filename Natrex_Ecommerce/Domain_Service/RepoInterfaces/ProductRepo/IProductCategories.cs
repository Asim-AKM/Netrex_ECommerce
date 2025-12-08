using Domain_Service.Entities.ProductAndCategoryModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductCategories
    {
        Task<ProductCategory> GetByName(string name);
    }
}
