using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.PaymentAndPayoutMappers;
using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Domain_Service.Entities.SellerPaymentModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.PaymentAndPayoutServices.Implementation
{
    /// <summary>
    /// Handles seller payout related business operations such as
    /// creating payouts, retrieving payout details, and marking payouts as paid.
    /// </summary>
    /// <remarks>
    /// This class implements <see cref="ISellerPayoutManager"/> and acts as an
    /// application service within the Payment and Payout module.
    /// 
    /// It follows Clean Architecture principles by using repository abstractions
    /// to interact with the persistence layer.
    /// </remarks>
    public class SellerPayoutManager : ISellerPayoutManager
    {
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="SellerPayoutManager"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// Generic repository used for seller payout persistence operations.
        /// </param>
        public SellerPayoutManager(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        /// <summary>
        /// Creates a new seller payout based on the provided payout data.
        /// </summary>
        /// <param name="dto">
        /// Data transfer object containing seller payout creation information.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{AddSellerPayoutDto}"/> indicating successful
        /// creation of the seller payout.
        /// </returns>
        public async Task<ApiResponse<AddSellerPayoutDto>> CreateSellerPayout(AddSellerPayoutDto dto)
        {
            var sellerPayout = dto.Map();

            await _uow.SellerPayoutRepo.Create(sellerPayout);
            await _uow.SaveChangesAsync();

            return ApiResponse<AddSellerPayoutDto>.Success(
                dto,
                "Seller Payout Created Successfully",
                ResponseType.Created);
        }

        /// <summary>
        /// Retrieves seller payout details by payout identifier.
        /// </summary>
        /// <param name="sellerPayoutId">
        /// The unique identifier of the seller payout.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{GetSellerPayoutByIdDto}"/> containing payout data
        /// if found; otherwise, returns a NotFound response.
        /// </returns>
        public async Task<ApiResponse<GetSellerPayoutByIdDto>> GetSellerPayoutById(Guid sellerPayoutId)
        {
            var payout = await _uow.SellerPayoutRepo.GetById(sellerPayoutId);

            if (payout == null)
            {
                return ApiResponse<GetSellerPayoutByIdDto>.Fail(
                    "Seller Payout not found",
                    ResponseType.NotFound);
            }

            var response = payout.Map();

            return ApiResponse<GetSellerPayoutByIdDto>.Success(
                response,
                "Seller Payout retrieved successfully",
                ResponseType.Ok);
        }

        /// <summary>
        /// Updates the seller payout status to paid.
        /// </summary>
        /// <param name="sellerPayoutId">
        /// The unique identifier of the seller payout to update.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{GetSellerPayoutByIdDto}"/> indicating successful
        /// update of the payout status.
        /// </returns>
        public async Task<ApiResponse<GetSellerPayoutByIdDto>> UpdateSellerPayoutAsPaid(Guid sellerPayoutId)
        {
            var payout = await _uow.SellerPayoutRepo.GetById(sellerPayoutId);

            if (payout == null)
            {
                return ApiResponse<GetSellerPayoutByIdDto>.Fail(
                    "Seller Payout not found",
                    ResponseType.NotFound);
            }
            if(payout.PaymentStatus == PaymentStatus.success)
            {
                return ApiResponse<GetSellerPayoutByIdDto>.Fail(
                    "Seller Payout is already marked as Paid",
                    ResponseType.BadRequest);
            }
      
            if(payout.PaymentStatus == PaymentStatus.failed)
            {
                return ApiResponse<GetSellerPayoutByIdDto>.Fail(
                    "Seller Payout has Failed, cannot mark as Paid",
                    ResponseType.BadRequest);
            }
            payout.PaymentStatus = PaymentStatus.success;
            payout.PayOutDate = DateTime.UtcNow;

            await _uow.SellerPayoutRepo.Update(payout);
            await _uow.SaveChangesAsync();
            return ApiResponse<GetSellerPayoutByIdDto>.Success(
                payout.Map(),
                "Seller Payout Updated As Paid Successfully",
                ResponseType.Ok);
        }
    }
}
