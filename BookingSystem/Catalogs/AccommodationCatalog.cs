using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Model;

namespace BookingSystem.Catalogs
{
    public class AccommodationCatalog
    {
        public ObservableCollection<Accommodation> AccommodationList;
        public AccommodationCatalog()
        {
            AccommodationList = new ObservableCollection<Accommodation>();
        }
        public Accommodation CreateNewAccommodation(string l, int ng, string t, decimal p, string fp, string d)
        {
            Accommodation accommodation = new Accommodation { Location = l, NumberOfGuests = ng, Title = t, Price = p, Picture = fp, Description = d};
            AccommodationList.Add(accommodation);
            return accommodation;
        }
    }
}
