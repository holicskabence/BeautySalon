using BookingApp.Models.Models;
using BookingApp.Repository.Database;
using BookingApp.Repository.GenericRepository;
using BookingApp.Repository.Interfaces;

namespace BookingApp.Repository.ModelRepositories
{
    public class AppointmentRepository : Repository<Appointment>, IRepository<Appointment>
    {
        public AppointmentRepository(BookingDbContext ctx) : base(ctx)
        {

        }

        public override Appointment Read(string id)
        {
            return ctx.Appointments.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Appointment item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
