namespace BookingApp.Models.Models
{
    public class FreeTime
    {
        public string DayName { get; set; }
        public int DayNumber { get; set; }
        public string DayMonth { get; set; }
        public List<DateTime> freeHours { get; set; }
        public FreeTime()
        {
            freeHours = new List<DateTime>();
        }
    }
}
