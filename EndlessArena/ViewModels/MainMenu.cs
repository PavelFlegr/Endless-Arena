using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EndlessArena.Utilities;
using EndlessArena.Utilities.Messages;

namespace EndlessArena.ViewModels
{
    class MainMenu : IViewModel
    {
        public ICommand StartGame { get; set; }
        public ICommand Exit { get; set; }

        public MainMenu()
        {
            Exit = new RelayCommand(o => ExitApp(), o => true);

        }

        void ExitApp()
        {
            Messenger.Publish<CloseWindowMessage>();
        }
    }
}
