using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Model;

namespace BookingSystem.Catalogs
{
    public class ReservationCatalog
    {

        public class ReservationsCatalog
        {
            public ObservableCollection<Reservation> ReservationsList;
            public ReservationsCatalog()
            {
                ReservationsList = new ObservableCollection<Reservation>();
            }
            public Reservation ReserveAnApartment(Reservation reservation)
            {
                ReservationsList.Add(reservation);
                return reservation;
            }
        }
    }
}
