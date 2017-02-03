using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using EndlessArena.Utilities;

namespace EndlessArena.Models
{
    class Cannon : GameObject
    {
        public Cannon()
        {
            Transform.Width = 25;
            Transform.Height = 25;
            Color = Brushes.Black;
            Transform.Position = new Vec2(25 + 12.5, 0);
            Transform.Origin = -Transform.Position;
        }
    }
}
