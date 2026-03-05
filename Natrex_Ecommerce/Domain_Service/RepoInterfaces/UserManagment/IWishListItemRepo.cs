namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IWishListItemRepo
    {
        IQueryable<WishListItem> QueryWishListItems();
    }
}
