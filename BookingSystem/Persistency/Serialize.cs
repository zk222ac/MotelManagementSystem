using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Composition;
using BookingSystem.Model;

namespace BookingSystem.Persistancy
{
    public class Serialize
    {
        private ObservableCollection<Accommodation> _theAccommodations;
        private string accomodationfile = "Accommodations.txt";
        private string bookingfilename = "Bookings.txt";
        private string reservationfilename = "Reservation.txt";
        private string employeefilename = "Employee.txt";

        private List<Employee> _employees;

        public async void SaveAccommodations(ObservableCollection<Accommodation> saveAccommodations)
        {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile file = await localFolder.CreateFileAsync(accomodationfile, CreationCollisionOption.ReplaceExisting);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Accommodation>));

                using (Stream stream = await file.OpenStreamForWriteAsync())
                {
                    xmlSerializer.Serialize(stream, saveAccommodations);
                }
        }

        //de
        public async Task<ObservableCollection<Accommodation>> LoadAccommodations()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
         

            StorageFile file = await localFolder.GetFileAsync(accomodationfile);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Accommodation>));

            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                _theAccommodations = xmlSerializer.Deserialize(stream) as ObservableCollection<Accommodation>;
            }

            return _theAccommodations;
        }

        // serialize customer

        private ObservableCollection<Reservation> _theReservations;
        

        public async void SaveReservations(ObservableCollection<Reservation> saveCustomers)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file =
                await localFolder.CreateFileAsync(reservationfilename, CreationCollisionOption.ReplaceExisting);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Reservation>));

            using (Stream stream = await file.OpenStreamForWriteAsync())
            {
                xmlSerializer.Serialize(stream, saveCustomers);
            }
        }

        //de
        public async Task<ObservableCollection<Reservation>> LoadReservations()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.GetFileAsync(reservationfilename);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Reservation>));

            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                _theReservations = xmlSerializer.Deserialize(stream) as ObservableCollection<Reservation>;
            }

            return _theReservations;
        }

        

        public async void SaveEmployee(List<Employee> saveEmployees)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file =
                await localFolder.CreateFileAsync(employeefilename, CreationCollisionOption.ReplaceExisting);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));

            using (Stream stream = await file.OpenStreamForWriteAsync())
            {
                xmlSerializer.Serialize(stream, saveEmployees);
            }
        }

        //ee
        public async Task<List<Employee>> LoadEmployees()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.GetFileAsync(employeefilename);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));

            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                _employees = xmlSerializer.Deserialize(stream) as List<Employee>;
            }

            return _employees;
        }

       

        //public async void SaveSales(List<Booking> saveBookings)
        //{
        //    StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        //    StorageFile file =
        //        await localFolder.CreateFileAsync(bookingfilename, CreationCollisionOption.ReplaceExisting);
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Booking>));

        //    using (Stream stream = await file.OpenStreamForWriteAsync())
        //    {
        //        xmlSerializer.Serialize(stream, saveBookings);
        //    }
        //}
    }
}