using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EndlessArena.Utilities;

namespace EndlessArena.Models
{
    class Player : GameObject
    {
        bool canShoot = true;
        Cannon weapon = new Cannon();

        public Player()
        {
            Transform.Width = 50;
            Transform.Height = 50;
            Children.Add(weapon);
        }

        public override void Update()
        {
            Vec2 velocity = new Vec2();
            double speed = 10;
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
            if (velocity.Magnitude > 0)
            {
                velocity = new Vec2(velocity.X * speed / velocity.Magnitude, velocity.Y * speed / velocity.Magnitude);
                Transform.Position += velocity;
            }
                
            Transform.Angle = (Math.Atan2(Input.Mouse.Position.Y - Transform.Position.Y, Input.Mouse.Position.X - Transform.Position.X))/Math.PI * 180;

        }

        void Shoot()
        {

            GameObject proj = new Bullet(new Vec2(Math.Cos(Transform.Angle / 180 * Math.PI) * 50, Math.Sin(Transform.Angle / 180 * Math.PI) * 50));
            proj.Transform.Position = new Vec2(Transform.Position.X + Math.Cos(Transform.Angle / 180 * Math.PI) * Transform.Width, Transform.Position.Y + Math.Sin(Transform.Angle / 180 * Math.PI) * Transform.Height);
            Scene.Add(proj);
            canShoot = false;
            Task.Delay(500).ContinueWith(x => canShoot = true);
        }
    }
}
