using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class BookingSingleton
    {
        private static UserSingleton _user;
        private static BookingSingleton _instance;

        // Properties
        public static Accommodation Accommodation { get; set; }
        public static Customer Customer { get; set; }
        public static string Employee { get; set; }

        // Constructor
        private BookingSingleton()
        {
            // Initialize object instance
            Customer = new Customer();
            Accommodation = new Accommodation();
            _user = UserSingleton.GetInstance();
        }
        public static BookingSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BookingSingleton();
            }
            return _instance;
        }
        public static void AddValues(Customer customerx, Accommodation carx)
        {
            Customer = customerx;
            Accommodation = carx;
            Employee = _user.GetCurrentUser();

        }
        public static Customer ReturnCustomer()
        {
            return Customer;
        }
        public static Accommodation ReturnCar()
        {
            return Accommodation;
        }
    }
}
