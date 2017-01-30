using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessArena.Models
{
    class GameObject
    {
        public Transform Transform { get; set; } = new Transform();

        public virtual void Update() { }
    }
}
