using Application_Service.Services.ProductManagementService.Interfaces;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.ProductManagementService.Implementation
{
    public class ProductViewManager : IProductViewManager
    {
        private readonly IUnitOfWork _unitofWork;
        public ProductViewManager(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public Task AddViewAsync()
        {
            throw new NotImplementedException();
        }
    }
}
