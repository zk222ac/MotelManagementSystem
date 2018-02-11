using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Model
{
    public class BankAccount
    {
        public string CardNumber { get; set; }
        public int CvcNumber { get; set; }
        public string OwnerName { get; set; }
        public DateTime ValidThrough { get; set; }

        internal Customer Person
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
