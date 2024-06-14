using GameEditor.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameEditor.Utilities.Wrapper
{
    [DataContract]
    class Vector3Wrapper : ViewModelBase
    {
        [DataMember]
        private Vector3 _vector;
        public Vector3 Vector => _vector;

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

        public float Z
        {
            get => _vector.Z;
            set
            {
                if (_vector.Z != value)
                {
                    _vector.Z = value;
                    OnPropertyChanged(nameof(Z));
                    SceneView.OnPropertyChanged_UpdateCanvas(SceneView.Instance.ActiveScene);
                }
            }
        }

        public Vector3Wrapper(Vector3 vector)
        {
            _vector = vector;
        }
    }
}
