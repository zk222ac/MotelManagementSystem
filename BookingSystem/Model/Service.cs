using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BookingSystem.Model
{
    public class Service
    {   
        public bool IsAvailable { get; set; }
        public string ServiceName { get; set; }

        public Service()
        { }


        public Service(bool isAvailable, string serviceName)
        {
            IsAvailable = isAvailable;
            ServiceName = serviceName;
        }
    }

    public class Services:ObservableCollection<Service>
    {
        public Services(bool breakfast = false, bool wifi = false, bool tv = false, bool parkingSlot = false, bool minibar = false)
        {
            this.Add(new Service(breakfast, "Breakfast"));
            this.Add(new Service(wifi, "Wi-Fi"));
            this.Add(new Service(tv, "TV"));
            this.Add(new Service(parkingSlot, "Parking Slot"));
            this.Add(new Service(minibar, "Minibar"));
        }   
    }
}
