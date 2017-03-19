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
using System.Threading;

namespace EndlessArena.ViewModels
{
    class Game : IViewModel, INotifyPropertyChanged
    {
        bool started;
        object l = new object();
        public IEnumerable<GameObject> Objects
        {
            get
            {
                foreach (var o in Scene.Current.Objects)
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
            Scene.Current = new EndlessArenaScene();
            ToggleMenuCommand = new RelayCommand(o => ShowMenu = !ShowMenu, o => true);
            MainMenuCommand = new RelayCommand(o => Messenger.Publish(new MainMenuMessage()), o => true);
            Player ob = new Player(new Vec2(-5, 0));
            ob.OnDeath += GameLost;
            ((EndlessArenaScene)Scene.Current).Player = ob;
            new Wall(new Vec2(2, 24.6), new Vec2(-18.2, 0));
            new Wall(new Vec2(2, 24.6), new Vec2(18.2, 0));
            new Wall(new Vec2(34.4, 2), new Vec2(0, -9.8));
            new Wall(new Vec2(34.4, 2), new Vec2(0, 9.8));
            new Enemy(new Vec2(5, 0)).OnDeath += GameWon;
            ob.Color = Brushes.Blue;
            new Task(() =>
            {
                Thread.Sleep(100);
                started = true;
            }).Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void GameLost(object o, EventArgs e)
        {
            started = false;
            Main.Instance.Current = new GameOver("You Lost");
        }

        void GameWon(object o, EventArgs e)
        {
            started = false;
            Main.Instance.Current = new GameOver("You Won");
        }

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
            //wpf doesn't seem to wait between frames so we have to
            lock (l)
            {
                if (!ShowMenu && started)
                {
                    foreach (GameObject o in Objects.ToArray())
                    {
                        o.Update();
                    }
                    Scene.Current.Update();
                    OnPropertyChanged(nameof(Objects));
                }
            }
        }
    }
}
