using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OwnGame.Converters
{
    public class BoolToVisibilityInvertedConverter : IValueConverter
    {
        public BoolToVisibilityInvertedConverter()
        {
            TrueValue = Visibility.Collapsed;
            FalseValue = Visibility.Visible;
        }

        public Visibility TrueValue { get; set; }
        public Visibility FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = System.Convert.ToBoolean(value);
            return val ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TrueValue.Equals(value);
        }
    }
}