using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class SkiaSharpService
    {
        public static int posX = 0;

        public void Render(SKCanvas canvas, Vector3 position, Vector2 scale, SKPaint customPaint)
        {
            // Object
            canvas.DrawRect(position.X, position.Y, scale.X, scale.Y, customPaint);
        }
    }
}
