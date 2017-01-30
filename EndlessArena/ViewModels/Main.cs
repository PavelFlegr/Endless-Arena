using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using EndlessArena.Utilities;
using System.Windows.Input;
using EndlessArena.Utilities.Messages;
using System.Windows.Media;

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
            Messenger.Subscribe<StartGameMessage>(a => Current = new Game());
            Messenger.Subscribe<KeyDownMessage>(a => OnKeyDown(a.Key));
            Messenger.Subscribe<MainMenuMessage>(a => Current = new MainMenu());
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            Update();
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnKeyDown(Key key)
        {
            Current.OnKeyDown(key);
        }

        public void Update()
        {
            Current.Update();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
