using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.SellerAndShopDetailsMapper;
using Application_Service.Common.Mappers.SellerAnShopDetailsMapper;
using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.DTO_s.SellerDtos;
using Application_Service.Services.Interface;
using Domain_Service.Entities.SellerModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Application_Service.Services.Implementation
{
    /// <summary>
    /// Provides services for managing seller-related operations such as creation, retrieval,
    /// update, and deletion. Implements the <see cref="ISellerManager"/> contract.
    /// </summary>
    public class SellerManager : ISellerManager
    {
        private readonly IRepository<Seller> _genericRepo;

        public SellerManager(IRepository<Seller> repository)
        {
            _genericRepo = repository;
        }

        public async Task<ApiResponse<bool>> DeleteSeller(Guid SellerId)
        {

            if (SellerId == Guid.Empty)
                return ApiResponse<bool>
                    .Fail("Invalid seller id");

            var domain = await _genericRepo.GetById(SellerId);

            if (domain == null)
                return ApiResponse<bool>
                    .Fail("Seller not found");

            await _genericRepo.Delete(domain);
            await _genericRepo.SaveChangesAsync();

            return ApiResponse<bool>
                .Success(true, "Seller deleted successfully");
        }

        public async Task<ApiResponse<GetByIdSellerDto?>> GetSellerById(Guid SellerId)
        {
            var domain = await _genericRepo.GetById(SellerId);

            if (domain == null)
                return ApiResponse<GetByIdSellerDto?>
                    .Fail("Seller not found");

            var resultDto = domain.Map();

            return ApiResponse<GetByIdSellerDto?>
                .Success(resultDto, "Seller fetched successfully");
        }

        public async Task<ApiResponse<CreateSellerDto>> InsertSeller(CreateSellerDto createSellerDto)
        {
            if (createSellerDto == null)
                return ApiResponse<CreateSellerDto>.Fail("Invalid request data");

            var domain = createSellerDto.Map();

            if (domain == null)
                return ApiResponse<CreateSellerDto>.Fail("Mapping failed");

            await _genericRepo.Create(domain);
            await _genericRepo.SaveChangesAsync();

            return ApiResponse<CreateSellerDto>
                .Success(createSellerDto, "Seller Created Successfully");
        }

        public async Task<ApiResponse<UpdateSellerDto>> UpdateSeller(UpdateSellerDto updateSellerDto)
        {
            if (updateSellerDto == null)
                return ApiResponse<UpdateSellerDto>
                    .Fail("Invalid request data");

            
            var domain = updateSellerDto.Map();

           
            var updatedDomain = await _genericRepo.Update(domain);

            if (updatedDomain == null)
                return ApiResponse<UpdateSellerDto>
                    .Fail("Seller not found");

            await _genericRepo.SaveChangesAsync();

           
            var resultDto = updatedDomain.MapDomainToDto();

            return ApiResponse<UpdateSellerDto>
                .Success(resultDto, "Seller Updated Successfully");

        }
    }
}
