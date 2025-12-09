using Application_Service.Common.Mappers.SellerAndShopDetailsMapper;
using Application_Service.Common.Mappers.SellerAnShopDetailsMapper;
using Application_Service.DTO_s.SellerDtos;
using Application_Service.Services.Interface;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.Implementation
{
    /// <summary>
    /// Provides services for managing seller-related operations such as creation, retrieval,
    /// update, and deletion. Implements the <see cref="ISellerManager"/> contract.
    /// </summary>
    public class SellerManager : ISellerManager
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="SellerManager"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work instance providing access to seller repositories.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="unitOfWork"/> parameter is <c>null</c>.
        /// </exception>
        public SellerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <summary>
        /// Creates a new seller in the system.
        /// </summary>
        /// <param name="createSellerDto">The data transfer object containing the seller details to create.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="createSellerDto"/> parameter is <c>null</c>.
        /// </exception>
        public async Task CreateSeller(CreateSellerDto createSellerDto)
        {
            if (createSellerDto is null)
                throw new ArgumentNullException(nameof(createSellerDto));

            await _unitOfWork.Seller.Create(createSellerDto.Map());
        }

        /// <summary>
        /// Deletes a seller using its unique identifier.
        /// </summary>
        /// <param name="SellerId">The unique identifier of the seller to delete.</param>
        /// <returns>
        /// A task that returns <c>true</c> if the seller is successfully deleted;
        /// otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> DeleteSeller(Guid SellerId)
        {
            var domain = await _unitOfWork.Seller.GetById(SellerId);

            if (domain != null)
            {
                await _unitOfWork.Seller.Delete(domain);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves a seller by its unique identifier.
        /// </summary>
        /// <param name="SellerId">The unique identifier of the seller to retrieve.</param>
        /// <returns>
        /// A task that returns a <see cref="GetByIdSellerDto"/> containing seller details if found;
        /// otherwise, <c>null</c>.
        /// </returns>
        public async Task<GetByIdSellerDto?> GetSellerById(Guid SellerId)
        {
            if (SellerId == Guid.Empty)
                return null;

            var domain = await _unitOfWork.Seller.GetById(SellerId);
            return domain?.Map();
        }

        /// <summary>
        /// Updates an existing seller record.
        /// </summary>
        /// <param name="updateSellerDto">The data transfer object containing updated seller information.</param>
        /// <returns>
        /// A task that returns the updated <see cref="UpdateSellerDto"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="updateSellerDto"/> parameter is <c>null</c>.
        /// </exception>
        public async Task<UpdateSellerDto> UpdateSeller(UpdateSellerDto updateSellerDto)
        {
            if (updateSellerDto is null)
                throw new ArgumentNullException(nameof(updateSellerDto));

            var domain = await _unitOfWork.Seller.Update(updateSellerDto.Map());
            return domain.MapDomainToDto();
        }
    }
}
