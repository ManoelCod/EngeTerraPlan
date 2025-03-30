using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace EngeTerraPlan.Ultils
{
    public class RadioButtonConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value?.ToString() == parameter?.ToString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return (bool)value ? parameter?.ToString() : null;
        }
    }
}
