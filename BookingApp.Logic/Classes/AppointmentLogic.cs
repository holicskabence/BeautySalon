using BookingApp.Models.Models;
using BookingApp.Repository.Interfaces;

namespace BookingApp.Logic.Classes
{
    public class AppointmentLogic : IAppointmentLogic
    {
        IRepository<Appointment> repo;

        public AppointmentLogic(IRepository<Appointment> repo)
        {
            this.repo = repo;
        }

        //CRUD
        public void Create(Appointment item)
        {
            this.repo.Create(item);
        }

        public void Delete(string id)
        {
            this.repo.Delete(id);
        }

        public Appointment Read(string id)
        {
            var appointment = this.repo.Read(id);
            if (appointment == null)
            {
                throw new ArgumentException("Appointment not exists");
            }
            return appointment;
        }

        public IQueryable<Appointment> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Appointment item)
        {
            this.repo.Update(item);
        }
    }
}