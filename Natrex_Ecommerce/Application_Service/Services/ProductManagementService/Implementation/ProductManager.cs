using Application_Service.Common.Mappers.ProductMapper;
using Application_Service.DTO_s.ProductDTOS;
using Application_Service.Services.ProductManagementService.Interfaces;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.ProductRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Application_Service.Services.ProductManagementService.Implementation
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductImageRepo _productImageRepo;
        private readonly IProductCategories _productCategories;
        private readonly IRepository<Product> _genericProductRepo;
        public ProductManager(IUnitOfWork unitOfWork, IProductCategories productCategories, IProductImageRepo productImageRepo, IRepository<Product> repository)
        {
            _unitOfWork = unitOfWork;
            _productCategories = productCategories;
            _productImageRepo = productImageRepo;
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
            var productDto = MapToGetByIdProductDto.MapToGetbyProductDto(domainProduct, domainImage);
            return productDto;
        }

        public async Task UpdateProduct(UpdateProductDTOS productDto) 
        {
            var Product = await _unitOfWork.Products.GetById(productDto.ProductId); 
            if (Product == null)
            {
                throw new Exception("Product not found");
            }

            productDto.Mapping(Product);

            if (string.IsNullOrEmpty(productDto.ImageUrl))
            {
                await _unitOfWork.Products.Update(Product);
                await _unitOfWork.SaveChangesAsync();
                return;
            }

            var ProductImage = await _productImageRepo.GetByProductId(productDto.ProductId);

            if (ProductImage == null)
            {
                var newimage = new ProductImage();
                newimage.ProductId = productDto.ProductId;
                newimage.ImageUrl = productDto.ImageUrl;
                newimage.IsPrimary = true;
                newimage.UploadedAt = DateTime.UtcNow;
                await _unitOfWork.ProductImages.Create(newimage);

            }
            else
            {
                productDto.MapToExistingImage(ProductImage);

                await _unitOfWork.ProductImages.Update(ProductImage);
            }

            await _unitOfWork.Products.Update(Product);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
