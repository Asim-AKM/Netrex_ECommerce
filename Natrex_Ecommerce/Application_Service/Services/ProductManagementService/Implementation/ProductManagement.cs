using Application_Service.Common.Mappers.ProductMapper;
using Application_Service.DTO_s.ProductDTOS;
using Application_Service.Services.ProductManagementService.Interfaces;
using Domain_Service.RepoInterfaces.ProductRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.ProductManagementService.Implementation
{
    public class ProductManagement : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductCategories _productCategories;
        public ProductManagement(IUnitOfWork unitOfWork, IProductCategories productCategories)
        {
            _unitOfWork = unitOfWork;
            _productCategories = productCategories;

        }
        public async Task AddProduct(AddProductDto productDto)
        {
            var category = await _productCategories.GetByName(productDto.CategoryName);

            if (category == null) throw new Exception("Category not found");
            var domainProduct = productDto.MapProduct();
            domainProduct.SellerId = Guid.NewGuid();  //Static Value just for now 
            domainProduct.ProductCategoryId = category.CategoryId;
            var domainImage = productDto.MapProductImage(domainProduct.ProductId);
            await _unitOfWork.Products.Create(domainProduct);
            await _unitOfWork.ProductImages.Create(domainImage);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
