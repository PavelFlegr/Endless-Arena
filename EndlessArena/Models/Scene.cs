using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box2DX.Common;
using Box2DX.Dynamics;
using Box2DX.Collision;

namespace EndlessArena.Models
{
    abstract class Scene : ContactListener
    {
        public static Scene Current { get; set; }
        World world = new World(new AABB { LowerBound = new Vec2(-500, -500), UpperBound = new Vec2(500, 500) }, new Vec2(0, 0), false);
        public HashSet<GameObject> Objects { get; } = new HashSet<GameObject>();
        List<GameObject[]> collisions = new List<GameObject[]>();
        
        public Scene()
        {
            world.SetContactListener(this);
        }

        public override void Add(ContactPoint point)
        {
            base.Add(point);
            if (point.Separation < 0)
            {
                collisions.Add(new GameObject[] { (GameObject)point.Shape1.GetBody().GetUserData(), (GameObject)point.Shape2.GetBody().GetUserData() });
            }
        }

        public void Add(GameObject gameObject)
        {
            gameObject.Body = world.CreateBody(new BodyDef { MassData = new MassData { Mass = 1 }, UserData = gameObject });
            Objects.Add(gameObject);
        }

        public void Destroy(GameObject gameObject)
        {
            if (Objects.Contains(gameObject))
            {
                Objects.Remove(gameObject);
                world.DestroyBody(gameObject.Body);
            }
        }

        public void Update()
        {       
            world.Step(1, 1, 1);
            foreach(var collision in collisions)
            {
                collision[0].OnCollision(collision[1]);
                collision[1].OnCollision(collision[0]);
            }
            collisions.Clear();
        }
    }
}
