using Application_Service.DTO_s.Payment_PayoutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.Interface
{
    public interface IInvoiceManager
    {
        Task GenerateInvoice(InvoiceDto dto);
        Task<FetchInvoiceDto> FetchInvoice(Guid InvoiceId);
    }
}
