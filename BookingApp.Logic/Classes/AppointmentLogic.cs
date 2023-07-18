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
        //NonCRUD

        public IEnumerable<FreeTime> FreeTimes()
        {
            List<DateTime> freetimes = new List<DateTime>();
            DateTime currentDate = DateTime.Today;
            //Kezdeti és végdátum beállítása
            DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0);
            DateTime endTime = currentDate.AddDays(14).Date.AddHours(18);

            while (startTime < endTime)
            {
                if ((startTime.DayOfWeek != DayOfWeek.Saturday && startTime.DayOfWeek != DayOfWeek.Sunday) && startTime.Hour >= 10 && startTime.Hour < 18)
                {
                    freetimes.Add(startTime);
                }
                //Mennyi időnként lehessen foglalni
                startTime = startTime.AddMinutes(30);
            }
            //Foglalt időpontok kivétele
            foreach (var item in repo.ReadAll())
            {
                DateTime appointmentTime = item.Time;
                int serviceLastTime = item.FullTime;
                DateTime serviceEndTime = appointmentTime.AddMinutes(serviceLastTime);

                freetimes.RemoveAll(t => t >= appointmentTime && t < serviceEndTime);
            }
            //Átalakítás 
            List<FreeTime> result = new List<FreeTime>();
            FreeTime tmp = new FreeTime()
            {
                DayName = freetimes[0].DayOfWeek.ToString(),
                DayNumber = freetimes[0].Day
            };
            foreach (var item in freetimes)
            {
                if (item.Day == tmp.DayNumber)
                {
                    tmp.freeHours.Add(item);
                }
                else
                {
                    result.Add(tmp);
                    tmp = new FreeTime()
                    {
                        DayName = item.DayOfWeek.ToString(),
                        DayNumber = item.Day,
                        DayMonth = item.ToString("M.d")
                    };
                }
            }

            result.Add(tmp); // Az utolsó időpont hozzáadása a listához

            return result.AsEnumerable();
        }
    }
}