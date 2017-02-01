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

        public override void Update()
        {
            Vec2 velocity = new Vec2();
            double speed = 3;
            if (Keyboard.IsKeyDown(Key.Right))
            {
                velocity += new Vec2(speed, 0);
            }

            if (Keyboard.IsKeyDown(Key.Left))
            {
                velocity -= new Vec2(speed, 0);
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                velocity += new Vec2(0, speed);
            }

            if (Keyboard.IsKeyDown(Key.Up))
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

            

            Transform.Position += velocity;
            Transform.Angle = (Math.Atan2(Input.Mouse.Position.Y - Transform.Position.Y, Input.Mouse.Position.X - Transform.Position.X))/Math.PI * 180;

        }

        void Shoot()
        {
            GameObject proj = new GameObject();
            proj.Transform.Position = Transform.Position;
            Scene.Add(proj);
            canShoot = false;
            Task.Delay(1000).ContinueWith(x => canShoot = true);
        }
    }
}
