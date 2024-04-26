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
using System.Windows.Shapes;

namespace GameEditor.GameProject
{
    /// <summary>
    /// Interaction logic for ProjectMenu.xaml
    /// </summary>
    public partial class ProjectMenu : Window
    {
        public ProjectMenu()
        {
            InitializeComponent();
        }

        private void button_Clicked(object sender, RoutedEventArgs e)
        {
            if (sender == openProjectButton)
            {
                if (createProjectButton.IsChecked == true)
                {
                    WindowPanel.HorizontalAlignment = HorizontalAlignment.Left;
                    createProjectButton.IsChecked = false;
                }
                openProjectButton.IsChecked = true;
            }
            else if (sender == createProjectButton)
            {
                if (openProjectButton.IsChecked == true)
                {
                    WindowPanel.HorizontalAlignment = HorizontalAlignment.Right;
                    openProjectButton.IsChecked = false;
                }
                createProjectButton.IsChecked = true;
            }
        }
    }
}
