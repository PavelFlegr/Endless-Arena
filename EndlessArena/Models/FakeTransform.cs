using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndlessArena.Utilities;

namespace EndlessArena.Models
{
    class FakeTransform : Transform
    {
        public override double Angle
        {
            get
            {
                return GetAngle();
            }
            set
            {
                SetAngle(value);
            }
        }

        public override Vec2 Position
        {
            get
            {
                return GetPosition();
            }
            set
            {
                SetPosition(value);
            }
        }

        public Action<double> SetAngle;
        public Func<double> GetAngle;

        public Action<Vec2> SetPosition;
        public Func<Vec2> GetPosition;
    }
}
