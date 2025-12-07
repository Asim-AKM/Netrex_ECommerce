namespace Domain_Service.RepoInterfaces.GenericRepo
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<bool> Delete(Guid Id);
        Task<T> GetById(Guid id);

    }
}
