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
using GameEditor.GameProject.ViewModel;

namespace GameEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Subscribe untuk event 'Loaded' dan 'Closing'
            Loaded += OnMainWindowLoaded;
            Closing += OnMainWindowClosed;
        }
        
        // EventHandler - Ketika jendela dimuat
        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            // Unsubscribe event 'Loaded'
            Loaded -= OnMainWindowLoaded;
            
            // Membuka jendela Project Menu (ProjectMenu.xaml)
            OpenProjectMenu();
        }

        // EventHandler - Ketika jendela ditutup
        private void OnMainWindowClosed(object sender, CancelEventArgs e)
        {
            // Unsubscribe event 'Closing'
            Closing -= OnMainWindowClosed;

            // Ketika jendela ditutup:
            // Jika terdapat DataContext pada Project, maka keluarkan DataContext
            Project.Current?.Unload();
        }

        private void OpenProjectMenu()
        {
            var projectMenu = new GameProject.ProjectMenu();
            if (projectMenu.ShowDialog() == false || projectMenu.DataContext == null)
            {
                Application.Current.Shutdown();
            }
            else
            {
                // Jika membuka project lain, maka Unload project sekarang
                Project.Current?.Unload();

                // DataContext jendela saat ini
                DataContext = projectMenu.DataContext;
            }
        }
    }
}
