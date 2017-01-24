using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessArena.ViewModels
{
    class Main : IViewModel
    {
        public IViewModel Current { get; set; } = new MainMenu();

        public Main()
        {
            
        }
    }
}
