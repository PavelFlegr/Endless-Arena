using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessArena.Models
{
    class Fighter : GameObject
    {
        public double Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
                if(health <= 0)
                {
                    RaiseOnDeath();
                }
            }
        }

        double health = 100;

        public EventHandler OnDeath;

        void RaiseOnDeath()
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
    }
}
