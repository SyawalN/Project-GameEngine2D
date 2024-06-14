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
                    _colorName = value;
                    SKColor = GetSKColorFromName(value);
                    OnPropertyChanged(nameof(ColorName));
                    SceneView.OnPropertyChanged_UpdateCanvas(SceneView.Instance.ActiveScene);
                }
            }
        }

        private SKColor _skColor;
        [DataMember]
        public SKColor SKColor
        {
            get => _skColor;
            set
            {
                if (_skColor != value)
                {
                    _skColor = value;
                    OnPropertyChanged(nameof(SKColor));
                }
            }
        }

        private string _paintMode;
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

        private SKColor GetSKColorFromName(string colorName)
        {
            colorName = colorName.ToLower();

            return colorName == "red" ? SKColors.Red :
                   colorName == "green" ? SKColors.Green :
                   colorName == "blue" ? SKColors.Blue :
                   colorName == "cyan" ? SKColors.Cyan :
                   colorName == "magenta" ? SKColors.Magenta :
                   colorName == "yellow" ? SKColors.Yellow :
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
            PaintMode = "Stroke";
        }

        public SpriteRenderer()
        { }
    }
}
