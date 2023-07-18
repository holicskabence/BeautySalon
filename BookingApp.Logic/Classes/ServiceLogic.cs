using BookingApp.Models.Models;
using BookingApp.Repository.Interfaces;
namespace BookingApp.Logic.Classes
{
    public class ServiceLogic : IServiceLogic
    {
        IRepository<Service> repo;

        public ServiceLogic(IRepository<Service> repo)
        {
            this.repo = repo;
        }

        //CRUD
        public void Create(Service item)
        {
            this.repo.Create(item);
        }

        public void Delete(string id)
        {
            this.repo.Delete(id);
        }

        public Service Read(string id)
        {
            var service = this.repo.Read(id);
            if (service == null)
            {
                throw new ArgumentException("Service not exists");
            }
            return service;
        }

        public IQueryable<Service> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Service item)
        {
            this.repo.Update(item);
        }
    }
}
