using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EndlessArena.Utilities.Messages
{
    class KeyDownMessage : IMessage
    {
        public Key Key { get; }

        public KeyDownMessage(Key key)
        {
            Key = key;
        }
    }
}
