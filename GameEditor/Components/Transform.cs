using GameEditor.Editors;
using GameEditor.Utilities.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Media3D;

namespace GameEditor.Components
{
    [DataContract]
    class Transform : Component
    {
        private Vector3Wrapper _position;
        [DataMember]
        public Vector3Wrapper Position
        {
            get => _position;
            set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPropertyChanged(nameof(Position));
                }
            }
        }

        private Vector2Wrapper _scale;
        [DataMember]
        public Vector2Wrapper Scale
        {
            get => _scale;
            set
            {
                if (_scale != value)
                {
                    _scale = value;
                    OnPropertyChanged(nameof(Scale));
                    SceneView.OnPropertyChanged_UpdateCanvas(SceneView.Instance.ActiveScene);
                }
            }
        }

        public Transform(GameObject owner) : base(owner)
        {
            _position = new Vector3Wrapper(new Vector3(0, 0, 0));
            _scale = new Vector2Wrapper(new Vector2(0, 0));
        }

        public Transform()
        { }
    }
}
