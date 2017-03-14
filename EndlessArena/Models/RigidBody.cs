using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box2DX.Dynamics;
using Box2DX.Common;
using Box2DX.Collision;

namespace EndlessArena.Models
{
    class RigidBody
    { 
        public Transform Transform { get; }

        Body body;

        public RigidBody()
        {
            BodyDef b = new BodyDef();
            body = World.Add(b);
            Transform = new FakeTransform
            {
                GetAngle = () => body.GetAngle(),
                SetAngle = (a) => body.SetXForm(body.GetPosition(), a),

                GetPosition = () => body.GetPosition(),
                SetPosition = (p) => body.SetXForm(p, body.GetAngle())
            };
        }
    }
}
