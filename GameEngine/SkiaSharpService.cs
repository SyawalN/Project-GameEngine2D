using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class SkiaSharpService
    {
        public float posX;
        public float posY;

        // Render solid color
        public void RenderSolidColor(SKCanvas canvas, Vector3 position, Vector2 scale, SKPaint customPaint)
        {
            // Object
            canvas.DrawRect(position.X, position.Y, scale.X, scale.Y, customPaint);
        }

        // Render image
        public void RenderImage(SKCanvas canvas, Vector3 position, Vector2 scale, string imagePath)
        {
            try
            {
                SKBitmap bitmap = SKBitmap.Decode(imagePath);
                SKRect rect = new SKRect(position.X, position.Y, position.X + scale.X, position.Y + scale.Y);
                canvas.DrawBitmap(bitmap, rect);
            }
            catch
            {
                canvas.DrawRect(position.X, position.Y, scale.X, scale.Y, new SKPaint()
                {
                    Color = SKColors.Purple,
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 4,
                    IsAntialias = true
                });
            }
        }

        public void GamePlayRender(SKCanvas canvas, Vector3 position, Vector2 scale, string RenderType, SKPaint customPaint)
        {
            if (RenderType == "image")
            {
                canvas.DrawRect(position.X, position.Y, scale.X, scale.Y, customPaint);
            }
            else if (RenderType == "solid color")
            {
                Debug.WriteLine("Solid Color");
            }
        }
    }
}
