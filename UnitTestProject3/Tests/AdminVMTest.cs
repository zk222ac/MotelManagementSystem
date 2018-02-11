using System;
using System.Linq;
using BookingSystem.Model;
using BookingSystem.ViewModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestProject3
{
    [TestClass]
    public class AdminVMTest
    {
        
        [TestMethod]
        public void TestRemove()
        {

            AdminViewModel adminVM = new AdminViewModel();
            AccommodationVM accTestVM = new AccommodationVM();
            adminVM.SelectedListView = accTestVM.ListOfAccommodations;
            int numberOfAccomodations = adminVM.SelectedListView.Count;
            string titleToRemove = accTestVM.ListOfAccommodations.ElementAt(2).Title;
            adminVM.Title = titleToRemove;
            adminVM.DoRemoveAccommodation();
            Assert.AreNotEqual(numberOfAccomodations, adminVM.SelectedListView.Count);
        }

     }
}