using Domain_Service.Entities.ProductManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IWishListItemRepo : IRepository<WishListItem>
    {
        IQueryable<WishListItem> QueryWishListItems();
    }
}
