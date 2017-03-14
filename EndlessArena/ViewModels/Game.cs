using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using EndlessArena.Utilities;
using EndlessArena.Utilities.Messages;
using EndlessArena.Models;
using System.Windows.Data;
using System.Windows.Media;
using System.Runtime.CompilerServices;

namespace EndlessArena.ViewModels
{
    class Game : IViewModel, INotifyPropertyChanged
    {
        object l = new object();
        public IEnumerable<GameObject> Objects
        {
            get
            {
                foreach (var o in Scene.Objects)
                {
                    yield return o;
                    foreach (var c in GetChildren(o)) yield return c;
                }
            }
        }

        IEnumerable<GameObject> GetChildren(GameObject parent)
        {
            foreach(var o in parent.Children)
            {
                yield return o;
                foreach (var c in GetChildren(o)) yield return c;
            }
        }

        public ICommand ToggleMenuCommand { get; set; }
        public ICommand MainMenuCommand { get; set; }

        public bool ShowMenu
        {
            get;set;
        }

        public Game()
        {
            ToggleMenuCommand = new RelayCommand(o => ShowMenu = !ShowMenu, o => true);
            MainMenuCommand = new RelayCommand(o => Messenger.Publish(new MainMenuMessage()), o => true);
            Player ob = new Player();
            new Wall(new Vec2(2, 24.6), new Vec2(-18.2, 0));
            new Wall(new Vec2(2, 24.6), new Vec2(18.2, 0));
            new Wall(new Vec2(34.4, 2), new Vec2(0, -9.8));
            new Wall(new Vec2(34.4, 2), new Vec2(0, 9.8));
            ob.Color = Brushes.Blue;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnKeyDown(Key key)
        {
            switch(key)
            {
                case Key.Escape:
                    ToggleMenuCommand.Execute(null);
                    break;
            }
        }

        void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Update()
        {
            lock (l)
            {
                if (!ShowMenu)
                {
                    foreach (GameObject o in Objects.ToArray())
                    {
                        o.Update();
                    }
                    Scene.Update();
                    //CollectionViewSource.GetDefaultView(Objects).Refresh();
                    OnPropertyChanged(nameof(Objects));
                }
            }
        }
    }
}
