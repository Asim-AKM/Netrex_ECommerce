using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.ProductMapper;
using Application_Service.DTO_s.ProductDTOS;
using Application_Service.Services.ProductManagementService.Interfaces;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.Enums;
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

        public async Task<ApiResponse<string>> DeleteProduct(Guid productId)
        {
            // Check if the product exists
            var domain = await _genericProductRepo.GetById(productId);
            if (domain == null)
            {
                ApiResponse<string>.Fail("Product not found", ResponseType.NotFound);
            }
            // Delete the product
            await _genericProductRepo.Delete(domain.ProductId);

            // Delete associated image
            var domainimage = await _unitOfWork.ProductImages.GetById(productId);
            // If an image exists, delete it
            if (domainimage != null)
            {
                await _unitOfWork.ProductImages.Delete(domainimage.ImageId);
            }

            // Save changes to the database
            await _genericProductRepo.SaveChangesAsync();
            return ApiResponse<string>.Success(string.Empty, "Product deleted successfully", ResponseType.Ok);
        }

        public async Task<ApiResponse<GetProductDto>> GetByProductId(Guid productId)
        {
            var domainProduct = await _genericProductRepo.GetById(productId);
            if (domainProduct == null)
            {
                ApiResponse<GetProductDto>.Fail("Product not found", ResponseType.NotFound);
            }
            var domainImage = await _unitOfWork.ProductImages.GetById(domainProduct.ProductId);
            var productDto = GetProductMap.MapToGetProductDto(domainProduct, domainImage);
            return ApiResponse<GetProductDto>.Success(productDto, "Product Fatch to Successfully", ResponseType.Ok);
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
