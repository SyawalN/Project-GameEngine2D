using GameEditor.Components;
using GameEditor.GameProject.ViewModel;
using GameEngine;
using SkiaSharp;
using SkiaSharp.Views.WPF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameEditor.Editors
{
    /// <summary>
    /// Interaction logic for GamePlayView.xaml
    /// </summary>
    public partial class GamePlayView : Window
    {
        private static SKElement Renderer { get; set; }
        private bool isListening = false;

        public GamePlayView()
        {
            InitializeComponent();
        }

        private void OnPaintSurface_SKElement(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            SKCanvas canvas = e.Surface.Canvas;
            float scaleX = (float)(e.Info.Width / SKElement.ActualWidth);
            float scaleY = (float)(e.Info.Height / SKElement.ActualHeight);

            canvas.Clear();
            canvas.Scale(scaleX, scaleY);

            // Simpan gameObject yang bergerak
            List<GameObject> movingObjects = new List<GameObject>();

            if (GameInstance.Game != null && GameInstance.Game.CurrentScene is Scene scene && scene != null)
            {
                Components.Transform transform = null;
                SpriteRenderer sprite = null;

                foreach (GameObject gameObject in scene.GameObjects)
                {
                    if (gameObject.IsEnabled == false) continue;
                    foreach (Component component in gameObject.Components)
                    {
                        if (component is Components.Transform t)
                        {
                            transform = t;
                        }
                        else if (component is SpriteRenderer sr)
                        {
                            sprite = sr;
                        }
                    }

                    if (sprite != null && sprite.PaintMode != "None")
                    {
                        if (sprite.PaintMode == "Solid Color")
                            scene.SkiaSharpRender.RenderSolidColor(canvas, transform.Position.Vector, transform.Scale.Vector, new SKPaint()
                            {
                                Color = sprite.SKPaintColor,
                                Style = sprite.SKPaintStyle,
                                IsAntialias = true
                            });
                        else if (sprite.PaintMode == "Image")
                        {
                            scene.SkiaSharpRender.RenderImage(canvas, GameInstance.Game.Position, transform.Scale.Vector, sprite.ImagePath);
                        }
                    }

                    // Butuh implementasi movingObjects
                    if (!isListening)
                    {
                        Components.Transform t = gameObject.Components.FirstOrDefault(x => x is Components.Transform) as Components.Transform;
                        GameInstance.Game.Position = t.Position.Vector;

                        SpriteRenderer sr = gameObject.Components.FirstOrDefault(x => x is SpriteRenderer) as Components.SpriteRenderer;
                        GameInstance.Game.ImagePath = sr.ImagePath;

                        KeyEventHandler OnKeyDown = (sender, e) => OnKeyDownRender(sender, e);
                        this.KeyDown += OnKeyDown;
                        isListening = true;
                    }
                }
            }
        }


        private bool isJumping = false;
        private async void OnKeyDownRender(object sender, KeyEventArgs e)
        {
            bool doInvalidateVisual = false;

            if (e.Key == Key.Space)
            {
                if (!isJumping)
                {
                    isJumping = true;
                    float currentJump = GameInstance.Game.Position.Y;
                    for (int i = 0; i < 10; i++)
                    {
                        GameInstance.Game.Position.Y -= 5;
                        SKElement.InvalidateVisual();
                        await Task.Delay(10);
                    }

                    currentJump = currentJump - GameInstance.Game.Position.Y;
                    for (int i = 0; i < currentJump / 5; i++)
                    {
                        GameInstance.Game.Position.Y += 5;
                        SKElement.InvalidateVisual();
                        await Task.Delay(10);
                    }

                    isJumping = false;
                    doInvalidateVisual = true;
                }
            }
            else
            {
                if (e.Key == Key.A)
                {
                    if (GameInstance.Game.ImagePath != @"C:\Users\ACER\OneDrive\Documents\2dProjects\ProjectNew\Assets\sprites\Knight-Left.png")
                        GameInstance.Game.ImagePath = @"C:\Users\ACER\OneDrive\Documents\2dProjects\ProjectNew\Assets\sprites\Knight-Left.png";
                    for (int i = 0; i < 10; i++)
                    {
                        GameInstance.Game.Position.X -= 1;
                        SKElement.InvalidateVisual();
                    }
                    doInvalidateVisual = true;
                }
                else if (e.Key == Key.D)
                {
                    GameInstance.Game.ImagePath = @"C:\Users\ACER\OneDrive\Documents\2dProjects\ProjectNew\Assets\sprites\Knight-Right.png";
                    for (int i = 0; i < 10; i++) {
                        GameInstance.Game.Position.X += 1;
                        SKElement.InvalidateVisual();
                    }
                }
            }

            if (doInvalidateVisual)
            {
                SKElement.InvalidateVisual();
            }
        }

        private void OnLoaded_SKElement(object sender, RoutedEventArgs e)
        {
            var renderer = sender as SKElement;
            if (renderer != null)
            {
                Renderer = renderer;
            }
        }
    }
}
