using Application_Service.Services.ProductManagementService.Interfaces;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.ProductManagementService.Implementation
{
    public class ProductReviewManager : IProductReviewManager
    {
        private readonly IUnitOfWork _unitofWork;
        public ProductReviewManager(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public Task AddReviewAsync()
        {
            throw new NotImplementedException();
        }
    }
}
