using BookingApp.Endpoint.Services;
using BookingApp.Logic.Classes;
using BookingApp.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BookingApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        IServiceLogic logic;
        IHubContext<SignalRHub> hub;

        public ServiceController(IServiceLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Service> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Service Read(string id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Service value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("ServiceCreated", value);
        }


        [HttpPut]
        public void Update([FromBody] Service value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ServiceUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var ServiceToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ServiceDeleted", ServiceToDelete);
        }
    }
}
