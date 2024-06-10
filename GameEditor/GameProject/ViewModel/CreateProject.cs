using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using GameEditor;
using GameEditor.Utilities;
using System.Collections.ObjectModel;

namespace GameEditor.GameProject.ViewModel
{
    [DataContract]
    public class ProjectTemplate
    {
        [DataMember]
        public string ProjectFile { get; set; }
        [DataMember]
        public List<string> Folders { get; set; }
        public string ProjectFilePath { get; set; }
    }

    class CreateProject : ViewModelBase
    {
        // DIrektori untuk template membuat project
        private readonly string _templateTestPath = @"C:\Users\ACER\source\repos\GameEngine2D\GameEditor\ProjectTemplates";
        private string _projectName = "New Project";
        public string ProjectName
        {
            get => _projectName;
            set
            {
                if (_projectName != value)
                {
                    _projectName = value;
                    ValidateProject();
                    OnPropertyChanged(nameof(ProjectName));
                }
            }
        }

        // Direktori bawaan untuk lokasi project
        private string _projectPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\2dProjects\";
        public string ProjectPath
        {
            get => _projectPath;
            set
            {
                if (_projectPath != value)
                {
                    _projectPath = value;
                    ValidateProject();
                    OnPropertyChanged(nameof(ProjectPath));
                }
            }
        }

        private bool _isValid;
        public bool IsValid
        {
            get => _isValid;
            set
            {
                if (_isValid != value)
                {
                    _isValid = value;
                    OnPropertyChanged(nameof(IsValid));
                }
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        private ProjectTemplate _projectTemplateItem;
        public ProjectTemplate ProjectTemplateItem
        {
            get => _projectTemplateItem;
            set
            {
                if (_projectTemplateItem != value)
                {
                    _projectTemplateItem = value;
                    OnPropertyChanged(nameof(ProjectTemplateItem));
                }
            }
        }

        public ProjectTemplate getProjectTemplate()
        {
            return ProjectTemplateItem;
        }

        // Validasi apakah nama dan path projek valid
        private bool ValidateProject()
        {
            var path = ProjectPath;
            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString())) path += @"\";
            path += $@"{ProjectName}\";

            IsValid = false;
            if (string.IsNullOrEmpty(ProjectName.Trim()))
            {
                ErrorMessage = "Please type in project name.";
            }
            else if (ProjectName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                ErrorMessage = "Project name contains invalid character(s).";
            }
            else if (String.IsNullOrEmpty(ProjectPath.Trim()))
            {
                ErrorMessage = "Please type in project path";
            }
            else if (ProjectPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                ErrorMessage = "Project path contains invalid character(s).";
            }
            else if (Directory.Exists(path) && Directory.EnumerateFileSystemEntries(path).Any())
            {
                ErrorMessage = "Project folder already exists or is not empty";
            }
            else
            {
                ErrorMessage = string.Empty;
                IsValid = true;
            }

            return IsValid;
        }

        public string NewProject(ProjectTemplate template)
        {
            // Validasi data dari field input
            ValidateProject();

            // Jika input salah, maka kembalikan nilai string kosong
            if (!IsValid) return string.Empty;

            // Jika data dari lokasi project tidak berakhiran dengan '\', maka tambahkan tanda '\'
            if (!ProjectPath.EndsWith(Path.DirectorySeparatorChar.ToString())) ProjectPath += @"\";
            var path = $@"{ProjectPath}{ProjectName}\";

            try
            {
                // Jika file belum ada pada direktori, maka buat folder baru
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                foreach (var folder in template.Folders)
                {
                    // Membuat folder baru pada direktori
                    Directory.CreateDirectory(Path.GetFullPath( Path.Combine(Path.GetDirectoryName(path), folder) ));
                }

                // Membuat direktori '.GameEngine2D' dan setel sebagai direktori tersembunyi
                var dirInfo = new DirectoryInfo(path + @"\.GameEngine2D");
                dirInfo.Attributes |= FileAttributes.Hidden;

                // Membaca data pada template
                var projectXML = File.ReadAllText(template.ProjectFilePath);
                projectXML = string.Format(projectXML, ProjectName, ProjectPath);

                var projectPath = Path.GetFullPath( Path.Combine(path, $"{ProjectName}{Project.Extension}") );
                File.WriteAllText(projectPath, projectXML);
                
                return path;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Logger.Log(MessageType.Error, $"Failed to create {ProjectName}");
                throw;
            }
        }

        // CONSTRUCTOR
        // Create Project - Membuat project
        public CreateProject()
        {
            try
            {
                // Mencari file pada direktori dan menelusuri setiap direktori di dalamnya
                var templateFiles = Directory.GetFiles(_templateTestPath, "template.xml", SearchOption.AllDirectories);
                Debug.Assert(templateFiles.Any());

                // Membagi setiap data dari list file
                foreach (var file in templateFiles)
                {
                    //// Create template files in template path
                    //var template = new ProjectTemplate()
                    //{
                    //    ProjectFile = "project.2dproj",
                    //    Folders = new List<string>() { ".GameEngine2D", "Content", "GameCode" }
                    //};
                    //Serializer.ToFile(template, file);

                    // Membaca file 'template.xml' yang telah diserialisasi
                    var template = Serializer.FromFile<ProjectTemplate>(file);

                    template.ProjectFilePath = Path.GetFullPath( Path.Combine(Path.GetDirectoryName(file), template.ProjectFile) );
                    ProjectTemplateItem = template;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                Logger.Log(MessageType.Error, $"Failed to read project template");
                throw;
            }
        }
    }
}
