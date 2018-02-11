using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using BookingSystem.Annotations;

namespace BookingSystem.Model
{
    public class Search
    {
        // classes
        public string Location { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Guests { get; set; }
        public string Price { get; set; }
        public ComboBoxItem SortString { get; set; }

        private IEnumerable<Accommodation> checkIfBooked(IEnumerable<Accommodation> list)
        {
            DateRange range = new DateRange(CheckInDate, CheckOutDate);
            bool booked = false;
            foreach (var accommodation in list)
            {
                booked = false;
                foreach (var date in accommodation.BookdeOn)
                {
                    if (range.Includes(date))
                    {
                        accommodation.IsBooked = true;
                        break;
                    }
                    else
                    {
                        accommodation.IsBooked = false;
                    }
                }
            }
            return list;
        }
        public ObservableCollection<Accommodation> SearchItems(
            [NotNull] ObservableCollection<Accommodation> listOfAccommodations, [NotNull] Search searchOptions)
        {
            try
            {
                if (listOfAccommodations.Count == 0)
                    throw new ArgumentException("Value cannot be an empty collection.", nameof(listOfAccommodations));
                searchOptions.CheckInDate = new DateTime(CheckInDate.Year, CheckInDate.Month, CheckInDate.Day);
                if (Location == null) throw new ArgumentNullException(nameof(Location));
                var listOfResults =
                    listOfAccommodations.Where(accommodation => accommodation.Location.Contains(Location))
                        .Where(accommodation => accommodation.NumberOfGuests >= Int32.Parse(Guests.ToString()))
                        .Where(accommodation => accommodation.Price <= Int32.Parse(Price));
                //IEnumerable<Accommodation> listOfResults1 = checkIfBooked(listOfResults);
                //listOfResults = listOfResults1.Where(accommodation => accommodation.IsBooked == false);
                ObservableCollection<Accommodation> listOfSearchResults =
                    new ObservableCollection<Accommodation>(listOfResults);
                return listOfSearchResults;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ObservableCollection<Accommodation> SortSearchResults(ObservableCollection<Accommodation> listOfAccommodations, string orderby)
        {
            var list = new List<Accommodation>();
            switch (orderby)
            {
                case "Name ↑":
                    {
                        list = listOfAccommodations.OrderBy(x => x.Location).ToList();
                        break;
                    }
                case "Price ↑":
                    {
                        list = listOfAccommodations.OrderBy(x => x.Price).ToList();
                        break;
                    }
                case "Guest Number ↑":
                    {
                        list = listOfAccommodations.OrderBy(x => x.NumberOfGuests).ToList();
                        break;
                    }
                case "Name ↓":
                    {
                        list = listOfAccommodations.OrderByDescending(x => x.Location).ToList();
                        break;
                    }
                case "Price ↓":
                    {
                        list = listOfAccommodations.OrderByDescending(x => x.Price).ToList();
                        break;
                    }
                case "Guest Number ↓":
                    {
                        list = listOfAccommodations.OrderByDescending(x => x.NumberOfGuests).ToList();
                        break;
                    }
            }

            var oc = new ObservableCollection<Accommodation>();
            list.ForEach(x => oc.Add(x));
            return oc;
        }
    }
}

