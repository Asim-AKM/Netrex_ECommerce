

namespace Application_Service.Services.CartAndOrderModuleServices.OrderServices.Implementation
{
    public class OrderManager(IUnitOfWork _unitOfWork,IPaymentManager _paymentManager) : IOrderManager
    {
        public async Task<ApiResponse<GetOrderDto>> CreateOrderAsync(Guid customerId,PaymentDetailDto paymentDetail)
        {
            var cart = await _unitOfWork.CartRepo.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if (cart == null)
                return ApiResponse<GetOrderDto>.Fail("Cart Cannot Found", ResponseType.NotFound);

            var cartItems = await _unitOfWork.CartItemRepo.GetCartItemsByCartId(cart.CartId);
            if (!cartItems.Any())
                return ApiResponse<GetOrderDto>.Fail("Cart is Empty", ResponseType.NotFound);
            var productList = new List<(Product product, int quantity)>();
            double totalAmount = 0;
            foreach (var item in cartItems)
            {
                var product = await _unitOfWork.ProductRepo.GetById(item.ProductId);
                if (product.StockQuantity < item.Quantity)
                    return ApiResponse<GetOrderDto>.Fail($"Product {product.ProductName} out of stock", ResponseType.BadRequest);
                totalAmount += item.Quantity * product.Price;
                productList.Add((product, item.Quantity));

            }
            string paymentId;
            try
            {
                paymentId = await _paymentManager.AuthorizePaymentAsync(paymentDetail);
            }
            catch (Exception ex)
            {
                return ApiResponse<GetOrderDto>.Fail($"Payment authorization failed: {ex.Message}", ResponseType.BadRequest);
            }

            var order = customerId.Map(totalAmount);
            try
            {
                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    await _unitOfWork.OrderRepo.Create(order);

                    foreach (var items in productList)
                    {
                        items.product.StockQuantity -= items.quantity;
                        var orderItem = new OrderItem
                        {
                            OrderItemId = Guid.NewGuid(),
                            OrderId = order.OrderId,
                            ProductId = items.product.ProductId,
                            Quantity = items.quantity,
                            Price = items.product.Price,
                            PriceTotal = items.product.Price * items.quantity
                        };
                        await _unitOfWork.OrderItemRepo.Create(orderItem);
                    }
                });
            }
            catch (Exception ex)
            {            // If transaction fails, void payment
                await _paymentManager.VoidPaymentAsync(paymentId);
                return ApiResponse<GetOrderDto>.Fail($"Order creation failed: {ex.Message}", ResponseType.InternalServerError);
            }
            bool captureSuccess;
            try
            {
                captureSuccess = await _paymentManager.CapturePaymentAsync(paymentId);
            }
            catch 
            {
                captureSuccess = false;
            }
            if (!captureSuccess)
            {
                await _paymentManager.VoidPaymentAsync(paymentId);

                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    foreach (var (product, qty) in productList)
                      product.StockQuantity += qty;
                    await _unitOfWork.OrderItemRepo.DeleteByOrderId(order.OrderId);
                    await _unitOfWork.OrderRepo.Delete(order.OrderId);
                });
                return ApiResponse<GetOrderDto>.Fail("Payment capture failed. Order cancelled.", ResponseType.BadRequest);
            }
            foreach (var item in cartItems)
                await _unitOfWork.CartItemRepo.Delete(item.CartItemId);

            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<GetOrderDto>.Success(order.Map(), "Order processed and payment captured successfully", ResponseType.Ok);
        
        }
        public async Task<ApiResponse<bool>> CancelOrderAsync(Guid orderId)
        {
            var order = await _unitOfWork.OrderRepo.GetById(orderId);
            if (order == null)
                return ApiResponse<bool>.Fail("No such order is found", ResponseType.NoContent);

            if (order.PaymentStatus == true)
                return ApiResponse<bool>.Fail("Paid order cannot be cancelled");

            var orderItems = (await _unitOfWork.OrderItemRepo.GetAll())
                .Where(x => x.OrderId == order.OrderId).ToList();

            try
            {
                await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    foreach (var item in orderItems)
                        await _unitOfWork.OrderItemRepo.Delete(item.OrderItemId);

                    await _unitOfWork.OrderRepo.Delete(order.OrderId);
                });

                return ApiResponse<bool>.Success(true, "Order is cancelled", ResponseType.Ok);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Failed to cancel order: {ex.Message}", ResponseType.InternalServerError);
            }
        }
        public async Task<ApiResponse<GetOrderDto>> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _unitOfWork.OrderRepo.GetById(orderId);
            if (order == null)
            {
                return ApiResponse<GetOrderDto>.Fail("Order not found", ResponseType.NotFound);
            }
            return ApiResponse<GetOrderDto>.Success(order.Map(),"Order is fetched",ResponseType.Ok);
        }
        public async Task<ApiResponse<IEnumerable<GetOrderDto>>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            var order=await _unitOfWork.OrderRepo.GetOrdersByCustomerId(customerId);
            if (order == null)
            {
                return ApiResponse<IEnumerable<GetOrderDto>>.Fail("this customer has no order yet", ResponseType.NotFound);
            }
            return ApiResponse<IEnumerable<GetOrderDto>>.Success(order.MapList(), "Order fetched successfully",ResponseType.Ok);
        }
        public async Task<ApiResponse<bool>> UpdateOrderStatusAsync(UpdateOrderDto updateOrderDto)
        {
            var order = await _unitOfWork.OrderRepo.GetById(updateOrderDto.OrderId);
            if (order == null)
                return ApiResponse<bool>.Fail("Order is null", ResponseType.NotFound);
            order.PaymentStatus=updateOrderDto.PaymentStatus;
            order.OrderStatus = updateOrderDto.OrderStatus;
            await _unitOfWork.OrderRepo.Update(order);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Success(true, "Order updated successfully", ResponseType.Ok);
        }
    }
}
