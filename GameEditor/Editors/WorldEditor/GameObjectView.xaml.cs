using GameEditor.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for GameObjectView.xaml
    /// </summary>
    public partial class GameObjectView : UserControl
    {
        public static GameObjectView Instance { get; private set; }
        public GameObjectView()
        {
            InitializeComponent();
            DataContext = null;
            Instance = this;
        }

        private void OnClick_ToggleBtn(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = !popup.IsOpen;
            if (DataContext != null && DataContext is GameObject gameObject)
            {
                bool toggleTransform = true;
                bool toggleSpriteRenderer = true;
                bool toggleController = true;

                foreach (Component component in gameObject.Components)
                {
                    if (component is Components.Transform)
                    {
                        toggleTransform = false;
                    }
                    else if (component is SpriteRenderer)
                    {
                        toggleSpriteRenderer = false;
                    }
                }

                Toggle_ListBoxItem("Transform", toggleTransform);
                Toggle_ListBoxItem("Sprite Renderer", toggleSpriteRenderer);
            }
        }

        private void OnSelectionChanged_ListBox(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var item = listBox.SelectedItem as ListBoxItem;
            if (item.IsEnabled)
                popup.IsOpen = false;
            Debug.WriteLine(item.IsEnabled);
        }

        private void Toggle_ListBoxItem(string ItemContent, bool isEnabled)
        {
            foreach (ListBoxItem listBoxItem in component_listBox.Items)
            {
                if (listBoxItem.Content.ToString() == ItemContent)
                {
                    listBoxItem.IsEnabled = isEnabled;
                    break;
                }
            }
        }
    }
}
