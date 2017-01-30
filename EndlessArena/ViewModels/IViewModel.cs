using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EndlessArena.ViewModels
{
    interface IViewModel
    {
        void OnKeyDown(Key key);
        void Update();
    }
}
