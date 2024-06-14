using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEditor.Components
{
    [DataContract]
    public class Component : ViewModelBase
    {
        [DataMember]
        public GameObject Owner { get; private set; }

        public Component(GameObject owner)
        {
            Debug.Assert(owner != null);
            Owner = owner;
        }

        public Component()
        { }
    }
}
