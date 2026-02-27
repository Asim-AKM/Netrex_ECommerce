using Domain_Service.Entities.ProductManagmentModule;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IWishListRepo
    {
        Task<List<WishListItem>> GetAllWishListItemsByWishListId(Guid wishListId);
    }
}
