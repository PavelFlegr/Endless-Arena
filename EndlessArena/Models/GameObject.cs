using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EndlessArena.Models
{
    class GameObject
    {
        public Transform Transform { get; set; } = new Transform();
        public HashSet<GameObject> Children { get; set; } = new HashSet<GameObject>();
        public Brush Color { get; set; }

        public virtual void Update() { }
    }
}
