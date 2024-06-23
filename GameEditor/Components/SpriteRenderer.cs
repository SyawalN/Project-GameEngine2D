using GameEditor.Editors;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameEditor.Components
{
    [DataContract]
    class SpriteRenderer : Component
    {
        private string _colorName;
        [DataMember]
        public string ColorName
        {
            get => _colorName;
            set
            {
                if (_colorName != value)
                {
                    _colorName = value.Substring(0, 1).ToUpper() + value.ToLower().Substring(1);
                    SKPaintColor = GetSKColorFromName(_colorName);
                    OnPropertyChanged(nameof(ColorName));
                    SceneView.OnPropertyChanged_UpdateCanvas(SceneView.Instance.ActiveScene);
                }
            }
        }

        private SKColor _skPaintColor;

        // Serialize SKColor as a string type
        [DataMember(Name = "SKPaintColor")]
        private string SKPaintColor_Serialized
        {
            get => _skPaintColor.ToString();
            set => _skPaintColor = SKColor.Parse(value);
        }
        public SKColor SKPaintColor
        {
            get => _skPaintColor;
            set
            {
                if (_skPaintColor != value)
                {
                    _skPaintColor = value;
                    OnPropertyChanged(nameof(SKPaintColor));
                }
            }
        }

        private string _paintMode = "Solid Color";
        [DataMember]
        public string PaintMode
        {
            get => _paintMode;
            set
            {
                if (_paintMode != value)
                {
                    _paintMode = value;
                    SKPaintStyle = GetPaintStyleFromControlTemplate(value);
                    OnPropertyChanged(nameof(PaintMode));
                    SceneView.OnPropertyChanged_UpdateCanvas(SceneView.Instance.ActiveScene);
                }
            }
        }

        private SKPaintStyle _skPaintStyle;
        [DataMember]
        public SKPaintStyle SKPaintStyle
        {
            get => _skPaintStyle;
            set
            {
                if (_skPaintStyle != value)
                {
                    _skPaintStyle = value;
                    OnPropertyChanged(nameof(SKPaintStyle));
                }
            }
        }

        private string _imagePath = "None";
        [DataMember]
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                if (_imagePath != value)
                {
                    _imagePath = value;
                    OnPropertyChanged(nameof(ImagePath));
                }
            }
        }

        public SKColor GetSKColorFromName(string colorName)
        {
            colorName = colorName.ToLower();

            return colorName == "red" ? SKColors.Red :
                   colorName == "green" ? SKColors.Green :
                   colorName == "blue" ? SKColors.Blue :
                   colorName == "cyan" ? SKColors.Cyan :
                   colorName == "magenta" ? SKColors.Magenta :
                   colorName == "yellow" ? SKColors.Yellow :
                   colorName.Substring(0, 1) == "#" && SKColor.TryParse(colorName, out SKColor hexColor) ? hexColor :
                   colorName == "black" ? SKColors.Black : SKColors.Black;
        }

        public SKPaintStyle GetPaintStyleFromControlTemplate(string paintStyle)
        {
            switch (paintStyle.ToLower())
            {
                case "none":
                    return SKPaintStyle.Stroke;

                case "solid color":
                    return SKPaintStyle.Fill;

                default:
                    return SKPaintStyle.Stroke;
            }
        }

        public SpriteRenderer(GameObject owner) : base(owner)
        {
            ColorName = "Black";
            PaintMode = "None";
        }

        public SpriteRenderer()
        { }
    }
}
