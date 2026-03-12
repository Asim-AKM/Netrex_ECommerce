using Domain_Service.RepoInterfaces.SellerAndShopDetails;

namespace Application_Service.Services.SellerAndShopDetailsServices.Implementations
{
    public class AdminSellerService : IAdminSellerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly  ISellerRepository _sellerRepository;

        public AdminSellerService(IUnitOfWork unitOfWork,ISellerRepository sellerrepository)
        {
            _unitOfWork = unitOfWork;
            _sellerRepository = sellerrepository;
        }
        public async Task<ApiResponse<GetSellerDto>> ApproveSellerAsync(Guid sellerId)
        {
            var seller=await _sellerRepository.GetById(sellerId);
            if (seller == null)
            {
                return ApiResponse<GetSellerDto>.Fail("Seller not found");
            }
            seller.Status = SellerStatus.Active;
            seller.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<GetSellerDto>.Success(default!, "Seller approved successfully");
        }

        public async Task<ApiResponse<List<GetSellerDto>>> GetPendingSellersAsync()
        {
            var sellersList = await _sellerRepository.GetAll();

            if (sellersList == null || !sellersList.Any())
            {
                return ApiResponse<List<GetSellerDto>>.Fail("No sellers found", ResponseType.NotFound);
            }

            // Filter for pending sellers
            var pendingSellers = sellersList
                .Where(s => s.Status == SellerStatus.Pending)
                .ToList();

            if (!pendingSellers.Any())
            {
                return ApiResponse<List<GetSellerDto>>.Fail("No pending sellers found", ResponseType.NotFound);
            }

            // Map to DTOs
            var sellerDtos = pendingSellers.Select(s => s.Map()).ToList();

            return ApiResponse<List<GetSellerDto>>.Success(sellerDtos, "Pending sellers retrieved successfully", ResponseType.Ok);
        }

        public async Task<ApiResponse<GetSellerDto>> RejectSellerAsync(Guid sellerId)
        {
            var seller = await _sellerRepository.GetById(sellerId);
            if (seller == null)
            {
                return ApiResponse<GetSellerDto>.Fail("Seller not found");
            }
            seller.Status = SellerStatus.Rejected;
            seller.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<GetSellerDto>.Success(default!, "Seller rejected successfully");
        }

        public async Task<ApiResponse<GetSellerDto>> SuspendSellerAsync(Guid sellerId)
        {
            var seller = await _sellerRepository.GetById(sellerId);
            if (seller == null)
            {
                return ApiResponse<GetSellerDto>.Fail("Seller not found");
            }
            seller.Status = SellerStatus.Suspended;
            seller.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<GetSellerDto>.Success(default!, "Seller suspended successfully");
        }
    }
}
