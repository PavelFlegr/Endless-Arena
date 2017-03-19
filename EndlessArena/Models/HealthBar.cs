using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessArena.Models
{
    class HealthBar : GameObject
    {
        public double Value
        {
            get
            {
                return entity.Health;
            }
        }
        Fighter entity;
        public HealthBar(Fighter entity)
        {
            Size = new Utilities.Vec2(entity.Size.X, 0.2);
            this.entity = entity;
        }

        public override void Update()
        {
            Transform.Position = entity.Transform.Position + new Utilities.Vec2(0, 2);
        }
    }
}
