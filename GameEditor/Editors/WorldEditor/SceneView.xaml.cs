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
        public SKElement Renderer;
        public Scene ActiveScene;

        public SceneView()
        {
            InitializeComponent();
            DataContext = null;
            Instance = this;
        }

        public static void OnSceneChanged_UpdateCanvas(Scene scene, SKElement renderer)
        {
            if (scene != null && renderer != null)
            {
                renderer.InvalidateVisual();
            }
        }

        private void OnPaintSurface_SKElement(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            // if (ActiveScene != null) ActiveScene.SkiaSharpRender.Render(e.Surface.Canvas, new SKPaint() { Color = SKColors.AliceBlue, Style = SKPaintStyle.Fill, IsAntialias = true });
            ActiveScene?.SkiaSharpRender.Render(e.Surface.Canvas, new SKPaint() { Color = SKColors.Blue, Style = SKPaintStyle.Fill, IsAntialias = true });
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
