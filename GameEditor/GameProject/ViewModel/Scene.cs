using GameEditor.Components;
using GameEditor.Utilities;
using GameEngine;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameEditor.GameProject.ViewModel
{
    [DataContract]
    public class Scene : ViewModelBase
    {
        [DataMember]
        public SkiaSharpService SkiaSharpRender { get; private set; }

        private string _name = "";
        [DataMember]
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

        [DataMember]
        public Project ProjectReference { get; private set; }

        private bool _isActive;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged(nameof(IsActive));
                }
            }
        }

        [DataMember(Name = nameof(GameObjects))]
        private readonly ObservableCollection<GameObject> _gameObjects = new ObservableCollection<GameObject>();
        public ReadOnlyObservableCollection<GameObject> GameObjects { get; private set; }

        public ICommand AddGameObjectCommand { get; private set; }
        public ICommand RemoveGameObjectCommand { get; private set; }

        private void AddGameObject(GameObject gameObject)
        {
            Debug.Assert(!_gameObjects.Contains(gameObject));
            _gameObjects.Add(gameObject);
        }

        private void RemoveGameObject(GameObject gameObject)
        {
            Debug.Assert(_gameObjects.Contains(gameObject));
            _gameObjects.Remove(gameObject);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (_gameObjects != null)
            {
                GameObjects = new ReadOnlyObservableCollection<GameObject>(_gameObjects);
                OnPropertyChanged(nameof(GameObjects));
            }

            AddGameObjectCommand = new RelayCommand<GameObject>(x =>
            {
                AddGameObject(x);
                var gameObjectIndex = _gameObjects.Count - 1;

                Project.UndoRedo.Add(new UndoRedoAction(
                    () => RemoveGameObject(x),
                    () => _gameObjects.Insert(gameObjectIndex, x),
                    $"Add {x.Name} to {Name}"));
            });

            RemoveGameObjectCommand = new RelayCommand<GameObject>(x =>
            {
                var gameObjectIndex = _gameObjects.IndexOf(x);
                RemoveGameObject(x);

                Project.UndoRedo.Add(new UndoRedoAction(
                    () => _gameObjects.Insert(gameObjectIndex, x),
                    () => RemoveGameObject(x),
                    $"Remove {x.Name} from {Name}"));
            });

        }

        public Scene(Project project, string name)
        {
            Debug.Assert(project != null);
            ProjectReference = project;
            SkiaSharpRender = new SkiaSharpService();
            Name = name;

            OnDeserialized(new StreamingContext());
        }

        public Scene()
        { }
    }
}
