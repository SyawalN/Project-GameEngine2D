using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditor.GameProject.ViewModel
{
    public class Scene : ViewModelBase
    {
        private string _name = "";
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public Project ProjectReference { get; private set; }

        public Scene(Project project, string name)
        {
            Debug.Assert(project != null);
            ProjectReference = project;
            Name = name;
        }
    }
}
