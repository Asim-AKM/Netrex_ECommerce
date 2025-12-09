using Application_Service.Common.Mappers.SellerAndShopDetailsMapper;
using Application_Service.Common.Mappers.SellerAnShopDetailsMapper;
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
