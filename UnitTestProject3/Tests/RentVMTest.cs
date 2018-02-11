using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Model;
using BookingSystem.ViewModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestProject3
{
    [TestClass]
    public class RentVMTest
    {
        RentViewModel rentVM = new RentViewModel();
        

        [TestMethod]
        public void TestAddAccommodation()
        {
            int numberOfAccommodations = rentVM.Accommodations.Count;
            rentVM.Location = "Florida";
            rentVM.NumberOfGuests = 1;
            rentVM.Price = 9999;
            rentVM.Title = "3 rooms appartment";
            rentVM.DoAddAccommodation();
            Assert.AreNotEqual(rentVM.Accommodations.Count, numberOfAccommodations);
        }
    }
}
