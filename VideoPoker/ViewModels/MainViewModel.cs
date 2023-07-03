using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VideoPoker.ViewModels
{
    public class MainViewModel
    {
        public ICommand PlayGameCommand { get; private set; }
        public ICommand QuitGameCommand { get; private set; }
        public MainViewModel()
        {
            PlayGameCommand = new Command(async () => await PlayGame());
            QuitGameCommand = new Command(() => Application.Current.Quit());
        }

        private async Task PlayGame()
        {
            await Shell.Current.GoToAsync("GamePage");
        }
    }
}
