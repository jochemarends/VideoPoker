using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VideoPoker.ViewModels
{
    [QueryProperty("Score", "Score")]
    public class GameOverViewModel : NotifyPropertyOnChanged
    {
        private int score;
        public int Score
        {
            get => score;
            set => SetProperty(ref score, value);
        }

        public ICommand GoToMenuCommand { get; } = new Command(GoToMenu);

        private static void GoToMenu()
        {
            Shell.Current.GoToAsync("../..");
        }
    }
}
