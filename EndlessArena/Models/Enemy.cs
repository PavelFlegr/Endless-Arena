using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Box2DX.Collision;
using Box2DX.Dynamics;
using EndlessArena.Utilities;

namespace EndlessArena.Models
{
    class Enemy : GameObject
    {
        public Enemy(Vec2 position)
        {
            Size = new Vec2(2, 2);
            Transform.Position = position;
            Body.SetMass(new MassData { Mass = 5 });
            //Children.Add(weapon);
            Color = Brushes.Blue;
            var p = new PolygonDef();
            p.SetAsBox(1f, 1f);
            Body.CreateShape(p);
        }
    }
}
