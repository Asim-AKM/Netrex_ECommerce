using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.Payment_PayoutDtos
{
    public record FetchInvoiceDto(Guid InvoiceId,Guid OrderId,DateTime CreatedAt,double Total);

}
