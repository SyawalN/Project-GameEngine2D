using GameEditor.Components;
using GameEditor.GameProject.ViewModel;
using GameEditor.Utilities;
using Microsoft.Win32;
using SkiaSharp;
using System;
using System.IO;
using System.Collections.Generic;
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

namespace GameEditor.Editors
{
    /// <summary>
    /// Interaction logic for SpriteRendererView.xaml
    /// </summary>
    public partial class SpriteRendererView : UserControl
    {
        public SpriteRendererView()
        {
            InitializeComponent();
            PopulateContextMenu();
            Loaded += OnLoad_SpriteRendererView;
        }

        private void OnLoad_SpriteRendererView(object sender, RoutedEventArgs e)
        {
            Loaded -= OnLoad_SpriteRendererView;
            string menuState = Btn_RenderType.Content as string;
            ExtraMenu.ContentTemplate = FindResource(menuState) as DataTemplate;
        }

        private void PopulateContextMenu()
        {
            string[] menuItemTitles = { "None", "Solid Color", "Image" };

            foreach (string title in menuItemTitles)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Header = title;
                menuItem.Click += OnClick_MenuItem;

                Btn_RenderType.ContextMenu.Items.Add(menuItem);
            };
        }

        private void OnClick_MenuItem(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            string selectedItem = menuItem.Header.ToString();

            Btn_RenderType.Content = selectedItem;
            ExtraMenu.ContentTemplate = FindResource(selectedItem) as DataTemplate;
            SpriteRenderer sr = ExtraMenu.Content as SpriteRenderer;
            sr.PaintMode = selectedItem;

            if (sr.PaintMode == "None" || sr.PaintMode == "Image") sr.SKPaintColor = SKColors.Black;
            else sr.SKPaintColor = sr.GetSKColorFromName(sr.ColorName);
        }

        private void OnClick_SetImage(object sender, RoutedEventArgs e)
        {
            if (ExtraMenu.Content == null) return;
            SpriteRenderer sr = (ExtraMenu.Content is SpriteRenderer value) ? value : null;

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files|*.jpg;*.jpeg;*.png";
                dialog.InitialDirectory = $@"{Project.Current.Path}{Project.Current.Name}\Assets";
                dialog.Title = "Please select an image file to encrypt.";

                if (dialog.ShowDialog() == true)
                {
                    sr.ImagePath = dialog.FileName;
                }
                else
                {
                    sr.ImagePath = "None";
                }
            }
            catch
            {
                Logger.Log(MessageType.Error, $"Failed to open assets folder");
            }
        }
    }
}
