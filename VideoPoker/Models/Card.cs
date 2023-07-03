using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using VideoPoker.Converters;

namespace VideoPoker.Models
{
    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public class Card : NotifyPropertyChanged
    {

        private Rank rank;
        [JsonPropertyName("value")]
        [JsonConverter(typeof(RankConverter))]
        public Rank Rank
        {
            get => rank;
            set => SetProperty(ref rank, value);
        }

        private Suit suit;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Suit Suit
        {
            get => suit;
            set => SetProperty(ref suit, value);
        }

        private string image;
        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        private bool isHolding = false;
        public bool IsHolding
        {
            get => isHolding;
            set
            {
                if (SetProperty(ref isHolding, value))
                {
                    OnPropertyChanged(nameof(ButtonColor));
                }
            }
        }

        public Color ButtonColor => IsHolding ? Colors.YellowGreen : Colors.Red;
    }
}
