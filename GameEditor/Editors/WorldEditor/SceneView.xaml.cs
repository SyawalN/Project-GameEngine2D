using GameEditor.Components;
using GameEditor.GameProject.ViewModel;
using GameEngine;
using SkiaSharp;
using SkiaSharp.Views.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            SKCanvas canvas = e.Surface.Canvas;
            List<Components.Transform> transfromList = new List<Components.Transform>();
            List<SpriteRenderer> spriteRendererList = new List<SpriteRenderer>();

            int width = 1500;
            int height = 1500;
            // Background
            canvas.DrawRect(0, 0, width, height, new SKPaint() { Color = SKColors.Gray, Style = SKPaintStyle.Fill, IsAntialias = true });

            //canvas.Clear();
            foreach (var gameObject in ActiveScene.GameObjects)
            {
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

                if (transform != null && spriteRenderer != null)
                {
                    ActiveScene?.SkiaSharpRender.Render(canvas, transform.Position.Vector, transform.Scale.Vector, new SKPaint()
                    {
                        Color = spriteRenderer.SKColor,
                        Style = spriteRenderer.SKPaintStyle,
                        IsAntialias = true
                    });
                }

                Renderer.InvalidateVisual();
            }
        }

        private static void RenderObjects(object sender, EventArgs e)
        {
            SkiaSharpService.posX += 10;
            Renderer?.InvalidateVisual();
            if (SkiaSharpService.posX > 100)
            {
                SkiaSharpService.posX = 0;
                CompositionTarget.Rendering -= RenderObjects;
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
