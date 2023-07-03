using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class FullHouse : IHand
    {
        private readonly ThreeOfAKind threeOfAKind = new();
        public string Name => "Full House";
        public int Reward => 6;

        public bool IsMatch(IList<Card> cards)
        {
            if (!threeOfAKind.IsMatch(cards))
                return false;

            return cards.GroupBy(card => card.Rank).Any(group => group.Count() == 2);
        }
    }
}
