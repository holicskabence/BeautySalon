using System.ComponentModel.DataAnnotations;


namespace BookingApp.Models.Models
{
    public class Service
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Time { get; set; }
        public string Category { get; set; }
        public Service()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
