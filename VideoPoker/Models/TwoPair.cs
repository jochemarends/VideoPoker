using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Models
{
    public class TwoPair : IHand
    {
        public string Name => "Two Pair";
        public int Reward => 2;

        public bool IsMatch(IList<Card> hand)
        {
            return hand.GroupBy(card => card.Rank).Where(group => group.Count() > 1).Count() > 1;
        }
    }
}
