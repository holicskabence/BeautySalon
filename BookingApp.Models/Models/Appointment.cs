using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Models.Models
{
    public class Appointment
    {
        [Key]
        public string Id { get; set; }

        public string OwnerId { get; set; }
        [NotMapped]
        public virtual SiteUser? Owner { get; set; }

        public DateTime Time { get; set; }
        public int Cost { get; set; }
        public int FullTime { get; set; }
        public string ServicesAsJson { get; set; }
        public Appointment()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}