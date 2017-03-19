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
    class GameObject
    { 
        public Transform Transform { get; private set; } = new Transform();
        public HashSet<GameObject> Children { get; set; } = new HashSet<GameObject>();
        public Brush Color { get; set; }
        public Vec2 Size { get; set; }
        public BodyDef BodyDef { get; set; } = new BodyDef();
        Body body;

        public GameObject()
        {
            Scene.Current.Add(this);
        }

        //replaces transform with a facade forwarding to physical body when set
        public Body Body
        {
            get { return body; }
            set
            {
                body = value;
                Transform = new FakeTransform
                {
                    GetAngle = () => body.GetAngle(),
                    SetAngle = (a) => body.SetXForm(Body.GetPosition(), (float)a),
                    GetPosition = () => new Vec2(body.GetPosition().X, body.GetPosition().Y),
                    SetPosition = (p) => body.SetXForm(new Box2DX.Common.Vec2((float)p.X, (float)p.Y), body.GetAngle())
                };
            }
        }

        public virtual void Update() { }
        public virtual void OnCollision(GameObject gameObject) { }
    }
}
