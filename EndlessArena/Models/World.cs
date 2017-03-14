using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box2DX.Common;
using Box2DX.Dynamics;

namespace EndlessArena.Models
{
    class World
    {
        static Box2DX.Dynamics.World world;

        static World()
        {
            world = new Box2DX.Dynamics.World(new Box2DX.Collision.AABB { LowerBound = new Vec2(0, 0), UpperBound = new Vec2(0, 0) }, new Vec2(), true);
        }

        public static Body Add(BodyDef body)
        {
            return world.CreateBody(body);
        }

        public static void Update()
        {
            world.Step(1, 1, 1);
        }
    }
}
