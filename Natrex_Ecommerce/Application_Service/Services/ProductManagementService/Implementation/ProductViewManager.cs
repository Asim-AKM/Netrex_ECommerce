using Application_Service.Common.Mappers.ProductMapper.ProductViewAndReviewMappers;
using Application_Service.DTO_s.ProductDTOS;
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
        public async Task<string> AddViewAsync(AddProductViewDto dto)
        {
            bool alreadyViewed = await _unitofWork.ProductView.AnyAsync(x =>
                 x.ProductId == dto.ProductId &&
             x.IPAddress == dto.IPAddress);

            if (alreadyViewed)
                return "Already Viewed";


            var product = await _unitofWork.Products.GetById(dto.ProductId);
            if (product != null)
            {
                var data = dto.ToEntity();
                product.TotalViews += 1;
                await _unitofWork.ProductView.Create(data);
                await _unitofWork.Products.Update(product);
            await _unitofWork.SaveChangesAsync();
                return "Viewed Successully";
            }
            return "Product Id is Wrong";
        }

        public async Task<int> GetTotalViewsByProductIdAsync(Guid productId)
        {
            var allViews = await _unitofWork.ProductView.GetAll();
            return allViews.Count(x => x.ProductId == productId);
        }
    }
}
