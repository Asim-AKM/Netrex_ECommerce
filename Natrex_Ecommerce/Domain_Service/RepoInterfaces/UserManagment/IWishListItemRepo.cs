using Domain_Service.Entities.ProductManagmentModule;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IWishListItemRepo
    {
        IQueryable<WishListItem> QueryWishListItems();
    }
}
