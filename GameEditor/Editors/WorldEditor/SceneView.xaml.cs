using GameEditor.Components;
using GameEditor.GameProject.ViewModel;
using GameEngine;
using SkiaSharp;
using SkiaSharp.Views.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameEditor.Editors
{
    /// <summary>
    /// Interaction logic for SceneView.xaml
    /// </summary>
    public partial class SceneView : UserControl
    {
        public static SceneView Instance { get; private set; }
        public static SKElement Renderer;
        public GameObject SelectedGameObject;
        public Scene ActiveScene;

        public SceneView()
        {
            InitializeComponent();
            DataContext = null;
            Instance = this;
        }

        public static void OnPropertyChanged_UpdateCanvas(Scene scene)
        {
            if (scene != null && Renderer != null)
            {
                Renderer.InvalidateVisual();
            }
        }

        private void OnPaintSurface_SKElement(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            if (ActiveScene == null) return;

            float scaleX = (float)(e.Info.Width / SKElement.ActualWidth);
            float scaleY = (float)(e.Info.Height / SKElement.ActualHeight);

            e.Surface.Canvas.Scale(scaleX, scaleY);

            SKCanvas canvas = e.Surface.Canvas;
            List<Components.Transform> transfromList = new List<Components.Transform>();
            List<SpriteRenderer> spriteRendererList = new List<SpriteRenderer>();

            int width = e.Info.Width;
            int height = e.Info.Height;

            // Background
            canvas.Clear();
            canvas.DrawRect(0, 0, width, height, new SKPaint() { Color = SKColors.Gray, Style = SKPaintStyle.Fill, IsAntialias = true });

            //canvas.Clear();
            foreach (var gameObject in ActiveScene.GameObjects)
            {
                if (gameObject.IsEnabled == false) continue;

                Components.Transform transform = null;
                SpriteRenderer spriteRenderer = null;

                foreach (var component in gameObject.Components)
                {

                    if (component is Components.Transform)
                    {
                        transform = (Components.Transform)component;
                    }

                    if (component is SpriteRenderer)
                    {
                        spriteRenderer = component as SpriteRenderer;
                    }
                }

                if (transform != null || spriteRenderer != null && spriteRenderer.ImagePath != "None")
                {
                    if (spriteRenderer.PaintMode == "Solid Color")
                    {
                        ActiveScene?.SkiaSharpRender.RenderSolidColor(canvas, transform.Position.Vector, transform.Scale.Vector, new SKPaint()
                        {
                            Color = spriteRenderer.SKPaintColor,
                            Style = spriteRenderer.SKPaintStyle,
                            IsAntialias = true
                        });
                    }
                    else if (spriteRenderer.PaintMode == "Image")
                    {
                        ActiveScene?.SkiaSharpRender.RenderImage(canvas, transform.Position.Vector, transform.Scale.Vector, spriteRenderer.ImagePath);
                    }
                }

                // Game object outline
                if (ActiveScene.SelectedGameObject != null && ActiveScene.SelectedGameObject.IsEnabled == true)
                {
                    Components.Transform currObject = ActiveScene.SelectedGameObject.Components.OfType<Components.Transform>().FirstOrDefault();
                    Instance.ActiveScene?.SkiaSharpRender.RenderSolidColor(canvas, currObject.Position.Vector, currObject.Scale.Vector, new SKPaint()
                    {
                        Color = SKColors.Black,
                        Style = SKPaintStyle.Stroke,
                        StrokeWidth = 2f,
                        IsAntialias = true
                    });
                }
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
