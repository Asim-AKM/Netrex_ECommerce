using Application_Service.Common.Mappers.ProductMapper;
using Application_Service.DTO_s.ProductDTOS;
using Application_Service.Services.ProductManagementService.Interfaces;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.ProductRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.ProductManagementService.Implementation
{
    public class ProductManagement : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductCategories _productCategories;
        private readonly IRepository<Product> _genericProductRepo;
        public ProductManagement(IUnitOfWork unitOfWork, IProductCategories productCategories, IRepository<Product> repository)
        {
            _unitOfWork = unitOfWork;
            _productCategories = productCategories;
            _genericProductRepo = repository;

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

        public async Task<bool> DeleteProduct(Guid productId)
        {
            var domain = await _genericProductRepo.GetById(productId);
            if (domain != null)
            {
                await _genericProductRepo.Delete(domain);
                var domainimage = await _unitOfWork.ProductImages.GetById(productId);
                if (domainimage != null)
                {
                    await _unitOfWork.ProductImages.Delete(domainimage);
                }
                await _genericProductRepo.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<GetByProductIdDto> GetByProductId(Guid productId)
        {
            var domainProduct = await _genericProductRepo.GetById(productId);
            if (domainProduct == null)
            {
                throw new Exception("Product not found");
            }
            var domainImage = await _unitOfWork.ProductImages.GetById(domainProduct.ProductId);
            var productDto = MapToGetByProductDto.MapToGetbyProductDto(domainProduct, domainImage);
            return productDto;
        }

    }

}    
   
