using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GameEditor.Utilities
{
    class SKColorsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string colorName)
            {
                return GetSKColorFromName(colorName);
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private SKColor GetSKColorFromName(string colorName)
        {
            switch (colorName.ToLower())
            {
                case "red":
                    return SKColors.Red;

                case "green":
                    return SKColors.Green;

                case "blue":
                    return SKColors.Blue;

                case "cyan":
                    return SKColors.Cyan;

                case "magenta":
                    return SKColors.Magenta;

                case "yellow":
                    return SKColors.Yellow;

                case "black":
                    return SKColors.Black;

                default:
                    return SKColors.Black;
            }
        }
    }
}
