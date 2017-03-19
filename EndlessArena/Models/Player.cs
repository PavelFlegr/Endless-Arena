using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EndlessArena.Utilities;
using System.Windows.Media;
using Box2DX.Collision;
using Box2DX.Dynamics;

namespace EndlessArena.Models
{
    class Player : Fighter
    {
        bool canShoot = true;
        Cannon weapon = new Cannon();

        public Player(Vec2 position)
        {
            Size = new Vec2(2, 2);
            //Children.Add(weapon);
            Color = Brushes.Blue;
            Transform.Position = position;
            var p = new PolygonDef();
            p.SetAsBox(1f, 1f);
            Body.SetBullet(true);
            Body.CreateShape(p);
            new HealthBar(this);
        }

        public override void Update()
        {
            Vec2 velocity = new Vec2();
            double speed = 0.3;
            if (Keyboard.IsKeyDown(Key.D))
            {
                velocity += new Vec2(speed, 0);
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                velocity -= new Vec2(speed, 0);
            }

            if (Keyboard.IsKeyDown(Key.S))
            {
                velocity += new Vec2(0, speed);
            }

            if (Keyboard.IsKeyDown(Key.W))
            {
                velocity -= new Vec2(0, speed);
            }

            if (canShoot)
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    Shoot();
                }
            }
            //Modify velocities to respect speed (lower both)
            if (velocity.Magnitude > 0)
            {
                velocity = new Vec2(velocity.X * speed / velocity.Magnitude, velocity.Y * speed / velocity.Magnitude);      
            }

            Body.SetLinearVelocity(new Box2DX.Common.Vec2((float)velocity.X, (float)velocity.Y));
            //rotate towards cursor. position * 50 because of the scale
            Transform.Angle = (Math.Atan2(Input.Mouse.Position.Y - Transform.Position.Y * 50, Input.Mouse.Position.X - Transform.Position.X * 50))/Math.PI * 180;

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
    }
}
