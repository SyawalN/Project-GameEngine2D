using GameEditor.Components;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SpriteRendererView.xaml
    /// </summary>
    public partial class SpriteRendererView : UserControl
    {
        public SpriteRendererView()
        {
            InitializeComponent();
            PopulateContextMenu();
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
        }
    }
}
