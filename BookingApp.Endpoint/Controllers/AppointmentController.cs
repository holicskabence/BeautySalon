using BookingApp.Endpoint.Services;
using BookingApp.Logic.Classes;
using BookingApp.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics.Metrics;

namespace BookingApp.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        IAppointmentLogic logic;
        IHubContext<SignalRHub> hub;

        public AppointmentController(IAppointmentLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Appointment> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Appointment Read(string id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Appointment value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("AppointmentCreated", value);
        }


        [HttpPut]
        public void Update([FromBody] Appointment value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("AppointmentUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var AppointmentToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("AppointmentDeleted", AppointmentToDelete);
        }
    }
}
