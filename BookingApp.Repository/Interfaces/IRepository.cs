namespace BookingApp.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ReadAll();
        T Read(string id);
        void Create(T item);
        void Update(T item);
        void Delete(string id);
    }
}