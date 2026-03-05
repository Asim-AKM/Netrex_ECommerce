namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IWishListItemRepo : IRepository<WishListItem>
    {
        IQueryable<WishListItem> QueryWishListItems();
    }
}
