using Application_Service.DTO_s.Payment_PayoutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.PaymentAndPayoutServices.Interface
{
    public interface ISellerPayoutManager
    {
        Task CreateSellerPayout(AddSellerPayoutDto dto);
        Task UpdateSellerPayoutAsPaid(Guid sellerPayoutId);
        Task<FetchSellerPayoutDto> GetSellerPayoutById(Guid sellerPayoutId);

    }
}
