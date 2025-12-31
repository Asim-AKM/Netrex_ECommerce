using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.SellerAndShopDetailsMapper.ShopDetailsDto;
using Application_Service.DTO_s.ShopDetailsDtos;
using Application_Service.Services.SellerAndShopDetailsServices.Interfaces;
using Domain_Service.Entities.SellerModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.SellerAndShopDetails;

namespace Application_Service.Services.SellerAndShopDetailsServices.Implementations
{
    /// <summary>
    /// Handles business logic for Shop Details operations such as creation, updating, deletion, and retrieval.
    /// </summary>
    public class ShopDetailsManager : IShopDetailsManager
    {
        private readonly IRepository<ShopDetail> _repository;
        //private readonly IShopDetailsRepository _shopDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopDetailsManager"/> class.
        /// </summary>
        /// <param name="repository">Generic repository for CRUD operations on <see cref="ShopDetail"/> entities.</param>
        public ShopDetailsManager(IRepository<ShopDetail> repository, IShopDetailsRepository shopDetailsRepository)
        {
            _repository = repository;
            //_shopDetails = shopDetailsRepository;
        }

        /// <summary>
        /// Creates new shop details asynchronously.
        /// </summary>
        /// <param name="createShopDetailsDto">The data required to create new shop details.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the created <see cref="CreateShopDetailsDto"/>.</returns>
        public async Task<ApiResponse<CreateShopDetailsDto>> CreateShopDetails(CreateShopDetailsDto createShopDetailsDto)
        {
            if (createShopDetailsDto == null)
                return ApiResponse<CreateShopDetailsDto>.Fail("Invalid request data", ResponseType.BadRequest);

            var domain = createShopDetailsDto.Map();

            if (domain == null)
                return ApiResponse<CreateShopDetailsDto>.Fail("Mapping failed", ResponseType.Conflict);

            await _repository.Create(domain);
            await _repository.SaveChangesAsync();

            return ApiResponse<CreateShopDetailsDto>.Success(createShopDetailsDto, "Shop details created successfully", ResponseType.Created);
        }

        /// <summary>
        /// Deletes shop details by its unique identifier asynchronously.
        /// </summary>
        /// <param name="shopDetailId">The unique identifier of the shop detail to delete.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing <c>true</c> if deletion is successful; otherwise <c>false</c> with an error message.</returns>
        public async Task<ApiResponse<bool>> DeleteShopDetails(Guid shopDetailId)
        {
            if (shopDetailId == Guid.Empty)
                return ApiResponse<bool>.Fail("Invalid ShopDetail Id", ResponseType.BadRequest);

            await _repository.Delete(shopDetailId);
            await _repository.SaveChangesAsync();

            return ApiResponse<bool>.Success(true, "ShopDetail deleted successfully", ResponseType.Ok);
        }

        /// <summary>
        /// Retrieves all shop details asynchronously.
        /// </summary>
        /// <returns>An <see cref="ApiResponse{T}"/> containing a list of <see cref="GetShopDetailsDto"/> entities.</returns>
        public async Task<ApiResponse<List<GetShopDetailsDto>>> GetAllShopDetails()
        {
            var shopDetails = await _repository.GetAll();

            if (shopDetails == null || !shopDetails.Any())
            {
                return ApiResponse<List<GetShopDetailsDto>>.Fail("No shop details found", ResponseType.NotFound);
            }

            var dtoList = shopDetails.Select(x => x.Map()).ToList();
            return ApiResponse<List<GetShopDetailsDto>>.Success(dtoList, "Operation performed successfully", ResponseType.Ok);
        }

        /// <summary>
        /// Retrieves shop details by its unique identifier asynchronously.
        /// </summary>
        /// <param name="shopDetailId">The unique identifier of the shop detail.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing <see cref="GetShopDetailsDto"/> if found; otherwise <c>null</c> with an error message.</returns>
        public async Task<ApiResponse<GetShopDetailsDto>> GetByIdShopDetails(Guid shopDetailId)
        {
            if (shopDetailId == Guid.Empty)
                return ApiResponse<GetShopDetailsDto>.Fail("Invalid ShopDetail Id", ResponseType.BadRequest);

            var domain = await _repository.GetById(shopDetailId);

            if (domain == null)
                return ApiResponse<GetShopDetailsDto>.Fail("ShopDetail not found", ResponseType.NotFound);

            var dto = domain.Map();
            return ApiResponse<GetShopDetailsDto>.Success(dto, "Operation performed successfully", ResponseType.Ok);
        }

        /// <summary>
        /// Updates existing shop details asynchronously.
        /// </summary>
        /// <param name="updateShopDetailsDto">The updated shop details information.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the updated <see cref="UpdateShopDetailsDto"/>.</returns>
        public async Task<ApiResponse<UpdateShopDetailsDto>> UpdateShopDetails(UpdateShopDetailsDto updateShopDetailsDto)
        {
            if (updateShopDetailsDto == null)
                return ApiResponse<UpdateShopDetailsDto>.Fail("Invalid request data", ResponseType.BadRequest);

            var domain = await _repository.Update(updateShopDetailsDto.MapToDomain());

            if (domain == null)
                return ApiResponse<UpdateShopDetailsDto>.Fail("ShopDetail not found", ResponseType.NotFound);

            await _repository.SaveChangesAsync();

            return ApiResponse<UpdateShopDetailsDto>.Success(updateShopDetailsDto, "Shop details updated successfully", ResponseType.Ok);
        }
    }
}
