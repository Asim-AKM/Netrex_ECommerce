namespace Application_Service.DTO_s.Payment_PayoutDtos
{
    public record FetchInvoiceDto(Guid InvoiceId,Guid OrderId,DateTime CreatedAt,double Total);

}
