namespace BookingWebApi.BookingWebApi.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetById(Guid id);
        protected Task AddAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
