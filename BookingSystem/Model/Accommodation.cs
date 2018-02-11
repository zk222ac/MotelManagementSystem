using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class Accommodation
    {
        public string Location { get; set; }
        public int NumberOfGuests { get; set; }
        public ObservableCollection<DateTime> BookdeOn { get; set; }
        public bool IsBooked { get; set; }
        public string Title { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; } = "It is located in the heart of the historic center in an extremely characteristic, quite and lively area within short walk distance to all sites and is surrounded by the extraordinary beauty of churches, buildings, shops and monuments. It is part of a lovingly restored 1800 palace";
        public Accommodation()
        {

        }
        public override string ToString()
        {
            return String.Format("{0} {1}, the price is {2}, it is located in: {3} and {4} can reside there", Title, Picture, Price, Location, NumberOfGuests);
        }
    }
}
