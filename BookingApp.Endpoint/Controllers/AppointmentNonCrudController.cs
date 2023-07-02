using BookingApp.Logic.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AppointmentNonCrudController : ControllerBase
    {
        IAppointmentLogic logic;

        public AppointmentNonCrudController(IAppointmentLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<DateTime> FreeTimes()
        {
            return this.logic.FreeTimes();
        }
    }
}
