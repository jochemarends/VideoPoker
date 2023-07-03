using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class ThreeOfAKind : IHand
    {
        public string Name => "Three of a Kind";
        public int Reward => 3;

        public bool IsMatch(IList<Card> hand)
        {
            return hand.GroupBy(card => card.Rank).Any(group => group.Count() > 2);
        }
    }
}
