using Application_Service.Common.Mappers.SellerAndShopDetailsMapper;
using Application_Service.Common.Mappers.SellerAnShopDetailsMapper;
using Application_Service.DTO_s.SellerDtos;
using Application_Service.Services.Interface;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.Implementation
{
    /// <summary>
    /// Implements the <see cref="ISellerManager"/> interface to manage seller operations such as creation, updating, deletion, and retrieval.
    /// </summary>
    public class SellerManager : ISellerManager
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="SellerManager"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work instance used for repository operations.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="unitOfWork"/> is null.</exception>
        public SellerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <summary>
        /// Creates a new seller record.
        /// </summary>
        /// <param name="createSellerDto">The DTO containing the seller data to create.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="createSellerDto"/> is null.</exception>
        public async Task CreateSeller(CreateSellerDto createSellerDto)
        {
            if (createSellerDto is null)
            {
                throw new ArgumentNullException(nameof(createSellerDto));
            }

            await _unitOfWork.Seller.Create(createSellerDto.Map());
        }

        /// <summary>
        /// Deletes an existing seller by its unique identifier.
        /// </summary>
        /// <param name="SellerId">The unique identifier of the seller to delete.</param>
        /// <returns>
        /// <c>true</c> if the seller was deleted successfully; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> DeleteSeller(Guid SellerId)
        {
            if (SellerId != Guid.Empty)
            {
                await _unitOfWork.Seller.Delete(SellerId);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves a seller by its unique identifier.
        /// </summary>
        /// <param name="SellerId">The unique identifier of the seller.</param>
        /// <returns>
        /// The <see cref="GetByIdSellerDto"/> containing seller details if found; otherwise, <c>null</c>.
        /// </returns>
        public async Task<GetByIdSellerDto?> GetSellerById(Guid SellerId)
        {
            if (SellerId == Guid.Empty)
            {
                return null;
            }

            var domain = await _unitOfWork.Seller.GetById(SellerId);
            return domain?.Map();
        }

        /// <summary>
        /// Updates an existing seller record.
        /// </summary>
        /// <param name="updateSellerDto">The DTO containing updated seller information.</param>
        /// <returns>The updated <see cref="UpdateSellerDto"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="updateSellerDto"/> is null.</exception>
        public async Task<UpdateSellerDto> UpdateSeller(UpdateSellerDto updateSellerDto)
        {
            if (updateSellerDto is null)
            {
                throw new ArgumentNullException(nameof(updateSellerDto));
            }

            var domain = await _unitOfWork.Seller.Update(updateSellerDto.Map());
            return domain.MapDomainToDto();
        }
    }
}
