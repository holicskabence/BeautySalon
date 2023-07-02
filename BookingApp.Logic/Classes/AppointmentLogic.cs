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

        public IEnumerable<DateTime> FreeTimes()
        {
            List<DateTime> freetimes = new List<DateTime>();
            DateTime currentDate = DateTime.Today;
            //Kezdeti és végdátum beállítása
            DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0);
            DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day+14, 18, 0, 0);

            while (startTime < endTime)
            {
                if ((startTime.DayOfWeek != DayOfWeek.Saturday && startTime.DayOfWeek != DayOfWeek.Sunday) && startTime.Hour >= 10 && startTime.Hour < 18)
                {
                    freetimes.Add(startTime);
                }
                //Mennyi időnként lehessen foglalni
                startTime = startTime.AddMinutes(30);
            }

            foreach (var item in repo.ReadAll())
            {
                DateTime appointmentTime = item.Time;
                int serviceLastTime = item.FullTime;
                DateTime serviceEndTime = appointmentTime.AddMinutes(serviceLastTime);

                freetimes.RemoveAll(t => t >= appointmentTime && t < serviceEndTime);
            }

            return freetimes.AsEnumerable();

            //List<DateTime> szabadOrak = new List<DateTime>();
            //DateTime currentDate = DateTime.Today;
            //DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0);
            //DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 18, 0, 0);

            //while (startTime < endTime)
            //{
            //    if (startTime.DayOfWeek != DayOfWeek.Saturday && startTime.DayOfWeek != DayOfWeek.Sunday && startTime.Hour >= 10 && startTime.Hour < 18)
            //    {
            //        szabadOrak.Add(startTime);
            //    }

            //    startTime = startTime.AddMinutes(60);
            //}

            //foreach (var item in this.repo.ReadAll())
            //{
            //    DateTime foglalasIdopont = item.Time;
            //    int szolgaltatasIdo = item.FullTime;
            //    DateTime foglalasVege = foglalasIdopont.AddMinutes(szolgaltatasIdo);

            //    szabadOrak.RemoveAll(t => t >= foglalasIdopont && t < foglalasVege);
            //}

            //return szabadOrak;

        }


    }
}