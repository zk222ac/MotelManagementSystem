using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Annotations;
using BookingSystem.Model;
using BookingSystem.Persistancy;

namespace BookingSystem.ViewModel
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private Accommodation _selecetedAccommodation;
        private readonly Serialize _serialize;
        private ObservableCollection<Accommodation> _selectedListView;
        private string _title;

        public ObservableCollection<Accommodation> SelectedListView
        {
            get { return this._selectedListView; }
            set
            {
                _selectedListView = value;
                OnPropertyChanged(nameof(SelectedListView));
            }
        }

        public Accommodation SelectedAccommodation
        {
            get { return this._selecetedAccommodation; }
            set
            {
                this._selecetedAccommodation = value;
                OnPropertyChanged(nameof(SelectedAccommodation));
            }
        }
        public RelayCommand RemoveCommand { get; set; }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string RemoveAccommodationMessage { get; set; }
        public AdminViewModel()
        {
            _serialize = new Serialize();
            RemoveCommand = new RelayCommand(DoRemoveAccommodation);
            SelectedAccommodation = new Accommodation();
            _selectedListView = new ObservableCollection<Accommodation>();
            Load();
        }
        public async void Load()
        {
            try
            {
                Serialize ser = new Serialize();
                ObservableCollection<Accommodation> loadedelp = await ser.LoadAccommodations();
                SelectedListView = loadedelp;
            }
            catch (Exception)
            {

                _selectedListView.Clear();
            }
        }
        public void DoRemoveAccommodation()
        {
            try
            {
                string t = Title;
                foreach (var accommodations in SelectedListView)
                {
                    if (t == accommodations.Title)
                    {
                        SelectedListView.Remove(accommodations);
                        _serialize.SaveAccommodations(SelectedListView);
                        Title = "";
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Title = "Something went wrong try again!";

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
