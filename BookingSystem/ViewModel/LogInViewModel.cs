using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using BookingSystem.Annotations;
using BookingSystem.Catalogs;
using BookingSystem.Model;
using BookingSystem.View;

namespace BookingSystem.ViewModel
{
    public class LogInViewModel : INotifyPropertyChanged
    {
        public EmployeeCatalog EmployeeCatalog;
        private string _displayVisibility;
        private string _displayText;
        private FrameNavigation _frameNavigation;
        public RelayCommand AddItemCommand { get; set; }
        public Employee Employees { get; set; }
        public string DisplayVisibility
        {
            get { return this._displayVisibility; }
            set
            {
                this._displayVisibility = value;
                OnPropertyChanged(nameof(DisplayVisibility));
            }
        }
        public string DisplayText
        {
            get { return this._displayText; }
            set
            {
                this._displayText = value;
                OnPropertyChanged(nameof(DisplayText));
            }
        }
        public LogInViewModel()
        {
            EmployeeCatalog = new EmployeeCatalog();
            Employees = new Employee();
            AddItemCommand = new RelayCommand(DoLogInUser);
            _frameNavigation = new FrameNavigation();
        }
        public async Task<string> SendLogInInfo(string userName, string password)
        {
            return await EmployeeCatalog.Verify(userName, password);
        }
        public async void DoLogInUser()
        {
            try
            {
                string s = await SendLogInInfo(Employees.UserName, Employees.Password);
                if (s == "Owner")
                {
                    Type type = typeof(Rent);
                    _frameNavigation.ActivateFrameNavigation(type);
                }
                else if (s == "Administrator")
                {
                    Type type = typeof(Admin);
                    _frameNavigation.ActivateFrameNavigation(type);
                }
                else
                {
                    DisplayVisibility = Visibility.Visible.ToString();
                    DisplayText = "Wrong username or password";
                }
            }
            catch (Exception ex)
            {
                DisplayVisibility = Visibility.Visible.ToString();
                DisplayText = ex.Message;

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
