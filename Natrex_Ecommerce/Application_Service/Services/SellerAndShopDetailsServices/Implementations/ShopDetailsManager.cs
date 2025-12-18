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

        public async Task<CreateShopDetailsDto> CreateShopDetails(CreateShopDetailsDto createShopDetailsDto)
        {
            if (createShopDetailsDto != null)
            {
                var Data = await _repository.Create(createShopDetailsDto.Map());
                return Data.MapToCreateShopDto();

            }
            throw new Exception(nameof(CreateShopDetails));
        }

        public async Task<bool> DeleteShopDetails(Guid ShopDetailId)
        {
            var Details = await _repository.Delete(ShopDetailId);
            if (!Details)
            {
                return false;
            }
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<GetAllShopDetailsDto> GetAllShopDetails()
        {
          var Details=await _shopDetails.GetAllShopDetails();
            if(Details != null)
            {
                return Details.MapToDto();
            }
            throw new Exception(nameof(GetAllShopDetails));
        }

        public async Task<GetByIdShopDetailsDto> GetByIdShopDetails(Guid ShopDetailId)
        {
         
          var Data=await _repository.GetById(ShopDetailId);
            if(Data != null)
            {
                return Data.Map();
            }
            throw new Exception(nameof(GetByIdShopDetails));
        }

        public async Task<UpdateShopDetailsDto> UpdateShopDetails(UpdateShopDetailsDto updateShopDetailsDto)
        {
          var Data=await _repository.Update(updateShopDetailsDto.MapToDomain());
            if( Data != null)
            {
                return Data.MapToUpdateDto();
            }
            throw new Exception(nameof(UpdateShopDetails));
        }
    }
}
