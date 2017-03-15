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
        bool canShoot = true;
        public Enemy(Vec2 position)
        {
            Size = new Vec2(2, 2);
            Transform.Position = position;
            //Children.Add(weapon);
            Color = Brushes.Blue;
            var p = new PolygonDef();
            p.SetAsBox(1f, 1f);
            Body.CreateShape(p);
        }

        public override void Update()
        {
            Body.SetLinearVelocity(new Box2DX.Common.Vec2(Body.GetLinearVelocity().X / 2, Body.GetLinearVelocity().Y / 2));
            if (canShoot) Shoot();
        }

        void Shoot()
        {
            //calculate direction
            Vec2 DirVec = new Vec2(Math.Cos(Transform.Angle / 180 * Math.PI), Math.Sin(Transform.Angle / 180 * Math.PI));
            //set velocity and position
            GameObject proj = new Bullet(DirVec, new Vec2(Transform.Position.X + DirVec.X * Size.X, Transform.Position.Y + DirVec.Y * Size.Y));
            //block shooting for 500ms
            canShoot = false;
            Task.Delay(500).ContinueWith(x => canShoot = true);
        }

        public override void OnCollision(GameObject gameObject)
        {
 
        }
    }
}
