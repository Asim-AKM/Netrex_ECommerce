using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.ProductMapper;
using Application_Service.DTO_s.ProductDTOS;
using Application_Service.Services.ProductManagementService.Interfaces;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.Cloudinary;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.ProductRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application_Service.Services.ProductManagementService.Implementation
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductImageRepo _productImageRepo;
        private readonly IProductCategories _productCategories;
        private readonly IRepository<Product> _genericProductRepo;
        private readonly IProductRepo _productRepo;
        private readonly ICloudinaryManager _cloudinaryManager;
        public ProductManager(IUnitOfWork unitOfWork, IProductCategories productCategories, IProductImageRepo productImageRepo, IRepository<Product> repository,ICloudinaryManager cloudinaryManager)
        {
            _unitOfWork = unitOfWork;
            _productCategories = productCategories;
            _productImageRepo = productImageRepo;
            _genericProductRepo = repository;
            _cloudinaryManager = cloudinaryManager;
        }
        public async Task<ApiResponse<AddProductDto>> AddProduct(AddProductDto productDto)
        {
            var category = await _productCategories.GetByName(productDto.CategoryName);
            if (category == null)
                return ApiResponse<AddProductDto>.Fail("Category not found", ResponseType.BadRequest);

            var product = productDto.MapProduct(category.CategoryId);

            await _unitOfWork.Products.Create(product);

            if (productDto.Images != null && productDto.Images.Any())
            {
                var productImages = productDto.Images.ToProductImages(product.ProductId);
                foreach (var img in productImages)
                {
                    await _unitOfWork.ProductImages.Create(img);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<AddProductDto>.Success(productDto, "Product added successfully", ResponseType.Created);
        }


        public async Task<ApiResponse<GetProductDto>> GetByProductId(Guid productId)
        {
            var product = await _genericProductRepo.GetById(productId);
            if (product == null)
                return ApiResponse<GetProductDto>.Fail("Product not found", ResponseType.NotFound);

            
            var images = await _productImageRepo.GetByProductId(productId);
            var productDto = GetProductMap.MapToGetProductDto(product, images);
            return ApiResponse<GetProductDto>.Success(productDto, "Product fetched successfully", ResponseType.Ok);
        }

       
        public async Task<ApiResponse<List<GetProductDto>>> GetAllProducts()
        {
            var products = await _genericProductRepo.GetAll();
            if (products == null || !products.Any())
                return ApiResponse<List<GetProductDto>>.Fail("No products found", ResponseType.NotFound);

            var images = await _productImageRepo.GetAllProductImages(); 
            var dto = products.GetAllProducts(images); 
            return ApiResponse<List<GetProductDto>>.Success(dto, "Products fetched successfully", ResponseType.Ok);
        }


        public async Task<ApiResponse<bool>> DeleteProduct(Guid productId)
        {
            var product = await _genericProductRepo.GetById(productId);

            if (product == null)
                return ApiResponse<bool>.Fail( Convert.ToString(false), ResponseType.NotFound);

            var images = await _productImageRepo.GetByProductId(productId);

            foreach (var img in images)
            {
                await _unitOfWork.ProductImages.Delete(img.ImageId);
            }

            await _genericProductRepo.Delete(product.ProductId);
            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<bool>.Success(true, "Product deleted successfully", ResponseType.Ok);
        }



        public async Task<ApiResponse<string>> UpdateProduct(UpdateProductDTOS productDto)
        {

            var product = await _unitOfWork.Products.GetById(productDto.ProductId);

            if (product == null)
                return ApiResponse<string>.Fail("Product not found", ResponseType.NotFound);

            productDto.Mapping(product);

            if (productDto.DeletedImagePublicIds != null &&
                productDto.DeletedImagePublicIds.Any())
            {
                await _cloudinaryManager.DeleteMultipleImagesAsync(
                    productDto.DeletedImagePublicIds);

                var existingImages =
                    await _productImageRepo.GetByProductId(product.ProductId);

                var imagesToDelete = existingImages
                    .Where(x => productDto.DeletedImagePublicIds.Contains(x.CloudPublicId))
                    .ToList();

                foreach (var img in imagesToDelete)
                {
                    await _unitOfWork.ProductImages.Delete(img.ImageId);
                }
            }

            
            if (productDto.Images != null && productDto.Images.Any())
            {
                var existingImages =
                    await _productImageRepo.GetByProductId(product.ProductId);

                foreach (var img in existingImages)
                {
                    await _unitOfWork.ProductImages.Delete(img.ImageId);
                }

                var newImages =
                    productDto.Images.ToProductImages(product.ProductId);

                foreach (var img in newImages)
                {
                    await _unitOfWork.ProductImages.Create(img);
                }
            }

            await _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<string>.Success(
                string.Empty,
                "Product updated successfully",
                ResponseType.Ok);
        }


        public async Task<ApiResponse<List<GetProvinceDto>>> GetAllProvinces()
        {
            var provinces = await _unitOfWork.Provinces.GetAll();
            return ApiResponse<List<GetProvinceDto>>.Success(provinces.Map(), "Provinces get succesfully");
        }

        public async Task<ApiResponse<List<GetCityDto>>> GetCitiesByProvinceId(Guid Id)
        {
            if (Id == Guid.Empty)
                return ApiResponse<List<GetCityDto>>.Fail("ProvinceId is not valid");

            var cities = await _productRepo.GetCitiesByProvinceId(Id);
            return ApiResponse<List<GetCityDto>>.Success(cities.Map(), "Cities Get Suuccesfuly");
        }

        public async Task<ApiResponse<List<ProductCategoryDto>>> GetCategoriesAsync()
        {
            var data = await _unitOfWork.ProductCategories.GetAll();

            var categories = data
                .Select(x => x.Map())
                .ToList();
            return ApiResponse<List<ProductCategoryDto>>.Success(categories, "Categories fetched successfully", ResponseType.Ok);

        }
    }
}
