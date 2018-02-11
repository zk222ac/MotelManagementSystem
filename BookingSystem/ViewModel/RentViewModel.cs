using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media.Imaging;
using BookingSystem.Annotations;
using BookingSystem.Catalogs;
using BookingSystem.Model;
using BookingSystem.Persistancy;

namespace BookingSystem.ViewModel
{
    public class RentViewModel : INotifyPropertyChanged
    {
        private readonly AccommodationCatalog _accommodationCatalog;
        private readonly AccommodationVM accommodation = new AccommodationVM();
        private readonly Serialize _serialize;
        private string _location;
        private int _numberOfGuests;
        private string _title;
        private decimal _price;
        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _filePath;

        public string Picture
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                OnPropertyChanged(nameof(Picture));
            }
        }
        public ObservableCollection<Accommodation> Accommodations
        {
            get { return accommodation.ListOfAccommodations; }
            set
            {
                accommodation.ListOfAccommodations = value;
                OnPropertyChanged(nameof(Accommodations));
            }
        }
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
        public int NumberOfGuests
        {
            get { return _numberOfGuests; }
            set
            {
                _numberOfGuests = value;
                OnPropertyChanged(nameof(NumberOfGuests));
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public string RegisterAccommodationMessage { get; set; }
        public string RegisterAccommodationMessageColor { get; set; }
        public RelayCommand AddAccommodation
        {
            get;
            set;
        }

        public RelayCommand AddImage { get; set; }
        public RentViewModel()
        {
            _accommodationCatalog = new AccommodationCatalog();
            AddAccommodation = new RelayCommand(DoAddAccommodation);
            AddImage = new RelayCommand(DoAddImage);
            _serialize = new Serialize();
        }

        public async void DoAddImage()
        {
            try
            {
                FileOpenPicker _image = new FileOpenPicker();
                _image.SuggestedStartLocation = PickerLocationId.Desktop;
                _image.ViewMode = PickerViewMode.Thumbnail;
                _image.FileTypeFilter.Add(".jpg");
                _image.FileTypeFilter.Add(".png");
                _image.FileTypeFilter.Add(".jpeg");
                StorageFile file = await _image.PickSingleFileAsync();
                if (file != null)
                {
                    var stream = await file.CopyAsync(await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets"));
                    _filePath = stream.Path;
                }
            }
            catch (Exception ex)
            {
                RegisterAccommodationMessage = "You cannot upload the same picture twice.";
                RegisterAccommodationMessageColor = "red";
                OnPropertyChanged(nameof(RegisterAccommodationMessage));
                OnPropertyChanged(nameof(RegisterAccommodationMessageColor));
            }
        }

        public void DoAddAccommodation()
        {

            try
            {
                string l = Location;
                int n = NumberOfGuests;
                string t = Title;
                decimal p = Price;
                string fp = Picture;
                string d = Description;
                foreach (var variable in accommodation.ListOfAccommodations.ToList())
                {
                    if (variable.Title.Equals(t))
                    {
                        RegisterAccommodationMessage =
                            string.Format(
                                "The accommodation with \n \n Location : {0}\n Number Of Guests : {1}\n Title : {2}\n Price : {3} \n  was not registered in the system. \n Two accommodations can't have same Title.",
                                l, n, t, p);
                        RegisterAccommodationMessageColor = "red";
                        OnPropertyChanged(nameof(RegisterAccommodationMessage));
                        OnPropertyChanged(nameof(RegisterAccommodationMessageColor));
                        return;
                    }

                }
                if (p > 0 && !string.IsNullOrWhiteSpace(l) && !string.IsNullOrWhiteSpace(t) && !string.IsNullOrWhiteSpace(n.ToString()))
                {
                    Accommodation acc = _accommodationCatalog.CreateNewAccommodation(l, n, t, p, fp, d);
                    accommodation.ListOfAccommodations.Add(acc);
                    _serialize.SaveAccommodations(accommodation.ListOfAccommodations);
                    RegisterAccommodationMessage = string.Format("The accommodation with \n \n Location : {0}\n Number Of Guests : {1}\n Title : {2}\n Price : {3} \n  has been registered in the system.",
                            l, n, t, p);
                    RegisterAccommodationMessageColor = "white";
                    OnPropertyChanged(nameof(RegisterAccommodationMessage));
                    OnPropertyChanged(nameof(RegisterAccommodationMessageColor));
                    Location = "";
                    NumberOfGuests = 0;
                    Title = "";
                    Price = 0;
                    Picture = "";
                    Description = "";

                }
                else
                {
                    RegisterAccommodationMessage = string.Format("The accommodation with \n \n Location : {0}\n Number Of Guests : {1}\n Title : {2}\n Price : {3} \n  was not registered in the system. ",
                            l, n, t, p);
                    RegisterAccommodationMessageColor = "black";
                    OnPropertyChanged(nameof(RegisterAccommodationMessage));
                    OnPropertyChanged(nameof(RegisterAccommodationMessageColor));
                }
            }
            catch (ArgumentException ex)
            {
                RegisterAccommodationMessage = ex.Message;

            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
