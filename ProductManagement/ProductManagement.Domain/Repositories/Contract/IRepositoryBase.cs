namespace ProductManagement.Domain.Repositories.Contract
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T item);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
