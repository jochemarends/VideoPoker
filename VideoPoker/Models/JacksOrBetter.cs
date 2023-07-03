using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class JacksOrBetter : IHand
    {
        public string Name => "Jacks or Better";
        public int Reward => 1;

        public bool IsMatch(IList<Card> hand)
        {
            return hand.Where(IsJackOrBetter).GroupBy(hand => hand.Rank).Any(group => group.Count() > 1);
        }

        private static bool IsJackOrBetter(Card card)
        {
            return card.Rank >= Rank.Jack;
        }
    }
}
