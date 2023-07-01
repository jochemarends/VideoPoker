using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoPoker.Models;

namespace VideoPoker.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Deck deck;
        public PlayerHand PlayerHand { get; set; } = new();
    
        public ICommand ToggleHoldCardCommand { get; set; }
        public ICommand DealCardsCommand { get; set; }

        public GameViewModel(Deck deck)
        {
            this.deck = deck;

            // Populating the player's hand.
            const int cardsInHand = 5;
            for (int i = 0; i < cardsInHand; i++)
            {
                PlayerHand.Add(deck.DrawCard());
            }

            ToggleHoldCardCommand = new Command<Card>(ToggleHoldCard);
            DealCardsCommand = new Command(DealCards);
        }

        public void ToggleHoldCard(Card card)
        {
            card.IsHolding = !card.IsHolding;
        }

        public void DealCards()
        {
            for (int index = 0; index < PlayerHand.Count; index++)
            {
                if (PlayerHand[index].IsHolding)
                {
                    PlayerHand[index].IsHolding = false;
                    SwapCardAt(index);
                }
            }
        }

        private void SwapCardAt(int index)
        {
            deck.Add(PlayerHand[index]);
            PlayerHand[index] = deck.DrawCard();
        }

        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
