namespace Application_Service.DTO_s.PaymentAndPayoutDtos
{
    public record FetchInvoiceDto(Guid InvoiceId,Guid OrderId,DateTime CreatedAt,double Total);

}
