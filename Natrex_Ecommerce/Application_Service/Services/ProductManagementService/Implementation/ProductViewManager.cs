namespace Application_Service.Services.ProductManagementService.Implementation
{
    public class ProductViewManager : IProductViewManager
    {
        private readonly IUnitOfWork _unitofWork;
        public ProductViewManager(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<string> AddViewAsync(AddProductViewDto dto)
        {
            bool alreadyViewed = await _unitofWork.ProductViews.AnyAsync(x =>
                x.ProductId == dto.ProductId &&
                x.IPAddress == dto.IPAddress);
            if (alreadyViewed)
                return "Already Viewed";

            var product = await _unitofWork.ProductRepo.GetById(dto.ProductId);
            if (product == null)
                return "Product Id is Wrong";

            try
            {
                await _unitofWork.ExecuteInTransactionAsync(async () =>
                {
                    var data = dto.ToEntity();
                    product.TotalViews += 1;

                    await _unitofWork.ProductViews.Create(data);
                    await _unitofWork.ProductRepo.Update(product);
                });

                return "Viewed Successfully";
            }
            catch (Exception ex)
            {
                return $"Failed to add view: {ex.Message}";
            }
        }

        public async Task<int> GetTotalViewsByProductIdAsync(Guid productId)
        {
            var allViews = await _unitofWork.ProductViews.GetAll();
            return allViews.Count(x => x.ProductId == productId);
        }
    }
}
