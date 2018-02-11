using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Model;
using BookingSystem.Persistancy;


namespace BookingSystem.Catalogs
{
    public class BookingCatalog
    {
        public Booking Booking;
        public List<Booking> bookingCatalog;
        private BookingSingleton singleton;
        private Serialize serializer;
        public BookingCatalog()
        {
            Booking = new Booking();
            bookingCatalog = new List<Booking>();
            serializer = new Serialize();
            singleton = BookingSingleton.GetInstance();
        }
        public void Book(Customer customerReference, Accommodation accommodationReference)
        {
            Booking = new Booking() { Customer = customerReference, Accommodation = accommodationReference, ReservationNumber = 1, BookingDate = DateTime.Now };
            if (customerReference != null && accommodationReference != null)
            {
                BookingSingleton.AddValues(customerReference, accommodationReference);
                bookingCatalog.Add(Booking);

               // serializer.SaveSales(bookingCatalog);
            }
        }
    }
}
