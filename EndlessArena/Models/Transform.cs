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
        public Vec2 Position { get; set; }
        public double Angle { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Vec2 Origin { get; set; }
    }
}
