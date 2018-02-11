using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public BankAccount BankAccountDetails { get; set; }
        public string MobileNumber { get; set; }
        public string Adress { get; set; }
        public string PersonalID { get; set; }

        
    }
}
