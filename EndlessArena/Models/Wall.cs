using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using EndlessArena.Utilities;
using Box2DX.Collision;
using Box2DX.Dynamics;

namespace EndlessArena.Models
{
    class Wall : GameObject
    {
        public Wall(Vec2 size, Vec2 position)
        {
            Size = size;
            Color = Brushes.DarkGray;
            Transform.Position = position;
            Body.SetMass(new MassData { Mass = 0 });
            var p = new PolygonDef();
            p.SetAsBox((float)size.X / 2, (float)size.Y / 2);
            Body.CreateShape(p);
        }
    }
}
