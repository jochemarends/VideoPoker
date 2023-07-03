using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class FourOfAKind : IHand
    {
        public string Name => "Four of a Kind";
        public int Reward => 7;

        public bool IsMatch(IList<Card> hand)
        {
            return hand.GroupBy(hand => hand.Rank).Any(group => group.Count() == 4);
        }
    }
}
