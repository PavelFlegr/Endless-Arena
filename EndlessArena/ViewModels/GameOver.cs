using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EndlessArena.Utilities;

namespace EndlessArena.ViewModels
{
    class GameOver : IViewModel
    {
        public string Message { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand PlayAgainCommand { get; set; }

        public GameOver(string message)
        {
            Message = message;
            ExitCommand = new RelayCommand((o) => Exit(), (o) => true);
            PlayAgainCommand = new RelayCommand((o) => PlayAgain(), (o) => true);
        }

        public void OnKeyDown(Key key)
        {
            
        }

        public void Update()
        {
            
        }

        void PlayAgain()
        {
            Messenger.Publish(new Utilities.Messages.StartGameMessage());
        }
        void Exit()
        {
            Messenger.Publish(new Utilities.Messages.CloseWindowMessage());
        }
    }
}
