using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.PaymentAndPayoutMappers;
using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Application_Service.Services.PaymentAndPayoutServices.Implementation
{
    /// <summary>
    /// Handles payment-related business operations such as
    /// processing payments and retrieving payment details.
    /// </summary>
    /// <remarks>
    /// This class implements <see cref="IPaymentDetailManager"/> and serves
    /// as an application service in the Payment and Payout module.
    /// 
    /// It follows Clean Architecture principles by interacting with the
    /// persistence layer through repository abstractions.
    /// </remarks>
    public class PaymentDetailManager : IPaymentDetailManager
    {
        private readonly IRepository<PaymentDetail> _genericpaymentDetailRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentDetailManager"/> class.
        /// </summary>
        /// <param name="repository">
        /// Generic repository used for payment detail persistence operations.
        /// </param>
        public PaymentDetailManager(IRepository<PaymentDetail> repository)
        {
            _genericpaymentDetailRepository = repository;
        }

        /// <summary>
        /// Processes a payment based on the provided payment data.
        /// </summary>
        /// <param name="dto">
        /// Data transfer object containing payment processing information.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{ProcessPaymentDto}"/> indicating successful
        /// processing of the payment.
        /// </returns>
        public async Task<ApiResponse<ProcessPaymentDto>> ProcessPayment(ProcessPaymentDto dto)
        {
            var payment = dto.Map();

            await _genericpaymentDetailRepository.Create(payment);
            await _genericpaymentDetailRepository.SaveChangesAsync();

            return ApiResponse<ProcessPaymentDto>.Success(
                dto,
                "Payment processed successfully",
                ResponseType.Created);
        }

        /// <summary>
        /// Retrieves payment details by payment identifier.
        /// </summary>
        /// <param name="paymentId">
        /// The unique identifier of the payment.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{GetPaymentByIdDto}"/> containing payment data
        /// if found; otherwise, returns a NotFound response.
        /// </returns>
        public async Task<ApiResponse<GetPaymentByIdDto>> GetPaymentById(Guid paymentId)
        {
            var data = await _genericpaymentDetailRepository.GetById(paymentId);

            if (data == null)
            {
                return ApiResponse<GetPaymentByIdDto>.Fail(
                    "Payment not found",
                    ResponseType.NotFound);
            }

            var response = data.Map();

            return ApiResponse<GetPaymentByIdDto>.Success(
                response,
                "Payment retrieved successfully",
                ResponseType.Ok);
        }
    }
}
