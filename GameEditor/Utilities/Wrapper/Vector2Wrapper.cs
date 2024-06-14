using GameEditor.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEditor.Utilities.Wrapper
{
    [DataContract]
    class Vector2Wrapper : ViewModelBase
    {
        [DataMember]
        private Vector2 _vector;
        public Vector2 Vector => _vector;

        public float X
        {
            get => _vector.X;
            set
            {
                if (_vector.X != value)
                {
                    _vector.X = value;
                    OnPropertyChanged(nameof(X));
                    SceneView.OnPropertyChanged_UpdateCanvas(SceneView.Instance.ActiveScene);
                }
            }
        }

        public float Y
        {
            get => _vector.Y;
            set
            {
                if (_vector.Y != value)
                {
                    _vector.Y = value;
                    OnPropertyChanged(nameof(Y));
                    SceneView.OnPropertyChanged_UpdateCanvas(SceneView.Instance.ActiveScene);
                }
            }
        }

        public Vector2Wrapper(Vector2 vector)
        {
            _vector = vector;
        }
    }
}
