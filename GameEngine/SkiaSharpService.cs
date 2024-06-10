using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class SkiaSharpService
    {
        private static int width = 100;
        private static int height = 100;

        public void Render(SKCanvas canvas)
        {
            canvas.Clear(SKColors.White);
            var paint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                Style = SKPaintStyle.Fill
            };
            canvas.DrawRect(0, 0, width / 2, height / 2, paint);
        }

        public void Render(SKCanvas canvas, SKPaint customPaint)
        {
            canvas.Clear(SKColors.White);
            canvas.DrawRect(0, 0, width / 2, height / 2, customPaint);
        }
    }
}
