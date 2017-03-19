using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Media;
using Box2DX.Collision;
using Box2DX.Dynamics;
using EndlessArena.Utilities;

namespace EndlessArena.Models
{
    class Enemy : Fighter
    {
        bool canShoot = true;
        IEnumerator movement;
        public Enemy(Vec2 position)
        {
            Size = new Vec2(2, 2);
            Transform.Position = position;
            //Children.Add(weapon);
            Color = Brushes.Red;
            var p = new PolygonDef();
            p.SetAsBox(1f, 1f);
            Body.CreateShape(p);
            movement = Move();
            new HealthBar(this);
        }

        public IEnumerator Move()
        {
            float speed = 0.3f;
            while (Transform.Position.Y > -7)
            {
                Body.SetLinearVelocity(new Box2DX.Common.Vec2(0, -speed));
                yield return 0;
            }
            while (Transform.Position.X > -15)
            {
                Body.SetLinearVelocity(new Box2DX.Common.Vec2(-speed, 0));
                yield return 0;
            }
            while(true)
            {
                while(Transform.Position.Y < 7)
                {
                    Body.SetLinearVelocity(new Box2DX.Common.Vec2(0, speed));
                    yield return 0;
                }
                while(Transform.Position.X < 15)
                {
                    Body.SetLinearVelocity(new Box2DX.Common.Vec2(speed, 0));
                    yield return 0;
                }
                while (Transform.Position.Y > -7)
                {
                    Body.SetLinearVelocity(new Box2DX.Common.Vec2(0, -speed));
                    yield return 0;
                }
                while (Transform.Position.X > -15)
                {
                    Body.SetLinearVelocity(new Box2DX.Common.Vec2(-speed, 0));
                    yield return 0;
                }
            }
        }

        public override void Update()
        {
            //infinite ienumerable
            movement.MoveNext();
            //look towards player
            Transform.Angle = (Math.Atan2(((EndlessArenaScene)Scene.Current).Player.Transform.Position.Y- Transform.Position.Y, ((EndlessArenaScene)Scene.Current).Player.Transform.Position.X  - Transform.Position.X )) / Math.PI * 180;
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
