using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using BookingSystem.Model;

namespace BookingSystem.Converter
{
    public class BoleanServicesConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
             var result = (bool) value;
            switch (result)
            {
                case true:
                    return " - Yes";
                    
                default:
                    return " - No";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
