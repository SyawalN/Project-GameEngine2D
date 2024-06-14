using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GameEditor.Utilities
{
    public class Vector3Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is float vectorValue && parameter is string component)
            {
                switch (component)
                {
                    case "X":
                        return vectorValue;
                    case "Y":
                        return vectorValue;
                    case "Z":
                        return vectorValue;
                }
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            if (value is float vectorValue && parameter is string component)
            {
                switch (component)
                {
                    case "X":
                        return vectorValue;
                    case "Y":
                        return vectorValue;
                    case "Z":
                        return vectorValue;
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
