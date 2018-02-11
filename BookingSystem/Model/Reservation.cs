using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Annotations;

namespace BookingSystem.Model
{
    public class Reservation : INotifyPropertyChanged
    {
        private string _fullName;
        private string _email;
        private string _telephoneNumber;
        private long _cardNumber;
        private int _expirationMonth;
        private int _expirationYear;
        private int _cvv;

        //public string FullName
        //{
        //    get { return _fullName; }
        //    set
        //    {

        //        if (!string.IsNullOrWhiteSpace(value) && !value.Any(char.IsDigit))
        //        {
        //            _fullName = value;
        //            OnPropertyChanged(nameof(FullName));
        //        }
        //        else
        //        {
        //            throw new ArgumentOutOfRangeException(nameof(FullName), "You should introduce a valid name.");
        //        }



        //    }
        //}

        public string FullName
        {
            get { return _fullName; }
            set
            {
                try
                {
                    if (value!=null)
                    {
                        _fullName = value;
                        OnPropertyChanged(nameof(FullName));
                    }
                }
                catch (NullReferenceException)
                {
                    throw new ArgumentOutOfRangeException(nameof(FullName), "You should introduce a valid name.");
                }

            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                try
                {
                    if (value.Contains("@") && value.Contains(".") && value.Length > 5)
                    {
                        _email = value;
                        OnPropertyChanged(nameof(Email));
                    }
                }
                catch (NullReferenceException nre)
                {
                    throw new ArgumentOutOfRangeException("The format of your e-mail does not meet the requirements.(contain @, .)", nre);
                }

            }
        }

        public string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set
            {
                try
                {

                    if (value.Length == 10)
                    {
                        _telephoneNumber = value;
                        OnPropertyChanged(nameof(TelephoneNumber));
                    }
                }
                catch (NullReferenceException)
                {
                    throw new ArgumentOutOfRangeException(nameof(TelephoneNumber), "The Telephone number must be 10 digits!");
                }
            }
        }

        public Int64 CardNumber
        {
            get { return _cardNumber; }
            set
            {
                if (value.ToString().Length == 16)
                {
                    _cardNumber = value;
                    OnPropertyChanged(nameof(CardNumber));
                }

                else

                {
                    throw new ArgumentOutOfRangeException(nameof(CardNumber), "The card number's length should be 16 digits!");
                }

            }
        }
        public int ExpirationMonth
        {
            get { return _expirationMonth; }
            set
            {

                if (value < 13 && value > 0 && NumberCheck(value.ToString()))
                {
                    _expirationMonth = value;
                    OnPropertyChanged(nameof(ExpirationMonth));
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(ExpirationMonth), "The expiration month of your card is not valid.");
                }
            }
        }

        public int ExpirationYear
        {
            get { return _expirationYear; }
            set
            {
                string b = value.ToString();
                if (b.Length == 2 && NumberCheck(value.ToString()) && int.Parse(b) > 16)
                {
                    _expirationYear = value;
                    OnPropertyChanged(nameof(ExpirationYear));
                }
                else if (int.Parse(b) == 16 && _expirationMonth == 12)
                {
                    _expirationYear = value;
                    OnPropertyChanged(nameof(ExpirationYear));
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(ExpirationYear), "The introduced expiration year is not valid.");
                }
            }
        }


        //public int ExpirationYear
        //{
        //    get { return _expirationYear; }
        //    set
        //    {
        //        if (_expirationYear>16)
        //        {
        //            _expirationYear = value;
        //            OnPropertyChanged(nameof(ExpirationYear));
        //        }
        //        else if (_expirationYear == 16 && _expirationMonth == 12)
        //        {
        //            _expirationYear = value;
        //            OnPropertyChanged(nameof(ExpirationYear));
        //        }
        //        else
        //        {
        //            throw new ArgumentOutOfRangeException(nameof(_expirationYear), "The introduced expiration year is not valid.");
        //        }
        //    }
        //}

        public int Cvv
        {
            get { return _cvv; }
            set
            {
                string a = value.ToString();
                if (a.Length == 3 && NumberCheck(a))
                {
                    _cvv = value;
                    OnPropertyChanged(nameof(Cvv));
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Cvv), "Yout CVV's lenght should be 3 digits.");
                }
            }
        }

        private bool NumberCheck(string value)
        {
            var isTrue = true;
            foreach (var c in value)
            {
                if (char.IsDigit(c))
                    continue;
                isTrue = false;
                break;
            }
            return isTrue;
        }

        public Reservation()
        {

        }

        public Reservation(Reservation reservation)
        {
            FullName = reservation.FullName;
            Email = reservation.Email;
            TelephoneNumber = reservation.TelephoneNumber;
            CardNumber = reservation.CardNumber;
            ExpirationMonth = reservation.ExpirationMonth;
            ExpirationYear = reservation.ExpirationYear;
            Cvv = reservation.Cvv;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
