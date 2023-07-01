using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Models
{
    public class Service
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Time { get; set; }
        public Service()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
