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
        private readonly ICloudinaryManager _cloudinaryManager;
        public ProductManager(IUnitOfWork unitOfWork,ICloudinaryManager cloudinaryManager)
        {
            _unitOfWork = unitOfWork;
            _cloudinaryManager = cloudinaryManager;
        }
        public async Task<ApiResponse<AddProductDto>> AddProduct(AddProductDto productDto)
        {
            var category = await _unitOfWork.ProductCategoryRepo.GetByName(productDto.CategoryName);
            if (category == null)
                return ApiResponse<AddProductDto>.Fail("Category not found", ResponseType.BadRequest);

            var product = productDto.MapProduct(category.CategoryId);

            await _unitOfWork.ProductRepo.Create(product);

            if (productDto.Images != null && productDto.Images.Any())
            {
                var productImages = productDto.Images.ToProductImages(product.ProductId);
                foreach (var img in productImages)
                {
                    await _unitOfWork.ProductImageRepo.Create(img);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<AddProductDto>.Success(productDto, "Product added successfully", ResponseType.Created);
        }


        public async Task<ApiResponse<GetProductDto>> GetByProductId(Guid productId)
        {
            var product = await _unitOfWork.ProductRepo.GetById(productId);
            if (product == null)
                return ApiResponse<GetProductDto>.Fail("Product not found", ResponseType.NotFound);

            
            var images = await _unitOfWork.ProductImageRepo.GetByProductId(productId);
            var productDto = GetProductMap.MapToGetProductDto(product, images);
            return ApiResponse<GetProductDto>.Success(productDto, "Product fetched successfully", ResponseType.Ok);
        }

       
        public async Task<ApiResponse<List<GetProductDto>>> GetAllProducts()
        {
            var products = await _unitOfWork.ProductRepo.GetAll();
            if (products == null || !products.Any())
                return ApiResponse<List<GetProductDto>>.Fail("No products found", ResponseType.NotFound);

            var images = await _unitOfWork.ProductImageRepo.GetAllProductImages(); 
            var dto = products.GetAllProducts(images); 
            return ApiResponse<List<GetProductDto>>.Success(dto, "Products fetched successfully", ResponseType.Ok);
        }


        public async Task<ApiResponse<bool>> DeleteProduct(Guid productId)
        {
            var product = await _unitOfWork.ProductRepo.GetById(productId);
            if (product == null)
                return ApiResponse<bool>.Fail(Convert.ToString(false), ResponseType.NotFound);

            var images = await _unitOfWork.ProductImageRepo.GetByProductId(productId);

            try
            {
                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    foreach (var img in images)
                        await _unitOfWork.ProductImageRepo.Delete(img.ImageId);

                    await _unitOfWork.ProductRepo.Delete(product.ProductId);
                });

                return ApiResponse<bool>.Success(true, "Product deleted successfully", ResponseType.Ok);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Failed to delete product: {ex.Message}", ResponseType.InternalServerError);
            }
        }



        public async Task<ApiResponse<string>> UpdateProduct(UpdateProductDTOS productDto)
        {
            var product = await _unitOfWork.ProductRepo.GetById(productDto.ProductId);
            if (product == null)
                return ApiResponse<string>.Fail("Product not found", ResponseType.NotFound);

            productDto.Mapping(product);

            try
            {
                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    if (productDto.DeletedImagePublicIds != null && productDto.DeletedImagePublicIds.Any())
                    {
                        await _cloudinaryManager.DeleteMultipleImagesAsync(productDto.DeletedImagePublicIds);

                        var existingImages = await _unitOfWork.ProductImageRepo.GetByProductId(product.ProductId);
                        var imagesToDelete = existingImages
                            .Where(x => productDto.DeletedImagePublicIds.Contains(x.CloudPublicId))
                            .ToList();

                        foreach (var img in imagesToDelete)
                            await _unitOfWork.ProductImageRepo.Delete(img.ImageId);
                    }

                    if (productDto.Images != null && productDto.Images.Any())
                    {
                        var existingImages = await _unitOfWork.ProductImageRepo.GetByProductId(product.ProductId);

                        foreach (var img in existingImages)
                            await _unitOfWork.ProductImageRepo.Delete(img.ImageId);

                        var newImages = productDto.Images.ToProductImages(product.ProductId);

                        foreach (var img in newImages)
                            await _unitOfWork.ProductImageRepo.Create(img);
                    }

                    await _unitOfWork.ProductRepo.Update(product);
                });

                return ApiResponse<string>.Success(string.Empty, "Product updated successfully", ResponseType.Ok);
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Fail($"Failed to update product: {ex.Message}", ResponseType.InternalServerError);
            }
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

            var cities = await _unitOfWork.ProductRepo.GetCitiesByProvinceId(Id);
            return ApiResponse<List<GetCityDto>>.Success(cities.Map(), "Cities Get Suuccesfuly");
        }

        public async Task<ApiResponse<List<ProductCategoryDto>>> GetCategoriesAsync()
        {
            var data = await _unitOfWork.ProductCategoryRepo.GetAll();

            var categories = data
                .Select(x => x.Map())
                .ToList();
            return ApiResponse<List<ProductCategoryDto>>.Success(categories, "Categories fetched successfully", ResponseType.Ok);

        }
    }
}
