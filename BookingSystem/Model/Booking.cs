using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class Booking
    {
        public Customer Customer { get; set; }
        public Accommodation Accommodation { get; set; }
        public DateTime BookingDate { get; set; }
        public int ReservationNumber { get; set; }

    }
}
