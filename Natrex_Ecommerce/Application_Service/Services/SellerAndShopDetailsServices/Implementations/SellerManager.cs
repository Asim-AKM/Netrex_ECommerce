namespace Application_Service.Services.Implementation
{
    /// <summary>
    /// Handles business logic for Seller operations such as creation, updating, deletion, and retrieval.
    /// </summary>
    public class SellerManager : ISellerManager
    {
        private readonly IUnitOfWork _uow;
        // private readonly ISellerRepository _sellerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SellerManager"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit of work for managing repositories and transactions.</param>
        public SellerManager(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
           // _sellerRepository = sellerRepository;
        }

        /// <summary>
        /// Deletes a seller by its unique identifier asynchronously.
        /// </summary>
        /// <param name="SellerId">The unique identifier of the seller to delete.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing <c>true</c> if deletion is successful; otherwise <c>false</c> with an error message.</returns>
        public async Task<ApiResponse<bool>> DeleteSeller(Guid SellerId)
        {
            if (SellerId == Guid.Empty)
                return ApiResponse<bool>.Fail("Invalid seller id", ResponseType.BadRequest);

            await _uow.SellerRepo.Delete(SellerId);
            await _uow.SaveChangesAsync();

            return ApiResponse<bool>.Success(true, "Seller deleted successfully", ResponseType.Ok);
        }

        /// <summary>
        /// Retrieves all sellers asynchronously.
        /// </summary>
        /// <returns>An <see cref="ApiResponse{T}"/> containing a list of <see cref="GetSellerDto"/> entities.</returns>
        public async Task<ApiResponse<List<GetSellerDto>>> GetAllSellerList()
        {
            var sellersList = await _uow.SellerRepo.GetAll();
            if (sellersList == null || !sellersList.Any())
            {
                return ApiResponse<List<GetSellerDto>>.Fail("No Sellers found", ResponseType.NotFound);
            }

            var sellerDtos = sellersList.Select(x => x.Map()).ToList();
            return ApiResponse<List<GetSellerDto>>.Success(sellerDtos, "Operation performed successfully", ResponseType.Ok);
        }

        /// <summary>
        /// Retrieves a seller by its unique identifier asynchronously.
        /// </summary>
        /// <param name="SellerId">The unique identifier of the seller.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing <see cref="GetSellerDto"/> if found; otherwise <c>null</c> with an error message.</returns>
        public async Task<ApiResponse<GetSellerDto?>> GetSellerById(Guid SellerId)
        {
            if (SellerId == Guid.Empty)
                return ApiResponse<GetSellerDto?>.Fail("Invalid seller id", ResponseType.BadRequest);

            var domain = await _uow.SellerRepo.GetById(SellerId);

            if (domain == null)
                return ApiResponse<GetSellerDto?>.Fail("Seller not found",ResponseType.NotFound);

            var resultDto = domain.Map();
            return ApiResponse<GetSellerDto?>.Success(resultDto, "Seller fetched successfully", ResponseType.Ok);
        }

        /// <summary>
        /// Creates a new seller asynchronously.
        /// </summary>
        /// <param name="createSellerDto">The data required to create a new seller.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the created <see cref="CreateSellerDto"/>.</returns>
        public async Task<ApiResponse<CreateSellerDto>> CreateSeller(CreateSellerDto createSellerDto)
        {
            if (createSellerDto == null)
                return ApiResponse<CreateSellerDto>.Fail("Invalid request data", ResponseType.BadRequest);

            var domain = createSellerDto.Map();

            if (domain == null)
                return ApiResponse<CreateSellerDto>.Fail("Mapping failed", ResponseType.Conflict);

            await _uow.SellerRepo.Create(domain);
            await _uow.SaveChangesAsync();

            return ApiResponse<CreateSellerDto>.Success(createSellerDto, "Seller created successfully",ResponseType.Created);
        }

        /// <summary>
        /// Updates an existing seller asynchronously.
        /// </summary>
        /// <param name="updateSellerDto">The updated seller information.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the updated <see cref="UpdateSellerDto"/>.</returns>
        public async Task<ApiResponse<UpdateSellerDto>> UpdateSeller(UpdateSellerDto updateSellerDto)
        {
            if (updateSellerDto == null)
                return ApiResponse<UpdateSellerDto>.Fail("Invalid request data", ResponseType.BadRequest);

            var domain = updateSellerDto.Map();
            var updatedDomain = await _uow.SellerRepo.Update(domain);

            if (updatedDomain == null)
                return ApiResponse<UpdateSellerDto>.Fail("Seller not found", ResponseType.NotFound);

            await _uow.SaveChangesAsync();
            var resultDto = updatedDomain.MapDomainToDto();

            return ApiResponse<UpdateSellerDto>.Success(resultDto, "Seller updated successfully", ResponseType.Ok);
        }
    }
}
