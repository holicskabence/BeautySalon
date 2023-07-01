using BookingApp.Models.Models;

namespace BookingApp.Logic.Classes
{
    public interface IServiceLogic
    {
        void Create(Service item);
        void Delete(string id);
        Service Read(string id);
        IQueryable<Service> ReadAll();
        void Update(Service item);
    }
}