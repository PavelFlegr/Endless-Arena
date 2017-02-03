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

namespace EndlessArena.ViewModels
{
    class Game : IViewModel, INotifyPropertyChanged
    {
        public IEnumerable<GameObject> Objects
        {
            get
            {
                List<GameObject> os = new List<GameObject>();
                foreach (var o in Scene.Current.Objects)
                {
                    os.Add(o);
                    GetChildren(os, o);
                }
                return os;
            }
        }

        void GetChildren(List<GameObject> os, GameObject parent)
        {
            foreach(var o in parent.Children)
            {
                var no = new GameObject {
                    Transform = new Transform {
                        Angle = parent.Transform.Angle + o.Transform.Angle,
                        Height = o.Transform.Height,
                        Position = parent.Transform.Position + o.Transform.Position,
                        Width = o.Transform.Width,
                        Origin = o.Transform.Origin
                        
                    },
                    Color = o.Color
                };
                os.Add(no);
                GetChildren(os, no);
            }
        }

        public ICommand ToggleMenuCommand { get; set; }
        public ICommand MainMenuCommand { get; set; }
        bool _showMenu;
        public bool ShowMenu
        {
            get { return _showMenu; }
            set
            {
                _showMenu = value;
                OnPropertyChanged("ShowMenu");
            }
        }

        public Game()
        {
            ToggleMenuCommand = new RelayCommand(o => ShowMenu = !ShowMenu, o => true);
            MainMenuCommand = new RelayCommand(o => Messenger.Publish(new MainMenuMessage()), o => true);
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

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Update()
        {
            if (!ShowMenu)
            {
                foreach (GameObject o in Objects)
                {
                    o.Update();
                }

                OnPropertyChanged("Objects");
            }
        }
    }
}
