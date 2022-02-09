namespace mycinema.Data.Base
{
    public interface IEntityBaseRespository<T> where T : class, IEntityBase, new()
    {

        Task<IEnumerable<T>> GetAll();
        Task AddAsync(T entity);
        Task Delete(int id);

        Task update(int id, T entity);
        Task<T> getByIdasnyc(int id);

    }
}
