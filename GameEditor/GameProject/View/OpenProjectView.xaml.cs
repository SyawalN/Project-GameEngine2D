using GameEditor.GameProject.ViewModel;
using System;
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
using System.Windows.Shapes;

namespace GameEditor.GameProject.View
{
    /// <summary>
    /// Interaction logic for OpenProjectView.xaml
    /// </summary>
    public partial class OpenProjectView : UserControl
    {
        public OpenProjectView()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                var item = projectListBox.ItemContainerGenerator
                .ContainerFromIndex(projectListBox.SelectedIndex) as ListBoxItem;
                item?.Focus();
            };
        }

        // Membuka Project yang dipilih user dari List Project
        private void OpenSelectedProject()
        {
            // Project yang dipilih untuk dibuka
            var project = OpenProject.Open(projectListBox.SelectedItem as ProjectData);

            // Referensi jendela ini
            var currentWindow = Window.GetWindow(this);

            // Boolean - Kodingan tidak tereksekusi
            bool isProjectExist = false;
            if (project != null)
            {
                // Boolean - Kodingan tereksekusi
                isProjectExist = true;
                currentWindow.DataContext = project;
            }

            // Jika project tidak ada , maka tutup jendela saat ini
            currentWindow.DialogResult = isProjectExist;
            currentWindow.Close();
        }

        // EventHandler - Apabila user menekan tombol 'Open Project'
        private void BtnOpen_Project(object sender, RoutedEventArgs e)
        {
            OpenSelectedProject();
        }

        // EventHandler - Apabila user double click pada project di list
        private void OnListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenSelectedProject();
        }
    }
}
