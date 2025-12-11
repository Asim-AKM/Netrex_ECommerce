using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.PaymentAndPayoutMappers;
using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Application_Service.Services.PaymentAndPayoutServices.Implementation
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IRepository<Invoice> _genericrepository;
        public InvoiceManager(IRepository<Invoice> repository)
        {
            _genericrepository = repository;
        }

     
        public async Task<ApiResponse<FetchInvoiceDto>> GetInvoiceById(Guid InvoiceId)
        {
            var fetchinvoice = await _genericrepository.GetById(InvoiceId);
            if (fetchinvoice == null)
            {
                return ApiResponse<FetchInvoiceDto>.Fail("Invoice not found",ResponseType.NotFound);
            }

            var invoicedto = fetchinvoice.Map();
            return ApiResponse<FetchInvoiceDto>.Success(invoicedto,"Invoice retrieved successfully", ResponseType.Ok);
        }


        public async Task<ApiResponse<InvoiceDto>> GenerateInvoice(InvoiceDto dto)
        {
            var invoice = dto.Map();
            await _genericrepository.Create(invoice);
            await _genericrepository.SaveChangesAsync();
            return ApiResponse<InvoiceDto>.Success(dto,"Invoice generated successfully",ResponseType.Created);

        }
    }
}
