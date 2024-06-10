using GameEditor.GameProject.ViewModel;
using GameEditor.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        // EventHandler - Apabila user menekan tombol 'Create Project'
        private void OnClickBtn_Create(object sender, RoutedEventArgs e)
        {
            // Data context ViewModel - Create Project
            var vm = DataContext as CreateProject;

            // Lokasi file project yang baru dibuat
            var projectPath = vm.NewProject(vm.getProjectTemplate());
            bool dialogResult = false;
            var win = Window.GetWindow(this);
            if (!string.IsNullOrEmpty(projectPath))
            {
                dialogResult = true;
                var project = OpenProject.Open(new ProjectData { ProjectName = vm.ProjectName, ProjectPath = projectPath });
                win.DataContext = project;
            }
            win.DialogResult = dialogResult;
            win.Close();
        }

        private void OnClickButton_OpenExplorer(object sender, RoutedEventArgs e)
        {
            var d = DataContext as CreateProject;
            try
            {
                if (!Directory.Exists(d.ProjectPath)) Directory.CreateDirectory(d.ProjectPath);
                var dialog = new FolderPicker();
                dialog.InputPath = d.ProjectPath;
                if (dialog.ShowDialog() == true)
                {
                    d.ProjectPath = dialog.ResultPath;
                } 
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
