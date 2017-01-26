using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using EndlessArena.Utilities;

namespace EndlessArena.ViewModels
{
    class Main : IViewModel, INotifyPropertyChanged
    {
        IViewModel _current;
        public IViewModel Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged("Current");
            }
        }

        public Main()
        {
            Current = new MainMenu();
            Messenger.Subscribe<Utilities.Messages.StartGameMessage>(a => Current = new Game());
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
