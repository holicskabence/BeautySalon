using BookingApp.Models.Models;

namespace BookingApp.Logic.Classes
{
    public interface IAppointmentLogic
    {
        void Create(Appointment item);
        void Delete(string id);
        Appointment Read(string id);
        IQueryable<Appointment> ReadAll();
        void Update(Appointment item);
    }
}