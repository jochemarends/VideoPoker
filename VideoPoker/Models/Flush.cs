using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class Flush : IHand
    {
        public string Name => "Flush";
        public int Reward => 5;

        public bool IsMatch(IList<Card> hand)
        {
            return hand.Skip(1).All(card => card.Suit == hand.First().Suit);
        }
    }
}
