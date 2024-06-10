using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GameEditor.Utilities
{
    class Vector3Converter : ViewModelBase, IMultiValueConverter
    {
        private float _positionX;
        public float PositionX
        {
            get => _positionX;
            set
            {
                if (_positionX != value)
                {
                    _positionX = value;
                    OnPropertyChanged(nameof(PositionX));
                }
            }
        }

        private float _positionY;
        public float PositionY
        {
            get => _positionY;
            set
            {
                if (_positionY != value)
                {
                    _positionY = value;
                    OnPropertyChanged(nameof(PositionY));
                }
            }
        }

        private float _positionZ;
        public float PositionZ
        {
            get => _positionZ;
            set
            {
                if (_positionZ != value)
                {
                    _positionZ = value;
                    OnPropertyChanged(nameof(PositionZ));
                }
            }
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 3)
            {
                return new Vector3
                {
                    X = (float)values[0],
                    Y = (float)values[1],
                    Z = (float)values[2]
                };
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var vector = (value != null) ? (Vector3)value : default(Vector3);
            return new object[] { vector.X, vector.Y, vector.Z };
        }
    }
}
