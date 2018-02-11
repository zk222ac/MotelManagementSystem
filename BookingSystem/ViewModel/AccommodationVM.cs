using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using BookingSystem.Annotations;
using BookingSystem.Catalogs;
using BookingSystem.Model;
using BookingSystem.Persistancy;


namespace BookingSystem.ViewModel
{
    public class AccommodationVM : INotifyPropertyChanged
    {

        public Reservation Reservation
        {
            get { return _reservation; }
            set
            {
                _reservation = value;
                OnPropertyChanged();
            }
        }
        private ReservationCatalog.ReservationsCatalog _reservationsCatalog;
        private ObservableCollection<Reservation> _reservations;
        private ObservableCollection<Reservation> _listOfReservations;
        private Serialize _serialize;

        private ObservableCollection<Accommodation> _searchedAccommodations;
        private Accommodation _selectedAccommodation;
        private Reservation _reservation;
        private string _registerReservationMessage;



        public string RegisterReservationMessage
        {
            get { return _registerReservationMessage; }
            set
            {
                _registerReservationMessage = value;
                OnPropertyChanged(nameof(RegisterReservationMessage));
            }
        }
        public string RegisterReservationMessageColor { get; set; }
        public Search SearchAccommodation { get; set; }
        public RelayCommand AddReservation { get; set; }
        public ObservableCollection<Reservation> Reservations
        {
            get { return _listOfReservations; }
            set
            {
                _listOfReservations = value;
                OnPropertyChanged(nameof(Reservations));
            }
        }
        public Accommodation SelectedAccommodation
        {
            get { return _selectedAccommodation; }
            set
            {
                _selectedAccommodation = value;
                OnPropertyChanged(nameof(SelectedAccommodation));
            }
        }
        public RelayCommand SortCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public ObservableCollection<Accommodation> SearchedAccommodations
        {
            get { return _searchedAccommodations; }
            set
            {
                _searchedAccommodations = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Accommodation> ListOfAccommodations { get; set; }

        public AccommodationVM()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            Reservation = new Reservation();
            _listOfReservations = new ObservableCollection<Reservation>();
            _reservationsCatalog = new ReservationCatalog.ReservationsCatalog();
            AddReservation = new RelayCommand(DoAddReservation);
            _serialize = new Serialize();

            SelectedAccommodation = new Accommodation();
            SortCommand = new RelayCommand(DoSortCommand);
            SearchCommand = new RelayCommand(DoSearchCommand);
            SearchAccommodation = new Search();
            Object value = localSettings.Values["FirstRun"];

            if (value == null)
            {
                ListOfAccommodations = new ObservableCollection<Accommodation>()
                {

                    new Accommodation()
                    {
                        Location = "Paris",
                        Picture = "/Assets/Pierre&Vacances.jpg",
                        Title = "Pierre&Vacances",
                        NumberOfGuests = 4,
                        Price = 950,
                        Description = "This well-located Pierre & Vacances residence of a high standard can be found in the 15th arrondissement close to the Seine. From the residence offers panoramic views of Paris, and several of the apartments have views of the Eiffel Tower and Les Invalides. The residence has a gym with swimming pool and jacuzzis.",
                        BookdeOn = new ObservableCollection<DateTime>()
                        {
                            new DateTime(2016, 12, 24),
                            new DateTime(2016, 12, 30)

                        }

                    },
                    new Accommodation()
                    {
                        Location = "Paris",
                        Picture = "/Assets/Villenuif.jpg",
                        Title = "Villenuif",
                        NumberOfGuests = 3,
                        Price = 750,
                        Description = "Everyone knows that traffic in Paris is a story in itself. In that regard do the statistics say that it cuts just taking one day before a new car has its first bump. Against this background, it is also understandable that many Danes prefer to settle outside or on the edge of this fascinating city - and then use public.",
                        BookdeOn = new ObservableCollection<DateTime>()
                        {
                            new DateTime(2016, 12, 24),
                            new DateTime(2016, 12, 30)

                        }
                    },
                    new Accommodation()
                    {
                        Location = "Paris",
                        Picture = "/Assets/Adagio.jpg",
                        Title = "Adagio",
                        NumberOfGuests = 6,
                        Description = "Our Adagio residence has best location in Paris - between the Pigalle district and artistic venue, Place du Tertre. Yes, we are on the legendary Montmartre, which works and acts as an authentic village in the cultural city of Paris.",
                        Price = 1500
                    },
                    new Accommodation()
                    {
                        Location = "Korsika",
                        Picture = "/Assets/corsica.jpg",
                        Title = "Borgo",
                        NumberOfGuests = 5,
                        Description = "Our new Belambra-residence Pineto is located on the edge of a lush pine forest and consists of fine newly renovated bungalows with air-conditioning and furnished terrace. The residence is located directly on the sandy beach and therefore from its beautiful large pool area with heated swimming pool of 300 m2, children's pool.",
                        Price = 1200
                    },
                    new Accommodation()
                    {
                        Location = "Toscana",
                        Picture = "/Assets/Castelfiorentino.jpg",
                        Title = "Castelfiorentino",
                        NumberOfGuests = 3,
                        Description = "Count Alberti constructed back in 1210 the old castle Castello di Cabriavoli, which is 35 km southwest of Florence and the luxurious castle building with room for 12 people can actually still be rented for an exclusive and expensive! stay in these historically interesting environments - but otherwise we recommend the agriturismo.",
                        Price = 800
                    },
                    new Accommodation()
                    {
                        Location = "Toscana",
                        Picture = "/Assets/San Ellero.jpg",
                        Title = "San Ellero",
                        NumberOfGuests = 6,
                        Description = "This cozy, Tuscan vineyard and Families page, just 20 km east of Florence and 7 km south of Pontassieve. The vineyard owner, Benelli, who won gold in skeet at the Olympics in Athens in 2004, these beautifully restored 16- and 1700s buildings furnished six cozy and spacious apartments in comfortable and regional typical style.",
                        Price = 1400
                    },
                    new Accommodation()
                    {
                        Location = "Toscana",
                        Picture = "/Assets/Barberino Val D'Elsa.jpg",
                        Title = "Barberino Val D'Elsa",
                        NumberOfGuests = 6,
                        Description = "The winery Le Torri Dating back to the 13th century and is the perfect place for those who want to spend their holidays in a relaxing environment and at the same time want to taste wine and olive oil from Chianti high quality!Le Torri is halfway between Florence(35km) and Siena(40 km), surrounded by medieval villages.",
                        Price = 1800
                    },
                    new Accommodation()
                    {
                        Location = "Paris",
                        Picture = "/Assets/villaparis.jpg",
                        Title = "Guibert Halldis Apartment",
                        NumberOfGuests = 6,
                        Description = "Guibert Halldis Apartment is a self-catering accommodation located in Paris. The property is 1.3 km from Eiffel Tower and 1.8 km from Arc de Triomphe. Accommodation will provide you with a TV, a seating area and a DVD player. There is a full kitchen with a dishwasher and a microwave. Featuring a shower, private bathrooms.",
                        Price = 1300
                    },
                    new Accommodation()
                    {
                        Location = "Paris",
                        Picture = "/Assets/eiffeltower.jpg",
                        Title = "Résidence Charles Floquet",
                        NumberOfGuests = 2,
                        Description = "Located in the heart of Paris, Résidence Charles Floquet is 50 m from the Eiffel Tower and a 20-minute walk from the Army Museum. Set in a renovated, historic building, it offers large, self-catering accommodation with views over the Eiffel Tower.",
                        Price = 2000
                    },
                    new Accommodation()
                    {
                        Location = "Paris",
                        Picture = "/Assets/citadine.jpg",
                        Title = "Citadines Bastille Gare de Lyon Paris",
                        NumberOfGuests = 3,
                        Description = "Located near the Bastille district, Bastille Opera House, and not far from AccorHôtels Arena, this residence offers self-catering studios and apartments. It boasts a 24-hour reception, free Wi-Fi access and daily newspapers.",
                        Price = 2000
                    },
                    new Accommodation()
                    {
                        Location = "Lyon",
                        Picture = "/Assets/saphir.jpg",
                        Title = "Best Western Saphir Lyon",
                        NumberOfGuests = 2,
                        Description = "Located in the Gorge de Loup business area, Best Western Saphir Lyon is 350 m from Gorge de Loup Metro Station and just one stop from Vieux Lyon. Lyon Perrache Train Station and Part-Dieu Train Station are both within a 15-minute drive from the hotel. Free WiFi is provided.",
                        Price = 1000
                    },
                    new Accommodation()
                    {
                        Location = "Lyon",
                        Picture = "/Assets/citywok.jpg",
                        Title = "City Work",
                        NumberOfGuests = 3,
                        Description = "City Work offers accommodation in Lyon. The Museum of Fine Arts of Lyon is 500 m away. Free WiFi is provided throughout the property.",
                        Price = 1200
                    },
                    new Accommodation()
                    {
                        Location = "Lyon",
                        Picture = "/Assets/kyriad.jpg",
                        Title = "Kyriad Lyon Centre - Perrache",
                        NumberOfGuests = 2,
                        Description = "Situated in Lyon’s Presqu’île district, an 18-minute walk from Place Bellecour, Kyriad Lyon Centre - Perrache offers accommodation featuring a terrace, a restaurant and a bar. Free WiFi is available throughout",
                        Price = 1400
                    },


                    new Accommodation()
                    {
                        Location = "Toscana",
                        Picture = "/Assets/Venturina.jpg",
                        Title = "Venturina",
                        NumberOfGuests = 4,
                        Description = "This lovely tuscan-residence we have been recommended by the couples who for several years have spent their holidays in Residence Ghiacci Vecchi. The thing that appeals to so many here, is - besides of the residence fine standard - the ideal location that allows you to combine a beach holiday with excursions into the charming Tuscan hinterland.",
                        Price = 800
                    },
                    new Accommodation()
                    {
                        Location = "Toscana",
                        Picture = "/Assets/San Casciano.jpg",
                        Title = "San Casciano",
                        NumberOfGuests = 4,
                        Description = "San Casciano has a central location in Tuscany, 32 km southwest of Florence. This is where managed to establish cooperation with one of Tuscany's vineyards - with an output of 80,000 bottles per year. For the vineyard belongs to a small agriturismo with just five apartments and three separate houses, which offers the most beautiful view.",
                        Price = 900
                    },
                    new Accommodation()
                    {
                        Location = "Toscana",
                        Picture = "/Assets/Calarossa.jpg",
                        Title = "Calarossa",
                        NumberOfGuests = 2,
                        Description = "The 110 ha. large residence of Pierre & Vacances consists of two neighborhoods. One district, holiday village center, and it is here they find most activities. The second quarter - Hauts de Calarossa - is a little higher up, and here there is a stunning panoramic view of the Mediterranean crystal clear waters. At one swimming pool edge.",
                        Price = 800
                    },
                    
                    new Accommodation()
                    {
                        Location = "Barcelona",
                        Picture = "/Assets/Terrazas Costa del Sol.jpg",
                        Title = "Terrazas Costa del Sol",
                        NumberOfGuests = 3,
                        Description = "Our brand new Pierre & Vacances residence is located midway between Estepona and San Pedro de Alcantara - held high and with a beautiful view over the Mediterranean and Saladillo Beach, which is 1.5 km. This gives our guests an opportunity to unite the dynamic beach life with the more tranquil surroundings.",
                        Price = 600
                    },
                    new Accommodation()
                    {
                        Location = "Gran Alicante",
                        Picture = "/Assets/Casa Chiqutta.jpg",
                        Title = "Casa Chiqutta",
                        NumberOfGuests = 4,
                        Description = "Gran Alicante is a small suburb of Alicante (10 km), located on the Costa Blanca - midway between Costa del Sol and the Riviera. Costa Blanca is in the top 10 of the world's best beaches and then released in Gran Alicante even for mass tourism and can instead enjoy the Spanish culture - and the favorable price!",
                        Price = 1800
                    },
                };
                _serialize.SaveAccommodations(ListOfAccommodations);
                localSettings.Values["FirstRun"] = "Run";
            }
            else
            {
                // Access data in value

                ListOfAccommodations = new ObservableCollection<Accommodation>()
                {

                    //new Accommodation()
                    //{
                    //    Location = "Rampelyset 1,4000 Roskilde",
                    //    Picture = "/Assets/hotel.png",
                    //    Title = "Aleksandar`s Hotel",
                    //    NumberOfGuests = 2,
                    //    Price = 487,
                    //    //Services = new Services(breakfast: true, minibar: true),
                    //     BookdeOn = new ObservableCollection<DateTime>()
                    //   {
                    //       new DateTime(2016, 12, 24),
                    //       new DateTime(2016, 12, 30)

                    //   }

                    //},
                    //    new Accommodation()
                    //    {
                    //        Location = "AleksGade 82,4000 Roskilde",
                    //        Picture = "/Assets/hotel.png",
                    //        Title = "Konstantin`s Hotel",
                    //        NumberOfGuests = 4,
                    //        Price = 824,
                    //         BookdeOn = new ObservableCollection<DateTime>()
                    //   {
                    //       new DateTime(2016, 12, 24),
                    //       new DateTime(2016, 12, 30)

                    //   }
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "KristoforsGade 23, Paris",
                    //        Picture = "/Assets/francehotel.jpg",
                    //        Title = "France Hotel",
                    //        NumberOfGuests = 4,
                    //        Price = 798
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "Golden Beach 23, Bulgaria",
                    //        Picture = "/Assets/a8330c07999fbdcbf72e5417c0b01e49.jpg",
                    //        Title = "Sea Hotel",
                    //        NumberOfGuests = 5,
                    //        Price = 1214
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "Carlton street 23, Paris",
                    //        Picture = "/Assets/1382964558_002831-01-exterior-from-water.jpg",
                    //        Title = "Carlton Hotel",
                    //        NumberOfGuests = 1,
                    //        Price = 645
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "Wolfstreet 42, USA",
                    //        Picture = "/Assets/Hotel-Martinez-Cannes-568x378.jpg",
                    //        Title = "Martinez Hotel",
                    //        NumberOfGuests = 1,
                    //        Price = 645
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "Golden Beach 23, Bulgaria",
                    //        Picture = "/Assets/a8330c07999fbdcbf72e5417c0b01e49.jpg",
                    //        Title = "Sea Hotel",
                    //        NumberOfGuests = 5,
                    //        Price = 1214
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "Wolfstreet 42, USA",
                    //        Picture = "/Assets/Hotel-Martinez-Cannes-568x378.jpg",
                    //        Title = "Martinez Hotel",
                    //        NumberOfGuests = 1,
                    //        Price = 645
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "KristoforsGade 23, Paris",
                    //        Picture = "/Assets/francehotel.jpg",
                    //        Title = "France Hotel",
                    //        NumberOfGuests = 4,
                    //        Price = 798
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "Carlton street 23, Paris",
                    //        Picture = "/Assets/1382964558_002831-01-exterior-from-water.jpg",
                    //        Title = "Carlton Hotel",
                    //        NumberOfGuests = 1,
                    //        Price = 645
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "Wolfstreet 42, USA",
                    //        Picture = "/Assets/Hotel-Martinez-Cannes-568x378.jpg",
                    //        Title = "Martinez Hotel",
                    //        NumberOfGuests = 1,
                    //        Price = 645
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "KristoforsGade 23, Paris",
                    //        Picture = "/Assets/francehotel.jpg",
                    //        Title = "France Hotel",
                    //        NumberOfGuests = 4,
                    //        Price = 798
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "Carlton street 23, Paris",
                    //        Picture = "/Assets/1382964558_002831-01-exterior-from-water.jpg",
                    //        Title = "Carlton Hotel",
                    //        NumberOfGuests = 1,
                    //        Price = 645
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "Golden Beach 23, Bulgaria",
                    //        Picture = "/Assets/a8330c07999fbdcbf72e5417c0b01e49.jpg",
                    //        Title = "Sea Hotel",
                    //        NumberOfGuests = 5,
                    //        Price = 1214
                    //    },
                    //    new Accommodation()
                    //    {
                    //        Location = "KristoforsGade 23, Paris",
                    //        Picture = "/Assets/francehotel.jpg",
                    //        Title = "France Hotel",
                    //        NumberOfGuests = 4,
                    //        Price = 798
                    //    },


                };


                Load();
            }
        }

        public async void Load()
        {
            try
            {
                Serialize ser = new Serialize();
                ObservableCollection<Accommodation> loadedelp = await ser.LoadAccommodations();
                ListOfAccommodations = loadedelp;
            }
            catch (Exception)
            {

                ListOfAccommodations.Clear();
            }
        }
        public void DoAddReservation()
        {
            try
            {
                var reservation = Reservation;
                reservation = new Reservation(Reservation);
                Reservation res = _reservationsCatalog.ReserveAnApartment(reservation);

                _listOfReservations.Add(res);
                _serialize.SaveReservations(Reservations);
                RegisterReservationMessage = "Your reservation has been accepted by the system!";
                RegisterReservationMessageColor = "White";
                OnPropertyChanged(nameof(RegisterReservationMessage));
                OnPropertyChanged(nameof(RegisterReservationMessageColor));
                Reservation = new Reservation();
            }
            catch (ArgumentOutOfRangeException exc)
            {
                RegisterReservationMessage = exc.Message;
                RegisterReservationMessageColor = "red";
                OnPropertyChanged(nameof(RegisterReservationMessage));
                OnPropertyChanged(nameof(RegisterReservationMessageColor));
            }
            catch (ArgumentNullException ex)
            {
                RegisterReservationMessage = ex.Message;
                RegisterReservationMessageColor = "red";
                OnPropertyChanged(nameof(RegisterReservationMessage));
                OnPropertyChanged(nameof(RegisterReservationMessageColor));
            }
            catch (ArgumentException ex)
            {
                RegisterReservationMessage = ex.Message;
                RegisterReservationMessageColor = "red";
                OnPropertyChanged(nameof(RegisterReservationMessage));
                OnPropertyChanged(nameof(RegisterReservationMessageColor));
            }
            //catch (Exception ex)
            //{
            //    RegisterReservationMessage = ex.Message;
            //    RegisterReservationMessageColor = "red";
            //    OnPropertyChanged(nameof(RegisterReservationMessage));
            //    OnPropertyChanged(nameof(RegisterReservationMessageColor));
            //}

        }

        public void DoSearchCommand()
        {
            try
            {
                SearchedAccommodations = SearchAccommodation.SearchItems(ListOfAccommodations, SearchAccommodation);

            }
            catch (Exception ex)
            {


            }

        }
        public void DoSortCommand()
        {
            try
            {
                SearchedAccommodations = SearchAccommodation.SortSearchResults(SearchedAccommodations,
                    SearchAccommodation.SortString.Content.ToString());
            }
            catch (Exception e)
            {

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
