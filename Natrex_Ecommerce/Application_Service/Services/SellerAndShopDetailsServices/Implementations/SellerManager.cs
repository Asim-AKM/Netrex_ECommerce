using Application_Service.Common.Mappers.SellerAndShopDetailsMapper.SellerDtos;
using Application_Service.DTO_s.SellerDtos;
using Application_Service.Services.SellerAndShopDetailsServices.Interfaces;
using Domain_Service.Entities.SellerModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.SellerAndShopDetails;

namespace Application_Service.Services.SellerAndShopDetailsServices.Implementations
{

    public class SellerManager : ISellerManager
    {
        private readonly IRepository<Seller> _genericRepo;
        private readonly ISellerRepository _sellerRepository;

        public SellerManager(IRepository<Seller> repository, ISellerRepository sellerRepository)
        {
            _genericRepo = repository;
            _sellerRepository = sellerRepository;
        }


        public async Task CreateSeller(CreateSellerDto createSellerDto)
        {
            if (createSellerDto is null)
                throw new ArgumentNullException(nameof(createSellerDto));

            await _genericRepo.Create(createSellerDto.Map());
            await _genericRepo.SaveChangesAsync();
        }


        public async Task<bool> DeleteSeller(Guid SellerId)
        {
            var domain = await _genericRepo.GetById(SellerId);

            if (domain != null)
            {
                await _genericRepo.Delete(domain);
                return true;
            }

            return false;
        }

        public async Task<GetAllSellerDto> GetAllSeller(GetAllSellerDto getAllSellers)
        {
           var Details= await _sellerRepository.GetAllSellers(getAllSellers.Map());
            if(getAllSellers !=null)
            {
                return Details.MapToDto();
            }
            throw new ArgumentException(nameof(getAllSellers));
        }

        public async Task<GetByIdSellerDto?> GetSellerById(Guid SellerId)
        {
            if (SellerId == Guid.Empty)
                return null;

            var domain = await _genericRepo.GetById(SellerId);
            return domain?.Map();
        }

        public async Task<UpdateSellerDto> UpdateSeller(UpdateSellerDto updateSellerDto)
        {
            if (updateSellerDto is null)
                throw new ArgumentNullException(nameof(updateSellerDto));

            var domain = await _genericRepo.Update(updateSellerDto.Map());
            return domain.MapDomainToDto();
        }
    }
}
