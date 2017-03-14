using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndlessArena.Utilities;

namespace EndlessArena.Models
{
    class Transform
    {
        public virtual Vec2 Position { get; set; }
        public virtual double Angle { get; set; }
        public virtual Vec2 Origin { get; set; }
        public virtual Vec2 Size { get; set; }
    }
}
