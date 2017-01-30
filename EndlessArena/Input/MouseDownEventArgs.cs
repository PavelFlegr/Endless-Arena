using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EndlessArena.Input
{
    class MouseDownEventArgs : EventArgs
    {
        public MouseButton Button { get; }
        public MouseDownEventArgs(MouseButton button)
        {
            Button = button;
        }
    }
}
