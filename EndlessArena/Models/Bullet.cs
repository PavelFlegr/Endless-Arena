﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndlessArena.Utilities;
using Box2DX.Collision;
using Box2DX.Common;
using Box2DX.Dynamics;
using System.Windows.Media;

namespace EndlessArena.Models
{
    class Bullet : GameObject
    {
        Utilities.Vec2 velocity;
        Fighter sourceShooter;
        public Bullet(Utilities.Vec2 velocity, Utilities.Vec2 position, Fighter sourceShooter)
        {
            this.sourceShooter = sourceShooter;
            Transform.Position = position;
            this.velocity = velocity;
            Size = new Utilities.Vec2(0.3, 0.3);
            Color = Brushes.Red;
            Body.SetBullet(true);
            PolygonDef p = new PolygonDef();
            p.SetAsBox(0.15f, 0.15f);
            Shape s = Body.CreateShape(p);
            Body.SetLinearVelocity((new Box2DX.Common.Vec2((float)velocity.X, (float)velocity.Y)));
        }

        public override void OnCollision(GameObject gameObject)
        {
            if(gameObject is Fighter)
            {
                if (gameObject != sourceShooter)
                {
                    var fighter = (Fighter)gameObject;
                    fighter.Health -= 10;
                    Scene.Current.Destroy(this);
                }
            }
            else
            {
                Scene.Current.Destroy(this);
            }
            
        }
    }
}
