using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoPoker.Models;

namespace VideoPoker.ViewModels
{
    public enum GameState
    {
        Dealing,
        Drawing
    }

    public class GameViewModel : NotifyPropertyOnChanged
    {
        private readonly Deck deck;
        private GameState gameState = GameState.Dealing;

        private int credits = 3;
        public int Credits
        {
            get => credits;
            set => SetProperty(ref credits, value);
        }

        private string result = string.Empty;
        public string Result
        {
            get => result;
            set => SetProperty(ref result, value);
        }

        private const int cardsInHand = 5;
        public ObservableCollection<Card> PlayerHand { get; private set; } = new();
        public HandEvaluator HandEvaluator { get; private set; }

        public ICommand ToggleHoldCardCommand { get; private set; }
        public ICommand DealCardsCommand { get; private set; }
        public ICommand DrawCardsCommand { get; private set; }
        public ICommand LeaveGameCommand { get; private set; }

        public GameViewModel(Deck deck, HandEvaluator handEvaluator)
        {
            this.deck = deck;
            HandEvaluator = handEvaluator;
            
            ToggleHoldCardCommand = new Command<Card>(ToggleHoldCard, CanToggleHoldCard);
            DealCardsCommand = new Command(DealCards, CanDealCards);
            DrawCardsCommand = new Command(DrawCards, CanDrawCards);
            LeaveGameCommand = new Command(LeaveGame);

            DealCards();
        }

        private bool CanToggleHoldCard(Card card) => gameState == GameState.Drawing;
        private void ToggleHoldCard(Card card)
        {
            card.IsHolding = !card.IsHolding;
        }

        private bool CanDealCards() => gameState == GameState.Dealing;
        private void DealCards()
        {
            if (Credits == 0) LeaveGame();
            Credits--;

            foreach (Card card in PlayerHand)
            {
                card.IsHolding = false;
                deck.Add(card);
            }

            PlayerHand.Clear();
            for (int i = 0; i < cardsInHand; i++)
            {
                PlayerHand.Add(deck.DrawCard());
            }


            IHand match = HandEvaluator.Evaluate(PlayerHand);
            Result = match.Name;

            NextGameState();
        }

        private bool CanDrawCards() => gameState == GameState.Drawing;
        private void DrawCards()
        {
            // Swap the cards that aren't marked as held.
            for (int index = 0; index < PlayerHand.Count; index++)
            {
                if (PlayerHand[index].IsHolding)
                {
                    PlayerHand[index].IsHolding = false;
                }
                else
                {
                    SwapCardAt(index);
                }
            }

            NextGameState();

            IHand match = HandEvaluator.Evaluate(PlayerHand);
            Credits += match.Reward;
            Result = match.Name;
        }

        private void NextGameState()
        {
            switch(gameState)
            {
                case GameState.Dealing:
                    gameState = GameState.Drawing;
                    break;
                case GameState.Drawing:
                    gameState = GameState.Dealing;
                    break;
            }

            (ToggleHoldCardCommand as Command).ChangeCanExecute();
            (DrawCardsCommand as Command).ChangeCanExecute();
            (DealCardsCommand as Command).ChangeCanExecute();
        }

        private void SwapCardAt(int index)
        {
            deck.Add(PlayerHand[index]);
            PlayerHand[index] = deck.DrawCard();
        }

        private void LeaveGame()
        {
            foreach (Card card in PlayerHand)
            {
                deck.Add(card);
            }

            Shell.Current.GoToAsync($"GameOverPage?Score={Credits}");
        }
    }
}
