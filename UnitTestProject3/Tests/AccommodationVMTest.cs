using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using BookingSystem.Model;
using BookingSystem.ViewModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestProject3
{
    [TestClass]
   public class AccommodationVMTest
    {
        

        
        [TestMethod]
        public void CheckLoading()
        {
           BookingSystem.ViewModel.AccommodationVM testVM = new BookingSystem.ViewModel.AccommodationVM();
        // testVM.ListOfAccommodations.Clear();
            testVM.Load();
            Assert.AreNotEqual(testVM.ListOfAccommodations.Count, 0);
        }

        [TestMethod]
        public void TestSearch()
        {
           BookingSystem.ViewModel.AccommodationVM testVM = new BookingSystem.ViewModel.AccommodationVM();

            //testVM.Load();
            testVM.SearchAccommodation.Guests = "1";
            testVM.SearchAccommodation.Price = "10000";
            testVM.SearchAccommodation.CheckInDate = DateTime.Today;
            testVM.SearchAccommodation.CheckOutDate = DateTime.Today;
            testVM.SearchAccommodation.Location = "Paris";/* testVM.ListOfAccommodations.ElementAt(1).Location;*/
            testVM.DoSearchCommand();
            Assert.AreNotEqual(testVM.SearchedAccommodations.Count, 0);
        }

        [TestMethod]
        public void TestAddReservation()
        {
            BookingSystem.ViewModel.AccommodationVM testVM = new BookingSystem.ViewModel.AccommodationVM();
            testVM.Reservation.FullName = "Chuck Norris";
            testVM.Reservation.CardNumber = 1012345678912345;
            testVM.Reservation.Cvv = 423;
            testVM.Reservation.ExpirationMonth = 10;
            testVM.Reservation.ExpirationYear = 17;
            testVM.Reservation.Email = "chuck@norris.com";
            testVM.Reservation.TelephoneNumber = "0123456789";
            testVM.DoAddReservation();
            Assert.IsNotNull(testVM.Reservations);
        }
    }
}
