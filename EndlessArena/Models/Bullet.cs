using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndlessArena.Utilities;
using System.Windows.Media;

namespace EndlessArena.Models
{
    class Bullet : GameObject
    {
        IEnumerator Movement;
        public Bullet(Vec2 velocity)
        {
            Transform.Width = 10;
            Transform.Height = 10;
            Movement = Move(velocity).GetEnumerator();
            Color = Brushes.Red;
        }

        public override void Update()
        {
            Movement.MoveNext();
            
        }

        IEnumerable Move(Vec2 velocity)
        {
            for(int i = 0; i < 100; i++)
            {
                Transform.Position += velocity;
                yield return null;
            }
            Scene.Destroy(this);
        }
    }
}
