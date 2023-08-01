using System;
using System.Windows.Data;

namespace NetTest1V4_UPS.TypeConverters
{
    public class BooleanReverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return convert(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return convert(value);
        }

        private object convert(object value)
        {
            return value is bool ? !(bool)value : false;
        }
    }
}
