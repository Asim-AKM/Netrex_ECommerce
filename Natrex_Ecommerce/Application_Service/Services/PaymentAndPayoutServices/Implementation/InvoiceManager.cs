using Application_Service.Common.Mappers.PaymentAndPayoutMappers;
using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Domain_Service.RepoInterfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.PaymentAndPayoutServices.Implementation
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FetchInvoiceDto> FetchInvoice(Guid InvoiceId)
        {
            var fetchinvoice = await _unitOfWork.Invoices.GetById(InvoiceId);
            if (fetchinvoice == null)
            {
                return null!;
            }

            return fetchinvoice.Map();
        }

        public async Task GenerateInvoice(InvoiceDto dto)
        {
            var invoice = dto.Map();
            await _unitOfWork.Invoices.Create(invoice);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
