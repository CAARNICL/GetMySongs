using System;
using System.Globalization;
using Xamarin.Forms;

namespace GetMySongs.Helper
{
    public class BoolToColorConverter : IValueConverter
    {
        public BoolToColorConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                {
                    return Color.LightGreen;
                }
            }
            return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
