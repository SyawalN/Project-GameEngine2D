using GameEditor.GameProject.ViewModel;
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

namespace GameEditor.GameProject.View
{
    /// <summary>
    /// Interaction logic for CreateProjectView.xaml
    /// </summary>
    public partial class CreateProjectView : UserControl
    {
        public CreateProjectView()
        {
            InitializeComponent();
        }

        private void OnClickBtn_Create(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as CreateProject;
            var projectPath = vm.NewProject(vm.getProjectTemplate());
            if (!string.IsNullOrEmpty(projectPath))
            {
                var window = Window.GetWindow(this);
                if (window != null) window.Close();
            }
        }
    }
}
