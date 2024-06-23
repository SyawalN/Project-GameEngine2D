using GameEditor.GameProject.ViewModel;
using GameEditor.Utilities.Wrapper;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameEditor
{
    class GameInstance : ViewModelBase
    {
        public static GameInstance Game { get; set; }
        public Project Project { get; set; }

        private Scene _currentScene;
        public Scene CurrentScene
        {
            get => _currentScene;
            set
            {
                if (_currentScene != value)
                {
                    _currentScene = value;
                    OnPropertyChanged(nameof(CurrentScene));
                }
            }
        }

        public List<Scene> Scenes;
        public Vector3 Position;
        public string ImagePath;

        public GameInstance()
        {
            Scenes = Project.Current.Scenes.ToList();
            CurrentScene = (Scenes.Count > 0) ? Scenes.FirstOrDefault(x => x.IsActive == true) : null;
        }
    }
}
