using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.SellerAndShopDetailsMapper.ShopDetailsDto;
using Application_Service.DTO_s.ShopDetailsDtos;
using Application_Service.Services.SellerAndShopDetailsServices.Interfaces;
using Domain_Service.Entities.SellerModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.SellerAndShopDetails;

namespace Application_Service.Services.SellerAndShopDetailsServices.Implementations
{
    public class ShopDetailsManager : IShopDetailsManager
    {
        private readonly IRepository<ShopDetail> _repository;
        private readonly IShopDetailsRepository _shopDetails;
        public ShopDetailsManager(IRepository<ShopDetail> repository, IShopDetailsRepository shopDetailsRepository)
        {
            _repository = repository;
            _shopDetails = shopDetailsRepository;
        }

        public async Task<ApiResponse<CreateShopDetailsDto>> CreateShopDetails(CreateShopDetailsDto createShopDetailsDto)
        {
            if (createShopDetailsDto == null)
                return ApiResponse<CreateShopDetailsDto>.Fail("Invailed Request data");

            var Damain = createShopDetailsDto.Map();

            if (Damain == null)
                return ApiResponse<CreateShopDetailsDto>.Fail("Mapping failed");

            await _repository.Create(Damain);
            await _repository.SaveChangesAsync();

            return ApiResponse<CreateShopDetailsDto>.Success(
                createShopDetailsDto,
                "Shop details created successfully");

        }

        public async Task<ApiResponse<bool>> DeleteShopDetails(Guid ShopDetailId)
        {
            if (ShopDetailId == Guid.Empty)
                return ApiResponse<bool>.Fail("Invailed ShopDetail Id");

            await _repository.Delete(ShopDetailId);
            await _repository.SaveChangesAsync();

            return ApiResponse<bool>.Success(true, "ShopDetail deleted successfully");

        }

        public async Task<ApiResponse<GetAllShopDetailsDto>> GetAllShopDetails()
        {
            var shopDetails = await _shopDetails.GetAllShopDetails();
           

            if (shopDetails == null)
            {
                return ApiResponse<GetAllShopDetailsDto>.Fail("No shop details found");
            }

            return ApiResponse<GetAllShopDetailsDto>.Success(shopDetails.MapToDto(),"Operation Performed Successfully");
        }

        public async Task<ApiResponse<GetByIdShopDetailsDto>> GetByIdShopDetails(Guid ShopDetailId)
        {
            if(ShopDetailId==Guid.Empty)
                return ApiResponse<GetByIdShopDetailsDto>
                    .Fail("Invailed ShopDetail Id");

            var Domain=await _repository.GetById(ShopDetailId);

            if(Domain==null)
                return ApiResponse<GetByIdShopDetailsDto>
                    .Fail("ShopDetail not found");

            var dto=Domain.Map();
                return ApiResponse<GetByIdShopDetailsDto>
                   .Success(dto,"Operation Performed Successfully");
        }

        public async Task<ApiResponse<UpdateShopDetailsDto>> UpdateShopDetails(UpdateShopDetailsDto updateShopDetailsDto)
        {
            if(updateShopDetailsDto==null)
                return ApiResponse<UpdateShopDetailsDto>
                    .Fail("Invailed Request data");

            var Domain=await _repository.Update(updateShopDetailsDto.MapToDomain());
            
            if(Domain==null)
                return ApiResponse<UpdateShopDetailsDto>
                    .Fail("ShopDetail not found");

            await _repository.SaveChangesAsync();

            return ApiResponse<UpdateShopDetailsDto>
                .Success(updateShopDetailsDto,"Shop details updated successfully");

        }
    }
}
