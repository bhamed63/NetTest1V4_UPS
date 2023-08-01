using System;
using System.Windows;
using System.Windows.Data;

namespace NetTest1V4_UPS.TypeConverters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType == typeof(Visibility))
            {
                if ((Boolean)value)
                    return Visibility.Visible;
                else 
                    return Visibility.Collapsed;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }

        #endregion
    }
}
