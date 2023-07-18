using BookingApp.Models.Models;
using BookingApp.Repository.Database;
using BookingApp.Repository.GenericRepository;
using BookingApp.Repository.Interfaces;

namespace BookingApp.Repository.ModelRepositories
{
    public class ServiceRepository : Repository<Service>, IRepository<Service>
    {
        public ServiceRepository(BookingDbContext ctx) : base(ctx){}

        public override Service Read(string id)
        {
            return ctx.Services.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Service item)
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
