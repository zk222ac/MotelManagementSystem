using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace BookingSystem.Converter
{
    class FormatConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is decimal)
            {
                return ((decimal)value).ToString("00.00");
            }
            else if (value is int)
            {
                if (parameter == null)
                {
                    return ((int)value).ToString("d1");
                }

                else
                {
                    return ((int)value).ToString(parameter.ToString());
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string type = parameter as string;

            if (type == "d2")
            {
                try
                {
                    return decimal.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    value = null;
                }
            }

            return value;
        }
    }
}
